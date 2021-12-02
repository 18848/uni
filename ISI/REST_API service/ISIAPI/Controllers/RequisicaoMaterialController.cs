using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Newtonsoft.Json;
using System.Text.Json;

namespace ISIAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequisicaoMaterialController : ControllerBase
    {
        public ModeloRequisicoesMateriais m = new ModeloRequisicoesMateriais();
        public ModeloRequisicoes r = new ModeloRequisicoes();

        // Rota para devolver todas as RequisicoesMateriais
        [HttpGet]
        [Route("getall")]
        public string GetRequisisoesMateriais()
        {
            return m.GetAllRequisicoesMateriais();
        }

        //Rota para adicionar uma RequisicaoMaterial
        [HttpPost]
        [Route("addrequisicaomaterial")]
        public string AddRequisicaoMaterial(string requisicaoMaterial)
        {
            ModeloRequisicaoMaterial requisicaoMaterialConvertido = Newtonsoft.Json.JsonConvert.DeserializeObject<ModeloRequisicaoMaterial>(requisicaoMaterial);
            return m.AddRequisicaoMaterial(requisicaoMaterialConvertido);
        }


        //Rota para obter os materiais de uma requisicao
        [HttpGet]
        [Route("getmaterialbyrequisicao/{idRequisicao}")]
        public string GetRequisicaoMaterialbyRequisicaoEquipa(int idRequisicao)
        {
            return m.GetRequisicaoMaterialByRequisicaoEquipa(idRequisicao);
        }

        //Rota para adicionar uma requisicaoMaterial
        //Formato {{"idMaterial":id, "qtd":qtd},{"idMaterial":id, "qtd":qtd},...}
        [HttpPost]
        [Route("postRequisicaoMateriais/{idEquipa}")]
        public string AddRequisicaoMaterial(int idEquipa,[FromBody]JsonElement body)
        {
            string idRequisicao;

            string materiais = body.ToString();

            List<MaterialParaRequisicao> listaMateriais = new List<MaterialParaRequisicao>();

            listaMateriais = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MaterialParaRequisicao>>(materiais);
            ModeloRequisicaoMaterial elementoAdd = new ModeloRequisicaoMaterial();
            ModeloRequisicao requisicaoAdd = new ModeloRequisicao();

            requisicaoAdd.IdEquipa = idEquipa;
            requisicaoAdd.Entregue = false;
            idRequisicao = r.AddRequisicao(requisicaoAdd);

            foreach(MaterialParaRequisicao mr in listaMateriais)
            {

                elementoAdd.IdRequisicao = int.Parse(idRequisicao);
                elementoAdd.IdMaterial = mr.idMaterial;
                elementoAdd.Qtd = mr.qtd;

                m.AddRequisicaoMaterial(elementoAdd);
            }
          
            return "True";
        }

        public class MaterialParaRequisicao
        {
            [JsonProperty]
            public int idMaterial { get; set; }
            [JsonProperty]
            public int qtd { get; set; }
        }

    }
}
