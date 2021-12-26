using System;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConversion
{
    /// <summary>
    /// Estrutura de Dados de Irregularidades detetadas em cada Visita.
    /// </summary>
    public class Irregularidade
    {
        [JsonProperty("Descricao")]
        [XmlText]
        public string Descricao { get; set; }
    }

    /// <summary>
    /// Estrutura de Dados dos Fiscalizados (Visitados).
    /// </summary>
    public class Fiscalizado
    {
        /// <summary>
        /// Construtor 
        /// </summary>
        /// <param name="nif"> Identificação do Fiscalizado. </param>
        /// <param name="data"> Momento da Fiscalização. </param>
        /// <param name="irregularidades"> Irregularidades detetadas na Visita. </param>
        public Fiscalizado(string nif, DateTime data, List<Irregularidade> irregularidades)
        {
            IdCivil = int.Parse(nif);
            Data = data; ;
            Irregularidades = irregularidades;
        }

        /// <summary>
        /// Construtor Vazio.
        /// </summary>
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

    /// <summary>
    /// Estrutura de Dados de uma Ação de Fiscalização.
    /// </summary>
    [XmlRoot(ElementName ="Fiscalizacao")]
    public class Fiscalizacao
    {
        [JsonProperty("fiscalizados")]
        [XmlElement(ElementName = "Fiscalizado")]
        public List<Fiscalizado> Fiscalizados { get; set; }
    }
}
