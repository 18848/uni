using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard
{
    class PrevBraga
    {
        [System.ComponentModel.DisplayName("Data")]
        public string forecastDate { get; set; }
        [System.ComponentModel.DisplayName("Temp. Mínima")]
        public float tMin { get; set; }
        [System.ComponentModel.DisplayName("Temp. Máxima")]
        public float tMax { get; set; }
        [System.ComponentModel.DisplayName("Descrição")]
        public string descIdWeatherTypePT { get; set; }
        [System.ComponentModel.DisplayName("Prob. Precipitação")]
        public float precipitaProb { get; set; }
        [System.ComponentModel.DisplayName("Tipo de Precipitação")]
        public string descClassPrecIntPT { get; set; }
        [System.ComponentModel.DisplayName("Velocidade do Vento")]
        public string descClassWindSpeedDailyPT { get; set; }
        [System.ComponentModel.DisplayName("Direção do Vento")]
        public string predWindDir { get; set; }
        public float longitude { get; set; }
        public float latitude { get; set; }

    }
}
