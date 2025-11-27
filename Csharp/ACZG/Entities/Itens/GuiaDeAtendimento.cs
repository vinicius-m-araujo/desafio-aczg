using ACZG.Entities.Itens;
using ACZG.Entities;
using ACZG.Entities.Vilao;

public class GuiaDeAtendimento : ItemBatalha
{
    public GuiaDeAtendimento() : base("Guia de atendimento", "Pergaminho") { }

    public override void AtivarBeneficio(Heroi heroi)
    {
        Console.WriteLine($"[{Nome}] ATIVADO: Você ergue a {Formato}!");
        Console.WriteLine(">> Benefício: Sorteando 2 números de uma só vez para o ataque...");
        heroi.QtdJogadasPorRodada = 2;
    }
    public override void AtivarBeneficio(SandubinhaReverse sandubinha, Heroi heroiAlvo)
    {
        sandubinha.QtdJogadasPorRodada = 2;
        Console.WriteLine($"[MÍMICA] Guia ativado pelo Sandubinha: 2 jogadas.");
    }
    public override void RemoverBeneficio(Heroi heroi)
    {
        Console.WriteLine("Guia de Atendimento REMOVIDO.");
    }

    public override void AplicarConsequencia(Heroi heroi, Monstro monstro, bool errouAtaque)
    {
    }
    
    public override void AplicarConsequencia(SandubinhaReverse sandubinha, Heroi heroiAlvo, bool errouAtaque)
    {
        if (errouAtaque)
        {
            heroiAlvo.DanoTemporario += 2; 
            Console.WriteLine("[REVERSO] Sandubinha errou o cálculo! Você ganhou +2 de força.");
        }
    }
}