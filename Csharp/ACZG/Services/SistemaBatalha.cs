using ACZG.Entities;
using ACZG.Entities.Itens;
using ACZG.Entities.Vilao;
using ACZG.Enums;
using ACZG.Views;

namespace ACZG.Services;

public class SistemaBatalha
{
    private static Random _random = new Random();

    public SistemaBatalha()
    {
    }

    public ResultadoBatalha Lutar(Heroi hotDog, Monstro monstro)
    {
        hotDog.SetarNumeroSecreto(_random.Next(1, hotDog.VidaMaxima + 1));
        monstro.SetarNumeroSecreto(_random.Next(1, monstro.VidaMaxima + 1));

        bool turnoDoHeroi = true;
        bool desistiu = ImprimirCabecalho(hotDog, monstro);
        if (!desistiu) return ResultadoBatalha.Desistencia;
        
        while (hotDog.EstaVivo && monstro.EstaVivo)
        {
            if (turnoDoHeroi)
            {
                if (hotDog.EstaAtordoado)
                {
                    Console.WriteLine("O Herói está atordoado e perdeu a vez");
                    hotDog.EstaAtordoado = false;
                    turnoDoHeroi = false;
                    continue;
                }
                ExecutarRodadaDeAtaque(
                    atacante: hotDog,
                    qtdJogadas: hotDog.QtdJogadasPorRodada,
                    alvo: monstro,
                    corTitulo: ConsoleColor.Cyan
                );
                if (!ProcessarMenuJogador(hotDog, monstro)){ return ResultadoBatalha.Desistencia;}

                if (!monstro.EstaVivo)
                {
                    Console.ReadKey();
                    break;
                }

                turnoDoHeroi = false;
            }
            else
            {
                if (monstro.EstaAtordoado)
                {
                    Console.WriteLine("O Monstro está atordoado e perdeu a vez!");
                    monstro.EstaAtordoado = false;
                    turnoDoHeroi = true;
                    continue;
                }

                if (monstro is SandubinhaReverse sandu && sandu.ItemMimetizado != null)
                {
                    sandu.ItemMimetizado.AtivarBeneficio(sandu, hotDog);
                }

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

        return hotDog.EstaVivo ? ResultadoBatalha.Vitoria : ResultadoBatalha.Derrota;
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

    public static bool ImprimirCabecalho(Heroi heroi, Monstro monstro)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"INICIO DE COMBATE: {heroi.Nome} vs {monstro.Nome} \n" +
                          $"Monstro = {monstro.VidaAtual} vida | Quantidade de números sorteados por rodada = {monstro.QtdJogadasPorRodada}" +
                          $" | Número secreto = {monstro.NumeroSecreto} \n" +
                          $"Herói = {heroi.VidaAtual} vida | Quantidade de números sorteados por rodada = {heroi.QtdJogadasPorRodada}" +
                          $" | Número secreto = {heroi.NumeroSecreto}");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Pressione ENTER para continuar...");
        Console.WriteLine("Pressione I para Trocar o Item...");
        Console.WriteLine("Pressione X para desistir da missão...");
        Console.WriteLine();
        var tecla = Console.ReadKey(true).Key;
        switch (tecla)
        {
            case ConsoleKey.I:
                heroi.AbrirInventario(monstro);
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

    //Quando fiz essa função eu e Deus sabíamos como funcionava, agora só ele sabe...
    public static void ExecutarRodadaDeAtaque(
        Personagem atacante,
        int qtdJogadas,
        Personagem alvo,
        ConsoleColor corTitulo)
    {
        Console.Clear();
        Console.ForegroundColor = corTitulo;
        Console.WriteLine($"--- Rodada do {atacante.Nome} ---");
        Console.WriteLine($"Sorteia {qtdJogadas} no intervalo de vida do {alvo.Nome} [1-{alvo.VidaMaxima}]");
        Console.ResetColor();

        var numeroSorteados = ListaNumerosSorteados(qtdJogadas, alvo.VidaMaxima);
        var hotDog = (atacante as Heroi) ?? (alvo as Heroi);
        Worm? worm = alvo as Worm;
        SandubinhaReverse? sandubinhaAtacante = atacante as SandubinhaReverse;
        SandubinhaReverse? sandubinhaAlvo = alvo as SandubinhaReverse;
        int numeroParaAcertar = alvo.NumeroSecreto;

        if (atacante is Heroi && sandubinhaAlvo != null)
        {
            sandubinhaAlvo.ObservarHeroi(hotDog);
        }

        ItemBatalha? itemAtivo = null;
        if (atacante is Heroi he)
        {
            itemAtivo = he.ItemBatalhaEquipado;
        }
        else if (sandubinhaAtacante != null)
        {
            itemAtivo = sandubinhaAtacante.ItemMimetizado;
            if (itemAtivo != null)
                Console.WriteLine($"[MÍMICA] Sandubinha está usando: {itemAtivo.Nome}!");
        }
        
        bool ataqueComBomba = itemAtivo is BombaMagica;
        var ataqueComColar = itemAtivo is ColarDaEstatuaSagrada;
        if(atacante is Heroi && ataqueComColar)
            hotDog.ItemBatalhaEquipado.AtivarBeneficio(hotDog);
        
        if (worm != null && worm.EstaEnterrado)
        {
            if (ataqueComBomba)
            {
                numeroParaAcertar = worm.NumeroSecretoDinamico;
                Console.WriteLine(
                    $"O Worm está no subsolo! A bomba busca a vibração na posição {numeroParaAcertar}...");
            }
            else
            {
                Console.WriteLine($"O Ataque falhou! O {alvo.Nome} está enterrado. Use a Bomba Mágica");

                if (atacante is Heroi)
                    hotDog.ItemBatalhaEquipado.AplicarConsequencia(hotDog, (Monstro)alvo, true);

                Console.ReadKey();
                return;
            }
        }

        bool acertou = numeroSorteados.Contains(numeroParaAcertar);


        if (acertou)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            int qtdAparicoes = numeroSorteados.Count(numero => numero == numeroParaAcertar);
            int danoTotal = numeroParaAcertar * qtdAparicoes;

            if (atacante.PetAtivo && atacante is Heroi && !ataqueComBomba)
            {
                danoTotal += 1;
                Console.WriteLine($"Salsichinha morde o {alvo.Nome} ferozmente!! (+1 dano)");
            }

            if (atacante.DanoTemporario > 0)
            {
                danoTotal += atacante.DanoTemporario;
                Console.WriteLine($"Usou força acumulada! {atacante.DanoTemporario}");
                atacante.DanoTemporario = 0;
            }

            if (ataqueComBomba)
            {
                danoTotal = 0;
                alvo.EstaAtordoado = true;
                if (worm != null && worm.EstaEnterrado)
                {
                    Console.WriteLine("O impacto expulsou o Worm do subsolo!");
                    worm.EstaEnterrado = false;
                }
                Console.WriteLine("KABOOM! A Bomba Mágica explodiu!");
                Console.WriteLine($"O impacto atordoou o {alvo.Nome}! (Perde o próximo turno)");

                
            }

            alvo.ReceberDano(danoTotal);
            
            if (ataqueComBomba)
            {
                Console.WriteLine("Dano numérico anulado pela mágica da Bomba.");
                Console.WriteLine($"O número alvo era {numeroParaAcertar} (Vibração/Secreto)" +
                                  $" e foi encontrado {qtdAparicoes} vezes: {string.Join(", ", numeroSorteados)}.");
                Console.WriteLine($"Vida do {alvo.Nome}: [{alvo.VidaAtual}]");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"Houve dano! O número secreto do {alvo.Nome} é {numeroParaAcertar}" +
                                  $" e foi sorteado {string.Join(", ", numeroSorteados)}.");
                Console.WriteLine(
                    $"Cálculo: {numeroParaAcertar} (Secreto) * {qtdAparicoes} (Aparições) = {danoTotal} de Dano.");
                Console.WriteLine($"Vida do {alvo.Nome}: [{alvo.VidaAtual}]");
                Console.ResetColor();
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(
                $"Não houve dano, pois o número secreto do {alvo.Nome} é {numeroParaAcertar} e foi sorteado" +
                $" {string.Join(",", numeroSorteados)}");

            if (worm != null && worm.EstaEnterrado)
            {
                Console.WriteLine("Worm está andando pelo subsolo!!");
                worm.MoverPeloSubSolo();
            }

            if (atacante.DanoTemporario > 0)
            {
                Console.WriteLine(
                    $"O monstro errou o ataque e desperdiçou sua força acumulada de {atacante.DanoTemporario}!");
                atacante.DanoTemporario = 0;
            }
            
            AplicarConsequenciaDeErro(atacante, alvo, itemAtivo);
            
            Console.ResetColor();


            
        }
    }



    private static void AplicarConsequenciaDeErro(Personagem atacante, Personagem alvo, ItemBatalha? item)
    {
        if (atacante is Heroi heroi && alvo is Monstro monstro)
        {
            item.AplicarConsequencia(heroi, monstro, true);
        }
        else if (atacante is SandubinhaReverse sandu && alvo is Heroi heroiAlvo)
        {
            item.AplicarConsequencia(sandu, heroiAlvo, true);
        }
    }

    private static bool ProcessarMenuJogador(Heroi heroi, Monstro monstroAtual)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
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