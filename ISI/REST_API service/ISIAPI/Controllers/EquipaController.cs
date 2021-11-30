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

        // Rota para devolver todas as equipas presentes na base de dados
        [HttpGet]
        [Route("getall")]
        public string GetEquipa()
        {
            return m.GetAllEquipas();
        }

        // Rota para devolver as 10 equipas mais caras
        [HttpGet]
        [Route("getEquipaMaisCara")]
        public string GetEquipaMaisCara()
        {
            return m.GetEquipaMaisCara();
        }


        // Rota para adicionar uma equipa
        // Formato {"nome": nome}
        [HttpPost]
        [Route("addequipa")]
        public string AddEquipa([FromBody] string equipa)
        {
            ModeloEquipa equipaConvertido = Newtonsoft.Json.JsonConvert.DeserializeObject<ModeloEquipa>(equipa);
            return m.AddEquipa(equipaConvertido);
        }

    }
}
