namespace ACZG.Entities.Vilao;

public class Worm : Monstro
{
    public int NumeroSecretoDinamico { get; private set; }
    public bool EstaEnterrado { get; set; } = true;
    
    private Random random = new Random();
    
    public Worm() : base("Worm", 12,3)
    {
        NumeroSecretoDinamico = random.Next(1, this.VidaMaxima + 1);
    }

    public void MoverPeloSubSolo()
    {
        if (EstaEnterrado)
        {
            this.NumeroSecretoDinamico = random.Next(1, this.VidaMaxima + 1);
            Console.WriteLine($"O Worm se moveu no subsolo! (Posição alterada)[{this.NumeroSecretoDinamico}]");
        }
    }
}