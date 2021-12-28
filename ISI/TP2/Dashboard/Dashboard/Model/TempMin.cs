using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard
{
    class TempMin
    {
        [System.ComponentModel.DisplayName("Data")]
        public string date { get; set; }
        [System.ComponentModel.DisplayName("Temperatura Mínima")]
        public float minimum { get; set; }
        [System.ComponentModel.DisplayName("Local")]
        public string local { get; set; }
    }
}
