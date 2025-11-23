using ACZG.Entities;
using ACZG.Entities.Vilao;
using ACZG.Views;

namespace ACZG.Services;

public class SistemaBatalha
{
    private static Random _random = new Random();
    private static bool turnoDoHeroi = true;
    private static ViewBase _view = new ViewBase();

    public static bool Lutar(Heroi hotDog, Monstro monstro)
    {
        hotDog.SetarNumeroSecreto(_random.Next(1, hotDog.VidaMaxima + 1));
        monstro.SetarNumeroSecreto(_random.Next(1, monstro.VidaMaxima + 1));
        var ultimoItemUsadoPeloHeroi = hotDog.ItemBatalhaEquipado;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"INICIO DE COMBATE: {hotDog.Nome} vs {monstro.Nome} \n" +
                          $"Monstro = {monstro.VidaAtual} vida | Quantidade de números sorteados por rodada = {monstro.QtdJogadasPorRodada} \n" +
                          $"Herói = {hotDog.VidaMaxima} vida | Quantidade de números sorteador por rodada = {hotDog.QtdJogadasPorRodada}");

        while (hotDog.EstaVivo &&  monstro.EstaVivo)
        {
            if (turnoDoHeroi)
            {
                
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("--- Rodada do Héroi ---");
                Console.WriteLine($"Sorteia {hotDog.QtdJogadasPorRodada} no intervalo de vida do Monstro [1-{monstro.VidaMaxima}]");
                var numerosSorteados = ListaNumerosSorteados(hotDog.QtdJogadasPorRodada, monstro.VidaMaxima);
                Console.WriteLine($"Número(s) Sorteado(s): [{string.Join(", ", numerosSorteados)}]");

                if (numerosSorteados.Contains(monstro.NumeroSecreto))
                {
                    int qtdAparicoes = numerosSorteados.Count(numero => monstro.NumeroSecreto == numero);
                    int danoTotal = monstro.NumeroSecreto * qtdAparicoes;
                    
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Houve dano! O número secreto do Monstro é {monstro.NumeroSecreto} e foi sorteado {qtdAparicoes}x.");
                    Console.WriteLine($"Cálculo: {monstro.NumeroSecreto} (Secreto) * {qtdAparicoes} (Aparições) = {danoTotal} de Dano.");
                    monstro.ReceberDano(danoTotal);
                    Console.WriteLine($"Vida do Monstro: {monstro.VidaAtual}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Não houve dano, pois o número secreto do monstro é {monstro.NumeroSecreto} e foi sorteado {string.Join(", ", numerosSorteados)}");
                }
                Console.WriteLine("Pressione ENTER para continuar...");
                Console.WriteLine("Pressione I para Trocar o Item...");
                Console.WriteLine("Pressione X para desistir da missão...");
                var tecla = Console.ReadKey(true).Key;

                switch (tecla)
                {
                    case ConsoleKey.Enter:
                        break;
                    
                    case ConsoleKey.I:
                        hotDog.AbrirInventario();
                        break;
                    
                    case ConsoleKey.X:
                        _view.ConfirmarDesistencia();
                        break;
                }
                
                turnoDoHeroi = true;
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            
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
    
} 