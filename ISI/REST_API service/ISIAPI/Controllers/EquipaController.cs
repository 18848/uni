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
    public class EquipaController : ControllerBase
    {
        public ModeloEquipas m = new ModeloEquipas();

        [HttpGet]
        [Route("getequipa/{idEquipa}")]
        public string GetEquipa(int idEquipa)
        {
            return m.GetEquipaById(idEquipa);
        }

        [HttpGet]
        [Route("getall")]
        public string GetEquipa()
        {
            return m.GetAllEquipas();
        }

        [HttpGet]
        [Route("getEquipaMaisCara")]
        public string GetEquipaMaisCara()
        {
            return m.GetEquipaMaisCara();
        }

        [HttpPost]
        [Route("addequipa")]
        public string AddEquipa([FromBody] string equipa)
        {
            ModeloEquipa equipaConvertido = Newtonsoft.Json.JsonConvert.DeserializeObject<ModeloEquipa>(equipa);
            return m.AddEquipa(equipaConvertido);
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
