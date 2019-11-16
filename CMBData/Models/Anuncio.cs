using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMBData.Models
{
    public class Anuncio
    {
        public int Id { get; set; }

        [Required]
        public Cliente Anunciante { get; set; }

        //TODO: Acrescentar [Required] ao modelo quando os modelos de carros forem implementados
        public Modelo Modelo { get; set; }

        [Required]
        public int Ano { get; set; }

        [Required]
        public string Descricao { get; set; }

        public string Imagem { get; set; }

        public double Preco { get; set; }

        [Required]
        public DateTime DataPublicacao { get; set; }

        //TODO: Excluir campo?
        public int Status { get; set; }
    }
}