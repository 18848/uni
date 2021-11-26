using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ISIAPI.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        public ModeloMateriais m;

        public MaterialController()
        {
            if (m == null) m = new ModeloMateriais();

            m.AddMaterial(new ModeloMaterial(1, "mascara", 3));
            m.AddMaterial(new ModeloMaterial(2, "seringa", 3));
            m.AddMaterial(new ModeloMaterial(3, "penço", 3));
            m.AddMaterial(new ModeloMaterial(4, "bata", 3));
        }

        [HttpGet]
        [Route("getmaterial/{idMaterial}")]
        public string GetMaterial(int idMaterial)
        {
            return m.GetMaterialById(idMaterial);
        }

        [HttpGet]
        [Route("getall")]
        public DataTable GetMateriais()
        {
            return m.GetAllMateriais();
        }


        //CORRIGIR, está a adicionar a lista de novo!!!!!!!!!!!!!!!!!!!!!!
        [HttpPost]
        [Route("addmaterial")]
        public bool AddMaterial(ModeloMaterial material)
        {
            return m.AddMaterial(material);
            
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
