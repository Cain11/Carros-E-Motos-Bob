using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CarrosMotosBob.Models.ViewModels.Cliente;
using CarrosMotosBob.Models.ViewModels.Modelo;

namespace CarrosMotosBob.Models.ViewModels.Anuncio
{
    public class ListaVm
    {
        public AnuncianteVm Anunciante { get; set; }

        public AnuncioListaVm Modelo { get; set; }

        public int Ano { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public string Imagem { get; set; }

        [Display(Name = "Data de publicação")]
        public DateTime DataPublicacao { get; set; }

        [Display(Name = "Preço")]
        public double Preco { get; set; }

    }
}
