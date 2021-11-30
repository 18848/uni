using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Newtonsoft.Json;
using System.Net.Http;

namespace ISIAPI.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        public ModeloMateriais m = new ModeloMateriais();

        [HttpGet]
        [Route("getmaterial/{idMaterial}")]
        public string GetMaterial(int idMaterial)
        {
            return m.GetMaterialById(idMaterial);
        }

        [HttpGet]
        [Route("getall")]
        public string GetMateriais()
        {
            return m.GetAllMateriais();
        }


        [HttpPost("addmaterial")]
        public string AddMaterial([FromBody] string material)
        {   
            ModeloMaterial materialConvertido = Newtonsoft.Json.JsonConvert.DeserializeObject<ModeloMaterial>(material);
            return m.AddMaterial(materialConvertido);
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
