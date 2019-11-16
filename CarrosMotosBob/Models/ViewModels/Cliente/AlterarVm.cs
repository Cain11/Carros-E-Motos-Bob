using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarrosMotosBob.Models.ViewModels.Cliente
{
    public class AlterarVm
    {
        [Editable(false)]
        public string Nome { get; set; }

        [Editable(false)]
        public long CPF { get; set; }

        [Editable(false)]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "É obrigatório informar a senha atual para qualquer mudança")]
        [Display(Name = "Senha atual (obrigatório)")]
        public string SenhaAtual { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Senha nova")]
        public string SenhaNova { get; set; }

        public string Cidade { get; set; }

        [StringLength(2, MinimumLength = 2)]
        public string Estado { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

    }
}
