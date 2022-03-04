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
            string opcao = "";
            bool existeChamada = false;

            string[,] titulo = new string[1000,1000];
            string[,] descricao = new string[1000, 1000];
            DateTime[,] dataAbertura = new DateTime[1000,1000];
            bool[,] chamdaAberto = new bool[1000,1000];
            int[] solicitanteChamada = new int[1000];// motivo pelo qual o solicitante da chamda nao e 2D e porque essa variavel so ira armazena o ID associado ao nome no methodo ele chama o nome associado a esse id


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

            titulo[1, 0] = "tit3";
            descricao[1, 0] = "desc3";
            dataAbertura[1, 0] = new DateTime(2027, 02, 02);
            solicitanteChamada[0] = 0;
            chamdaAberto[1, 0] = true;

            titulo[1, 1] = "tit4";
            descricao[1, 1] = "desc4";
            dataAbertura[1, 1] = new DateTime(2027, 02, 02);
            solicitanteChamada[1] = 0;
            chamdaAberto[1, 1] = true;

            titulo[1, 2] = "tit5";
            descricao[1, 2] = "desc5";
            dataAbertura[1, 2] = new DateTime(2027, 02, 02);
            solicitanteChamada[2] = 0;
            chamdaAberto[1, 2] = true;


            nome[1] = "nome2";
            preco[1] = 1995;
            numeroSerie[1] = "abc1563";
            dataFabricacao[1] = new DateTime(2025, 02, 02);
            fabricante[1] = "Fab5";

            #endregion

            while (true)
            {
                Console.Clear();
                opcao = selecionarOpcao("Digite uma opção \n" +
                "1 - Equipamentos\n" +
                "2 - Chamadas\n" +
                "3 - Solicitantes\n" +
                "4 - Maquinas com maiores problemas\n" +
                "s - Sair");

                switch (opcao)
                {
                    case "1":
                        Console.Clear();
                        opcao = selecionarOpcao("Digite uma opção \n" +
              "1 - Mostrar equipamentos\n" +
              "2 - Registar equipamentos\n" +
              "3 - Editar equipamentos\n" +
              "4 - Excluir equipmanetos\n" +
              "s - Voltar");
                        switch (opcao)
                        {
                            case "1":
                                Console.Clear();
                                mostrarEquipamentos(nome, preco, numeroSerie, dataFabricacao, fabricante);
                                Console.ReadKey();
                                break;
                            case "2":
                                Console.Clear();
                                registarEquipamento(ref nome, ref preco, ref numeroSerie, ref dataFabricacao, ref fabricante);
                                Console.ReadKey();
                                break;
                            case "3":
                                Console.Clear();
                                editarEquipamento(ref nome, ref preco, ref numeroSerie, ref dataFabricacao, ref fabricante);
                                break;
                            case "4":
                                Console.Clear();
                                removerEquipmaneto(chamdaAberto, titulo, ref nome, ref preco, ref numeroSerie, ref dataFabricacao, ref fabricante);
                                break;
                            case "s":
                                break;
                            default:
                                mensagenDeErro("Numero invalido");
                                Console.ReadKey();
                                break;
                        }
                        break;


                    case "2":
                        Console.Clear();
                        opcao = selecionarOpcao("Digite uma opção \n" +
              "1 - Mostrar chamadas\n" +
              "2 - Registar nova chamda\n" +
              "3 - Editar chamada\n" +
              "4 - Excluir chamda\n" +
              "5 - Encerrar chamado\n" +
              "s - Voltar");
                        switch (opcao)
                        {
                            case "1":
                                Console.Clear();
                                abertoOuFechado = abertoOuFechados(abertoOuFechado);
                                mostrarChamadas(abertoOuFechado, chamdaAberto, nome, existeChamada, titulo, descricao, dataAbertura, nomeSolicitante, solicitanteChamada);
                                Console.ReadKey();
                                break;
                            case "2":
                                Console.Clear();
                                registarNovaChamda(fabricante, dataFabricacao, numeroSerie, preco, ref chamdaAberto, ref nome, ref titulo, ref descricao, ref dataAbertura, nomeSolicitante, ref solicitanteChamada);
                                Console.ReadKey();
                                break;
                            case "3":
                                Console.Clear();
                                editarChamda(ref existeChamada, chamdaAberto, ref nome, ref titulo, ref descricao, ref dataAbertura, ref solicitanteChamada, nomeSolicitante);
                                break;
                            case "4":
                                Console.Clear();
                                removerChamada(solicitanteChamada, nomeSolicitante, dataAbertura,descricao, existeChamada,ref chamdaAberto, nome, titulo);
                                break;
                            case "5":
                                encerarChamda(nome, existeChamada, titulo, descricao, dataAbertura, chamdaAberto, solicitanteChamada, nomeSolicitante);
                                break;
                            case "s":
                                break;
                            default:
                                mensagenDeErro("Numero invalido");
                                Console.ReadKey();
                                break;
                        }

                        break;

                    case "3":
                        Console.Clear();
                        opcao = selecionarOpcao("Digite uma opção \n" +
              "1 - Mostrar solicitante\n" +
              "2 - Registar novo solicitante\n" +
              "3 - Editar solicitante\n" +
              "4 - Excluir solicitante\n" +
              "s - Voltar");
                        switch (opcao)
                        {
                            case "1":
                                Console.Clear();
                                mostrarSolicitante(nomeSolicitante, emailSolicitante, telefoneSolicitante);
                                Console.ReadKey();
                                break;
                            case "2":
                                Console.Clear();
                                registrarSolicitante(ref nomeSolicitante, ref emailSolicitante, ref telefoneSolicitante);
                                Console.ReadKey();
                                break;
                            case "3":
                                Console.Clear();
                                editarSolicitante(ref nomeSolicitante, ref emailSolicitante, ref telefoneSolicitante);
                                break;
                            case "4":
                                Console.Clear();
                                removerSolicitante(nomeSolicitante, emailSolicitante, telefoneSolicitante);
                                break;
                            case "s":
                                break;
                            default:
                                mensagenDeErro("Numero invalido");
                                Console.ReadKey();
                                break;
                        }
                        break;
                    case "4":
                        Console.Clear();
                        maquinasNumeroProblemas(nome, titulo);
                        break;
                    case "s":
                        goto fim;
                    default:
                        mensagenDeErro("Numero invalido");
                        Console.ReadKey();
                        break;
                }
            }
        fim:;
        }

        private static void encerarChamda(string[] nome, bool existeChamada, string[,] titulo, string[,] descricao, DateTime[,] dataAbertura, bool[,] chamdaAberto, int[] solicitanteChamada, string[] nomeSolicitante)
        {
            while (true)
            {
                bool haEquipamento = veSeHaEquipamento(nome);

                if (haEquipamento == false)
                {
                    mensagenDeErro("não ha equipamento");
                    Console.ReadKey();
                    goto fim;
                }
              bool haChamda =  mostrarChamadas(true, chamdaAberto, nome, existeChamada, titulo, descricao, dataAbertura, nomeSolicitante, solicitanteChamada);
                if(haChamda == false)
                {
                    mensagenDeErro("nao existem chamadas para encerrar");
                    Console.ReadKey();
                    goto fim;
                }
            volta:
                Console.WriteLine("qual o numero do equipamento com a chamda ao qual quer encerrar\n" +
                    "para voltar ao menu principal digite s");
                string numeroEquipamento = Console.ReadLine().ToLower();
                if (!(int.TryParse(numeroEquipamento, out int alterarNumero)) || nome[alterarNumero] == null)
                {
                    if (numeroEquipamento == "s")
                    {
                        goto fim;
                    }
                    mensagenDeErro("numero invalido ou nao existente");
                    goto volta;
                }
                bool haChamada = veSeHaChamada("aberta",alterarNumero, titulo, chamdaAberto);

                if (haChamada == false)
                {
                    mensagenDeErro("não ha chamdas para esse equipamento");
                    goto volta;
                }
            volta2:
                Console.WriteLine("qual a chamda que deseja encerrar?\n" +
                    "para voltar ao menu principal digite s");
                string numeroChamda = Console.ReadLine().ToLower();
                if (!(int.TryParse(numeroChamda, out int alterarNumeroChamda)) || chamdaAberto[alterarNumero, alterarNumeroChamda] == false)
                {
                    if (numeroChamda == "s")
                    {
                        goto fim;
                    }
                    mensagenDeErro("chamdad invalido ou nao existente");
                    goto volta2;
                }

                if (chamdaAberto[alterarNumero, alterarNumeroChamda] == true)
                {
                    chamdaAberto[alterarNumero, alterarNumeroChamda] = false;
                    mensagenDeSucesso("chamda encerrada com sucesso");
                }
                else
                    mensagenDeErro("chamada ja esta fechada");
                Console.ReadKey();
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
                if (nome[i] == null) //1
                    continue;
                else
                    for (int z = 0; z < 1000; z++)
                    {
                        if (titulo[i, z] == null)
                            continue;
                        else
                            contador++; //3
                    }
                //1                         3
                qunatidadeChamadas[i] = contador;
                contador = 1;
            }
            Array.Sort(qunatidadeChamadas, nome);
            for (int i = qunatidadeChamadas.Length - 1; i >= 0; i--)
            {
                if (qunatidadeChamadas[i] != 0)
                    Console.WriteLine($"maquina : {nome[i]} contem : {qunatidadeChamadas[i] - 1} chamdas");//{qunatidadeChamadas[i] - 1} pq inicializei com um
            }
            Console.ReadKey();
        }

        private static void removerSolicitante(string[] nomeSolicitante, string[] emailSolicitante, string[] telefoneSolicitante)
        {
           
            while (true)
            {
                bool haSolicitante = haSolicitantes(nomeSolicitante);
                if (haSolicitante == false)
                {
                    mensagenDeErro("nao existe solicitante");
                    Console.ReadKey();
                    goto fim;
                }
                mostrarSolicitante(nomeSolicitante, emailSolicitante, telefoneSolicitante);
            volta:
                Console.WriteLine("qual o numero do solicitante que deseja excluir?" +
                    "para voltar ao menu principal digite s");
                string numeroSolicitante = Console.ReadLine();
                if (!(int.TryParse(numeroSolicitante, out int removerNumero)))
                {
                    if (numeroSolicitante == "s")
                    {
                        goto fim;
                    }
                    mensagenDeErro("solicitante invalido ou nao existente");
                    goto volta;
                }
                nomeSolicitante[removerNumero] = default;
                emailSolicitante[removerNumero] = default;
                telefoneSolicitante[removerNumero] = default;
                mensagenDeSucesso("solicitante removido com sucesso");
                Console.ReadKey();
            }
        fim:;
        }

        private static bool haSolicitantes(string[] nomeSolicitante)
        {
            bool haSolicitante = false;
            foreach (var item in nomeSolicitante)
            {
                if (item != null)
                {
                    haSolicitante = true;
                    break;
                }
            }

            return haSolicitante;
        }

        private static void editarSolicitante(ref string[] nomeSolicitante,ref string[] emailSolicitante,ref string[] telefoneSolicitante)
        {
            bool haSolicitante = haSolicitantes(nomeSolicitante);
            if (haSolicitante == false)
            {
                mensagenDeErro("nao existe solicitante");
                Console.ReadKey();
                goto fim;
            }
            while(true){
                mostrarSolicitante(nomeSolicitante, emailSolicitante, telefoneSolicitante);

            volta:
                Console.WriteLine("qual o id do solicitante que deseja alterar?\n" +
                    "para voltar ao menu principal digite s");
                string numeroEquipamento = Console.ReadLine();
                if (!(int.TryParse(numeroEquipamento, out int alterarNumero)) || nomeSolicitante[alterarNumero] == null)
                {
                    if(numeroEquipamento == "s")
                    {
                        goto fim;
                    }
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
                Console.ReadKey();
            }
            fim:;
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
                    volta:
                    Console.WriteLine("digite o email do solicitante");
                    emailSolicitante[i] = Console.ReadLine();
                    if (emailSolicitante[i] == "")
                    {
                        mensagenDeErro("email nao poder ser vazio");
                        goto volta;
                    }
                    volta2:
                    Console.WriteLine("digite o telefone do solicitante");
                    telefoneSolicitante[i] = Console.ReadLine();
                    if (telefoneSolicitante[i] == "" || telefoneSolicitante[i].Trim().Length < 9)
                    {
                        mensagenDeErro("email nao poder ser vazio");
                        goto volta2;
                    }

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

        private static void removerChamada(int[] solicitanteChamada, string[] nomeSolicitante, DateTime[,] dataAbertura, string[,] descricao,bool existeChamada,ref bool[,] chamdaAberto, string[] nome, string[,] titulo)
        {
            
            while (true){
                bool haEquipamento = veSeHaEquipamento(nome);

                if (haEquipamento == false)
                {
                    mensagenDeErro("não ha equipamento");
                    Console.ReadKey();
                    goto fim;
                }
               bool haChamado = mostrarChamadas(false, chamdaAberto, nome, existeChamada, titulo, descricao, dataAbertura, nomeSolicitante, solicitanteChamada);
                if (haChamado == false)
                {
                    mensagenDeErro("nao existem chamadas para remover");
                    goto fim;
                }
            volta:
                Console.WriteLine("qual o numero do equipamento com a chamda ao qual quer exluir\n" +
                    "para voltar ao menu principal digite s");
                string numeroEquipamento = Console.ReadLine().ToLower();
                if (!(int.TryParse(numeroEquipamento, out int alterarNumero)) || nome[alterarNumero] == null)
                {
                    if(numeroEquipamento == "s")
                    {
                        goto fim;
                    }
                    mensagenDeErro("numero invalido ou nao existente");
                    goto volta;
                }
                bool haChamada = veSeHaChamada("fechado",alterarNumero, titulo, chamdaAberto);

                if (haChamada == false)
                {
                    mensagenDeErro("não ha chamdas para esse equipamento");
                    goto volta;
                }
            volta2:
                Console.WriteLine("qual a chamda que deseja excluir?\n" +
                    "para voltar ao menu principal digite s");
                string numeroChamda = Console.ReadLine().ToLower();
                if (!(int.TryParse(numeroChamda, out int alterarNumeroChamda)))
                {
                    if(numeroChamda == "s")
                    {
                        goto fim;
                    }
                    mensagenDeErro("chamdad invalido ou nao existente");
                    goto volta2;
                }

                if (chamdaAberto[alterarNumero, alterarNumeroChamda] == false)
                {
                    mensagenDeSucesso("chamda excluida com sucesso");
                    titulo[alterarNumero, alterarNumeroChamda] = default;
                    descricao[alterarNumero, alterarNumeroChamda] = default;
                    dataAbertura[alterarNumero, alterarNumeroChamda] = default;
                    solicitanteChamada[alterarNumeroChamda] = default;
                }
                else
                    mensagenDeErro("nao pode excluir uma chamda aberta");
                Console.ReadKey();
            }
        fim:;
        }

        private static void editarChamda(ref bool existeChamada,bool[,] chamdaAberto,ref string[] nome,ref string[,] titulo,ref string[,] descricao,ref DateTime[,] dataAbertura,ref int[] solicitanteChamada,string[] nomeSolicitante)
        {
            while (true)
            {
                bool haEquipamento = veSeHaEquipamento(nome);

                if (haEquipamento == false)
                {
                    mensagenDeErro("não ha equipamento");
                    Console.ReadKey();
                    goto fim;
                }
                bool haChamada = mostrarChamadas(true, chamdaAberto, nome, existeChamada, titulo, descricao, dataAbertura, nomeSolicitante, solicitanteChamada);
                if (haChamada == false)
                {
                    mensagenDeErro("nao existem chamadas para editar");
                    goto fim;
                }
            volta:
                Console.WriteLine("qual o numero do equipamento com a chamda ao qual quer editar\n" +
                    "digite s para sair");
                string equipamentoNumero = Console.ReadLine().ToLower();
                if (!(int.TryParse(equipamentoNumero, out int alterarNumero)) || nome[alterarNumero] == null)
                {
                    if(equipamentoNumero == "s")
                    {
                        goto fim;
                    }
                    mensagenDeErro("equipamento invalido ou nao existente");
                    goto volta;
                }
                bool haChamado = veSeHaChamada("aberta",alterarNumero, titulo, chamdaAberto);

                if (haChamado == false)
                {
                    mensagenDeErro("não ha chamadas para esse equipamento");
                    goto volta;
                }
            volta2:
                Console.WriteLine("qual a chamda que deseja alterar?\n" +
                    "digite s para sair");
                string numeroChamada = Console.ReadLine().ToLower();
                if (!(int.TryParse(numeroChamada, out int alterarNumeroChamda)) || titulo[alterarNumero, alterarNumeroChamda] == null)
                {
                    if (numeroChamada == "s")
                    {
                        goto fim;
                    }

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
                        volta6:
                        Console.WriteLine("digite o tiulo da chamada");
                        titulo[alterarNumero, alterarNumeroChamda] = Console.ReadLine();
                        if (titulo[alterarNumero, alterarNumeroChamda] == "")
                        {
                            mensagenDeErro("titulo nao poder ser vazio");
                            goto volta6;
                        }
                        break;
                    case 2:
                        volta7:
                        Console.WriteLine("digite a descricao da chamada");
                        descricao[alterarNumero, alterarNumeroChamda] = Console.ReadLine();
                        if (descricao[alterarNumero, alterarNumeroChamda] == "")
                        {
                            mensagenDeErro("descrição nao poder ser vazio");
                            goto volta7;
                        }
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
                Console.ReadKey();
            }
        fim:;
        }

        private static bool veSeHaChamada(string chamadaAberta,int alterarNumero, string[,] titulo, bool[,] chamadaAberto)
        {
            bool haChamada = false;


            for (int z = 0; z < 1000; z++)
            {
                switch (chamadaAberta) {
                    case "aberta":
                    if (titulo[alterarNumero, z] != null && chamadaAberto[alterarNumero, z] == true)
                    haChamada = true;
                        break;
                    case "fechado":
                        if (titulo[alterarNumero, z] != null && chamadaAberto[alterarNumero, z] == false)
                            haChamada = true;
                        break;
                             }
                }
            

            return haChamada;
        }

        private static void registarNovaChamda(string[] fabricante,DateTime[] dataFabricacao, string[] numeroSerie,decimal[] preco,ref bool[,] chamadaAberto,ref string[] nome,ref string[,] titulo,ref string[,] descricao,ref DateTime[,] dataAbertura,string[] nomeSolicitante,ref int[] solicitanteChamada)
        {
            mostrarEquipamentos(nome, preco, numeroSerie, dataFabricacao, fabricante);


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
                volta4:
                Console.WriteLine("digite o tiulo da chamada");
                titulo[NumeroEquipamento, i] = Console.ReadLine();
                if (titulo[NumeroEquipamento, i] == "")
                {
                    mensagenDeErro("titulo nao poder ser vazio");
                    goto volta4;
                }
                volta5:
                Console.WriteLine("digite a descricao da chamada");
                descricao[NumeroEquipamento, i] = Console.ReadLine();
                if (descricao[NumeroEquipamento, i] == "")
                {
                    mensagenDeErro("descrição nao poder ser vazio");
                    goto volta5;
                }
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
                if (nomeSolicitante[solicitanteChamada[i]] == default)
                {
                    mensagenDeErro("solicitante nao existe");
                    goto volta3;
                }
                chamadaAberto[NumeroEquipamento, i] = true;
                mensagenDeSucesso("chamada registrado com sucesso");
                break;
            }
        }

        private static bool mostrarChamadas(bool abertoOuFechado,bool[,] abertoChamda, string[] nome, bool existeChamada, string[,] titulo, string[,] descricao, DateTime[,] dataAbertura,string[] nomeSolicitante,int[] solicitanteChamada)
        {
            bool haChamada = false;
            for (int i = 0; i < 1000; i++)
            {
                existeChamada = false;
                if (nome[i] == null)
                    continue;
                for (int z = 0; z < 1000; z++)
                {
                    if (titulo[i,z] == null || abertoChamda[i,z] != abertoOuFechado)
                        continue;
                    haChamada = true;
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
            return haChamada;
        }

        private static void removerEquipmaneto(bool[,] chamdaAberto, string[,] titulo,ref string[] nome,ref decimal[] preco,ref string[] numeroSerie,ref DateTime[] dataFabricacao,ref string[] fabricante)
        {
            while (true)
            {
                bool haEquipamento = veSeHaEquipamento(nome);

                if (haEquipamento == false)
                {
                    mensagenDeErro("não ha equipamentos");
                    Console.ReadKey();
                    goto fim;
                }
                mostrarEquipamentos(nome, preco, numeroSerie, dataFabricacao, fabricante);
            volta:
                Console.WriteLine("qual o numero do equipamento que deseja remover?\n" +
                    "caso queira voltar ao menu digite s");
                string numeroEquipamento = Console.ReadLine().ToLower();
                if (!(int.TryParse(numeroEquipamento, out int removerNumero)) || nome[removerNumero] == null)
                {
                    if (numeroEquipamento == "s")
                    {
                        goto fim;
                    }
                    mensagenDeErro("equipamento invalido ou nao existente");
                    goto volta;
                }

                for (int i = 0; i < 1000; i++)
                {
                    if (chamdaAberto[removerNumero, i] == true)
                    {
                        mensagenDeErro("equipamento contem chamadas");
                        goto volta;
                    }
                }
                nome[removerNumero] = default;
                preco[removerNumero] = default;
                numeroSerie[removerNumero] = default;
                dataFabricacao[removerNumero] = default;
                fabricante[removerNumero] = default;
                mensagenDeSucesso("item removido com sucesso");
                Console.ReadKey();
            }
        fim:;
        }

        private static void editarEquipamento(ref string[] nome, ref decimal[] preco,ref string[] numeroSerie,ref  DateTime[] dataFabricacao,ref string[] fabricante)
        {
            bool haEquipamento = veSeHaEquipamento(nome);

            if (haEquipamento == false)
            {
                mensagenDeErro("não ha equipamentos");
                Console.ReadKey();
                goto fim;
            }
            while (true)
            {
                mostrarEquipamentos(nome, preco, numeroSerie, dataFabricacao, fabricante);
            volta:
                Console.WriteLine("qual o numero do equipamento que deseja alterar?\n" +
                    "caso queira voltar ao menu original digite s");
                string numeroEquipamento = Console.ReadLine().ToLower();
                if (!(int.TryParse(numeroEquipamento, out int alterarNumero)) || nome[alterarNumero] == null)
                {
                    if (numeroEquipamento == "s")
                    {
                        goto fim;
                    }
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
                        if (!(decimal.TryParse(Console.ReadLine(), out preco[alterarNumero])) || preco[alterarNumero] < 1)
                        {
                            mensagenDeErro("preco invalido");
                            goto volta2;
                        }
                        break;
                    case 3:
                    volta6:
                        Console.WriteLine("digite o numero da serie do equipamento");
                        string numeroSerieNovo = Console.ReadLine();
                        if (numeroSerieNovo == "")
                        {
                            mensagenDeErro("serie nao pode ser nulo");
                            goto volta6;
                        }

                        foreach (var item in numeroSerie)
                        {
                            if (item == numeroSerieNovo)
                            {
                                mensagenDeErro("numero de serie ja existente");
                                goto volta6;
                            }
                        }
                        numeroSerie[alterarNumero] = numeroSerieNovo;
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
                Console.ReadKey();
            }
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
                    if (!(decimal.TryParse(Console.ReadLine(), out preco[i])) || preco[i] < 1)
                    {
                        mensagenDeErro("preco invalido");
                        goto volta;
                    }
                    volta3:
                    Console.WriteLine("digite o numero da serie do equipamento");
                    string numeroSerieNovo = Console.ReadLine();
                    if (numeroSerieNovo == "")
                    {
                        mensagenDeErro("serie nao pode ser nulo");
                        goto volta3;
                    }

                    foreach (var item in numeroSerie)
                    {
                        if (item == numeroSerieNovo)
                        {
                            mensagenDeErro("numero de serie ja existente");
                            goto volta3;
                        }
                    }
                    numeroSerie[i] = numeroSerieNovo;
                volta2:
                    Console.WriteLine("digite a data de fabricacao do equipamento");
                    if (!(DateTime.TryParse(Console.ReadLine(), out dataFabricacao[i])))
                    {
                        mensagenDeErro("data invalido");
                        goto volta2;
                    }
                    volta4:
                    Console.WriteLine("digite o fabricante");
                    fabricante[i] = Console.ReadLine();
                    if (fabricante[i] == "")
                    {
                        mensagenDeErro("fabricante nao pode ser vazio");
                        goto volta4;
                    }

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

        static string selecionarOpcao(string mensagen)
        {
           Console.WriteLine(mensagen);
            return Console.ReadLine().ToLower();
        }

        private static void mensagenDeErro(string mensagen)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensagen);
            Console.ResetColor();
        }
    }
}
