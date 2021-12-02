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


        //Rota para devolver todas as requisições presentes na base de dados
        [HttpGet]
        [Route("getall")]
        public string GetRequisicoes()
        {
            return m.GetAllRequisicoes();
        }

        //Rota para adicionar uma requisicao
        //formato {"idEquipa":id, "entregue":(true or false)}
        [HttpPost]
        [Route("addRequisicao")]
        public string AddRequisicao(string requisicao)
        {
            ModeloRequisicao requisicaoConvertido = Newtonsoft.Json.JsonConvert.DeserializeObject<ModeloRequisicao>(requisicao);
            return m.AddRequisicao(requisicaoConvertido);
        }

        //Rota para devolver as requisições de uma equipa
        [HttpGet]
        [Route("getrequisicaobyequipa/{idEquipa}")]
        public string GetRequisicaoByEquipca(int idEquipa)
        {
            return m.GetRequisicaoByEquipa(idEquipa);
        }

        //Rota para dar update ao estado de entregue de uma requisição
        [HttpPut]
        [Route("updateEntregue/{idRequisicao}")]
        public string UpdateRequisicaoEntregue(int idRequisicao)
        {
            return m.UpdateRequisicao(idRequisicao);
        }



    }
}
