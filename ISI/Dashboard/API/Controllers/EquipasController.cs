using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Net.Http;
using API.Models;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    //[Authorize(Roles = "Admin,User")]
    public class EquipasController : Controller
    {
        [HttpGet("equipas")]
        public object Equipas()
        {
            List<EquipaModel> equipas = new List<EquipaModel>();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("https://localhost:44370/api/Equipa/getEquipaMaisCara").Result;
            var res = response.Content.ReadAsStringAsync().Result;

            equipas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EquipaModel>>(res);
            return new ObjectResult(equipas);
        }

        [HttpGet("material")]
        public object Produtos()
        {
            List<MaterialModel> materiais = new List<MaterialModel>();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("https://localhost:44370/api/Material/getMaterialMaisUsado").Result;
            var res = response.Content.ReadAsStringAsync().Result;

            materiais = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MaterialModel>>(res);
            return new ObjectResult(materiais);
        }
    }
}
