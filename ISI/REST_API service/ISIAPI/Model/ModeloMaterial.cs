using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ISIAPI
{
    public class ModeloMaterial
    {
        private int idMaterial;
        private string nome;
        private float custo;


        public ModeloMaterial(int id, string n, float c){
            idMaterial = id;
            nome = n;
            custo = c;
        }

        [Required]
        public int Id { get => idMaterial; set => idMaterial = value; }
        [Required]
        public string Nome { get => nome; set => nome = value; }
        public float Custo { get => custo; set => custo = value; }
    }

    
    public class ModeloMateriais{

        List<ModeloMaterial> materiais;
        static string server = ConfigurationManager.ConnectionStrings["ISI"].ConnectionString;
        readonly SqlConnection con = new SqlConnection(server);

        public ModeloMateriais(){
            if (materiais == null)
                materiais = new List<ModeloMaterial>();
        }

        public List<ModeloMaterial> Materiais
        {
            get => materiais;
        }

        //Obter todos os materiais
        public DataTable GetAllMateriais()
        {
            con.Open();

            string q = "SELECT * FROM materiais";
            SqlDataAdapter da = new SqlDataAdapter(q, con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }




        //Adicionar um material
        public bool AddMaterial(ModeloMaterial s)
        {
            if (!materiais.Contains(s))
            {
                materiais.Add(s);
                return true;
            }
            else
            {
                return false;
            }

        }

        //Encontrar nome de material
        public string GetMaterialById(int idMaterial)
        {
            foreach(ModeloMaterial m in materiais)
            {
                if (m.Id == idMaterial) return m.Nome;
            }
            return "";
        }

    }
}
