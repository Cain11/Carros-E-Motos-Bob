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

        public CadastroVm() { }
        public CadastroVm(List<Modelo.AnuncioCadastroVm> listaModelos)
        {
            ListaModelos = listaModelos;
        }

        [Required]
        [Range(1900, 2100)]
        public int Ano { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Modelo")]
        public int ModeloId { get; set; }

        public IFormFile Imagem { get; set; }

        [Required]
        [Display(Name = "Preço")]
        [DataType(DataType.Currency)]
        public double Preco { get; set; }

        public List<Modelo.AnuncioCadastroVm> ListaModelos { get; set; }

    }
}
