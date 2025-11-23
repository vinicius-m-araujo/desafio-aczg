using ACZG.Controllers;
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

        var game = new GameController();
        game.Start();

    }
}