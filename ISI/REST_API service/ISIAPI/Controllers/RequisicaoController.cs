using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Newtonsoft.Json;

namespace ISIAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequisicaoController : ControllerBase
    {
        public ModeloRequisicoes m = new ModeloRequisicoes();

        [HttpGet]
        [Route("getrequisicao/{idRequisicao}")]
        public string GetRequisicao(int idRequisicao)
        {
            return m.GetRequisicaoById(idRequisicao);
        }

        [HttpGet]
        [Route("getall")]
        public string GetRequisicoes()
        {
            return m.GetAllRequisicoes();
        }


        [HttpPost]
        [Route("addRequisicao")]
        public string AddRequisicao(string requisicao)
        {
            ModeloRequisicao requisicaoConvertido = Newtonsoft.Json.JsonConvert.DeserializeObject<ModeloRequisicao>(requisicao);
            return m.AddRequisicao(requisicaoConvertido);
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
