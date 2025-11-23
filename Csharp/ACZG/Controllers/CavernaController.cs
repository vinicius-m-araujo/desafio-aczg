using ACZG.Entities;
using ACZG.Entities.Itens;
using ACZG.Entities.Vilao;
using ACZG.Services;
using ACZG.Views;

namespace ACZG.Controllers;

public class CavernaController
{
    private SistemaBatalha _sistemaBatalha = new SistemaBatalha();
    private ViewCavernasDeFaturamentus _view = new ViewCavernasDeFaturamentus();

    public bool IniciarLutaCaverna(Heroi heroi)
    {
        if (heroi.Inventario.Any(item => item.Nome == "Faturamentus") ||
            heroi.ItemBatalhaEquipado.Nome == "Faturamentus")
        {
            Console.WriteLine("Você já venceu essa fase");
            return true;
        }

        _view.IniciarFase();

        var monstro = new Monstro("Glozium Administratus", 6, 2);
        
        ProcessarEnigma(heroi, monstro);

        if (!heroi.EstaVivo)
        {
            _view.MostrarCenaDerrota();
            return false;
        }
        
        _view.IniciarLuta();

        bool vitoria = _sistemaBatalha.Lutar(heroi, monstro);
        if (vitoria)
        {
            _view.MostrarCenaVitoria();
            var item = new Faturamentus();
            heroi.AdicionarItem(item);

            heroi.AumentarVidaMaxima(5);
            return true;
        }

        _view.MostrarCenaDerrota();
        return false;
    }

    private void ProcessarEnigma(Heroi heroi, Monstro monstro)
    {
        bool escolhaValida = false;
        while (!escolhaValida)
        {
            Console.WriteLine("Do enfermo vem o início, do registro o meio, do pagamento o fim do anseio. " +
                              "Gira sem parar nos salões do curar — que ciclo é esse a sustentar?\n" +
                              "A) O Ciclum Receitatus Hospitalis\n" +
                              "B) O Rito dos Curandeiros Eternos\n" +
                              "C) A Roda da Vida e da Cura");
            string escolha = Console.ReadLine().ToUpper();
            switch (escolha)
            {
                case "A":
                    Console.WriteLine("Resposta correta! Você avança para a batalha.");
                    escolhaValida = true;
                    Console.ReadKey();
                    break;

                case "B":
                    Console.WriteLine("Você caiu em uma armadilha e recebeu 2 de dano");
                    heroi.ReceberDano(2);
                    escolhaValida = true;
                    Console.ReadKey();
                    break;

                case "C":
                    Console.WriteLine("Resposta errada! O monstro se fortaleceu com sua ignorância.");
                    monstro.AumentarVidaMaxima(6);
                    escolhaValida = true;
                    Console.ReadKey();
                    break;

                default:
                    Console.WriteLine("Escolha uma letra correta.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }
    }
}