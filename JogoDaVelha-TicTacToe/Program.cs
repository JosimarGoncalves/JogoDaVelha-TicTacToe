using System;
using System.Threading;
using System.Diagnostics;


class Program
{
    #region Variaveis
    public static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    public static int player = 1;

    public static int modoJogo;
    public static int escolhaJogo;

    public static int choice;

    public static int sortearJogadaCpu;
        
    public static int status =0;

    public static bool jogandoVs;
    public static bool jogandoCpu;

    public static int pontoA;
    public static int pontoB;
    public static int pontoCpu;
    #endregion
    #region Chamada Principal 
    static void Main()
    {
        jogandoVs = false;
        jogandoCpu = false;
        pontoA = 0;
        pontoB = 0;
        pontoCpu = 0;

        EscolherModo();

        TabuleiroThread();

        while (jogandoVs == true)
        {                        
            while (status == 0)
            {                
                if (player % 2 ==0)
                {
                    Player2Threading();
                    CheckThreading();
                    
                }
                else
                {
                    Player1Threading();
                    CheckThreading();
                    
                }
            }
           
        }
        while (jogandoCpu == true)
        {
            while (status == 0)
            {
                if (player % 2 == 0)
                {
                    CpuThreading();
                    CheckThreading();

                }
                else
                {
                    Player1Threading();
                    CheckThreading();

                }
            }

        }
        


    }
    #endregion
    #region Criacao das Threads
    public static void TabuleiroThread()
    {        
        Thread tabuleiro = new Thread(Board);
        tabuleiro.Start();
        tabuleiro.Join();
    }

    public static void CpuThreading()
    {
        Thread Computador = new Thread(Cpu);
        Computador.Start();
        Computador.Join();
    }

    public static void Player1Threading()
    {
        Thread Player1 = new Thread(JogadorA);
        Player1.Start();
        Player1.Join();
    }

    public static void Player2Threading()
    {
        Thread Player2 = new Thread(JogadorB);
        Player2.Start();
        Player2.Join();
    }
    
    public static void CheckThreading()
    {
        Thread CheckGame = new Thread(Check);
        CheckGame.Start();
        CheckGame.Join();
    }

   

    #endregion

    #region Metodos
   
    
    public static void Board()
    {
        Console.Clear();

        ConsoleColor background = Console.BackgroundColor;
        ConsoleColor foreground = Console.ForegroundColor;
        Console.WriteLine(" ");
        if (escolhaJogo == 1)
        {
            Console.WriteLine("Player1: X and CPU: O");
        }
        if (escolhaJogo ==2)
        {
            Console.WriteLine("Player1: X and Player2: O");
        }
        
        Console.WriteLine(choice);
        Console.WriteLine(sortearJogadaCpu);

        Console.WriteLine("\n");

        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
        Console.WriteLine("     |     |      ");

    }
   

    public static void EscolherModo()
    {
        Console.WriteLine(" ");
        Console.WriteLine("INICIANDO JOGO DA VELHA");
        Console.WriteLine("ESCOLHA MODO DE JOGO: ");
        Console.WriteLine("1: 1P VS CPU");
        Console.WriteLine("2: 1P VS 2P");
        Console.Write("DIGITE 1 OU 2: ");

        try
        {
           escolhaJogo = int.Parse(Console.ReadLine());
            while (escolhaJogo < 1 || escolhaJogo > 2)
            {
                Console.Write("DIGITE 1 OU 2 ");

                escolhaJogo = int.Parse(Console.ReadLine());

            }

            if (escolhaJogo == 1)
            {
                jogandoCpu = true;
                Console.Write("Sera que foi 1?");
            }
            if (escolhaJogo == 2)
            {
                jogandoVs = true;
                Console.Write("Sera que foi 2?");
            }

            
        }

        catch (Exception e)
        {
            Console.WriteLine("DIGITE UM NUMERO VÁLIDO ENTRE 1 OU 2: ");
            EscolherModo();
           
        }

        
    }
    
    public static void Cpu()
    {
        Random s = new Random();

        // choice = r.Next(1, 9);

        sortearJogadaCpu = s.Next(1, 3);
       

        if (arr[choice] != 'X' && arr[choice] != 'O')
        {
           arr[choice] = 'O';
           player++;

         }
        else
        {
            // choice = r.Next(1, 9);
            if (sortearJogadaCpu == 1)
            {
                JogadaCpuDefesa();
            }
            if (sortearJogadaCpu == 2)
            {
                JogadaCpuAtaque();
            }

        }
              
        Console.Clear();
        TabuleiroThread();
    }

    

