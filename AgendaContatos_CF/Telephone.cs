using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaContatos_CF
{
    internal class Telephone
    {
        [Key()]
        public int Id { get; set; }
        public string Celular { get; set; }
        public string Fixo { get; set; }
        [ForeignKey("Contact")]
        public int IdContato { get; set; }
        public virtual Contact Contact { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} | IdContato: {IdContato} " +
                $"\nCelular: {Celular} | Fixo: {Fixo} " +
                $"\n"; 
        }
    }
}
