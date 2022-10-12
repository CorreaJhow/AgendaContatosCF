using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaContatos_CF.Controller;

namespace AgendaContatos_CF.Service
{
    internal class ContactService 
    {
        private IContactController _contactController;
        public ContactService()
        {
            _contactController = new ContactController();
        }
        public void Register()
        {
            _contactController.Register();
        }
        public void Edit()
        {
            _contactController.Edit();
        }
        public void ConsultAll()
        {
            _contactController.ConsultAll();
        }
        public void ConsultOne()
        {
            _contactController.ConsultOne();
        }
        public void Delete()
        {
            _contactController.Delete();
        }
    }
}
