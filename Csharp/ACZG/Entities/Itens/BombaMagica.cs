using ACZG.Entities.Vilao;

namespace ACZG.Entities.Itens;

public class BombaMagica : ItemBatalha
{
    private int _errosNaBatalha = 0;
    public Monstro? Monstro { get; set; }

    public BombaMagica() : base("Bomba-mágica", "Bomba")
    {
    }

    public override void AtivarBeneficio(Heroi heroi)
    {
        
        //heroi.QtdJogadasPorRodada = 
    }

    public override void RemoverBeneficio(Heroi heroi)
    {
        heroi.QtdJogadasPorRodada = 1;
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
            }
            else
            {
                Console.WriteLine($"Cuidado! Erros acumulados com a bomba: {_errosNaBatalha}/3");
            }
        }
    }

    public int CalcularQtdJogadas(int vidaMaximaMonstro)
    {
        int jogadas = (int)Math.Round(vidaMaximaMonstro * 0.8);
        return jogadas;
    }
}