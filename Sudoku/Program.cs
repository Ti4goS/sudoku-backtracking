
using Sudoku.Jogo;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Digite qunatos numeros você deseja gerar:");
        int quantidadeNumeros = ReadNumber();

        Board sudoku = new Board(quantidadeNumeros);

        Console.WriteLine("Tabuleiro Antes:");
        sudoku.ImprimeTabuleiro();


        Console.WriteLine("Aperte alguma tecla para resolver o tabuleiro");
        Console.ReadKey();
        sudoku.ResolverTabuleiro();


        Console.WriteLine("\n\n\nTabuleiro Depois:");
        sudoku.ImprimeTabuleiro();
    }

    private static int ReadNumber()
    {
        int numero;
        while (true)
        {
            try
            {
                numero = int.Parse(Console.ReadLine());
                break;
            }
            catch (Exception)
            {
                Console.WriteLine("Numero inválido");
            }
        }

        return numero;
    }
}