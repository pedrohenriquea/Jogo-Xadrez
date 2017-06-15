
using System;

namespace tabuleiro
{
    class Tabuleiro
    {

        public int linhas = 8;
        public int colunas = 8;
        private Peca[,] pecas { get;set; }

        public Tabuleiro()
        {
            this.pecas = new Peca[linhas, colunas];
        }

        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna] ;
        }

        public Peca peca(Posicao p)
        {
            return pecas[p.linha, p.coluna];
        }

        public bool PosicaoValida(Posicao p)
        {
            if(p.linha<0 || p.linha >= linhas || p.coluna <0 || p.coluna > colunas)
            {
                return false;
            }

            return true;
        }
        
        public bool existePeca(Posicao p)
        {
            ValidarPosicao(p);
            return peca(p) != null;
        }

        public void ValidarPosicao(Posicao p)
        {

            if (!PosicaoValida(p))
            {
                throw new TabuleiroException("Posição inválida");
            }

        }

        
        public void ColocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição");
            }

            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;

        }
        

        public Peca retirarPeca(Posicao pos)
        {
            if(peca(pos) == null)
            {
                return null;
            }

            Peca aux = peca(pos);
            aux.posicao = null;
            pecas[pos.linha, pos.coluna] = null;
            return aux;
        }

    }
}
