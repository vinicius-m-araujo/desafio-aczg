using ACZG.Entities;
using ACZG.Entities.Itens;
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
        bool temCapa = heroi.ItemBatalhaEquipado is AzahTransmissao || heroi.Inventario.Any(i => i is AzahTransmissao);
        if (temCapa)
        {
            Console.WriteLine("Herói equipa a Azah Transmissão e ativa a skill de voo!");
            Console.WriteLine("Você Cruza os seus, ignorando os perigos do chão, e pousa suavemente.");

            ItemBatalha itemExistente = heroi.Inventario.FirstOrDefault(i => i is AzahTransmissao);
            heroi.TrocarItem(itemExistente);
        }
        else
        {
            Console.WriteLine("Você não possui o item Azah Transmissão e não pode voar");
            Console.WriteLine("A jornada a pé é longa, cheia de obstáculos");
            Console.WriteLine("Herói chega cansado na torre.");
            Console.WriteLine("Consequência: -3 de Vida.");
            heroi.ReceberDano(3);
            Console.WriteLine($"Vida Atual: {heroi.VidaAtual}");

            if (!heroi.EstaVivo)
            {
                Console.WriteLine("Você sucumbiu à exaustão.");
                Console.ReadKey();
                return false;
            }
        }
        
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

            ItemBatalha colar = new ColarDaEstatuaSagrada();
            heroi.AdicionarItem(colar);
            heroi.AumentarVidaMaxima(5);
        }

        bool temFaturamentus = heroi.Inventario.Any(i => i is Faturamentus) || heroi.ItemBatalhaEquipado is Faturamentus;
        bool temGuiaDeAtendimento = heroi.Inventario.Any(i => i is GuiaDeAtendimento) || heroi.ItemBatalhaEquipado is GuiaDeAtendimento;
        bool temAzah = heroi.Inventario.Any(i => i is AzahTransmissao) || heroi.ItemBatalhaEquipado is AzahTransmissao;
        bool temColarEstatua = heroi.Inventario.Any(i => i is ColarDaEstatuaSagrada) || heroi.ItemBatalhaEquipado is ColarDaEstatuaSagrada;
        bool temEspadaZG = heroi.Inventario.Any(i => i is EspadaZg);
        



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
        int numeroGargula = rnd.Next(1, 11); 
        Console.WriteLine($"Gárgulas mostraram: {numeroGargula}");

        bool ePar = numeroGargula % 2 == 0;
        bool venceu = (escolha == "P" && ePar) || (escolha == "I" && !ePar);

        return venceu;
    }
}
