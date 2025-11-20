namespace ACZG.Entities;

public abstract class Personagem
{
    public string Nome { get; set; }
    public int VidaAtual { get; protected set;}
    public int VidaMaxima { get;  protected set; }
    public int NumeroSecreto { get; protected set; }
    public int QtdDadosPorRodada { get; set; }
    
    public Personagem(string nome, int vidaMaxima)
    {
        Nome = nome;
        VidaMaxima = vidaMaxima;
        VidaAtual = vidaMaxima;
    }

    public void ReceberDano(int dano)
    {
        VidaAtual -= dano;
        if(VidaAtual <= 0) VidaAtual = 0;
    }

    public void AdicionarVida(int vida)
    {
        VidaAtual += vida;
        if(VidaAtual >= VidaMaxima) VidaAtual = VidaMaxima;
    }
    
    public bool EstaVivo => VidaAtual > 0;
}