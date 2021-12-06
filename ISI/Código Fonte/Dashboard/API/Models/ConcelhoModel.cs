namespace API.Models
{
    // Classe dos dados provenintes da api https://covid19-api.vost.pt
    public class ConcelhoModel
    {
        public string data { get; set; }
        public string concelho { get; set; }
        public int confirmados_14 { get; set; }
        public int confirmados_1 { get; set; }
        public int incidencia { get; set; }
        public string incidencia_categoria { get; set; }
        public string incidencia_risco { get; set; }
        public string tendencia_incidencia { get; set; }
        public string tendencia_categoria { get; set; }
        public string tendencia_desc { get; set; }
        public int casos_14dias { get; set; }
        public string ars { get; set; }
        public string distrito { get; set; }
        public int dicofre { get; set; }
        public float area { get; set; }
        public int population { get; set; }
        public int population_65_69 { get; set; }
        public int population_70_74 { get; set; }
        public int population_75_79 { get; set; }
        public int population_80_84 { get; set; }
        public int population_85_mais { get; set; }
        public int population_80_mais { get; set; }
        public int population_75_mais { get; set; }
        public int population_70_mais { get; set; }
        public int population_65_mais { get; set; }
        public float densidade_populacional { get; set; }
        public float densidade_1 { get; set; }
        public float densidade_2 { get; set; }
        public float densidade_3 { get; set; }
    }
}
