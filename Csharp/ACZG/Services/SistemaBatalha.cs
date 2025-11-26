using ACZG.Entities;
using ACZG.Entities.Itens;
using ACZG.Entities.Vilao;
using ACZG.Enums;
using ACZG.Views;

namespace ACZG.Services;

public class SistemaBatalha
{
    private static Random _random = new Random();

    public ResultadoBatalha Lutar(Heroi hotDog, Monstro monstro)
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
                    atacante: hotDog,
                    qtdJogadas: hotDog.QtdJogadasPorRodada,
                    alvo: monstro,
                    corTitulo: ConsoleColor.Cyan
                );
                if (!ProcessarMenuJogador(hotDog, monstro)) return ResultadoBatalha.Desistencia;
                turnoDoHeroi = false;
            }
            else
            {
                ExecutarRodadaDeAtaque(
                    atacante: monstro,
                    qtdJogadas: monstro.QtdJogadasPorRodada,
                    alvo: hotDog,
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
        return hotDog.EstaVivo ?  ResultadoBatalha.Vitoria : ResultadoBatalha.Derrota;
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
                          $"Monstro = {monstro.VidaAtual} vida | Quantidade de números sorteados por rodada = {monstro.QtdJogadasPorRodada}" +
                          $" | Número secreto = {monstro.NumeroSecreto} \n" +
                          $"Herói = {heroi.VidaAtual} vida | Quantidade de números sorteados por rodada = {heroi.QtdJogadasPorRodada}" +
                          $" | Número secreto = {heroi.NumeroSecreto}");
        ProcessarMenuJogador(heroi, monstro);
        Console.ReadKey();
        Console.WriteLine();
    }

    public static bool ExecutarRodadaDeAtaque(
        Personagem atacante,
        int qtdJogadas,
        Personagem alvo,
        ConsoleColor corTitulo)
    {
        Console.Clear();  
        Console.ForegroundColor = corTitulo;
        Console.WriteLine($"--- Rodada do {atacante.Nome} ---");
        Console.WriteLine($"Sorteia {qtdJogadas} no intervalo de vida do {alvo.Nome} [1-{alvo.VidaMaxima}]");

        var numeroSorteados = ListaNumerosSorteados(qtdJogadas, alvo.VidaMaxima);
        Console.ResetColor();
        var hero = atacante is Heroi ? atacante : alvo;
        Heroi hotDog = (Heroi)hero;
        var monstroWorm = alvo is Worm ? alvo : atacante;
        Worm worm = (Worm)monstroWorm;
        bool personagemAtordoado = false;
        int numeroParaAcertar = alvo.NumeroSecreto;


        if (alvo is Worm && worm.EstaEnterrado)
        {
            if (atacante is Heroi && hotDog.ItemBatalhaEquipado is BombaMagica)
            {
                numeroParaAcertar = worm.NumeroSecretoDinamico;
                Console.WriteLine($"O Worm está no subsolo! A bomba busca a vibração na posição {numeroParaAcertar}...");
            }
            else
            {
                Console.WriteLine($"O Ataque falhou! O {alvo.Nome} está enterrado. Use a Bomba Mágica");
                
                if(atacante is Heroi && hotDog.ItemBatalhaEquipado != null)
                    hotDog.ItemBatalhaEquipado.AplicarConsequencia(hotDog, (Monstro)alvo, true);

                Console.ReadKey();
                return false;
            }
        }
        
        
        if (numeroSorteados.Contains(alvo.NumeroSecreto))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            int qtdAparicoes = numeroSorteados.Count(numero => numero == alvo.NumeroSecreto);
            int danoTotal = alvo.NumeroSecreto * qtdAparicoes;
            
            if (atacante.PetAtivo)
            {
                danoTotal += 1;
                Console.WriteLine($"Salsichinha morde o {alvo.Nome} ferozmente!! Causando mais 1 de dano");
            }

            if (atacante is Monstro monstroAtacante)
            {
                if (monstroAtacante.DanoTemporario > 0)
                {
                    danoTotal += monstroAtacante.DanoTemporario;
                    Console.WriteLine($"O monstro usou força acumulada! {monstroAtacante.DanoTemporario}");
                    monstroAtacante.DanoTemporario = 0;
                }
            }

            if (atacante is Heroi && hotDog.ItemBatalhaEquipado is BombaMagica)
            {
                danoTotal = 0;
            }
            alvo.ReceberDano(danoTotal);

            Console.WriteLine($"Houve dano! O número secreto do {alvo.Nome} é {alvo.NumeroSecreto}" +
                              $" e foi sorteado {string.Join(", ", numeroSorteados)}.");
            Console.WriteLine($"Cálculo: {alvo.NumeroSecreto} (Secreto) * {qtdAparicoes} (Aparições) = {danoTotal} de Dano.");
            Console.WriteLine($"Vida do {alvo.Nome}: [{alvo.VidaAtual}]");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Não houve dano, pois o número secreto do {alvo.Nome} é {alvo.NumeroSecreto} e foi sorteado" +
                              $" {string.Join(",", numeroSorteados)}");
            
            if (alvo is Worm)
            {
                Console.WriteLine("Worm está andando pelo subsolo!!");
                worm.MoverPeloSubSolo();
            }
            if (atacante is Monstro monstroQueErrou && monstroQueErrou.DanoTemporario > 0)
            {
                Console.WriteLine($"O monstro errou o ataque e desperdiçou sua força acumulada de {monstroQueErrou.DanoTemporario}!");
                monstroQueErrou.DanoTemporario = 0; 
            }
            
            Console.ResetColor();
            
            
            if (atacante is Heroi)
            {
                if (alvo is Monstro monstroAlvo)
                {
                    hotDog.ItemBatalhaEquipado.AplicarConsequencia(hotDog, monstroAlvo, true);
                }
            }
        }
    }

    private static bool ProcessarMenuJogador(Heroi heroi, Monstro monstroAtual)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("Pressione ENTER para continuar...");
        Console.WriteLine("Pressione I para Trocar o Item...");
        Console.WriteLine("Pressione X para desistir da missão...");
        var tecla = Console.ReadKey(true).Key;

        switch (tecla)
        {
            case ConsoleKey.I:
                heroi.AbrirInventario(monstroAtual);
                break;
            case ConsoleKey.X:
                ExecutarDesistenciaDaMissao();
                return false;
            case ConsoleKey.Enter:
            default:
                break;
        }
        Console.ResetColor();
        return true;
    }

    public static void ExecutarDesistenciaDaMissao()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Você desistiu da missão.");
        Console.ResetColor();
        Console.ReadKey();
    }
}