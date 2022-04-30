using System;
using System.Threading;
using System.Diagnostics;


class Program
{

    #region Variaveis
    public static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    public static int player = 1;

    
    public static int choice;
        
    public static int status =0;

    public static bool jogando =true;
    #endregion
    #region Chamada Principal 
    static void Main()
    {
        
        TabuleiroThread();

        while (jogando == true)
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
       
    }
    #endregion
    #region Criacao das Threads
    public static void TabuleiroThread()
    {        
        Thread tabuleiro = new Thread(Board);
        tabuleiro.Start();
        tabuleiro.Join();
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
        Console.WriteLine("Player1: X and Player2: O");
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
        if (status == 1)

        {
            Console.WriteLine("Temos um vencedor!!!!");
            Console.WriteLine("Player {0} vendeu!!!", (player % 2) + 1);

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
