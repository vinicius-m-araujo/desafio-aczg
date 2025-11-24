namespace ACZG.Entities.Itens;
using Vilao;

public class Faturamentus : ItemBatalha
{
    public Faturamentus() : base("Faturamentus", "Placa de Pedra")
    {
    }

    public override void AtivarBeneficio(Heroi heroi)
    {
        Console.WriteLine($"[{Nome}] ATIVADO: Você ergue a {Formato}!");
        Console.WriteLine(">> Benefício: Sorteando 4 números de uma só vez para o ataque...");
        heroi.QtdJogadasPorRodada = 4;

    }

    public override void RemoverBeneficio(Heroi heroi)
    {
        heroi.QtdJogadasPorRodada = 1;
    }

    public override void AplicarConsequencia(Heroi heroi,Monstro monstro, bool errouAtaque)
    {
        if (errouAtaque)
        {
            monstro.DanoTemporario += 2;
            Console.WriteLine("Faturamentus pesou! O Monstro ficou mais forte na próxima rodada");
        }
    }
}