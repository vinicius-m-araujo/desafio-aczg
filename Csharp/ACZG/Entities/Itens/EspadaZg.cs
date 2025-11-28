using ACZG.Entities.Vilao;

namespace ACZG.Entities.Itens;

public class EspadaZg : ItemBatalha
{
    public EspadaZg() : base("Espada ZG", "Espada")
    {
    }

    public override void AtivarBeneficio(Heroi heroi)
    {
        heroi.QtdJogadasPorRodada = 40;
    }

    public override void RemoverBeneficio(Heroi heroi)
    {
        heroi.QtdJogadasPorRodada = 0;
    }

    public override void AplicarConsequencia(Heroi heroi, Monstro monstro, bool errouAtaque)
    {
    }
}