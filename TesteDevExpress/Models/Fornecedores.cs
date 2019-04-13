using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//https://www.devexpress.com/Support/Center/Question/Details/T722888/the-entity-type-requires-a-primary-key-to-be-defined-error-occurs-under-certain-conditions

namespace TesteDevExpress.Models
{
    public class Fornecedores
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }
}
