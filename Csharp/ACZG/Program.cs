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
        Console.Title = "RPG ACZG";
        var controller = new GameController();
        controller.IniciarLutaTorre();
    }
}