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

    public virtual void ReceberDano(int numeroSecreto, int qtdVezesQueAparece)
    {
        int dano = numeroSecreto * qtdVezesQueAparece;
        VidaAtual -= dano;
        if(VidaAtual <= 0) VidaAtual = 0;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($" >>> DANO CONFIRMADO! O monstro perdeu {dano} de vida.");
        Console.ResetColor();
    }
    
    
    public bool EstaVivo => VidaAtual > 0;


    public void SetarNumeroSecreto(int numeroSecreto)
    {
        NumeroSecreto = numeroSecreto;
    }
    
    
}