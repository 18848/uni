using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard
{
    public class itemPrec
    {
        [System.ComponentModel.DisplayName("Data")]
        public string date { get; set; }
        [System.ComponentModel.DisplayName("Qtd Precipitação")]
        public float maximum { get; set; }
        [System.ComponentModel.DisplayName("Local")]
        public string local { get; set; }

    }

}
