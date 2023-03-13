using System.Security.Cryptography.X509Certificates;
using System.Xml;

internal class Program
{
    private static void Main(string[] args)
    {
        char[,] mat = new char[3, 3];
        char jogador1 = 'X';
        char jogador2 = 'O';
        bool fimPartida = false;
        bool jogadorAtual = false;
        int escolhaLinha = 0;
        int escolhaColuna = 0;
        int contador = 0;
        int posicao = 0;
        string nome1 = "";
        string nome2 = "";
        string nomeAtual = nome1;

        Console.WriteLine("Escolha o jogador: ");


        PreencheMatriz(mat);




        do
        {

            MostrarTabuleiro(mat);
            EscolhePosicao();
            if (RealizaJogada(mat, escolhaLinha, escolhaColuna))
            {
                contador++;
            }
            
            if ((VerificaLinha(mat) || VerificaColuna(mat) || VerificaDiagonalPrincipal(mat) ||
                verificaDiagonalSegundaria(mat)) &&  (contador >= 5))
            {
                fimPartida = true;
                Console.WriteLine(fimPartida);
            }


        } while ((contador <= 8) && fimPartida == false);

        MostrarTabuleiro(mat); 
        Console.WriteLine();
        Console.WriteLine("\t   FIM DO JOGO!!!");

        // VERIFICAÇÕES PARA FINALIZAR MENSAGEM PERSONALIZADA NO FIM DA PARTIDA
        if(contador < 9)
        {
             
            Console.WriteLine("\t   JOGADOR " + nomeAtual + " VENCEU!");
        }
        else if( (contador == 9) && (fimPartida == true ))
        {
            
            Console.WriteLine("\t   JOGADOR " + nomeAtual + " VENCEU!");
            
        }
        else
        {
           
            Console.WriteLine("\t   DEU VELHA!!!");
        }
        



        void EscolhePosicao()
        {   string aux;
            Console.WriteLine();
            Console.Write("\tInforme a posição desejada: ");            
            aux = Console.ReadLine();
            if(!int.TryParse(aux,out posicao)) // trata entradas de caracteres inválidos
            {
                Console.WriteLine("\tDigite apenas números de 1 a 9!");
                Console.ReadKey(); 
                Console.Clear();
                MostrarTabuleiro(mat);
                EscolhePosicao();
            }
             
            
            


            switch (posicao)
            {
                case 1:
                    {
                        escolhaLinha = 0;
                        escolhaColuna = 0;

                        break;
                    }
                case 2:
                    {
                        escolhaLinha = 0;
                        escolhaColuna = 1;

                        break;
                    }
                case 3:
                    {
                        escolhaLinha = 0;
                        escolhaColuna = 2;

                        break;
                    }
                case 4:
                    {
                        escolhaLinha = 1;
                        escolhaColuna = 0;

                        break;
                    }
                case 5:
                    {
                        escolhaLinha = 1;
                        escolhaColuna = 1;                        
                        break;
                    }
                case 6:
                    {
                        escolhaLinha = 1;
                        escolhaColuna = 2;                       
                        break;
                    }
                case 7:
                    {
                        escolhaLinha = 2;
                        escolhaColuna = 0;                        
                        break;
                    }
                case 8:
                    {
                        escolhaLinha = 2;
                        escolhaColuna = 1;                        
                        break;
                    }
                case 9:
                    {
                        escolhaLinha = 2;
                        escolhaColuna = 2;                        
                        break;
                    }
                default:
                    {
                        Console.WriteLine("\tEssa posição não existe, escolha novamente!");
                        Console.ReadKey();                       
                        break;
                    }
            } 
                // trata erros de entrada de valores
            if( (posicao <= 0) || (posicao > 9) )
            {
                EscolhePosicao();
            }
            
        }




        bool RealizaJogada(char[,] aux, int lin, int col)
        {
            if ((aux[lin, col] == jogador1) || (aux[lin, col] == jogador2))
            {
                Console.WriteLine("\tEssa posição já foi utilizada! Escolha outra");
                Console.ReadKey();
                return false;
            }
            else if (aux[lin, col] == '-')
            {

                if (jogadorAtual == false)
                {
                    aux[lin, col] = jogador1;
                    jogadorAtual = true;
                    nomeAtual = nome1;
                    return true;
                }
                else
                {
                    aux[lin, col] = jogador2;
                    jogadorAtual = false;
                    nomeAtual = nome2;
                    return true;
                }
                
            }
            return false;
        }


        //PREENCHIMENTO INICIAL DA MATRIZ COM '-'
        void PreencheMatriz(char[,] aux)
        {
            Console.Write("Informe o nome do 1º jogador: ");
            nome1 = Console.ReadLine().ToUpper();

            Console.Write("Informe o nome do 2º jogador: ");
            nome2 = Console.ReadLine().ToUpper();

            
            for (int linha = 0; linha < aux.GetLength(0); linha++)
            {
                for (int coluna = 0; coluna < aux.GetLength(1); coluna++)
                {
                    aux[linha, coluna] = '-';
                }

            }
        }

        // IMPRESSÃO DO TABULEIRO
        void MostrarTabuleiro(char[,] aux)
        {
            Console.Clear();
            int numeroPosicao = 1;
            for (int linha = 0; linha < aux.GetLength(0); linha++)
            {
                for (int coluna = 0; coluna < aux.GetLength(1); coluna++)
                {
                    if (aux[linha, coluna] != '-')
                    {
                        Console.Write("\t " + aux[linha, coluna] + " ");
                        numeroPosicao++;
                    }                   
                    else
                    {
                        Console.Write("\t " + numeroPosicao + " ");
                        numeroPosicao++;
                    }

                }
                Console.WriteLine();
            }

        }

        //VERIFICA SE EXISTE ALGUMA LINHA COMPLETA COM OS MESMOS VALORES
        bool VerificaLinha(char[,] aux)
        {
            for (int linha = 0; linha < aux.GetLength(0); linha++)
            {
                if (aux[linha, 0] != '-')
                {
                    if ((aux[linha, 0] == aux[linha, 1]) && (aux[linha, 1] == aux[linha, 2]))
                    {
                        Console.WriteLine("ganhou");
                        return true;
                    }
                }


            }

            return false;
        }

        //VERIFICA SE EXISTE ALGUMA COLUNA COMPLETA COM OS MESMOS VALORES 
        bool VerificaColuna(char[,] aux)
        {
            for (int coluna = 0; coluna < aux.GetLength(1); coluna++)
            {
                if (aux[0, coluna] != '-')
                    if ((aux[0, coluna] == aux[1, coluna]) && (aux[1, coluna] == aux[2, coluna]))
                    {
                        Console.WriteLine("ganhou");
                        return true;
                    }

            }

            return false;
        }


        //VERIFICA SE A DIAGONAL PRINCIPAL ESTA COMPLETA COM OS MESMOS VALORES
        bool VerificaDiagonalPrincipal(char[,] aux)
        {
            if (aux[0, 0] != '-')
            {
                if ((aux[0, 0] == aux[1, 1]) && (aux[1, 1] == aux[2, 2]))
                {
                    Console.WriteLine("ganhou");
                    return true;
                }
            }
            return false;
        }
        //VERIFICA SE A DIAGONAL SECUNDÁRIA ESTA COMPLETA COM OS MESMOS VALORES
        bool verificaDiagonalSegundaria(char[,] aux)
        {
            if (aux[0, 2] != '-')
            {
                if ((aux[0, 2] == aux[1, 1]) && (aux[1, 1] == aux[2, 0]))
                {
                    Console.WriteLine("ganhou");
                    return true;
                }
            }
            return false;
        }
    }
}
