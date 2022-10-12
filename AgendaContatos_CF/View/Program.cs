using System;
using AgendaContatos_CF.Service;

namespace AgendaContatos_CF
{
    internal class Program
    {
        static ContactService Servicos = new ContactService();
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
                    Servicos.Register();
                    Menu();
                    break;
                case 2:
                    Servicos.Edit();
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
                            Servicos.ConsultAll();
                            break;
                        case 2:
                            Servicos.ConsultOne();
                            break;
                        default:
                            break;
                    }
                    Menu();
                    break;
                case 4:
                    Servicos.Delete();
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
    }
}
