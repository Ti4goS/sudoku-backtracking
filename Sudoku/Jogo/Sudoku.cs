namespace Sudoku.Jogo;

public class Sudoku
{

    private readonly int[,] Tabuleiro = new int[9, 9];


    /// <summary>
    /// Inicializa o tabuleiro e adiciona peças aleatórias nele
    /// </summary>
    /// <param name="quantidadeDePecas">Quantas peças vão ser geradas automáticamente</param>
    public Sudoku(int quantidadeDePecas)
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
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
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
    /// Verifica se o posicionamento da peça é valido para o ocntexto atual
    /// </summary>
    private bool JogadaValida(int numero, int coluna, int linha)
    {
        throw new NotImplementedException();
    }
}

