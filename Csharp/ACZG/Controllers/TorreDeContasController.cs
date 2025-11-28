using ACZG.Entities;
using ACZG.Entities.Vilao;
using ACZG.Enums;
using ACZG.Services;
using ACZG.Views;

namespace ACZG.Controllers;

public class TorreDeContasController
{
    private bool _sandubinhaDerrotado = false;
    private ViewTorreDeContas _view = new ViewTorreDeContas();
    private SistemaBatalha _sistemaBatalha = new SistemaBatalha();

    public bool Start(Heroi heroi)
    {
        if (!_sandubinhaDerrotado)
        {
            _view.IniciarFaseSandubinha();
            var sandubinha = new SandubinhaReverse();

            var resultadoSandu = _sistemaBatalha.Lutar(heroi, sandubinha);

            if (resultadoSandu == ResultadoBatalha.Derrota)
            {
                _view.MostrarCenaDerrotaSandubinha();
                return false;
            }

            if (resultadoSandu == ResultadoBatalha.Desistencia) return true;

            _view.MostrarCenaVitoriaSandubinha();
            _sandubinhaDerrotado = true;


            heroi.AumentarVidaMaxima(10);
        }

        bool subirAgora = _view.PerguntarSeSobeOuDesce();
        if (!subirAgora) return true;


        bool temEspadaZG = heroi.Inventario.Any(i => i is EspadaZG);

        if (temEspadaZG)
        {
            Console.WriteLine("Com a Espada ZG, você voa direto para a sala final!");
            Console.ReadKey();
        }
        else
        {
            bool venceuGargulas = ExecutarMiniGameGargulas();
            if (!venceuGargulas)
            {
                Console.WriteLine("Você perdeu o jogo! As gárgulas levaram o Salsichinha!");
                heroi.PetAtivo = false;
                Glozium.PetSequestrado = true;
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Você venceu as Gárgulas e manteve o Salsichinha!");
                Console.ReadKey();
            }
        }

        _view.IniciarFaseGlozium();
        var glozium = new Glozium(heroi);

        var resultadoFinal = _sistemaBatalha.Lutar(heroi, glozium);

        if (resultadoFinal == ResultadoBatalha.Desistencia)
        {
            _view.MostrarFinal(false, temEspadaZG, true);
        }
        else if (resultadoFinal == ResultadoBatalha.Vitoria)
        {
            _view.MostrarFinal(true, temEspadaZG, false);
        }
        else
        {
            _view.MostrarFinal(false, temEspadaZG, false);
        }

        Environment.Exit(0);
        return true;
    }

    private bool ExecutarMiniGameGargulas()
    {
        Console.Clear();
        Console.WriteLine("--- GÁRGULAS CAPTCHAS ---");
        Console.WriteLine("Elas bloqueiam o caminho! Vença no Par ou Ímpar.");
        Console.Write("Escolha [P]ar ou [I]mpar: ");
        string escolha = Console.ReadLine().ToUpper();

        Random rnd = new Random();
        int numeroGargula = rnd.Next(1, 11); // 1 a 10
        Console.WriteLine($"Gárgulas mostraram: {numeroGargula}");

        bool ehPar = numeroGargula % 2 == 0;
        bool venceu = (escolha == "P" && ehPar) || (escolha == "I" && !ehPar);

        return venceu;
    }
}
