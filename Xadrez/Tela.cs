using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;
using xadrez;

namespace Xadrez
{
    class Tela
    {

        public static void imprimirTabuleiro(Tabuleiro tab)
        {

            for(int i =0; i < tab.linhas; i++)
            {
                Console.Write(8-i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    
                    if (tab.peca(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        imprimePeca(tab.peca(i, j));
                        Console.Write(" ");
                    }

                }
                Console.WriteLine();
            }
                Console.WriteLine("  a b c d e f g h");

                Console.WriteLine();
            
           
        }

        public static void imprimePeca(Peca peca)
        {
            if(peca.cor == Cor.Branca)
            {
                Console.Write(peca);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;
                
            }
        }
    }
}
