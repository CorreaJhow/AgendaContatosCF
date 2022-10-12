using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaContatos_CF
{
    internal class Contact
    {
        [Key()]
        public int Id { get; set; }
        public string Nome { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}" +
                $"\nNome: {Nome}" +
                $"\n";
        }
    }
}
