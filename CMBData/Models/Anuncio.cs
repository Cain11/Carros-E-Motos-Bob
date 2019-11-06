using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMBData.Models
{
    public class Anuncio
    {
        public int Id { get; set; }

        // Anotações "Required" foram removidas para apresentação do projeto
        // ao professor. Colocar novamente quando necessário (necessitará de atualização
        // manual do banco de dados ou removê-lo e criar novamente com o EF)

        //[Required]
        public Cliente Anunciante { get; set; }

        [Required] 
        public int Ano { get; set; }

        //[Required] 
        public Modelo Modelo { get; set; }

        [Required] 
        public string Descricao { get; set; }

        [Range(1, 3)] 
        public int Status { get; set; }
    }
}