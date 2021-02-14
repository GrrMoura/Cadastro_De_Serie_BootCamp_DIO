using CadastroDeSeries.Classes;
using CadastroDeSeries.Enums;
using System;

namespace CadastroDeSeries
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string Op = ObterOpcao();
            while (Op.ToUpper() != "X")
            {
                switch (Op)
                {
                    case "1":
                        ListarSeries();
                        break; ;

                    case "2":
                        InserirSeries();
                        break;

                    case "3":
                        AtualizarSerie();
                        break;

                    case "4":
                        Excluir();

                        break;

                    case "5":
                        Visualizar();

                        break;

                    case "C":
                        Console.Clear();

                        break;

                    case "X":
                        Op = "X";

                        break;


                    default:
                        break;
                }
                Op = ObterOpcao();
            }
        }

        private static void Visualizar()
        {
            Console.WriteLine("Qual o ID da série que quer visualizar");
            int indiceVisualizar = int.Parse(Console.ReadLine());
            repositorio.RetornarPorId(indiceVisualizar);
        }

        private static void Excluir()
        {
            Console.WriteLine("Qual o Id da série que quer excluir");
            int indiceExcluir = int.Parse(Console.ReadLine());

            repositorio.Excluir(indiceExcluir);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Qual o Id da série");
            int indiceSerie = int.Parse(Console.ReadLine());


            foreach (int i in Enum.GetValues(typeof(Generos)))
            {
                Console.WriteLine("{0} -{1}", i, Enum.GetName(typeof(Generos), i));
            }

            Console.WriteLine("Digite o gênero enttre as opções acima");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Titulo");
            string enntradaTitulo = Console.ReadLine();
            Console.WriteLine("Digite o Ano da série");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine("Faça uma descricao da serie");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(indiceSerie, genero: (Generos)entradaGenero, enntradaTitulo, entradaDescricao, entradaAno);

            repositorio.Atualizar(indiceSerie, novaSerie);
        }

        private static void InserirSeries()
        {
            Console.WriteLine("Inserir Nova Serie");


            foreach (int i in Enum.GetValues(typeof(Generos)))
            {
                Console.WriteLine("{0} -{1}", i, Enum.GetName(typeof(Generos), i));
            }

            Console.WriteLine("Digite o gênero enttre as opções acima");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Titulo");
            string enntradaTitulo = Console.ReadLine();
            Console.WriteLine("Digite o Ano da série");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine("Faça uma descricao da serie");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(repositorio.Proximo(), genero: (Generos)entradaGenero, enntradaTitulo, entradaDescricao, entradaAno);

            repositorio.Insere(novaSerie);
        }

        private static void ListarSeries()
        {
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nao tem serie Cadastrado");
                return;

            }
            foreach (var item in lista)
            {
                if (item.Ativo == false)
                {
                    Console.WriteLine("# {0}: -{1}", item.RetornaId(), item.RetornaTitulo());
                }
               

            }
        }

        private static string ObterOpcao()
        {
            Console.WriteLine("");
            Console.WriteLine("Rocha Séries a seus Dispor");
            Console.WriteLine("Informe a opção Desejada");
            Console.WriteLine("1- Listar");
            Console.WriteLine("2- Inserir nova serie");
            Console.WriteLine("3- Atualizar");
            Console.WriteLine("4- Excluir");
            Console.WriteLine("5- Vizualizar Serie");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine("");

            string opcaoUsuario = Console.ReadLine();
            return opcaoUsuario;
        }

    }
}
