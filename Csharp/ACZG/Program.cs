using ACZG.Controllers;
using ACZG.Entities;
using ACZG.Entities.Itens;
using ACZG.Entities.Vilao;
using ACZG.Enums;
using ACZG.Services;
using ACZG.Views;

class Program
{
    public static void Main(string[] args)
    {
        Console.Title = "Teste ACZG - Worm e Bomba Mágica";

        // 1. Configuração do Herói
        Heroi hotDog = new Heroi();
        hotDog.Nome = "Sir Hot Dog";
        

        // 2. Adicionando itens ao inventário
        Console.WriteLine("--- Configurando Inventário ---");

        // Item Padrão (já vem equipado no construtor): Espada Simples

        // Item de Teste: Bomba Mágica
        BombaMagica bomba = new BombaMagica();
        hotDog.AdicionarItem(bomba);
        Console.WriteLine($"> Item '{bomba.Nome}' adicionado ao inventário.");

        // 3. Criando o Inimigo (Worm)
        // Ele tem 12 de vida por padrão e começa com EstaEnterrado = true
        Worm worm = new Worm();

        Console.WriteLine("\n--- Inimigo Encontrado ---");
        Console.WriteLine($"Monstro: {worm.Nome} | Vida: {worm.VidaMaxima}");
        Console.WriteLine($"Status Inicial: {(worm.EstaEnterrado ? "Enterrado no subsolo" : "Na superfície")}");

        Console.WriteLine("\n[!] DICA DE TESTE: ");
        Console.WriteLine("1. Na primeira rodada, tente atacar com a Espada (deve falhar).");
        Console.WriteLine("2. Use 'I' para abrir o inventário e equipe a 'Bomba-mágica'.");
        Console.WriteLine("3. Observe se a qtd de jogadas muda para 80% da vida do Worm (aprox. 9 números).");
        Console.WriteLine("4. Acerte a posição do Worm para desenterrá-lo e atordoá-lo.");
        Console.WriteLine("\nPressione qualquer tecla para iniciar a batalha...");
        Console.ReadKey();

        // 4. Iniciar o Sistema de Batalha
        SistemaBatalha sistema = new SistemaBatalha();
        ResultadoBatalha resultado = sistema.Lutar(hotDog, worm);

        // 5. Resultado Final
        Console.Clear();
        if (resultado == ResultadoBatalha.Vitoria)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
             _   _ ___ _____  ___  ____  ___
            | | | |_ _|_   _|/ _ \|  _ \|_ _|
            | | | || |  | | | | | | |_) || |
            | |_| || |  | | | |_| |  _ < | |
             \___/|___| |_|  \___/|_| \_\___|
            ");
            Console.WriteLine($"Hot Dog venceu o {worm.Nome}!");
        }
        else if (resultado == ResultadoBatalha.Derrota)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("GAME OVER - Hot Dog foi derrotado.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("O herói fugiu da batalha (Desistência).");
        }

        Console.ResetColor();
        Console.WriteLine("\nPressione qualquer tecla para sair.");
        Console.ReadKey();
    }
}