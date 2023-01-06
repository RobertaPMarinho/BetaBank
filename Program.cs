namespace BetaBank
{
    public class Program
    {
        static void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("1 - Cadastrar novo usuário:");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("2 - Deletar um usuário");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("3 - Listar todas as contas registradas");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("4 - Detalhar o usuário");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("5 - Movimentar a conta");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("0 - Finalizar o programa");
            Console.ResetColor();

            Console.WriteLine();
            Console.Write("Digite a opção desejada: ");
        }

        static void CadastrarNovoUsuario(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.Write("Digite o nome completo: ");
            titulares.Add(Console.ReadLine());
            Console.Write("Digite o CPF: ");
            cpfs.Add(Console.ReadLine());
            saldos.Add(1000); //deposito mínimo inicial!
        }

        static void DeletarUsuario(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.Write("Digite o CPF: ");
            string CpfParaDeletar = Console.ReadLine();

            int indexToFind = cpfs.IndexOf(CpfParaDeletar);

            if (indexToFind == -1)
            {
                MensagemDeErro();
            }
            else
            {
                titulares.RemoveAt(indexToFind);
                cpfs.RemoveAt(indexToFind);
                saldos.RemoveAt(indexToFind);

                Console.WriteLine("Usuário deletado do sistema!");
            }
        }

        static void MensagemDeErro()
        {
            Console.WriteLine("Informação Inválida!");
        }

        static void ListarTodasContas(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            int indexOfList = titulares.Count();
            Console.WriteLine($"Total de contas registradas: {indexOfList}");

            for (int i = 0; i < cpfs.Count; i++)
            {
                Console.WriteLine($"CPF = {cpfs[i]} | Titular = {titulares[i]} | Saldo = R${saldos[i]:F2}");
            }
        }

        static void DetalharUsuarios(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.Write("Digite o CPF do usuário: ");
            string cpf = Console.ReadLine();

            int indexToFind = cpfs.IndexOf(cpf);

            if (indexToFind == -1)
            {
                Console.WriteLine("CPF Inexixtente!");
            }
            else
            {
                Console.WriteLine("Titular da conta: " + titulares[indexToFind]);
                Console.WriteLine("CPF do titular: " + cpfs[indexToFind]);
                Console.WriteLine("Saldo em conta: R$ " + saldos[indexToFind]);
            }
        }

        static void MovimentarConta(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1 - Depositar");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("2 - Sacar");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("3 - Transferir");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("0 - Finalizar o programa");
            Console.ResetColor();

            Console.WriteLine();
            Console.Write("Digite a opção desejada: ");

            int optionMovimento;

            do
            {
                ShowMenu();

                optionMovimento = int.Parse(Console.ReadLine());

                Console.WriteLine("-------------------------------------------------------------------------------------------------------------");

                switch (optionMovimento)
                {
                    case 0:
                        Console.WriteLine("Programa foi finalizado! Sempre que precisar, estamos a disposição!");
                        break;
                    case 1:
                        Depositar(cpfs, saldos);
                        break;
                    case 2:
                        Sacar(cpfs, saldos);
                        break;
                    case 3:
                        Transferir(cpfs, saldos);
                        break;
                }
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------");

            } while (optionMovimento != 0);


            static void Depositar(List<string> cpfs, List<double> saldos)
            {
                Console.Write("Insira seu CPF: ");
                string cpfDeposito = Console.ReadLine();

                int indexToFind = cpfs.IndexOf(cpfDeposito);

                if (indexToFind == -1)
                {
                    Console.WriteLine("CPF inexistente!");
                }
                else
                {
                    Console.Write("Qual o valor do depósito: R$ ");

                    double valorDeposito = double.Parse(Console.ReadLine());
                    string tenteNovamente;

                    while (true)
                    {
                        if (valorDeposito > saldos[indexToFind])
                        {
                            Console.WriteLine("Saldo insuficiente");
                            Console.Write("Gostaria de tentar depositar outro valor? S/N");
                            tenteNovamente = Console.ReadLine();
                        }
                        else
                        {
                            saldos[indexToFind] += valorDeposito;
                            Console.WriteLine("Depósito realizado com sucesso.");
                            Console.WriteLine($" Seu saldo atual é de R$ {saldos[indexToFind]:F2}");

                            tenteNovamente = "N";
                        }
                        if (tenteNovamente == "S")
                        {
                            Console.Write("Qual o valor do depósito: R$ ");

                            valorDeposito = double.Parse(Console.ReadLine());
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            static void Sacar(List<string> cpfs, List<double> saldos)
            {
                Console.Write("Insira seu CPF: ");
                string cpfDeposito = Console.ReadLine();

                int indexToFind = cpfs.IndexOf(cpfDeposito);

                if (indexToFind == -1)
                {
                    Console.WriteLine("CPF inexistente!");
                }
                else
                {
                    Console.Write("Qual o valor do saque: R$ ");
                    double valorSaque = double.Parse(Console.ReadLine());
                    string tenteNovamente;

                    while (true)
                    {
                        if (valorSaque > saldos[indexToFind])
                        {
                            Console.WriteLine("Saldo insuficiente");

                            Console.Write("Gostaria de tentar sacar outro valor? S/N");
                            tenteNovamente = Console.ReadLine();
                        }
                        else
                        {
                            saldos[indexToFind] -= valorSaque;
                            Console.WriteLine("Saque realizado com sucesso!");
                            Console.WriteLine($" Seu saldo atual é de R$ {saldos[indexToFind]:F2}");
                            tenteNovamente = "N";
                        }
                        if (tenteNovamente == "S")
                        {
                            Console.Write("Qual o valor do saque? R$ ");
                            valorSaque = double.Parse(Console.ReadLine());
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            static void Transferir(List<string> cpfs, List<double> saldos)
            {
                Console.Write("Insira seu CPF: ");
                string cpfUsuario1 = Console.ReadLine();


                int indexUsuario1 = cpfs.IndexOf(cpfUsuario1);

                if (indexUsuario1 == -1)
                {
                    Console.WriteLine("CPF inexistente!");
                }
                else
                {
                    Console.WriteLine("Insira o CPF do destinatário: R$ ");
                    string cpfUsuario2 = Console.ReadLine();
                    int indexUsuario2 = cpfs.IndexOf(cpfUsuario2);

                    if (indexUsuario2 == -1)
                    {
                        Console.WriteLine("Usuário não foi localizado");
                    }
                    else
                    {
                        Console.WriteLine("Qual o valor da transferência? R$ ");
                        double valorTransferencia = double.Parse(Console.ReadLine());
                        string tenteNovamente;

                        while (true)
                        {
                            if (valorTransferencia > saldos[indexUsuario1])
                            {
                                Console.WriteLine("Saldo insuficiente");

                                Console.Write("Gostaria de transferir outro valor? S/N");
                                tenteNovamente = Console.ReadLine();
                            }
                            else
                            {
                                saldos[indexUsuario1] -= valorTransferencia;
                                saldos[indexUsuario2] += valorTransferencia;
                                Console.WriteLine("Transferência realizada com sucesso!");
                                Console.WriteLine($" Seu saldo atual é de R$ {saldos[indexUsuario1]:F2}");
                                tenteNovamente = "N";
                            }

                            if (tenteNovamente == "S")
                            {
                                Console.Write("Qual o valor da transferência? R$ ");
                                valorTransferencia = double.Parse(Console.ReadLine());
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {

            Console.WriteLine("---------------------------------------------------------------BEM-VINDO AO BETABANK------------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Antes de começar a usar, vamos configurar alguns valores: ");

            List<string> cpfs = new List<string>();
            List<string> titulares = new List<string>();
            List<double> saldos = new List<double>();


            int option;

            do
            {
                ShowMenu();
                option = int.Parse(Console.ReadLine());

                Console.WriteLine("-------------------------------------------------------------------------------------------------------------");

                switch (option)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Programa foi finalizado! Sempre que precisar, estamos a disposição!");
                        Console.ResetColor();
                        break;
                    case 1:
                        CadastrarNovoUsuario(cpfs, titulares, saldos);
                        break;
                    case 2:
                        DeletarUsuario(cpfs, titulares, saldos);
                        Console.WriteLine();
                        break;
                    case 3:
                        ListarTodasContas(cpfs, titulares, saldos);
                        break;
                    case 4:
                        DetalharUsuarios(cpfs, titulares, saldos);
                        break;
                    case 5:
                        MovimentarConta(cpfs, titulares, saldos);
                        break;
                }

                Console.WriteLine("-------------------------------------------------------------------------------------------------------------");

            } while (option != 0);
        }
    }
}