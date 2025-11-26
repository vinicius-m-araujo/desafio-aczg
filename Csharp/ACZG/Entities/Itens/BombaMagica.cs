using ACZG.Entities.Vilao;

namespace ACZG.Entities.Itens;

public class BombaMagica : ItemBatalha
{
    private int _errosNaBatalha = 0;

    public BombaMagica() : base("Bomba-mágica", "Bomba")
    {
    }

    public override void AtivarBeneficio(Heroi heroi)
    {

        heroi.QtdJogadasPorRodada = 1;
    }

    public override void RemoverBeneficio(Heroi heroi)
    {
        heroi.QtdJogadasPorRodada = 1;
    }

    public override void AtivarBeneficio(Heroi heroi, Monstro monstro)
    {
        int novasJogadas = (int)Math.Floor(monstro.VidaMaxima * 0.8);
        
        heroi.QtdJogadasPorRodada = novasJogadas < 1 ? 1 : novasJogadas;

        Console.WriteLine($"[ITEM] Bomba equipada! Alvo: {monstro.Nome}. Jogadas ajustadas para: {heroi.QtdJogadasPorRodada}");
    }

    public override void AplicarConsequencia(Heroi heroi, Monstro monstro, bool errouAtaque)
    {
        if (errouAtaque)
        {
            _errosNaBatalha++;
            if (_errosNaBatalha >= 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A bomba instável explodiu na sua mão! Você perdeu 2 de vida.");
                heroi.ReceberDano(2);
                Console.ResetColor();
                _errosNaBatalha = 0;
            }
            else
            {
                Console.WriteLine($"Cuidado! Erros acumulados com a bomba: {_errosNaBatalha}/3");
            }
        }
    }
}