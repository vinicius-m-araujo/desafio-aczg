using ACZG.Entities;
using ACZG.Entities.Vilao;
using ACZG.Views;

namespace ACZG.Services;

public class SistemaBatalha
{
    private static Random _random = new Random();
    private static ViewBase _view = new ViewBase();

    public bool Lutar(Heroi hotDog, Monstro monstro)
    {
        hotDog.SetarNumeroSecreto(_random.Next(1, hotDog.VidaMaxima + 1));
        monstro.SetarNumeroSecreto(_random.Next(1, monstro.VidaMaxima + 1));

        bool turnoDoHeroi = true;
        ImprimirCabecalho(hotDog, monstro);

        while (hotDog.EstaVivo && monstro.EstaVivo)
        {
            if (turnoDoHeroi)
            {
                ExecutarRodadaDeAtaque(
                    nomeAtacante: hotDog.Nome,
                    qtdJogadas: hotDog.QtdJogadasPorRodada,
                    personagem: monstro,
                    corTitulo: ConsoleColor.Cyan
                );
                if (!ProcessarMenuJogador(hotDog)) return false;
                turnoDoHeroi = false;
            }
            else
            {
                ExecutarRodadaDeAtaque(
                    nomeAtacante: monstro.Nome,
                    qtdJogadas: monstro.QtdJogadasPorRodada,
                    personagem: hotDog,
                    corTitulo: ConsoleColor.Yellow
                );
                turnoDoHeroi = true;
            }

            if (turnoDoHeroi)
            {
                Console.WriteLine("Fim do turno do monstro. Pressione qualquer tecla para continuar.");
                Console.ReadKey();
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

    public static void ImprimirCabecalho(Heroi heroi, Monstro monstro)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"INICIO DE COMBATE: {heroi.Nome} vs {monstro.Nome} \n" +
                          $"Monstro = {monstro.VidaAtual} vida | Quantidade de números sorteados por rodada = {monstro.QtdJogadasPorRodada} \n" +
                          $"Herói = {heroi.VidaMaxima} vida | Quantidade de números sorteador por rodada = {heroi.QtdJogadasPorRodada}");
        Console.ReadKey();
        Console.WriteLine();
    }

    public static void ExecutarRodadaDeAtaque(
        string nomeAtacante,
        int qtdJogadas,
        Personagem personagem,
        ConsoleColor corTitulo)
    {
        Console.Clear();  
        Console.ForegroundColor = corTitulo;
        Console.WriteLine($"--- Rodada do {nomeAtacante} ---");
        Console.WriteLine($"Sorteia {qtdJogadas} no intervalo de vida do {personagem.Nome} [1 {personagem.VidaMaxima}]");
        
        var numeroSorteados = ListaNumerosSorteados(qtdJogadas, personagem.VidaMaxima);
        Console.ResetColor();
        if (numeroSorteados.Contains(personagem.NumeroSecreto))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            int qtdAparicoes = numeroSorteados.Count(numero => numero == personagem.NumeroSecreto);
            int danoTotal = personagem.NumeroSecreto * qtdAparicoes;
            personagem.ReceberDano(danoTotal);

            Console.WriteLine($"Houve dano! O número secreto do {personagem.Nome} é {personagem.NumeroSecreto} e foi sorteado {qtdAparicoes}x.");
            Console.WriteLine($"Cálculo: {personagem.NumeroSecreto} (Secreto) * {qtdAparicoes} (Aparições) = {danoTotal} de Dano.");
            Console.WriteLine($"Vida do {personagem.Nome}: [{personagem.VidaAtual}]");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Não houve dano, pois o número secreto do {personagem.Nome} é {personagem.NumeroSecreto} e foi sorteado" +
                              $" {string.Join(",", numeroSorteados)}");
            Console.ResetColor();
        }
    }

    private static bool ProcessarMenuJogador(Heroi heroi)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("Pressione ENTER para continuar...");
        Console.WriteLine("Pressione I para Trocar o Item...");
        Console.WriteLine("Pressione X para desistir da missão...");
        var tecla = Console.ReadKey(true).Key;

        switch (tecla)
        {
            case ConsoleKey.I:
                heroi.AbrirInventario();
                break;
            case ConsoleKey.X:
                _view.ConfirmarDesistencia();
                return false;
            case ConsoleKey.Enter:
            default:
                break;
        }
        Console.ResetColor();
        return true;
    }
}