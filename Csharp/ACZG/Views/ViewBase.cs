namespace ACZG.Views;

public abstract class ViewBase
{
    public void EscreverLento(string texto, int delay = 20)
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

    protected bool Pausar()
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
                Console.Clear();
                return false;
            }

            if (tecla.Key == ConsoleKey.X)
            {
                Console.Clear();
                return true;
            }
        }
    }

    protected bool ExibirNarrativa(params string[] dialogos)
    {
        foreach (var dialogo in dialogos)
        {
            Console.Clear();
            EscreverLento(dialogo);
            if (Pausar())
            {
                EscreverLento("Você desistiu da missão");
                Console.ReadKey();
                return true;
            }
        }

        return false;
    }
}