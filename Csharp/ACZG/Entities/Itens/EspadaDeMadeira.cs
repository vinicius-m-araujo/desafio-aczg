using ACZG.Entities.Itens;
using ACZG.Entities;
using ACZG.Entities.Vilao; // Caso precise do namespace

public class EspadaDeMadeira : ItemBatalha
{
    public EspadaDeMadeira() : base("Espada de Madeira", "Espada") { }

    public override void AtivarBeneficio(Heroi heroi)
    {
        Console.WriteLine("[Espada de Madeira] ATIVADO: Você se sente... farpas na mão.");
        // Essa espada não muda o número de jogadas, então serve pra testar se o status reseta.
    }

    public override void RemoverBeneficio(Heroi heroi)
    {
        Console.WriteLine("[Espada de Madeira] REMOVIDO.");
    }

    public override void AplicarConsequencia(Vilao vilao) { /* Nada acontece */ }
}