namespace ACZG.Entities;

public abstract class Personagem
{
    public string Nome { get; set; }
    public int VidaAtual { get; protected set;}
    public int VidaMaxima { get;  protected set; }
    public int NumeroSecreto { get; protected set; }
    
    private static Random Random = new Random();
    
    public Personagem(string nome, int vidaMaxima)
    {
        Nome = nome;
        VidaMaxima = vidaMaxima;
        VidaAtual = vidaMaxima;
    }

    public virtual void ReceberDano(int dano)
    {
        VidaAtual -= dano;
        if(VidaAtual <= 0) VidaAtual = 0;
    }
    
    
    public bool EstaVivo => VidaAtual > 0;

    public void GerarNumeroSecreto()
    {
        int numero = Random.Next(1, VidaMaxima + 1);
        NumeroSecreto = numero;
    }
}