using System;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConversion
{
    public class Civil
    {
        public Civil(int nif, string nome, DateTime data, int irregularidades)
        {
            IdCivil = nif;
            Nome = nome;
            Data = data; ;
            Irregularidades = irregularidades;
        }
        public Civil()
        {
            IdCivil = 0;
            Nome = "";
            Data = DateTime.UtcNow;
            Irregularidades = 0;
        }

        [JsonProperty("NIF")]
        [XmlAttribute("NIF")]
        public int IdCivil { get; set; }
        [JsonProperty("Nome")]
        [XmlAttribute("Nome")]
        public string Nome { get; set; }
        [JsonProperty("Data")]
        [XmlAttribute("Data")]
        public DateTime Data { get; set; }
        [JsonProperty("Irregularidades")]
        [XmlAttribute("Irregularidades")]
        public int Irregularidades { get; set; }
    }

    [XmlRoot("Fiscalizacao")]
    public class Fiscalizacao
    {
        [JsonProperty("Civis")]
        [XmlElement("Civil")]
        public List<Civil> Fiscalizados { get; set; }
    }
}
