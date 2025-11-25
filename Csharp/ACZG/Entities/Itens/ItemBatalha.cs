namespace ACZG.Entities.Itens;
using Vilao;

public abstract class ItemBatalha
{
    public string Nome { get; protected set; }
    public string Formato { get; protected set; }
    public int QtdSorteioExtra { get; protected set; } = 0;

    public ItemBatalha(string nome, string formato)
    {
        Nome = nome;
        Formato = formato;
    }

    public abstract void AtivarBeneficio(Heroi heroi);
    public abstract void RemoverBeneficio(Heroi heroi);
    public abstract void AplicarConsequencia(Heroi heroi, Monstro monstro,  bool errouAtaque);

    public virtual void AtivarBeneficio(Heroi heroi, Monstro monstro)
    {
        AtivarBeneficio(heroi);
    }
    
}