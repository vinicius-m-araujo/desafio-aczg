namespace ACZG.Views;

public abstract class BaseView
{
    protected void EscreverLento(string texto, int delay = 50)
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
                if (SairSimOuNao())
                {
                    EncerrarJogo();
                }
                Console.WriteLine("Continuamos a aventura.");
            }
        }
        Console.Clear();
    }

    protected void ExibirNarrativa(string texto)
    {
        EscreverLento(texto);
        Pausar();
    }
    protected bool SairSimOuNao()
    {
        while (true)
        {
            EscreverLento("Realmente deseja sair? (S/N)");
            string input = Console.ReadLine()?.ToUpper();
            
            if (input == "S") return true;
            if (input == "N") return false;
            
            Console.WriteLine("Opção inválida! Digite apenas S ou N.");
        }
    }

    protected void EncerrarJogo()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        EscreverLento("Você desistiu. O mundo cairá nas trevas de Glozium...");
        Console.ResetColor();
        Environment.Exit(0);
    }
}