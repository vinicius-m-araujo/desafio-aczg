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
        ProcessarErro(errouAtaque, () => heroi.ReceberDano(2), "Sua mão");
    }   
    public override void AplicarConsequencia(SandubinhaReverse sandubinhaReverse, Heroi heroi, bool errouAtaque)
    {
        ProcessarErro(errouAtaque, () => sandubinhaReverse.ReceberDano(2), "Sua mão");
    }
    public override void AtivarBeneficio(SandubinhaReverse sandubinha, Heroi heroiAlvo)
    {
        int novasJogadas = (int)Math.Floor(heroiAlvo.VidaMaxima * 0.8);
        sandubinha.QtdJogadasPorRodada = novasJogadas < 1 ? 1 : novasJogadas;
        Console.WriteLine($"[MÍMICA] Bomba do Sandubinha ajustada para {sandubinha.QtdJogadasPorRodada} jogadas.");
    }
    
    private void ProcessarErro(bool errou, Action aplicarDano, string quem)
    {
        if (errou)
        {
            _errosNaBatalha++;
            if (_errosNaBatalha >= 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A bomba instável explodiu n{quem}! -2 Vida.");
                aplicarDano();
                Console.ResetColor();
                _errosNaBatalha = 0;
            }
            else
            {
                Console.WriteLine($"Tick-tock... Erros com a bomba: {_errosNaBatalha}/3");
            }
        }
    }
}