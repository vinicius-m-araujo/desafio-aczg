using ACZG.Entities.Vilao;

namespace ACZG.Entities.Itens;

public class AzahTransmissao : ItemBatalha
{
    public AzahTransmissao() : base("Azah Transmissão", "Capa")
    {
    }

    public override void AtivarBeneficio(Heroi heroi)
    {
        Console.WriteLine("Heroi voa com a capa! +10 jogadas.");
        heroi.QtdJogadasPorRodada += 10;
    }
    
    public override void AtivarBeneficio(SandubinhaReverse sandubinha, Heroi heroiAlvo)
    {
        sandubinha.QtdJogadasPorRodada += 10;
        Console.WriteLine($"[MÍMICA] Sandubinha voa com a capa! +10 jogadas.");
    }

    public override void RemoverBeneficio(Heroi heroi)
    {
        heroi.QtdJogadasPorRodada = 1;
    }

    public override void AplicarConsequencia(Heroi heroi, Monstro monstro, bool errouAtaque)
    {
    }
    
}