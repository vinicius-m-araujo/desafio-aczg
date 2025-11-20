namespace ACZG.Entities.Itens;

public abstract class ItemBatalha
{
    public string Nome { get; protected set; }
    public string Formato { get; protected set; }

    public ItemBatalha(string nome, string formato)
    {
        Nome = nome;
        Formato = formato;
    }

    public abstract void AtivarBeneficio();
    public abstract void AplicarConsequencia();
}