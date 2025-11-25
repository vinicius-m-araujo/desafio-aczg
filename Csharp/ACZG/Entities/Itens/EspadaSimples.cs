using ACZG.Entities;
using ACZG.Entities.Itens;
using ACZG.Entities.Vilao;

public class EspadaSimples : ItemBatalha
{

    public EspadaSimples() : base("Espada comum", "Espada comum") { }
    
    public override void AtivarBeneficio(Heroi heroi)
    {
    }

    public override void RemoverBeneficio(Heroi heroi)
    {
    }
    public override void AplicarConsequencia(Heroi heroi, Monstro monstro, bool errouAtaque)
    {
    }
}