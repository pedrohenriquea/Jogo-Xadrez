using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;
using xadrez;

namespace xadrez
{
    class PartidaDeXadrez
    {

        public Tabuleiro tab { get; set; }
        private int turno { get; set; }
        private Cor jogadorAtual { get; set; }
        public bool Terminada { get; private set; }
        public HashSet<Peca> pecas;
        public HashSet<Peca> pecasCapturadas;



        public PartidaDeXadrez()
        {
            tab = new Tabuleiro();
            pecas = new HashSet<Peca>();
            pecasCapturadas = new HashSet<Peca>();
            turno = 1;
            jogadorAtual = Cor.Branca;
            colocarPecas();
        }


        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.peca(origem);
            Peca pecaCapturada = tab.peca(destino);

            if (pecaCapturada != null)
            {
                pecasCapturadas.Add(pecaCapturada);
                tab.ColocarPeca(p, destino);
            }
            else
            {
                if(p.cor != pecaCapturada.cor)
                {
                    pecasCapturadas.Add(pecaCapturada);
                    tab.ColocarPeca(p, destino);
                }
                
            }


        }

        public HashSet<Peca> capturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca x in pecasCapturadas)
            {
                if(x.cor == cor)
                {
                    aux.Add(x);
                }
            }

            return aux;
        }

        public HashSet<Peca> pecasEmjogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca x in pecas)
            {
                if(x.cor == cor)
                {
                    aux.Add(x);
                }
            }

            aux.ExceptWith(capturadas(cor));
            return aux;
        }


        public void colocaNovaPeca(char coluna, int linha, Peca p)
        {
            tab.ColocarPeca(p, new PosicaoXadrez(coluna,linha).toPosicao());
            pecas.Add(p);
        }


        private void colocarPecas()
        {
            //Pecas Brancas
            colocaNovaPeca('a', 1, new Torre(tab, Cor.Branca));
            colocaNovaPeca('h', 1, new Torre(tab, Cor.Branca));
            colocaNovaPeca('b', 1, new Cavalo(tab, Cor.Branca));
            colocaNovaPeca('g', 1, new Cavalo(tab, Cor.Branca));
            colocaNovaPeca('f', 1, new Bispo(tab, Cor.Branca));
            colocaNovaPeca('c', 1, new Bispo(tab, Cor.Branca));
            colocaNovaPeca('e', 1, (new Rei(tab, Cor.Branca)));
            colocaNovaPeca('d', 1, (new Rainha(tab, Cor.Branca)));

            colocaNovaPeca('a', 2, new Piao(tab, Cor.Branca));
            colocaNovaPeca('b', 2, new Piao(tab, Cor.Branca));
            colocaNovaPeca('c', 2, new Piao(tab, Cor.Branca));
            colocaNovaPeca('d', 2, new Piao(tab, Cor.Branca));
            colocaNovaPeca('e', 2, new Piao(tab, Cor.Branca));
            colocaNovaPeca('f', 2, new Piao(tab, Cor.Branca));
            colocaNovaPeca('g', 2, new Piao(tab, Cor.Branca));
            colocaNovaPeca('h', 2, new Piao(tab, Cor.Branca));


            //Pecas Pretas

            colocaNovaPeca('a', 8, (new Torre(tab, Cor.Preta)));
            colocaNovaPeca('h', 8, (new Torre(tab, Cor.Preta)));
            colocaNovaPeca('b', 8, (new Cavalo(tab, Cor.Preta)));
            colocaNovaPeca('g', 8, (new Cavalo(tab, Cor.Preta)));
            colocaNovaPeca('c', 8, (new Bispo(tab, Cor.Preta)));
            colocaNovaPeca('f', 8, (new Bispo(tab, Cor.Preta)));
            colocaNovaPeca('e', 8, (new Rei(tab, Cor.Preta)));
            colocaNovaPeca('d', 8, (new Rainha(tab, Cor.Preta)));

            colocaNovaPeca('a', 7, (new Piao(tab, Cor.Preta)));
            colocaNovaPeca('b', 7, (new Piao(tab, Cor.Preta)));
            colocaNovaPeca('c', 7, (new Piao(tab, Cor.Preta)));
            colocaNovaPeca('d', 7, (new Piao(tab, Cor.Preta)));
            colocaNovaPeca('e', 7, (new Piao(tab, Cor.Preta)));
            colocaNovaPeca('f', 7, (new Piao(tab, Cor.Preta)));
            colocaNovaPeca('g', 7, (new Piao(tab, Cor.Preta)));
            colocaNovaPeca('h', 7, (new Piao(tab, Cor.Preta)));

        }

      
    }
}
