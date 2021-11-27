using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConversion
{
    class Civil
    {
        public Civil(int nif, string nome, DateTime data, int irregularidades)
        {
            IdCivil = nif;
            Nome = nome;
            Data = data;
            Irregularidades = irregularidades;
        }
        public Civil()
        {
            IdCivil = 0;
            Nome = "";
            Data = DateTime.UtcNow;
            Irregularidades = 0;
        }

        [JsonProperty("nif")]
        public int IdCivil { get; set; }
        [JsonProperty("nome")]
        public string Nome { get; set; }
        [JsonProperty("data")]
        public DateTime Data { get; set; }
        [JsonProperty("irregularidades")]
        public int Irregularidades { get; set; }
    }
}
