namespace ACZG.Entities.Vilao;

public class Vilao : Personagem
{
    public int Dano { get; set; }
    public Vilao(string nome, int vidaMaxima) : base(nome, vidaMaxima)
    {
    }
}