    public static void JogadaCpuDefesa()
    {
        Random r = new Random();
        //Verificador Segundo Linha
        if (arr[2] == 'X' && arr[3] == 'X') { choice = 1; }
        else if (arr[1] == 'X' && arr[2] == 'X') { choice = 3; }
        else if (arr[1] == 'X' && arr[3] == 'X') { choice = 2; }


        //Verificador Segundo Linha
        else if (arr[5] == 'X' && arr[6] == 'X') { choice = 4; }
        else if (arr[4] == 'X' && arr[5] == 'X') { choice = 6; }
        else if (arr[4] == 'X' && arr[6] == 'X') { choice = 5; }

        //Verificador Terceira linha
        else if (arr[8] == 'X' && arr[9] == 'X') { choice = 7; }
        else if (arr[7] == 'X' && arr[8] == 'X') { choice = 9; }
        else if (arr[7] == 'X' && arr[9] == 'X') { choice = 8; }

        #endregion
        #region Vertical
        //Primeira Coluna 
        else if (arr[4] == 'X' && arr[7] == 'X') { choice = 1; }
        else if (arr[1] == 'X' && arr[4] == 'X') { choice = 7; }
        else if (arr[1] == 'X' && arr[7] == 'X') { choice = 4; }

        //Segunda Coluna
        else if (arr[5] == 'X' && arr[8] == 'X') { choice = 2; }
        else if (arr[2] == 'X' && arr[5] == 'X') { choice = 8; }
        else if (arr[2] == 'X' && arr[8] == 'X') { choice = 5; }

        //Terceira Coluna
        else if (arr[6] == 'X' && arr[9] == 'X') { choice = 3; }
        else if (arr[3] == 'X' && arr[6] == 'X') { choice = 9; }
        else if (arr[3] == 'X' && arr[9] == 'X') { choice = 6; }

        #endregion
        #region Diagonais
        else if (arr[5] == 'X' && arr[9] == 'X') { choice = 1; }
        else if (arr[1] == 'X' && arr[5] == 'X') { choice = 9; }
        else if (arr[5] == 'X' && arr[7] == 'X') { choice = 3; }
        else if (arr[3] == 'X' && arr[5] == 'X') { choice = 7; }
        else if (arr[1] == 'X' && arr[9] == 'X') { choice = 5; }
        else if (arr[7] == 'X' && arr[3] == 'X') { choice = 5; }


        else
        {
            choice = r.Next(1, 10);
            JogadaCpuAtaque();
        }
    }

