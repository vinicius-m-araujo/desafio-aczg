using ACZG.Entities;
using ACZG.Entities.Vilao;
using ACZG.Views;

namespace ACZG.Services;

public class SistemaBatalha
{
    private static Random _random = new Random();
    private static bool turnoDoHeroi = true;

    public static bool Lutar(Heroi hotDog, Monstro monstro)
    {
        hotDog.SetarNumeroSecreto(_random.Next(1, hotDog.VidaMaxima + 1));
        monstro.SetarNumeroSecreto(_random.Next(1, monstro.VidaMaxima + 1));
        var ultimoItemUsadoPeloHero = hotDog.ItemBatalhaEquipado;

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"INICIO DE COMBATE: {hotDog.Nome} vs {monstro.Nome} \n" +
                          $"Monstro = {monstro.VidaAtual} vida | Quantidade de números sorteados por rodada = {monstro.QtdJogadasPorRodada}" +
                          $"Herói = {hotDog.VidaMaxima} vida | Quantidade de números sorteador por rodada = {hotDog.QtdJogadasPorRodada}");

        while (hotDog.EstaVivo &&  monstro.EstaVivo)
        {
            if (turnoDoHeroi)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("--- Rodada do Héroi ---");
                Console.WriteLine($"Sorteia {hotDog.QtdJogadasPorRodada} no intervalo de vida do Monstro [1-{monstro.VidaMaxima}]");
                NumerosSorteados()
            }
        }
    }

    public static List<int> NumerosSorteados(int qtdJogadasPorRodada)
    {
        var lista = new List<int>();
        foreach (var VARIABLE in COLLECTION)
        {
            
        }
        return 
    }
} 