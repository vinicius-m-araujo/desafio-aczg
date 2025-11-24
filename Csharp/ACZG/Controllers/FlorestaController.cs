using ACZG.Entities;
using ACZG.Entities.Vilao;
using ACZG.Enums;
using ACZG.Services;
using ACZG.Views;

namespace ACZG.Controllers;

public class FlorestaController
{
    private ViewFlorestaDoAtendimentus _florestaView = new ViewFlorestaDoAtendimentus();
    private SistemaBatalha _sistemaBatalha = new SistemaBatalha();

    public bool IniciarLutaFloresta(Heroi heroi)
    {
        if (heroi.Inventario.Any(item => item.Nome == "Guia de atendimento") ||
            heroi.ItemBatalhaEquipado.Nome == "Guia de atendimento")
        {
            Console.WriteLine("Você já venceu essa fase");
            return true;
        }

        _florestaView.IniciarFase();
        var monstro = new Monstro("Anti-authorizatus", 3, 1);

        var resultado = _sistemaBatalha.Lutar(heroi, monstro);
        if (resultado == ResultadoBatalha.Vitoria)
        {
            _florestaView.MostrarCenaVitoria();
            var item = new GuiaDeAtendimento();
            heroi.AdicionarItem(item);

            heroi.AumentarVidaMaxima(5);
            return true;
        }

        if (resultado == ResultadoBatalha.Desistencia)
        {
            return true;
        }

        _florestaView.MostrarCenaDerrota();
        return false;
    }
}