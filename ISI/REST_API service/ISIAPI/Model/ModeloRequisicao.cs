using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ISIAPI
{
    public class ModeloRequisicao
    {
        private int idRequisicao;
        private bool entregue;

        [Required]
        public int Id { get => idRequisicao; set => idRequisicao = value; }
        [Required]
        public bool Entregue { get => entregue; set => entregue = value; }

    }
}
