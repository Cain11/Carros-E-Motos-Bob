using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarrosMotosBob.Models.ViewModels.Anuncio
{
    public class ListaVm
    {
        public AnuncianteVm Anunciante { get; set; }

        public ModeloVm Modelo { get; set; }

        public int Ano { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public string Imagem { get; set; }

        [Display(Name = "Data de publicação")]
        public DateTime DataPublicacao { get; set; }

        [Display(Name = "Preço")]
        public double Preco { get; set; }

        public class AnuncianteVm
        {
            public string Nome { get; set; }

            public string Telefone { get; set; }

            public string Estado { get; set; }

            public string Cidade { get; set; }
        }

        public class ModeloVm
        {
            //TODO: Preencher classe com os campos de modelo que serão exibidos na listagem de anúncios
        }

    }
}
