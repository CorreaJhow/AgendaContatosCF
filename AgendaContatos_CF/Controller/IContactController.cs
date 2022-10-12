using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaContatos_CF.Controller
{
    public interface IContactController
    {
        void Register();
        void Edit();
        void ConsultAll();
        void ConsultOne();
        void Delete();
    }
}
