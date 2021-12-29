using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard
{
    class TempMax
    {
        [System.ComponentModel.DisplayName("Data")]
        public string date { get; set; }
        [System.ComponentModel.DisplayName("Temperatura Máxima")]
        public float maximum { get; set; }
        [System.ComponentModel.DisplayName("Local")]
        public string local { get; set; }
    }
}
