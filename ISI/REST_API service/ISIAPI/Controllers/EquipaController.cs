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

        /// <summary>
        /// Rota para devolver todas as equipas presentes na base de dados 
        /// </summary>
        /// <returns string=Equipas> If reaches end of function. </returns>
        /// <returns string="$EXCEPTION$"> If it fails. </returns>
        [HttpGet]
        [Route("getall")]
        public string GetEquipa()
        {
            return m.GetAllEquipas();
        }

        /// <summary>
        /// Rota para devolver as 10 equipas mais caras
        /// </summary>
        /// <returns json=EquipasMaisCaras> If reaches end of function. </returns>
        /// <returns string="$EXCEPTION$"> If it fails. </returns>
        [HttpGet]
        [Route("getEquipaMaisCara")]
        public string GetEquipaMaisCara()
        {
            return m.GetEquipaMaisCara();
        }


        /// <summary>
        /// Rota para adicionar uma equipa
        /// </summary>
        /// <param name="equipa"> Recebe uma variavel do tipo json com o nome da equipa a adicionar no formato {"nome": nome}"</param>
        /// <returns string="Success"> If reaches end of function. </returns>
        /// <returns string="$EXCEPTION$"> If it fails. </returns>
        [HttpPost]
        [Route("addequipa")]
        public string AddEquipa([FromBody] string equipa)
        {
            ModeloEquipa equipaConvertido = Newtonsoft.Json.JsonConvert.DeserializeObject<ModeloEquipa>(equipa);
            return m.AddEquipa(equipaConvertido);
        }

    }
}
