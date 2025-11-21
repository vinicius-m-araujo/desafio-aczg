namespace ACZG.Entities.Itens;
using Vilao;

public abstract class ItemBatalha
{
    public string Nome { get; protected set; }
    public string Formato { get; protected set; }

    public ItemBatalha(string nome, string formato)
    {
        Nome = nome;
        Formato = formato;
    }

    public abstract void AtivarBeneficio(Heroi heroi);
    public abstract void RemoverBeneficio(Heroi heroi);
    public abstract void AplicarConsequencia(Monstro monstro);
}