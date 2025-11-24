using ACZG.Entities.Vilao;

namespace ACZG.Entities.Itens;

public class Salsichinha : ItemBatalha
{
    public Salsichinha() : base("Salsichinha","Amigo leal do héroi")
    {
    }

    public override void AtivarBeneficio(Heroi heroi)
    {
        throw new NotImplementedException();
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