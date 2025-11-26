using ACZG.Entities;
using ACZG.Entities.Itens;
using ACZG.Entities.Vilao;
using ACZG.Enums;
using ACZG.Services;
using ACZG.Views;

namespace ACZG.Controllers;

public class VilaController
{
    private ViewVilaDaTransmissao _viewVilaDaTransmissao = new ViewVilaDaTransmissao();
    private SistemaBatalha _sistemaBatalha = new SistemaBatalha();

    public bool IniciarLutaVila(Heroi heroi)
    {
        if (heroi.Inventario.Any(item => item.Nome == "Azah Transmissão") ||
            heroi.ItemBatalhaEquipado.Nome == "Azah Transmissão")
        {
            Console.WriteLine("Você já venceu essa fase");
            Console.ReadKey();
            return true;
        }

        if (_viewVilaDaTransmissao.IniciarFase()) return true;

        var monstro = new Worm();
        var bomba = new BombaMagica();
        heroi.AdicionarItem(bomba);

        var resultado = _sistemaBatalha.Lutar(heroi, monstro);
        if (resultado == ResultadoBatalha.Vitoria)
        {
            _viewVilaDaTransmissao.MostrarCenaVitoria();
            var item = new AzahTransmissao();
            heroi.AdicionarItem(item);
            heroi.AumentarVidaMaxima(5);
            return true;
        }

        if (resultado == ResultadoBatalha.Desistencia)
        {
            return true;
        }

        _viewVilaDaTransmissao.MostrarCenaDerrota();
        return false;
    }
}