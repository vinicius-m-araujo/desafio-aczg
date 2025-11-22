using ACZG.Entities;
using ACZG.Entities.Itens;
using ACZG.Entities.Vilao;
using ACZG.Services;
using ACZG.Views;

class Program
{
    public static void Main(string[] args)
    {
        Console.Title = "Teste de Batalha RPG";

        // 1. CRIANDO O HERÓI PARA O TESTE
        Heroi hotDog = new Heroi();


        // 2. CRIANDO O MONSTRO
        Monstro monstro = new Monstro("Vilao", 20, 2);

        Console.WriteLine("--- PREPARAÇÃO PARA BATALHA ---");
        Console.WriteLine($"Herói: {hotDog.Nome} (Vida: {hotDog.VidaAtual})");
        Console.WriteLine($"Monstro: {monstro.Nome} (Vida: {monstro.VidaAtual})");
        Console.WriteLine("Pressione ENTER para começar...");
        Console.ReadLine();

        // 3. INICIANDO A BATALHA
        // O método Lutar vai controlar o loop até alguém perder
        SistemaBatalha.Lutar(hotDog, monstro);

        Console.WriteLine("\nTeste finalizado. Pressione ENTER para fechar.");
        Console.ReadLine();
    }
}