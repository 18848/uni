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

        //Rota para devolver todos os materiais presentes na base de dados
        [HttpGet]
        [Route("getall")]
        public string GetMateriais()
        {
            return m.GetAllMateriais();
        }

        //Rota para devolver os 5 materiais presentes em mais requisições
        [HttpGet]
        [Route("getMaterialMaisUsado")]
        public string GetMaterialMaisUsado()
        {
            return m.GetMaterialMaisUsado();
        }

        //Rota para adicionar um novo material
        // formato {"nome":nome, "custo":custo}
        [HttpPost("addmaterial")]
        public string AddMaterial([FromBody] string material)
        {   
            ModeloMaterial materialConvertido = Newtonsoft.Json.JsonConvert.DeserializeObject<ModeloMaterial>(material);
            return m.AddMaterial(materialConvertido);
        }

    }
}
