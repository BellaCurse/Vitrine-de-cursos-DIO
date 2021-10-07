using System;

namespace DIO.Vitrine
{
    class Program
    {
        static VitrineRepositorio repositorio = new VitrineRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarVitrine();
                        break;
                    case "2":
                        InserirVitrine();
                        break;
                    case "3":
                        AtualizarVitrine();
                        break;
                    case "4":
                        ExcluirVitrine();
                        break;
                    case "5":
                        VisualizarVitrine();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ExcluirVitrine()
        {
            Console.Write("Digite o id da vitrine: ");
            int indiceVitrine = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceVitrine);
        }

        private static void VisualizarVitrine()
        {
            Console.Write("Digite o id da vitrine: ");
            int indiceVitrine = int.Parse(Console.ReadLine());

            var vitrine = repositorio.RetornaPorId(indiceVitrine);

            Console.WriteLine(vitrine);
        }

        private static void AtualizarVitrine()
        {
            Console.Write("Digite o id da vitrine: ");
            int indiceVitrine = int.Parse(Console.ReadLine());

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in Enum.GetValues(typeof(Categoria)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Categoria), i));
            }
            Console.Write("Digite o categoria entre as opções acima: ");
            int entradaCategoria = int.Parse(Console.ReadLine());

            Console.Write("Digite o Curso da Vitrine: ");
            string entradaCurso = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Vitrine: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Vitrine: ");
            string entradaDescricao = Console.ReadLine();

            Vitrine atualizaVitrine = new Vitrine(id: indiceVitrine,
                                        categoria: (Categoria)entradaCategoria,
                                        curso: entradaCurso,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceVitrine, atualizaVitrine);
        }
        private static void ListarVitrine()
        {
            Console.WriteLine("Listar vitrine");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma vitrine cadastrada.");
                return;
            }

            foreach (var vitrine in lista)
            {
                var excluido = vitrine.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", vitrine.retornaId(), vitrine.retornaCurso(), (excluido ? "*Excluído*" : ""));
            }
        }

        private static void InserirVitrine()
        {
            Console.WriteLine("Inserir nova vitrine");

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in Enum.GetValues(typeof(Categoria)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Categoria), i));
            }
            Console.Write("Digite o categoria entre as opções acima: ");
            int entradaCategoria = int.Parse(Console.ReadLine());

            Console.Write("Digite o Curso da Vitrine: ");
            string entradaCurso = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Vitrine: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Vitrine: ");
            string entradaDescricao = Console.ReadLine();

            Vitrine novaVitrine = new Vitrine(id: repositorio.ProximoId(),
                                        categoria: (Categoria)entradaCategoria,
                                        curso: entradaCurso,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaVitrine);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Vitrine a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar vitrine");
            Console.WriteLine("2- Inserir nova vitrine");
            Console.WriteLine("3- Atualizar vitrine");
            Console.WriteLine("4- Excluir vitrine");
            Console.WriteLine("5- Visualizar vitrine");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}