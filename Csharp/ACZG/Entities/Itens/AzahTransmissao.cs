using ACZG.Entities.Vilao;

namespace ACZG.Entities.Itens;

public class AzahTransmissao : ItemBatalha
{
    public AzahTransmissao() : base("Azah Transmissão", "Capa")
    {
    }

    public override void AtivarBeneficio(Heroi heroi)
    {
        heroi.QtdJogadasPorRodada += 10;
    }

    public override void RemoverBeneficio(Heroi heroi)
    {
        throw new NotImplementedException();
    }

    public override void AplicarConsequencia(Heroi heroi, Monstro monstro, bool errouAtaque)
    {
        throw new NotImplementedException();
    }
}