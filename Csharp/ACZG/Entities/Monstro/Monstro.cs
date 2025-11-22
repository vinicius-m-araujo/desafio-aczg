namespace ACZG.Entities.Vilao;

public class Monstro : Personagem
{
    public int QtdJogadasPorRodada { get; set; }
    public int Dano { get; set; }
    public Monstro(string nome, int vidaMaxima, int qtdJogadasPorRodada) : base(nome, vidaMaxima)
    {
        QtdJogadasPorRodada = qtdJogadasPorRodada;
    }
}