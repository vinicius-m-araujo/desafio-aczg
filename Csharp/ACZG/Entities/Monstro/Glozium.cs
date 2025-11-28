using ACZG.Services;

namespace ACZG.Entities.Vilao;

public class Glozium : Monstro
{
    private Heroi _heroiAlvo;
    private bool _eventoScriptAtivado = false;
    public static bool PetSequestrado = false;
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
            Console.WriteLine("Glozium: 'Melhor não se mover. Desista e entregue a espada, e ele viverá. Recuse e ele morrerá.'");
            Console.ResetColor();

            Console.WriteLine("\nO QUE VOCÊ FARÁ?");
            Console.WriteLine("[1] Continuar a batalha (Recusar oferta)");
            Console.WriteLine("[2] Desistir (Salvar o cachorro, mas perder a honra)");
            
            string escolha = Console.ReadLine();

            if (escolha == "2")
            {
                SistemaBatalha.ExecutarDesistenciaDaMissao();
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
                
                Console.WriteLine("=== MODO BERSERKER: Vida +50 | Ataque x3 ===");
                Console.WriteLine("Pressione Enter para retomar a matança...");
                Console.ReadKey();
            }
        }
}