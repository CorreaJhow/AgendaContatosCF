using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace AgendaContatos_CF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        public static void Menu()
        {
            Console.Clear();
            PhoneBooksImage();
            Console.WriteLine("\nEscolha uma opção: \n");
            Console.WriteLine("[0] Sair \n[1] Cadastrar \n[2] Editar \n[3] Consultar \n[4] Deletar");
            int op = int.Parse(Console.ReadLine());
            while (op < 0 || op > 4)
            {
                Console.WriteLine("Opção inválida, digite novamente:");
                op = int.Parse(Console.ReadLine());
            }
            switch (op)
            {
                case 0:
                    Console.Clear();
                    PhoneBooksImage();
                    Console.WriteLine("Obrigado a visita, volte sempre e nos contratem!");
                    Console.WriteLine("");
                    PressContinue();
                    Environment.Exit(0);
                    break;
                case 1:
                    Register();
                    Menu();
                    break;
                case 2:
                    Edit();
                    Menu();
                    break;
                case 3:
                    Console.Clear();
                    PhoneBooksImage();
                    Console.WriteLine("### Consult ###");
                    Console.WriteLine("Voce deseja consultar: \n[1] Todos Contatos \n[2] Contato Especifico");
                    int opc = int.Parse(Console.ReadLine());
                    while (opc < 1 || opc > 2)
                    {
                        Console.WriteLine("Opção inválida, informe novamente: ");
                        opc = int.Parse(Console.ReadLine());
                    }
                    switch (opc)
                    {
                        case 1:
                            ConsultAll();
                            break;
                        case 2:
                            ConsultOne();
                            break;
                        default:
                            break;
                    }
                    Menu();
                    break;
                case 4:
                    Delete();
                    Menu();
                    break;
                default:
                    break;
            }
        }
        public static void PhoneBooksImage()
        {
            Console.WriteLine(" +--------------------------------------------------------------------------------------------------------------------+");
            Console.WriteLine(" |                                                    Agenda de Contatos                                              |");
            Console.WriteLine(" +--------------------------------------------------------------------------------------------------------------------+");
        }
        public static void PressContinue()
        {
            Console.WriteLine("-=-=-=-=-= Pressione alguma tecla para prosseguir -=-=-=-=-=");
            Console.ReadKey();
        }
        public static void Register()
        {
            Contact c = new Contact();
            Telephone telephone = new Telephone();
            using (var context = new Context())
            {
                Console.Clear();
                PhoneBooksImage();
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
                    PressContinue();
                }
                else
                {
                    Console.WriteLine("Esse nome já existe em nosso banco de dados, volte e insira outro!!");
                    PressContinue();
                }
            }
        }
        public static void Edit() 
        {
            Contact person = new Contact();
            using (var context = new Context())
            {
                Console.Clear();
                PhoneBooksImage();
                Console.WriteLine("### Edit ###");
                Console.WriteLine("Informe o nome para consultar os dados do contato: ");
                person.Nome = Console.ReadLine().ToLower();
                var find = context.Telephone.FirstOrDefault(t => t.Contact.Nome == person.Nome);
                if (find != null)
                {
                    Console.WriteLine(find.ToString());
                    PressContinue();
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
                            PressContinue();
                            break;
                        case 2:
                            Console.WriteLine("### Alterar Telefone Fixo ### ");
                            string f = Console.ReadLine();
                            find.Fixo = f;
                            context.Entry(find).State = EntityState.Modified;
                            context.SaveChanges();
                            Console.WriteLine("\n ### Telefone fixo atualizado! ###");
                            Console.WriteLine(find.ToString());
                            PressContinue();
                            break;
                        default:
                            Console.WriteLine("Informe uma das opções ofertadas!!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nDesculpe-nos, esse contato não foi encontrado!");
                    PressContinue();
                }
            }
        }
        public static void ConsultAll()
        {
            var telephone = new Context().Telephone.ToList();
            if (telephone.Count == 0)
            {
                Console.WriteLine("\n ### Nao possuem contatos cadastrados ### \n");
                PressContinue();
            }
            else
            {
                foreach (var item in telephone)
                {
                    Console.WriteLine(item.ToString());
                }
                PressContinue();
            }
        }
        public static void ConsultOne()
        {
            Contact person = new Contact();
            using (var context = new Context())
            {
                Console.Clear();
                PhoneBooksImage();
                Console.WriteLine("### Consult One ###");
                Console.WriteLine("Informe o nome para consultar: ");
                person.Nome = Console.ReadLine().ToLower();
                var find = context.Telephone.FirstOrDefault(t => t.Contact.Nome == person.Nome);
                if (find != null)
                {
                    Console.WriteLine(find.ToString());
                    Console.WriteLine("");
                    PressContinue();
                }
                else
                {
                    Console.WriteLine("\nDesculpe, cadastro não encontrado!");
                    Console.WriteLine("");
                    PressContinue();
                }
            }
        }
        public static void Delete()
        {
            Contact person = new Contact();
            using (var context = new Context())
            {
                Console.Clear();
                PhoneBooksImage();
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
                        PressContinue();
                    }
                    else
                    {
                        Console.WriteLine("\nOperação cancelada!");
                        PressContinue();
                    }
                }
                else
                {
                    Console.WriteLine("\n### Contato não encontrado! ###");
                    PressContinue();
                }
            }
        }
    }
}
