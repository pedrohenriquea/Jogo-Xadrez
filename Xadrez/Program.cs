using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using tabuleiro;
using xadrez;

namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
           
            // Instanciando uma nova partida de Xadrez
            PartidaDeXadrez p = new PartidaDeXadrez();


            // Laço que vai se repetir até que a partida seja finalizada
            while (!p.Terminada)
            {
                
                // Sempre que as instruções do bloco while chegarem ao fim, o console será limpado.
                Console.Clear();
                
                // "imprimirTabuleiro" é um método estático da classe Tela, por isso não está sendo instanciado. Ele imprime o tabuleiro na tela do console.
                Tela.imprimirTabuleiro(p.tab);
                Console.WriteLine();

                //Aqui estamos mostrando as peças capturadas. Este campo é atualizado a cada movimento de peça.
                Console.Write("Peças capturadas(Brancas): ");
                // Usamos o foreach para percorrer toda coleção "capturadas" da cor Branca e exibe no console.
                foreach (Peca x in p.capturadas(Cor.Branca))
                {
                    Console.WriteLine(x + " ");
                    
                }
                
                Console.WriteLine();
                Console.WriteLine();

                Console.Write("Peças capturadas(Pretas): ");
                foreach (Peca x in p.capturadas(Cor.Preta))
                {
                    Console.Write(x + " ");
                }

                Console.WriteLine();
                Console.WriteLine();

                // Estamos lendo uma posição de Xadrez(caracter + inteiro) e transformando para posição da matriz de peças.
                Console.Write("Origem: ");
                Posicao origem = PosicaoXadrez.lerPosicaoXadrez().toPosicao();

                Console.WriteLine();

                // Estamos lendo uma posição de Xadrez(caracter + inteiro) e transformando para posição da matriz de peças.
                Console.Write("Destino: ");
                Posicao destino = PosicaoXadrez.lerPosicaoXadrez().toPosicao();

                // O método "executaMovimento" pega a peça que o usuário digitou em "Origem" e coloca em "Destino". Caso haja alguma peça no destino, ela é adicionada no conjunto de "pecasCapturadas"
                try
                {
                    p.executaMovimento(origem, destino);
                }
                catch (TabuleiroException e)
                {
                    Console.WriteLine(e.Message);
                    Thread.Sleep(1500);
                }


            }
        }
    }
}
