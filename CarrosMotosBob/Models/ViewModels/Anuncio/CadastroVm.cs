using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CarrosMotosBob.Models.ViewModels.Anuncio
{
    public class CadastroVm
    {

        [Required]
        [Range(1900, 2100)]
        public int Ano { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        //TODO: Descomentar quando implementar os modelos de carros
        //public int ModeloId { get; set; }

        public IFormFile Imagem { get; set; }

        [Required]
        [Display(Name = "Preço")]
        [DataType(DataType.Currency)]
        public double Preco { get; set; }
    }
}
