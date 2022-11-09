using System;
using System.Drawing;

namespace Sudoku.Jogo;

public class Board
{

    private readonly int[,] Tabuleiro = new int[9, 9];

    /// <summary>
    /// Inicializa o tabuleiro e adiciona peças aleatórias nele
    /// </summary>
    /// <param name="quantidadeDePecas">Quantas peças vão ser geradas automáticamente</param>
    public Board(int quantidadeDePecas)
    {
        InicializarTabuleiro();

        GerarPecasAleatorias(quantidadeDePecas);
    }


    /// <summary>
    /// Função de bvacktracking para resolver o tabuleiro atual do contexto
    /// </summary>
    /// <returns></returns>
    public bool ResolverTabuleiro()
    {
        throw new NotImplementedException();
    }


    /// <summary>
    /// Imprime o tabuleiro atual do sudoku
    /// </summary>
    public void ImprimeTabuleiro()
    {

    }


    /// <summary>
    /// Inicializa o tabuleiro, onde -1 são todas as casas em branco
    /// </summary>
    private void InicializarTabuleiro()
    {
        for (int i = 0; i < SudokuHelpers.TOTAL_LINHAS; i++)
        {
            for (int j = 0; j < SudokuHelpers.TOTAL_COLUNAS; j++)
            {
                this.Tabuleiro[i, j] = -1;
            }
        }
    }


    /// <summary>
    /// Gera os itens iniciais do tabuleiro a partir da função randomica
    /// </summary>
    /// <param name="quantidadeDePecas">Quantidade de itens que devem ser gerados no tabuleiro</param>
    private void GerarPecasAleatorias(int quantidadeDePecas)
    {

    }


    /// <summary>
    /// Verifica as 3 condições para o numero ser aceito em um tabuleiro de sudoku:
    /// <list type="bullet">
    /// <item>Se existe o mesmo numero na coluna atual</item>
    /// <item>Se existe o mesmo numero na linha atual</item>
    /// <item>Se existe o mesmo numero na box atual</item>
    /// </list>
    /// </summary>
    /// <param name="numero">Numero que quer ser adicionado ao tabuleiro</param>
    /// <param name="coluna">Posição da coluna em que o numero deseja ser posicionado</param>
    /// <param name="linha">Posição da linha em que o numero deseja ser posicionado</param>
    /// <returns>Retorna true se a posição Tabuleiro[Linha, Coluna] for valida para o numero em questão e false se não for válida</returns>
    private bool JogadaValida(int numero, int coluna, int linha)
    {
        for (int colunaAtual = 0; colunaAtual < SudokuHelpers.TOTAL_COLUNAS; colunaAtual++)
            if (numero == Tabuleiro[linha, colunaAtual]) return false;


        for (int linhaAtual = 0; linhaAtual < SudokuHelpers.TOTAL_LINHAS; linhaAtual++)
            if (numero == Tabuleiro[linhaAtual, coluna]) return false;


        int boxLinha = (int)Math.Floor(linha / 3.0) * 3;
        int boxColuna = (int)Math.Floor(coluna / 3.0) * 3;

        foreach (int linhaAtual in Enumerable.Range(boxLinha, 3))
            foreach (int colunaAtual in Enumerable.Range(boxColuna, 3))
                if (numero == Tabuleiro[linhaAtual, colunaAtual])
                    return false;


        return true;
    }




}

