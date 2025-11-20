namespace ACZG.Views;

public abstract class ViewBase
{
    public int ExibirMenuInicial()
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            EscreverLento("=== ACZG RPG: A JORNADA DE HOT DOG ===");
            Console.ResetColor();
            Console.WriteLine("1. Iniciar Jornada");
            Console.WriteLine("2. Sair");
            Console.Write("Escolha uma opção: ");
            string input = Console.ReadLine();

            if (input == "1") return 1;
            if (input == "2") return 2;
            Console.Clear();
        }
    }

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
                if (ConfirmarDesistencia())
                {
                    ExecutarDesistenciaDaMissao();
                }
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

    protected bool ConfirmarDesistencia()
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

    public void ExecutarDesistenciaDaMissao()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        EscreverLento("Você desistiu da missão.");
        Console.ResetColor();
        ExibirMenuInicial();
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