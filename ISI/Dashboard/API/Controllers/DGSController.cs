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
    //[Authorize(Roles = "Admin,Reader" )]
    public class DGSController : Controller
    {
        public object DGS()
        {
            List<ConcelhoModel> concelhos = new List<ConcelhoModel>();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("https://covid19-api.vost.pt/Requests/get_last_update_counties").Result;
            var res = response.Content.ReadAsStringAsync().Result;

            concelhos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ConcelhoModel>>(res);
            return new ObjectResult(concelhos);
        }
    }
}
