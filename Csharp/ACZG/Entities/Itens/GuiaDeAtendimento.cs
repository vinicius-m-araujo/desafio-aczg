using ACZG.Entities.Itens;
using ACZG.Entities;
using ACZG.Entities.Vilao;

public class GuiaDeAtendimento : ItemBatalha
{
    public GuiaDeAtendimento() : base("Guia de atendimento", "Pergaminho") { }

    public override void AtivarBeneficio(Heroi heroi)
    {
        Console.WriteLine($"[{Nome}] ATIVADO: Você ergue a {Formato}!");
        Console.WriteLine(">> Benefício: Sorteando 4 números de uma só vez para o ataque...");
        heroi.QtdJogadasPorRodada = 2;
    }

    public override void RemoverBeneficio(Heroi heroi)
    {
        Console.WriteLine("Guia de Atendimento REMOVIDO.");
    }

    public override void AplicarConsequencia(Vilao vilao) {}
}