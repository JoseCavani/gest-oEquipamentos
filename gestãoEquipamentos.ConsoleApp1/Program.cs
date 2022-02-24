using System;

namespace gestãoEquipamentos.ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region variaveis
            string[] nome = new string[1000];
            decimal[] preco = new decimal[1000];
            string[] numeroSerie = new string[1000];
            DateTime[] dataFabricacao = new DateTime[1000];
            string[] fabricante = new string[1000];
            int opcao = 0;
            bool existeChamada = false;

            string[,] titulo = new string[1000,1000];
            string[,] descricao = new string[1000, 1000];
            DateTime[,] dataAbertura = new DateTime[1000,1000];


            #endregion

            #region valores
            nome[0] = "nome1";
            preco[0] = 1005;
            numeroSerie[0] = "abc123";
            dataFabricacao[0] = new DateTime(2022, 02, 02);
            fabricante[0] = "Fab1";

            titulo[0, 0] = "tit1";
            descricao[0, 0] = "desc1";
            dataAbertura[0, 0] = new DateTime(2022, 02, 02);

            titulo[0, 1] = "tit2";
            descricao[0, 1] = "desc2";
            dataAbertura[0, 1] = new DateTime(2027, 02, 02);


            nome[1] = "nome2";
            preco[1] = 1995;
            numeroSerie[1] = "abc1563";
            dataFabricacao[1] = new DateTime(2025, 02, 02);
            fabricante[1] = "Fab5";

            #endregion

            while (true)
            {
                Console.Clear();
                opcao = selecionarOpcao();

                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        mostrarEquipamentos(nome, preco, numeroSerie, dataFabricacao, fabricante);
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        registarEquipamento(ref nome, ref preco, ref numeroSerie, ref dataFabricacao, ref fabricante);
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        editarEquipamento(ref nome, ref preco,ref numeroSerie,ref dataFabricacao,ref fabricante);
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        removerEquipmaneto(titulo,ref nome,ref preco,ref numeroSerie,ref dataFabricacao,ref fabricante);
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        mostrarChamadas(ref nome,ref existeChamada,ref titulo,ref descricao,ref dataAbertura);
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.Clear();
                        registarNovaChamda(ref nome,ref titulo,ref descricao,ref dataAbertura);
                        Console.ReadKey();
                        break;
                    case 7:
                        Console.Clear();
                        editarChamda(ref nome,ref titulo,ref descricao,ref dataAbertura);
                        Console.ReadKey();
                        break;
                    case 8:
                        Console.Clear();
                        excuilrChamada(ref nome,ref titulo,ref descricao,ref dataAbertura);
                        Console.ReadKey();
                        break;
                    case 9:
                        goto fim;

                }
            }
        fim:;
        }

        private static void excuilrChamada(ref string[] nome,ref string[,] titulo,ref string[,] descricao,ref DateTime[,] dataAbertura)
        {
        volta:
            Console.WriteLine("qual o numero do equipamento com a chamda ao qual quer exluir");
            if (!(int.TryParse(Console.ReadLine(), out int alterarNumero)) || nome[alterarNumero] == null)
            {
                mensagenDeErro("numero invalido ou nao existente");
                goto volta;
            }

        volta2:
            Console.WriteLine("qual a chamda que deseja excluir?");
            if (!(int.TryParse(Console.ReadLine(), out int alterarNumeroChamda)) || titulo[alterarNumero, alterarNumeroChamda] == null)
            {
                mensagenDeErro("chamdad invalido ou nao existente");
                goto volta2;
            }
            titulo[alterarNumero, alterarNumeroChamda] = default;
            descricao[alterarNumero, alterarNumeroChamda] = default;
            dataAbertura[alterarNumero, alterarNumeroChamda] = default;
            mensagenDeSucesso("chamda excluida com sucesso");
        }

        private static void editarChamda(ref string[] nome,ref string[,] titulo,ref string[,] descricao,ref DateTime[,] dataAbertura)
        {
        volta:
            Console.WriteLine("qual o numero do equipamento com a chamda ao qual quer editar");
            if (!(int.TryParse(Console.ReadLine(), out int alterarNumero)) || nome[alterarNumero] == null)
            {
                mensagenDeErro("equipamento invalido ou nao existente");
                goto volta;
            }

        volta2:
            Console.WriteLine("qual a chamda que deseja alterar?");
            if (!(int.TryParse(Console.ReadLine(), out int alterarNumeroChamda)) || titulo[alterarNumero, alterarNumeroChamda] == null)
            {
                mensagenDeErro("chamda invalido ou nao existente");
                goto volta2;
            }

        volta5:
            Console.WriteLine("o que deseja alterar?\n" +
                "1 = titulo\n" +
                "2 = descricao\n" +
                "3 = data de abertura\n");
            if (!(int.TryParse(Console.ReadLine(), out int opcaoAlterar)))
            {
                mensagenDeErro("opção invalido ou nao existente");
                goto volta5;
            }

            switch (opcaoAlterar)
            {
                case 1:
                    Console.WriteLine("digite o tiulo da chamada");
                    titulo[alterarNumero, alterarNumeroChamda] = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("digite a descricao da chamada");
                    descricao[alterarNumero, alterarNumeroChamda] = Console.ReadLine();
                    break;
                case 3:
                volta3:
                    Console.WriteLine("digite a data da chamada");
                    if (!(DateTime.TryParse(Console.ReadLine(), out dataAbertura[alterarNumero, alterarNumeroChamda])))
                    {
                        mensagenDeErro("data invalido");
                        goto volta3;
                    }
                    break;

            }
            mensagenDeSucesso("chamada editada com sucesso");
        }

        private static void registarNovaChamda(ref string[] nome,ref string[,] titulo,ref string[,] descricao,ref DateTime[,] dataAbertura)
        {
        volta:
            Console.WriteLine("qual o numero do equipamento para registar uma nova chamda?");
            if (!(int.TryParse(Console.ReadLine(), out int NumeroEquipamento)) || nome[NumeroEquipamento] == null)
            {
                mensagenDeErro("equipmaneto invalido ou nao existente");
                goto volta;
            }

            for (int i = 0; i < 1000; i++)
            {
                if (titulo[NumeroEquipamento, i] != null)
                    continue;
                Console.WriteLine("digite o tiulo da chamada");
                titulo[NumeroEquipamento, i] = Console.ReadLine();
                Console.WriteLine("digite a descricao da chamada");
                descricao[NumeroEquipamento, i] = Console.ReadLine();
            volta2:
                Console.WriteLine("digite a data da chamada");
                if (!(DateTime.TryParse(Console.ReadLine(), out dataAbertura[NumeroEquipamento, i])))
                {
                    mensagenDeErro("data invalido");
                    goto volta2;
                }
                mensagenDeSucesso("chamada registrado com sucesso");
                break;
            }
        }

        private static bool mostrarChamadas(ref string[] nome,ref bool existeChamada,ref string[,] titulo,ref string[,] descricao,ref DateTime[,] dataAbertura)
        {
            for (int i = 0; i < 1000; i++)
            {
                existeChamada = false;
                if (nome[i] == null)
                    continue;
                Console.WriteLine($"equipmaneto numero: {i}\n");
                for (int z = 0; z < 1000; z++)
                {
                    if (titulo[i, z] == null)
                        continue;

                    existeChamada = true;
                    Console.WriteLine($"numero da chamda : {z}\n" +
                        $"Titulo: {titulo[i, z]}\n" +
                        $"Descricao: {descricao[i, z]}\n" +
                        $"Data de abertura: {dataAbertura[i, z].ToShortDateString()}\n" +
                        $"dias desde o inicio da abertura {(DateTime.Now - dataAbertura[i, z]).Days}\n");
                }
                if (existeChamada == false)
                    Console.WriteLine("não há chamada\n");

            }
            Console.ReadKey();
            return existeChamada;
        }

        private static void removerEquipmaneto(string[,] titulo,ref string[] nome,ref decimal[] preco,ref string[] numeroSerie,ref DateTime[] dataFabricacao,ref string[] fabricante)
        {
        volta:
            Console.WriteLine("qual o numero do equipamento que deseja remover?");

            if (!(int.TryParse(Console.ReadLine(), out int removerNumero)))
            {
                mensagenDeErro("equipamento invalido ou nao existente");
                goto volta;
            }
            for (int i = 0; i < 1000; i++)
            {
                if(titulo[removerNumero,i] != null)
                {
                    mensagenDeErro("equipamento contem chamadas");
                    goto fim;
                }
            }
            nome[removerNumero] = default;
            preco[removerNumero] = default;
            numeroSerie[removerNumero] = default;
            dataFabricacao[removerNumero] = default;
            fabricante[removerNumero] = default;
            mensagenDeSucesso("item removido com sucesso");
        fim:;
        }

        private static void editarEquipamento(ref string[] nome, ref decimal[] preco,ref string[] numeroSerie,ref  DateTime[] dataFabricacao,ref string[] fabricante)
        {
        volta:
            Console.WriteLine("qual o numero do equipamento que deseja alterar?");
            if (!(int.TryParse(Console.ReadLine(), out int alterarNumero)))
            {
                mensagenDeErro("equipamento invalido ou nao existente");
                goto volta;
            }
        volta5:
            Console.WriteLine("o que deseja alterar?\n" +
                "1 = nome\n" +
                "2 = preco\n" +
                "3 = numero da serie\n" +
                "4 = data de fabicação\n" +
                "5 = fabricante\n");
            if (!(int.TryParse(Console.ReadLine(), out int opcaoAlterar)))
            {
                mensagenDeErro("opção invalido ou nao existente");
                goto volta5;
            }

            switch (opcaoAlterar)
            {


                case 1:
                    volta4:
                    Console.WriteLine("digite o nome do equipamento");
                    nome[alterarNumero] = Console.ReadLine();
                    if (VerficarNome(nome[alterarNumero]))
                        goto volta4;
                    break;
                case 2:
                volta2:
                    Console.WriteLine("digite o preco do equipamento");
                    if (!(decimal.TryParse(Console.ReadLine(), out preco[alterarNumero])))
                    {
                        mensagenDeErro("preco invalido");
                        goto volta2;
                    }
                    break;
                case 3:
                    Console.WriteLine("digite o numero da serie do equipamento");
                    numeroSerie[alterarNumero] = Console.ReadLine();
                    break;
                case 4:
                volta3:
                    Console.WriteLine("digite a data de fabricacao do equipamento");
                    if (!(DateTime.TryParse(Console.ReadLine(), out dataFabricacao[alterarNumero])))
                    {
                        mensagenDeErro("data invalido");
                        goto volta3;
                    }
                    break;
                case 5:
                    Console.WriteLine("digite o fabricante");
                    fabricante[alterarNumero] = Console.ReadLine();
                    break;
            }
            mensagenDeSucesso("equipmaneto editado com sucesso");
        }

        private static void mensagenDeSucesso(string mensagen)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(mensagen);
            Console.ResetColor();
        }

        private static void registarEquipamento(ref string[] nome,ref decimal[] preco,ref string[] numeroSerie,ref DateTime[] dataFabricacao,ref string[] fabricante)
        {
            for (int i = 0; i < 1000; i++)
            {
                if (nome[i] == null)
                {
                    volta7:
                    Console.WriteLine("digite o nome do equipamento");
                    nome[i] = Console.ReadLine();
                    if (VerficarNome(nome[i]))
                        goto volta7;
                volta:
                    Console.WriteLine("digite o preco do equipamento");
                    if (!(decimal.TryParse(Console.ReadLine(), out preco[i])))
                    {
                        mensagenDeErro("preco invalido");
                        goto volta;
                    }
                    Console.WriteLine("digite o numero da serie do equipamento");
                    numeroSerie[i] = Console.ReadLine();
                volta2:
                    Console.WriteLine("digite a data de fabricacao do equipamento");
                    if (!(DateTime.TryParse(Console.ReadLine(), out dataFabricacao[i])))
                    {
                        mensagenDeErro("data invalido");
                        goto volta2;
                    }
                    Console.WriteLine("digite o fabricante");
                    fabricante[i] = Console.ReadLine();
                    break;
                }
            }
            mensagenDeSucesso("equipmaneto editado com sucesso");
        }

        private static bool VerficarNome(string nome)
        {
            if (nome.Length < 6)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("nome muito pequeno minimo 6 caracters");
                Console.ResetColor();
                return true;
            }
            return false;
        }

        private static void mostrarEquipamentos(string[] nome, decimal[] preco, string[] numeroSerie, DateTime[] dataFabricacao, string[] fabricante)
        {
            for (int i = 0; i < 1000; i++)
            {
                if (nome[i] == null)
                    continue;

                Console.WriteLine($"equipamento: {i}\n" +
                    $"Nome: {nome[i]}\n" +
                    $"Numero da serie: {numeroSerie[i]}\n" +
                    $"Fabricante: {fabricante[i]}\n");
            }
        }

        static int selecionarOpcao()
        {
        volta:
            Console.WriteLine("digite uma opção \n" +
                "1 = mostrar equipamentos\n" +
                "2 = registrar novo equipamento\n" +
                "3 = editar um equipamento\n" +
                "4 = deletar um eqipmaneto \n" +
                "5 = ver chamadas para equipamentos\n" +
                "6 = registrar uma nova chamda para um equipamento\n" +
                "7 = editar uma chamda de um equipamento\n" +
                "8 = excluir uma chamda de um equipamento\n" +
                "9 = sair");
            if (!(int.TryParse(Console.ReadLine(), out int opcao)))
            {
                mensagenDeErro("opção invalido ou nao existente");
                goto volta;
            }
            return opcao;
        }

        private static void mensagenDeErro(string mensagen)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensagen);
            Console.ReadKey();
            Console.ResetColor();
        }
    }
}
