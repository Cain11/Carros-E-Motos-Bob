using System;
using System.Collections.Generic;
using System.Text;

namespace CMBData.Models
{
    //TODO: Excluir classe?
    public class AnunciosAbertos
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public Anuncio Anuncio { get; set; }

    }
}
