namespace ACZG.Views;

public class ViewBase
{

    public void EscreverLento(string texto, int delay = 50)
    {
        for (int i = 0; i < texto.Length; i++)
        {
            Console.Write(texto[i]);
            if (Console.KeyAvailable)
            {
                Console.ReadKey(true);
                Console.Write(texto.Substring(i + 1));
                break;
            }
            Thread.Sleep(delay);
        }
        Console.WriteLine();
    }

    protected void Pausar()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("Pressione enter para continuar...");
        Console.WriteLine("Pressione X para desistir da missão");
        Console.ResetColor();

        while (true)
        {
            var tecla = Console.ReadKey(true);
            if (tecla.Key == ConsoleKey.Enter)
            {
                break;
            }

            if (tecla.Key == ConsoleKey.X)
            {
            }
        }

        Console.Clear();
    }

    protected void ExibirNarrativa(string texto)
    {
        Console.Clear();
        EscreverLento(texto);
        Pausar();
    }
    
    public void FecharPrograma()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        EscreverLento("Você desistiu. O mundo cairá nas trevas de Glozium.. \n" +
                      "Fechando programa...");
        Console.ResetColor();
        Environment.Exit(0);
    }
}