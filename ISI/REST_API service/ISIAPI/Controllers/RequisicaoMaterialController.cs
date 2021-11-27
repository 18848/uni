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
    public class RequisicaoMaterialController : ControllerBase
    {
        public ModeloRequisicoesMateriais m = new ModeloRequisicoesMateriais();

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
