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

    public class Civil
    {
        public Civil(int nif, string nome, DateTime data, List<Irregularidade> irregularidades)
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
            Irregularidades = null;
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
        [XmlElement("Irregularidade")]
        public List<Irregularidade> Irregularidades { get; set; }
    }

    [XmlRoot(ElementName ="Fiscalizacao")]
    public class Fiscalizacao
    {
        [JsonProperty("Civis")]
        [XmlElement(ElementName ="Civil")]
        public List<Civil> Fiscalizados { get; set; }

        public Civil this[string name]
        {
            get { return Fiscalizados.FirstOrDefault(s => string.Equals(s.Nome, name, StringComparison.OrdinalIgnoreCase)); }
        }
    }
}
