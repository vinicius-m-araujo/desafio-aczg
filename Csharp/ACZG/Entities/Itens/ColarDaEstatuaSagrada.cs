using ACZG.Entities.Vilao;

namespace ACZG.Entities.Itens;

public class ColarDaEstatuaSagrada : ItemBatalha
{
    public ColarDaEstatuaSagrada() : base("Colar da Estátua Sagrada", "Colar")
    {
    }

    public override void AtivarBeneficio(Heroi heroi)
    {
        heroi.QtdJogadasPorRodada += 10;

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"O Colar brilha com poder proibido! (+10 Jogadas)");
        Console.WriteLine($"A energia do colar drena sua vitalidade... -3 HP");
        Console.ResetColor();

        heroi.ReceberDano(3);
    }

    public override void RemoverBeneficio(Heroi heroi)
    {
        heroi.QtdJogadasPorRodada -= 10;
    }

    public override void AplicarConsequencia(Heroi heroi, Monstro monstro, bool errouAtaque)
    {
    }
}