    public static void JogadaCpuAtaque()
    {
        Random r = new Random();
        //Verificador Segundo Linha
        if (arr[2] == 'O' && arr[3] == 'O') { choice = 1; }
        else if (arr[1] == 'O' && arr[2] == 'O') { choice = 3; }
        else if (arr[1] == 'O' && arr[3] == 'O') { choice = 2; }


        //Verificador Segundo Linha
        else if (arr[5] == 'O' && arr[6] == 'O') { choice = 4; }
        else if (arr[4] == 'O' && arr[5] == 'O') { choice = 6; }
        else if (arr[4] == 'O' && arr[6] == 'O') { choice = 5; }

        //Verificador Terceira linha
        else if (arr[8] == 'O' && arr[9] == 'O') { choice = 7; }
        else if (arr[7] == 'O' && arr[8] == 'O') { choice = 9; }
        else if (arr[7] == 'O' && arr[9] == 'O') { choice = 8; }

        #endregion
        #region Vertical
        //Primeira Coluna 
        else if (arr[4] == 'O' && arr[7] == 'O') { choice = 1; }
        else if (arr[1] == 'O' && arr[4] == 'O') { choice = 7; }
        else if (arr[1] == 'O' && arr[7] == 'O') { choice = 4; }

        //Segunda Coluna
        else if (arr[5] == 'O' && arr[8] == 'O') { choice = 2; }
        else if (arr[2] == 'O' && arr[5] == 'O') { choice = 8; }
        else if (arr[2] == 'O' && arr[8] == 'O') { choice = 5; }

        //Terceira Coluna
        else if (arr[6] == 'O' && arr[9] == 'O') { choice = 3; }
        else if (arr[3] == 'O' && arr[6] == 'O') { choice = 9; }
        else if (arr[3] == 'O' && arr[9] == 'O') { choice = 6; }

        #endregion
        #region Diagonais
        else if (arr[5] == 'O' && arr[9] == 'O') { choice = 1; }
        else if (arr[1] == 'O' && arr[5] == 'O') { choice = 9; }
        else if (arr[5] == 'O' && arr[7] == 'O') { choice = 3; }
        else if (arr[3] == 'O' && arr[5] == 'O') { choice = 7; }
        else if (arr[1] == 'O' && arr[9] == 'O') { choice = 5; }
        else if (arr[7] == 'O' && arr[3] == 'O') { choice = 5; }


        else
        {
           choice = r.Next(1, 10);
           
            
        }

    }
    public static void JogadorA()
    {               
            Console.WriteLine(" ");
            Console.Write("PLAYER 1 ESCOLHA UMA POSIÇÃO DE 1 a 9: ");

            try
            {
                choice = int.Parse(Console.ReadLine());
                while (choice < 1 || choice > 9)
                {
                    Console.Write("POSIÇÃO INCORRETA! PLAYER 1 DIGITE UMA POSIÇÃO VÁLIDA ENTRE 1 A 9: ");

                    choice = int.Parse(Console.ReadLine());

                }
                if (arr[choice] != 'X' && arr[choice] != 'O')
                {
                    arr[choice] = 'X';
                    player++;

                }
                else
                {
                    Console.Write("POSIÇÃO JÁ PREENCHIDA! PLAYER 1 DIGITE OUTRA POSIÇÃO: ");
                    choice = int.Parse(Console.ReadLine());
                }

            }

            catch (Exception e)
            {
                Console.WriteLine("DIGITE UM NUMERO VÁLIDO ENTRE 1 A 9: ");
                JogadorA();  
            
            }
         
        Console.Clear();
        TabuleiroThread();
        
    }
    public static void JogadorB()
    {
        
        Console.WriteLine(" ");
        Console.Write("PLAYER 2 ESCOLHA UMA POSIÇÃO DE 1 a 9: ");

        try
        {
            choice = int.Parse(Console.ReadLine());
            while (choice < 1 || choice > 9)
            {
                Console.Write("POSIÇÃO INCORRETA!PLAYER 2 DIGITE UMA POSIÇÃO VÁLIDA ENTRE 1 A 9: ");

                choice = int.Parse(Console.ReadLine());


            }
            if (arr[choice] != 'X' && arr[choice] != 'O')
            {
                arr[choice] = 'O';
                player++;
            }
            else
            {
                Console.Write("POSIÇÃO JÁ PREENCHIDA! PLAYER 2 DIGITE OUTRA POSIÇÃO: ");
                choice = int.Parse(Console.ReadLine());
            }

            
        }

        catch (Exception e)
        {
            Console.WriteLine("PLAYER 2 DIGITE UM NUMERO VÁLIDO ENTRE 1 A 9: ");
            JogadorB();
           
        }
        Console.Clear();
        TabuleiroThread();
    }
    public static void Check() //Verifica se algum jogador ganhou
    {
       
        #region Horizontal 
        //Verificador Primeira linha
        if (arr[1] == arr[2] && arr[2] == arr[3])
        {
            status = 1;
            
        }
        //Verificador Segundo Linha
        else if (arr[4] == arr[5] && arr[5] == arr[6])
        {
            status = 1;
            
        }
        //Verificador Terceira linha
        else if (arr[7] == arr[8] && arr[8] == arr[9])
        {
            status = 1;
           
        }
        #endregion
        #region Vertical
        //Primeira Coluna
        else if (arr[1] == arr[4] && arr[4] == arr[7])
        {
            status = 1;
            
        }
        //Segunda Coluna
        else if (arr[2] == arr[5] && arr[5] == arr[8])
        {
            status = 1;
            
        }
        //Terceira Coluna
        else if (arr[3] == arr[6] && arr[6] == arr[9])
        {
            status = 1;
            
        }
        #endregion
        #region Diagonais
        else if (arr[1] == arr[5] && arr[5] == arr[9])
        {
            status = 1;
            
        }
        else if (arr[3] == arr[5] && arr[5] == arr[7])
        {
            status = 1;
            
        }
        #endregion
        #region Deu Velha
        //Todas as array preenchidas
        else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
        {
            status = -1;
            
        }
        
        #endregion
        else
        {
            status = 0;
        }
        CheckWin();

    }
    public static void CheckWin()//Checar Status do jogo.
    {
        if (status == 1 && jogandoVs ==true)

        {
            Console.WriteLine("Temos um vencedor!!!! ");
            Console.WriteLine("Player {0} venceu!!! ", (player % 2) + 1);

        }

        if (status == 1 && jogandoCpu== true)

        {
            Console.WriteLine("Temos um vencedor!!!! ");
            if (player %2 == 0)
            {
                Console.WriteLine("Player 1 venceu!!! ");
                pontoA++;

            }
            if (player % 2 == 1)
            {
                Console.WriteLine("Player CPU venceu!!! ");
                pontoCpu++;
            }
            //Console.WriteLine("Player {0} venceu!!! ", (player % 2) + 1);


        }

        else if(status == -1)
        {
            Console.WriteLine("Deu Empate!");

        }
        else
        {
            Console.Write("Continuem jogando...");

        }
        
        
    }

    
    #endregion
}
