namespace ACZG.Entities;

public abstract class Personagem
{
    public string Nome { get; set; }
    public int VidaAtual { get; protected set;}
    public int VidaMaxima { get;  protected set; }
    public int NumeroSecreto { get; set; }
    
    public int Dano { get; set; }
    
    public Personagem()
    {
    }
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


    public void SetarNumeroSecreto(int numeroSecreto)
    {
        NumeroSecreto = numeroSecreto;
    }
    
}