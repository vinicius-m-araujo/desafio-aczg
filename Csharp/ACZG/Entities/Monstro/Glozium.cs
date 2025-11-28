using ACZG.Services;

namespace ACZG.Entities.Vilao;

public class Glozium : Monstro
{
    private Heroi _heroiAlvo;
    private bool _eventoScriptAtivado = false;
    public static bool PetSequestrado = false;
    public bool Desistiu { get; private set; } = false;

    public Glozium(Heroi heroi) : base("Glozium", 100, 10)
    {
        _heroiAlvo = heroi;
    }

    public override void ReceberDano(int dano)
    {
        base.ReceberDano(dano);

        if (VidaAtual > 0 && VidaAtual < (VidaMaxima * 0.8) && PetSequestrado && !_eventoScriptAtivado)
        {
            _eventoScriptAtivado = true;
            ExecutarEventoRefem();
        }
    }

    private void ExecutarEventoRefem()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("=== EVENTO CRÍTICO DESENCADEADO ===");
        Console.WriteLine("Glozium: 'Venham até mim gárgulas captchas e tragam o presentinho!'");
        Console.WriteLine("As gárgulas trazem o Salsichinha amarrado.");
        Console.WriteLine(
            "Glozium: 'Melhor não se mover. Desista e entregue a espada, e ele viverá. Recuse e ele morrerá.'");
        Console.ResetColor();

        Console.WriteLine("O QUE VOCÊ FARÁ?");
        Console.WriteLine("[1] Continuar a batalha (Recusar oferta)");
        Console.WriteLine("[2] Desistir (Salvar o cachorro, mas perder a honra)");

        string escolha = "";
        while (true)
        {
            Console.WriteLine("O QUE VOCÊ FARÁ?");
            Console.WriteLine("[1] Continuar a batalha (Recusar oferta)");
            Console.WriteLine("[2] Desistir (Salvar o cachorro, mas perder a honra)");
            Console.Write("Sua escolha: ");
            escolha = Console.ReadLine();

            if (escolha == "1" || escolha == "2")
            {
                break; 
            }
            Console.WriteLine("Opção inválida! O destino dele depende de uma escolha exata (1 ou 2).");
        }
        if (escolha == "2")
        {
            Desistiu = true;
            Console.WriteLine("Você abaixa a espada e se rende...");
            Console.WriteLine("Glozium liberta herói e mascote, que sobrevivem, mas desonrados.");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Glozium destrói o mundo.");
            Console.WriteLine("Pressione qualquer tecla...");
            Console.ReadKey();

            _heroiAlvo.ReceberDano(_heroiAlvo.VidaMaxima + 999);
        }
        else
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Glozium mata Salsichinha em frente aos olhos do herói!");
            Console.WriteLine("Hot Dog entra em FÚRIA INCONTROLÁVEL!");
            Console.ResetColor();

            _heroiAlvo.PetAtivo = false;
            _heroiAlvo.ModoBerserker = true;

            _heroiAlvo.AumentarVidaMaxima(50);
            _heroiAlvo.QtdJogadasPorRodada *= 3;

            Console.WriteLine("=== MODO BERSERKER ATIVADO: Vida +50 | Ataque x3 ===");
            Console.ReadKey();
        }
    }
}