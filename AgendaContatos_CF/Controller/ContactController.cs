using System;
using System.Data.Entity;
using System.Linq;

namespace AgendaContatos_CF.Controller
{
    internal class ContactController : IContactController
    {
        public void ConsultAll()
        {
            var telephone = new Context().Telephone.ToList();
            if (telephone.Count == 0)
            {
                Console.WriteLine("\n ### Nao possuem contatos cadastrados ### \n");
                Program.PressContinue();
            }
            else
            {
                foreach (var item in telephone)
                {
                    Console.WriteLine(item.ToString());
                }
                Program.PressContinue();
            }
        }
        public void ConsultOne()
        {
            Contact person = new Contact();
            using (var context = new Context())
            {
                Console.Clear();
                Program.PhoneBooksImage();
                Console.WriteLine("### Consult One ###");
                Console.WriteLine("Informe o nome para consultar: ");
                person.Nome = Console.ReadLine().ToLower();
                var find = context.Telephone.FirstOrDefault(t => t.Contact.Nome == person.Nome);
                if (find != null)
                {
                    Console.WriteLine(find.ToString());
                    Console.WriteLine("");
                    Program.PressContinue();
                }
                else
                {
                    Console.WriteLine("\nDesculpe, cadastro não encontrado!");
                    Console.WriteLine("");
                    Program.PressContinue();
                }
            }
        }
        public void Delete()
        {
            Contact person = new Contact();
            using (var context = new Context())
            {
                Console.Clear();
                Program.PhoneBooksImage();
                Console.WriteLine("### Delete ###");
                Console.WriteLine("Informe o nome para buscar o cadastro: ");
                person.Nome = Console.ReadLine().ToLower();
                var find = context.Telephone.FirstOrDefault(t => t.Contact.Nome == person.Nome);
                if (find != null)
                {
                    Console.WriteLine(find.ToString());
                    Console.WriteLine("Deseja realmente deletar esse contato? \n[1] Sim \n[2] Não");
                    int op = int.Parse(Console.ReadLine());
                    while (op < 1 || op > 2)
                    {
                        Console.WriteLine("Opção inválida, informe novamente: ");
                        op = int.Parse(Console.ReadLine());
                    }
                    if (op == 1)
                    {
                        context.Entry(find).State = EntityState.Deleted;
                        context.Telephone.Remove(find);
                        context.SaveChanges();
                        Console.WriteLine(" ### Contato deletado com sucesso! ### \n");
                        Program.PressContinue();
                    }
                    else
                    {
                        Console.WriteLine("\nOperação cancelada!");
                        Program.PressContinue();
                    }
                }
                else
                {
                    Console.WriteLine("\n### Contato não encontrado! ###");
                    Program.PressContinue();
                }
            }
        }
        public void Edit()
        {
            Contact person = new Contact();
            using (var context = new Context())
            {
                Console.Clear();
                Program.PhoneBooksImage();
                Console.WriteLine("### Edit ###");
                Console.WriteLine("Informe o nome para consultar os dados do contato: ");
                person.Nome = Console.ReadLine().ToLower();
                var find = context.Telephone.FirstOrDefault(t => t.Contact.Nome == person.Nome);
                if (find != null)
                {
                    Console.WriteLine(find.ToString());
                    Program.PressContinue();
                    Console.WriteLine("\nO que deseja atualizar?\n[1] Celular\n[2] Fixo");
                    int op = int.Parse(Console.ReadLine());
                    while (op < 1 || op > 2)
                    {
                        Console.WriteLine("Opção inválida informada, informe novamente: ");
                        op = int.Parse(Console.ReadLine());
                    }
                    switch (op)
                    {
                        case 1:
                            Console.WriteLine("### Alterar Celular ###");
                            Console.WriteLine("Digite o novo numero de celular: ");
                            string c = Console.ReadLine();
                            find.Celular = c;
                            context.Entry(find).State = EntityState.Modified;
                            context.SaveChanges();
                            Console.WriteLine("\n### Telefone celular atualizado! ###");
                            Console.WriteLine(find.ToString());
                            Program.PressContinue();
                            break;
                        case 2:
                            Console.WriteLine("### Alterar Telefone Fixo ### ");
                            string f = Console.ReadLine();
                            find.Fixo = f;
                            context.Entry(find).State = EntityState.Modified;
                            context.SaveChanges();
                            Console.WriteLine("\n ### Telefone fixo atualizado! ###");
                            Console.WriteLine(find.ToString());
                            Program.PressContinue();
                            break;
                        default:
                            Console.WriteLine("Informe uma das opções ofertadas!!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nDesculpe-nos, esse contato não foi encontrado!");
                    Program.PressContinue();
                }
            }
        }
        public void Register()
        {
            Contact c = new Contact();
            Telephone telephone = new Telephone();
            using (var context = new Context())
            {
                Console.Clear();
                Program.PhoneBooksImage();
                Console.WriteLine("### Register ###");
                Console.WriteLine("Informe o nome do novo contato: ");
                c.Nome = Console.ReadLine().ToLower();
                var veriryName = context.Contact.FirstOrDefault(t => t.Nome == c.Nome);
                if (veriryName == null)
                {
                    context.Contact.Add(c);
                    Console.WriteLine("Informe o numero do novo contato: [celular]");
                    telephone.Celular = Console.ReadLine();
                    Console.WriteLine("Informe o 2° numero do novo contato: [Fixo]");
                    telephone.Fixo = Console.ReadLine();
                    telephone.IdContato = c.Id;
                    context.Telephone.Add(telephone);
                    context.SaveChanges();
                    Console.WriteLine("### Contato salvo com sucesso! ###");
                    Program.PressContinue();
                }
                else
                {
                    Console.WriteLine("Esse nome já existe em nosso banco de dados, volte e insira outro!!");
                    Program.PressContinue();
                }
            }
        }
    }
}
