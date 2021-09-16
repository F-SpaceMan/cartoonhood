using System;

namespace cartoonhood
{
    class Program {

        static CartoonRepositorio repositorio = new CartoonRepositorio();

        static void Main(string[] args) {

            string opcao = obterOpcao();

            while (opcao != "X") {

                switch (opcao) {
                    case "1":
                        listarCartoons();
                        break;
                    case "2":
                        inserirCartoon();
                        break;
                    case "3":
                        attCartoon();
                        break;
                    case "4":
                        excluirCartoon();
                        break;
                    case "5":
                        visCartoon();
                        break;
                    case "L":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcao = obterOpcao();
            }
            Console.WriteLine("Tamo junto");
        }

        private static void listarCartoons(){
            Console.WriteLine("Lista de cartoons");

            var lista = repositorio.lista();
            if(lista.Count == 0){
                Console.WriteLine("Nenhum cartoon cadastrado");
                Console.WriteLine();
                return;
            }

            foreach (var cartoon in lista)
            {
                var excluido = cartoon.retornaExcluido();
                Console.WriteLine($"ID: {cartoon.retornaId()} - {cartoon.retornaTitulo()} - {(excluido ? "*Excluído*" : "")}");

            }
            Console.WriteLine();
        }

        private static void inserirCartoon(){
            Console.WriteLine("Insira um cartoon");
            Console.WriteLine();

            Console.Write("Digite o título do cartoon: ");
            string titulo = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Digite o ano do cartoon: ");
            int ano = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Gêneros:");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }
            Console.WriteLine();

            Console.Write("Digite o gênero dentre as opções listadas acima: ");
            Genero genero = (Genero)int.Parse((Console.ReadLine()));
            Console.WriteLine();

            Console.Write("Preencha a descrição: ");
            string descricao = Console.ReadLine();
            Console.WriteLine();

            Cartoon novoCartoon = new Cartoon(repositorio.proximoId(), titulo, genero, descricao, ano);
            
            repositorio.insere(novoCartoon);

        }

        private static void attCartoon(){

            Console.WriteLine("Digite o ID do cartoon a ser atualizado: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Digite o título do cartoon: ");
            string titulo = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Digite o ano do cartoon: ");
            int ano = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Gêneros:");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }
            Console.WriteLine();

            Console.Write("Digite o gênero dentre as opções listadas acima: ");
            Genero genero = (Genero)int.Parse((Console.ReadLine()));
            Console.WriteLine();

            Console.Write("Preencha a descrição: ");
            string descricao = Console.ReadLine();
            Console.WriteLine();

            Cartoon novoCartoon = new Cartoon(id, titulo, genero, descricao, ano);
            
            repositorio.atualiza(id, novoCartoon);
        }

        private static void excluirCartoon(){
            Console.Write("Digite o ID do cartoon a ser excluído: ");
            int id = int.Parse(Console.ReadLine());

            repositorio.exclui(id);
        }

        private static void visCartoon(){
            Console.Write("Digite o ID do cartoon a ser visualizado: ");
            int id = int.Parse(Console.ReadLine());

            var cartoon = repositorio.retornaPorId(id);
            
            Console.WriteLine(cartoon);
        }

        private static string obterOpcao(){

            Console.WriteLine();

            Console.WriteLine("C A R T O O N H O O D");

            Console.WriteLine("1 - Listar cartoons");
            Console.WriteLine("2 - Inserir cartoon");
            Console.WriteLine("3 - Atualizar cartoon");
            Console.WriteLine("4 - Excluir cartoon");
            Console.WriteLine("5 - Visualizar cartoon");
            Console.WriteLine("L - Limpar tela");
            Console.WriteLine("X - SAIR");
            Console.WriteLine();

            string opcao = Console.ReadLine().ToUpper();

            return opcao;

        }
    }

}