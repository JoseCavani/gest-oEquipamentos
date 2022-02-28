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
            bool abertoOuFechado = true;
            int opcao = 0;
            bool existeChamada = false;

            string[,] titulo = new string[1000,1000];
            string[,] descricao = new string[1000, 1000];
            DateTime[,] dataAbertura = new DateTime[1000,1000];
            int[] solicitanteChamada = new int[1000];// motivo pelo qual o solicitante da chamda nao e 2D e porque essa variavel so ira armazena o ID associado ao nome no methodo ele chama o nome associado a esse id
            bool[,] chamdaAberto = new bool[1000,1000];

            string[] nomeSolicitante = new string[1000];
            string[] emailSolicitante = new string[1000];
            string[] telefoneSolicitante = new string[1000];
            #endregion

            #region valores

            nomeSolicitante[0] = "joão";
            emailSolicitante[0] = "joão@email.com";
            telefoneSolicitante[0] = "99999-888";

            nomeSolicitante[1] = "ivo";
            emailSolicitante[1] = "ivo@email.com";
            telefoneSolicitante[1] = "444444";


            nome[0] = "nome1";
            preco[0] = 1005;
            numeroSerie[0] = "abc123";
            dataFabricacao[0] = new DateTime(2022, 02, 02);
            fabricante[0] = "Fab1";

            titulo[0, 0] = "tit1";
            descricao[0, 0] = "desc1";
            dataAbertura[0, 0] = new DateTime(2022, 02, 02);
            solicitanteChamada[0] = 0;
            chamdaAberto[0, 0] = true;

            titulo[0, 1] = "tit2";
            descricao[0, 1] = "desc2";
            dataAbertura[0, 1] = new DateTime(2027, 02, 02);
            solicitanteChamada[0] = 0;
            chamdaAberto[0, 1] = false;

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
                        mostrarEquipamentos(nome, preco, numeroSerie, dataFabricacao, fabricante);
                        editarEquipamento(ref nome, ref preco,ref numeroSerie,ref dataFabricacao,ref fabricante);
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        mostrarEquipamentos(nome, preco, numeroSerie, dataFabricacao, fabricante);
                        removerEquipmaneto(chamdaAberto, titulo,ref nome,ref preco,ref numeroSerie,ref dataFabricacao,ref fabricante);
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        abertoOuFechado = abertoOuFechados(abertoOuFechado);
                        mostrarChamadas(abertoOuFechado, chamdaAberto, ref nome, ref existeChamada, ref titulo, ref descricao, ref dataAbertura, nomeSolicitante, solicitanteChamada);
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.Clear();
                        mostrarEquipamentos(nome, preco, numeroSerie, dataFabricacao, fabricante);
                        registarNovaChamda(ref chamdaAberto,ref nome,ref titulo,ref descricao,ref dataAbertura, nomeSolicitante,ref solicitanteChamada);
                        Console.ReadKey();
                        break;
                    case 7:
                        Console.Clear();
                        mostrarChamadas(true, chamdaAberto, ref nome, ref existeChamada, ref titulo, ref descricao, ref dataAbertura, nomeSolicitante, solicitanteChamada);
                        editarChamda(chamdaAberto,ref nome,ref titulo,ref descricao,ref dataAbertura,ref solicitanteChamada,nomeSolicitante);
                        Console.ReadKey();
                        break;
                    case 8:
                        Console.Clear();
                        mostrarChamadas(true, chamdaAberto, ref nome, ref existeChamada, ref titulo, ref descricao, ref dataAbertura, nomeSolicitante, solicitanteChamada);
                        excuilrChamada(ref chamdaAberto,nome,titulo);
                        Console.ReadKey();
                        break;
                    case 9:
                        Console.Clear();
                        mostrarSolicitante(nomeSolicitante, emailSolicitante, telefoneSolicitante);
                        Console.ReadKey();
                        break;
                    case 10:
                        Console.Clear();
                        registrarSolicitante(ref nomeSolicitante,ref emailSolicitante,ref telefoneSolicitante);
                        Console.ReadKey();
                        break;
                    case 11:
                        Console.Clear();
                        mostrarSolicitante(nomeSolicitante, emailSolicitante, telefoneSolicitante);
                        editarSolicitante(ref nomeSolicitante,ref emailSolicitante,ref telefoneSolicitante);
                        Console.ReadKey();
                        break;
                    case 12:
                        Console.Clear();
                        mostrarSolicitante(nomeSolicitante, emailSolicitante, telefoneSolicitante);
                        removerSolicitante(nomeSolicitante, emailSolicitante, telefoneSolicitante);
                        Console.ReadKey();
                        break;
                    case 13:
                        Console.Clear();
                        maquinasNumeroProblemas(nome, titulo);
                        break;
                    case 14:
                        goto fim;
                }
            }
        fim:;
        }

        private static bool abertoOuFechados(bool abertoOuFechado)
        {
        volta:
            Console.WriteLine("gostaria de ver as chamdas 0 = abertas ou 1 = fechadas");
            if (!(int.TryParse(Console.ReadLine(), out int opcaoChamda)) || opcaoChamda < 0 || opcaoChamda > 1)
            {
                mensagenDeErro("opcao invalido");
                goto volta;
            }
            if (opcaoChamda == 0)
                abertoOuFechado = true;
            else
                abertoOuFechado = false;
            return abertoOuFechado;
        }

        private static void maquinasNumeroProblemas(string[] nome, string[,] titulo)
        {
            int contador = 1;// valor default de um int[] e 0 então fiz isso para que possa mostrar todos os equipamentos independte se tem ou nao chamdados
            int[] qunatidadeChamadas = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                if (nome[i] == null)
                    continue;
                else
                    for (int z = 0; z < 1000; z++)
                    {
                        if (titulo[i, z] == null)
                            continue;
                        else
                            contador++;
                    }
                qunatidadeChamadas[i] = contador;
                contador = 1;
            }
            Array.Sort(qunatidadeChamadas);
            Array.Reverse(qunatidadeChamadas);
            for (int i = 0; i < qunatidadeChamadas.Length; i++)
            {
                if (qunatidadeChamadas[i] != 0)
                    Console.WriteLine($"maquina : {i} contem : {qunatidadeChamadas[i] - 1} chamdas");//{qunatidadeChamadas[i] - 1} pq inicializei com um
            }
            Console.ReadKey();
        }

        private static void removerSolicitante(string[] nomeSolicitante, string[] emailSolicitante, string[] telefoneSolicitante)
        {
        volta:
            Console.WriteLine("qual o numero do solicitante que deseja excluir?");

            if (!(int.TryParse(Console.ReadLine(), out int removerNumero)))
            {
                mensagenDeErro("solicitante invalido ou nao existente");
                goto volta;
            }

            nomeSolicitante[removerNumero] = default;
            emailSolicitante[removerNumero] = default;
            telefoneSolicitante[removerNumero] = default;
            mensagenDeSucesso("solicitante removido com sucesso");
        }

        private static void editarSolicitante(ref string[] nomeSolicitante,ref string[] emailSolicitante,ref string[] telefoneSolicitante)
        {
        volta:
            Console.WriteLine("qual o id do solicitante que deseja alterar?");
            if (!(int.TryParse(Console.ReadLine(), out int alterarNumero)))
            {
                mensagenDeErro("solicitante invalido ou nao existente");
                goto volta;
            }
        volta5:
            Console.WriteLine("o que deseja alterar?\n" +
                "1 = nome\n" +
                "2 = email\n" +
                "3 = telefone\n");
            if (!(int.TryParse(Console.ReadLine(), out int opcaoAlterar)))
            {
                mensagenDeErro("opção invalido ou nao existente");
                goto volta5;
            }

            switch (opcaoAlterar)
            {


                case 1:
                volta4:
                    Console.WriteLine("digite o nome do solicitante");
                    nomeSolicitante[alterarNumero] = Console.ReadLine();
                    if (VerficarNome(nomeSolicitante[alterarNumero]))
                        goto volta4;
                    break;
                case 2:
                    Console.WriteLine("digite o email do solicitante");
                    emailSolicitante[alterarNumero] = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("digite o telefone do solicitante");
                    telefoneSolicitante[alterarNumero] = Console.ReadLine();
                    break;
            }
            mensagenDeSucesso("solicitante editado com sucesso");
        }

        private static void registrarSolicitante(ref string[] nomeSolicitante,ref string[] emailSolicitante,ref string[] telefoneSolicitante)
        {
            for (int i = 0; i < 1000; i++)
            {
                if (nomeSolicitante[i] == null)
                {
                volta7:
                    Console.WriteLine("digite o nome do solicitante");
                    nomeSolicitante[i] = Console.ReadLine();
                    if (VerficarNome(nomeSolicitante[i]))
                        goto volta7;

                    Console.WriteLine("digite o email do solicitante");
                    emailSolicitante[i] = Console.ReadLine();

                    Console.WriteLine("digite o telefone do solicitante");
                    telefoneSolicitante[i] = Console.ReadLine();
                    mensagenDeSucesso("solicitante registrado com successo");
                    break;
                }
            }
        }

        private static void mostrarSolicitante(string[] nomeSolicitante, string[] emailSolicitante, string[] telefoneSolicitante)
        {
            for (int i = 0; i < 1000; i++)
            {
                if (nomeSolicitante[i] == null)
                    continue;
                Console.WriteLine($"id : {i}\n" +
                    $"nome do solicitante : {nomeSolicitante[i]}\n" +
                    $"email do solicitante : {emailSolicitante[i]}\n" +
                    $"telefone do solicitante : {telefoneSolicitante[i]}\n");

            }
        }

        private static void excuilrChamada(ref bool[,] chamdaAberto, string[] nome, string[,] titulo)
        {
        volta:
            Console.WriteLine("qual o numero do equipamento com a chamda ao qual quer exluir");
            if (!(int.TryParse(Console.ReadLine(), out int alterarNumero)) || nome[alterarNumero] == null)
            {
                mensagenDeErro("numero invalido ou nao existente");
                goto volta;
            }
            bool haChamada = veSeHaChamada(alterarNumero, titulo, chamdaAberto);

            if (haChamada == false)
            {
                mensagenDeErro("não ha chamdas para esse equipamento");
                goto fim;
            }
        volta2:
            Console.WriteLine("qual a chamda que deseja excluir?");
            if (!(int.TryParse(Console.ReadLine(), out int alterarNumeroChamda)) || chamdaAberto[alterarNumero, alterarNumeroChamda] == false)
            {
                mensagenDeErro("chamdad invalido ou nao existente");
                goto volta2;
            }

            chamdaAberto[alterarNumero, alterarNumeroChamda] = false;
            mensagenDeSucesso("chamda excluida com sucesso");
        fim:;
        }

        private static void editarChamda(bool[,] chamdaAberto,ref string[] nome,ref string[,] titulo,ref string[,] descricao,ref DateTime[,] dataAbertura,ref int[] solicitanteChamada,string[] nomeSolicitante)
        {
        volta:
            Console.WriteLine("qual o numero do equipamento com a chamda ao qual quer editar");
            if (!(int.TryParse(Console.ReadLine(), out int alterarNumero)) || nome[alterarNumero] == null)
            {
                mensagenDeErro("equipamento invalido ou nao existente");
                goto volta;
            }
            bool haChamada = veSeHaChamada(alterarNumero, titulo, chamdaAberto);

            if (haChamada == false)
            {
                mensagenDeErro("não ha chamadas para esse equipamento");
                goto fim;
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
                "3 = data de abertura\n" +
                "4 = solicitante");
            if (!(int.TryParse(Console.ReadLine(), out int opcaoAlterar)) || opcaoAlterar > 4 || opcaoAlterar < 1)
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
                case 4:
                    for (int z = 0; z < 1000; z++)
                    {
                        if (nomeSolicitante[z] == null)
                            continue;
                        Console.WriteLine($"{z} = {nomeSolicitante[z]}");
                    }
                volta4:
                    Console.WriteLine("digite o ID do solicitante da chamada\n");
                    if (!(int.TryParse(Console.ReadLine(), out solicitanteChamada[alterarNumeroChamda])))
                    {
                        mensagenDeErro("solicitante invalido");
                        goto volta4;
                    }
                    break;
            }
            mensagenDeSucesso("chamada editada com sucesso");
        fim:;
        }

        private static bool veSeHaChamada(int alterarNumero, string[,] titulo, bool[,] chamadaAberto)
        {
            bool haChamada = false;

       
                for (int z = 0; z < 1000; z++)
                {

                    if (titulo[alterarNumero, z] != null && chamadaAberto[alterarNumero, z] == true)
                        haChamada = true;
                }
            

            return haChamada;
        }

        private static void registarNovaChamda(ref bool[,] chamadaAberto,ref string[] nome,ref string[,] titulo,ref string[,] descricao,ref DateTime[,] dataAbertura,string[] nomeSolicitante,ref int[] solicitanteChamada)
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

                for (int z = 0; z < 1000; z++)
                {
                    if (nomeSolicitante[z] == null)
                        continue;
                    Console.WriteLine($"{z} = {nomeSolicitante[z]}");
                }
            volta3:
                Console.WriteLine("digite o solicitante da chamada\n");
                if (!(int.TryParse(Console.ReadLine(), out solicitanteChamada[i])))
                {
                    mensagenDeErro("solicitante invalido");
                    goto volta3;
                }
                chamadaAberto[NumeroEquipamento, i] = true;
                mensagenDeSucesso("chamada registrado com sucesso");
                break;
            }
        }

        private static void mostrarChamadas(bool abertoOuFechado,bool[,] abertoChamda, ref string[] nome,ref bool existeChamada,ref string[,] titulo,ref string[,] descricao,ref DateTime[,] dataAbertura,string[] nomeSolicitante,int[] solicitanteChamada)
        {
          
            for (int i = 0; i < 1000; i++)
            {
                existeChamada = false;
                if (nome[i] == null)
                    continue;
                for (int z = 0; z < 1000; z++)
                {
                    if (titulo[i,z] == null || abertoChamda[i,z] != abertoOuFechado)
                        continue;

                    existeChamada = true;
                    Console.WriteLine($"equipamento: {i}\n" +
                        $"numero da chamda : {z}\n" +
                        $"Titulo: {titulo[i, z]}\n" +
                        $"Descricao: {descricao[i, z]}\n" +
                        $"Data de abertura: {dataAbertura[i, z].ToShortDateString()}\n" +
                        $"dias desde o inicio da abertura {(DateTime.Now - dataAbertura[i, z]).Days}\n" +
                        $"solicitante da chamda {nomeSolicitante[solicitanteChamada[z]]}\n");
                }
                if (existeChamada == false)
                    Console.WriteLine($"não há chamada para o equipamento {i}\n");

            }
        }

        private static void removerEquipmaneto(bool[,] chamdaAberto, string[,] titulo,ref string[] nome,ref decimal[] preco,ref string[] numeroSerie,ref DateTime[] dataFabricacao,ref string[] fabricante)
        {
            bool haEquipamento = veSeHaEquipamento(nome);

            if (haEquipamento == false)
            {
                mensagenDeErro("não ha equipamentos");
                goto fim;
            }
        volta:
            Console.WriteLine("qual o numero do equipamento que deseja remover?");

            if (!(int.TryParse(Console.ReadLine(), out int removerNumero)) || nome[removerNumero] == null)
            {
                mensagenDeErro("equipamento invalido ou nao existente");
                goto volta;
            }

            for (int i = 0; i < 1000; i++)
            {
                if(chamdaAberto[removerNumero,i] == true)
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
            bool haEquipamento = veSeHaEquipamento(nome);

            if (haEquipamento == false)
            {
                mensagenDeErro("não ha equipamentos");
                goto fim;
            }
        volta:
            Console.WriteLine("qual o numero do equipamento que deseja alterar?");
            if (!(int.TryParse(Console.ReadLine(), out int alterarNumero)) || nome[alterarNumero] == null)
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
        fim:;
        }

        private static bool veSeHaEquipamento(string[] nome)
        {
            bool haEquipamento = false;
            foreach (var item in nome)
            {
                if (item != null)
                    haEquipamento = true;
            }

            return haEquipamento;
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
                "9 = mostrar solicitantes\n" +
                "10 = registar novo solicitante\n" +
                "11 = editar um solicitante\n" +
                "12 = excluir um solicitante\n" +
                "13 = numero de chamdas por maquina\n" +
                "14 = sair");
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
