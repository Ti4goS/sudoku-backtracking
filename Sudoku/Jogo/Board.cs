namespace Sudoku.Jogo;

public class Board
{

    public int[,] Tabuleiro { get; }

    
    /// <summary>
    /// Inicializa o tabuleiro e adiciona peças aleatórias nele
    /// </summary>
    /// <param name="quantidadeDePecas">Quantas peças vão ser geradas automáticamente</param>
    public Board(int quantidadeDePecas)
    {
        Tabuleiro = new int[9, 9];

        InicializarTabuleiro();

        GerarPecasAleatorias(quantidadeDePecas);
    }


    /// <summary>
    /// Função de backtracking para resolver o tabuleiro atual do contexto
    /// </summary>
    /// <returns>True se conseguir achar uma solução para o tabuleiro e False se não conseguir achar</returns>
    public bool ResolverTabuleiro() => Solucao(0, 0);



    /// <summary>
    /// Imprime o tabuleiro atual do sudoku
    /// </summary>
    public void ImprimeTabuleiro()
    {
        Console.WriteLine("|---|---|---|---|---|---|---|---|---|");
        for (int linhaAtual = 0; linhaAtual < SudokuHelpers.TOTAL_LINHAS; linhaAtual++)
        {            
            Console.Write("|");
            
            for (int colunaAtual = 0; colunaAtual < SudokuHelpers.TOTAL_COLUNAS; colunaAtual++)
            {
                if(Tabuleiro[linhaAtual, colunaAtual] != -1)
                {
                        Console.Write(" " + Tabuleiro[linhaAtual, colunaAtual] + " |");                                     
                }
                else
                {
                    Console.Write("   |");
                }
            }
            Console.Write("\n");
            Console.WriteLine("|---|---|---|---|---|---|---|---|---|");
        }
    }


    /// <summary>
    /// Limpa o tabuleiro para uma nova instancia do jogo
    /// </summary>
    public void LimparTabuleiro() => InicializarTabuleiro();
    

    /// <summary>
    /// Inicializa o tabuleiro, onde -1 são todas as casas em branco
    /// </summary>
    private void InicializarTabuleiro()
    {
        for (int linhaAtual = 0; linhaAtual < SudokuHelpers.TOTAL_LINHAS; linhaAtual++)        
            for (int colunaAtual = 0; colunaAtual < SudokuHelpers.TOTAL_COLUNAS; colunaAtual++)
                Tabuleiro[linhaAtual, colunaAtual] = -1;
            
        
    }


    /// <summary>
    /// Gera os itens iniciais do tabuleiro a partir da função randomica
    /// </summary>
    /// <param name="quantidadeDePecas">Quantidade de itens que devem ser gerados no tabuleiro</param>
    private void GerarPecasAleatorias(int quantidadeDePecas)
    {
        Random numeroRandom = new Random();

        for (int peca = 0; peca < quantidadeDePecas; peca++)
        {
            int linhaRandom, colunaRandom, numero;

            do
            {
                linhaRandom = numeroRandom.Next(9);
                colunaRandom = numeroRandom.Next(9);
            } while (Tabuleiro[linhaRandom, colunaRandom] != -1);

            do
            {
                numero = numeroRandom.Next(1,9);
            } while (NotValid(numero, colunaRandom, linhaRandom));

            if (JogadaValida(numero, colunaRandom, linhaRandom))
                Tabuleiro[linhaRandom, colunaRandom] = numero;
        }
    }
    


    private bool NotValid(int numero, int colunaRandom, int linhaRandom) => !JogadaValida(numero, colunaRandom, linhaRandom);


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


    /// <summary>
    /// Resolve Através de Backtracking as partes restantes do tabuleiro
    /// </summary>
    /// <param name="linha">Linha atual em que o método se encontra</param>
    /// <param name="coluna">Coluna atual em que o método se encontra</param>
    /// <returns>True se conseguir achar uma solução para o tabuleiro e False se não conseguir achar</returns>
    private bool Solucao(int linha, int coluna)
    {
        if (linha == 9)
        {
            return true;
        }
        else if (coluna == 9)
        {
            return Solucao(linha + 1, 0);
        }
        else if (Tabuleiro[linha, coluna] != -1)
        {
            return Solucao(linha, coluna + 1);
        }
        else
        {
            foreach (int numero in Enumerable.Range(1, 9))
            {
                if (JogadaValida(numero, coluna, linha))
                {
                    Tabuleiro[linha, coluna] = numero;
                    if (Solucao(linha, coluna + 1))
                    {
                        return true;
                    }
                    else
                    {
                        Tabuleiro[linha, coluna] = -1;
                    }
                }
            }
        }
        return false;
    }


}

