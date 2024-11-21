using System;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace EnergySaverAPI.Application.Services
{
    public class MLService
    {
        private readonly MLContext _mlContext;

        public MLService()
        {
            _mlContext = new MLContext();
        }

        public void TrainModel(string trainingDataPath, string modelPath)
        {
            // Define os esquemas dos dados
            var dataSchema = new[]
            {
                new TextLoader.Column("Hora", DataKind.Single, 0),
                new TextLoader.Column("Temperatura", DataKind.Single, 1),
                new TextLoader.Column("ConsumoEnergetico", DataKind.Single, 2)
            };

            // Carregar dados de treinamento
            var trainingData = _mlContext.Data.LoadFromTextFile<EnergyData>(trainingDataPath, hasHeader: true, separatorChar: ',');

            // Configurar o pipeline de aprendizado
            var pipeline = _mlContext.Transforms.Concatenate("Features", new[] { "Hora", "Temperatura" })
                .Append(_mlContext.Regression.Trainers.Sdca(labelColumnName: "ConsumoEnergetico", maximumNumberOfIterations: 100));

            // Treinar o modelo
            var model = pipeline.Fit(trainingData);

            // Salvar o modelo treinado
            _mlContext.Model.Save(model, trainingData.Schema, modelPath);
        }

        public float Predict(float hora, float temperatura, string modelPath)
        {
            // Carregar o modelo treinado
            var loadedModel = _mlContext.Model.Load(modelPath, out var schema);

            var predictionEngine = _mlContext.Model.CreatePredictionEngine<EnergyData, EnergyConsumptionPrediction>(loadedModel);

            var prediction = predictionEngine.Predict(new EnergyData
            {
                Hora = hora,
                Temperatura = temperatura
            });

            return prediction.ConsumoEnergetico;
        }
    }

    // Classe para representar os dados de entrada
    public class EnergyData
    {
        public float Hora { get; set; }
        public float Temperatura { get; set; }
        public float ConsumoEnergetico { get; set; }
    }

    // Classe para representar os resultados previstos
    public class EnergyConsumptionPrediction
    {
        [ColumnName("Score")]
        public float ConsumoEnergetico { get; set; }
    }
}
