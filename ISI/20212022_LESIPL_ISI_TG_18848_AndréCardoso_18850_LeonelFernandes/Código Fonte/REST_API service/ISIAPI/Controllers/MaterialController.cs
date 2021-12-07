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

        /// <summary>
        /// Rota para devolver todos os materiais presentes na base de dados
        /// </summary>
        /// <returns string=Materiais> If reaches end of function. </returns>
        /// <returns string="$EXCEPTION$"> If it fails. </returns>
        [HttpGet]
        [Route("getall")]
        public string GetMateriais()
        {
            return m.GetAllMateriais();
        }

        /// <summary>
        /// Rota para devolver os 5 materiais presentes em mais requisições
        /// </summary>
        /// <returns string=Materiais> If reaches end of function. </returns>
        /// <returns string="$EXCEPTION$"> If it fails. </returns>
        [HttpGet]
        [Route("getMaterialMaisUsado")]
        public string GetMaterialMaisUsado()
        {
            return m.GetMaterialMaisUsado();
        }

        /// <summary>
        /// Rota para adicionar um novo material
        /// </summary>
        /// <param name="material">recebe uma variável do tipo json no formato {"nome":nome, "custo":custo}</param>
        /// <returns string="Success"> If reaches end of function. </returns>
        /// <returns string="$EXCEPTION$"> If it fails. </returns>
        [HttpPost("addmaterial")]
        public string AddMaterial([FromBody] string material)
        {   
            ModeloMaterial materialConvertido = Newtonsoft.Json.JsonConvert.DeserializeObject<ModeloMaterial>(material);
            return m.AddMaterial(materialConvertido);
        }

    }
}
