using System;

namespace CadastroDeSeries
{
    class Program
    {
        static SeriesRepositorios repositorio = new SeriesRepositorios();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOperacaoUsuario();
            while (opcaoUsuario.ToUpper() != "x")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListaSeries();
                        break;
                    case "2":
                        InseriSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOperacaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos Serviços");
            Console.ReadLine();
        }

        private static void ListaSeries()
        {
            Console.WriteLine("Listar series");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série encontrada");
                return;
            }

            foreach (var series in lista)
            {
                var excluido = series.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1}", series.retornaId(), series.retornaTitulo(), excluido ? "*Excluido*" : "");
            }
        }

        private static void InseriSerie()
        {
            Console.WriteLine("Insira uma nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gereno entre as opções acima");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da serie");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano do inicio da serie");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrião da serie");
            string entradaDescricao = Console.ReadLine();

            Series novaSerie = new Series(id: repositorio.proximoId(), genero: (Genero)entradaGenero,
            titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o Id da série");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da série");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano do inicio da serie");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrião da serie");
            string entradaDescricao = Console.ReadLine();

            Series atualizaSerie = new Series(id: indiceSerie, genero: (Genero)entradaGenero,
            titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);

        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o Id da série");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o Id da série");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.retornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static string ObterOperacaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("NetWill a seu dispor!!!");
            Console.WriteLine("Informe a opão desejada!");

            Console.WriteLine("1 - Listar série");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar série");
            Console.WriteLine("X - Sair");
            Console.WriteLine("");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}
