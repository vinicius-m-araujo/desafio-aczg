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
                var numerosSorteados = ListaNumerosSorteados(hotDog.QtdJogadasPorRodada, monstro.VidaMaxima);
                if (numerosSorteados.Count == 1)
                {
                    Console.WriteLine($"Número Sorteado: [{numerosSorteados}]");
                }
                else
                {
                    Console.WriteLine($"Números Sorteados =[{string.Join(", ", numerosSorteados)}]");
                }

                if (SorteadoIgualSecreto(numerosSorteados, monstro.NumeroSecreto))
                {
                    int dano = QtdNumeroAparece(numerosSorteados, monstro.NumeroSecreto);
                    monstro.ReceberDano(monstro.NumeroSecreto, dano);
                }
            }
        }
        return true;
    }

    public static List<int> ListaNumerosSorteados(int qtdJogadasPorRodada, int vidaMaxima)
    {
        var lista = new List<int>();
        
        for (int i = 0; i < qtdJogadasPorRodada; i++)
        {
            int numeroSorteado = _random.Next(1, vidaMaxima + 1);
            lista.Add(numeroSorteado);
        }
        return lista;
    }

    public static bool SorteadoIgualSecreto(List<int>lista, int numeroSecreto)
    {
        int numero = 0;
        foreach (var a in lista)
        {
            if (a == numeroSecreto)
            {
                return true;
            }
        }
        return false;
    }
    public static int QtdNumeroAparece(List<int> lista, int numeroSecreto)
    {
        int numeroAparece = 0;
        foreach (var numeros in lista)
        {
            if (numeros == numeroSecreto)
            {
                numeroAparece++;
            }
        }
        return numeroAparece;
    }
} 