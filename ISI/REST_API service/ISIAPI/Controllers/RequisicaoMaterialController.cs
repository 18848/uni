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

        [HttpGet]
        [Route("getrequisicaomaterial/{idRequisicaoMaterial}")]
        public string GetRequisicaoMaterial(int idMaterial)
        {
            return m.GetRequisicaoMaterialById(idMaterial);
        }

        [HttpGet]
        [Route("getall")]
        public string GetRequisisoesMateriais()
        {
            return m.GetAllRequisicoesMateriais();
        }


        [HttpPost]
        [Route("addrequisicaomaterial")]
        public string AddRequisicaoMaterial(string requisicaoMaterial)
        {
            ModeloRequisicaoMaterial requisicaoMaterialConvertido = Newtonsoft.Json.JsonConvert.DeserializeObject<ModeloRequisicaoMaterial>(requisicaoMaterial);
            return m.AddRequisicaoMaterial(requisicaoMaterialConvertido);
        }

        [HttpGet]
        [Route("getmaterialbyrequisicao/{idRequisicao}")]
        public string GetRequisicaoMaterialbyRequisicaoEquipa(int idRequisicao)
        {
            return m.GetRequisicaoMaterialByRequisicaoEquipa(idRequisicao);
        }

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

        /*

        [HttpPost("UpdateMaterial")]
        public ActionResult Update(ModeloMaterial m)
        {
            if (m.Id >= 0 && m.Id < materiais.Count)
            {
                materiais[m.Id] = m;
                return Ok();
            }
            return NotFound();
        }
        */

    }
}
