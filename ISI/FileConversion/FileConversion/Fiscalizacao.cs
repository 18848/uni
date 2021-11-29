using System;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConversion
{
    public class Irregularidade
    {
        [JsonProperty("Descricao")]
        [XmlText]
        public string Descricao { get; set; }
    }

    public class Fiscalizado
    {
        public Fiscalizado(string nif, DateTime data, List<Irregularidade> irregularidades)
        {
            IdCivil = int.Parse(nif);
            Data = data; ;
            Irregularidades = irregularidades;
        }
        public Fiscalizado()
        {
            IdCivil = 0;
            Data = DateTime.UtcNow;
            Irregularidades = null;
        }

        [JsonProperty("nif")]
        [XmlAttribute(AttributeName = "nif")]
        public int IdCivil { get; set; }
        [JsonProperty("data")]
        [XmlAttribute(AttributeName = "data")]
        public DateTime Data { get; set; }

        [JsonProperty("irregularidades")]
        [XmlElement(ElementName = "Irregularidade")]
        public List<Irregularidade> Irregularidades { get; set; }
    }

    [XmlRoot(ElementName ="Fiscalizacao")]
    public class Fiscalizacao
    {
        [JsonProperty("fiscalizados")]
        [XmlElement(ElementName = "Fiscalizado")]
        public List<Fiscalizado> Fiscalizados { get; set; }
    }
}
