using ACZG.Entities;
using ACZG.Entities.Itens;
using ACZG.Views;

namespace ACZG.Controllers;

public class ForjaHospitalisController
{
    private ViewForjaDeHospitalis _view = new ViewForjaDeHospitalis();

    public bool ForjarEspadaZg(Heroi heroi)
    {
        if (heroi.ItemBatalhaEquipado is EspadaZg || heroi.Inventario.Any(i => i is EspadaZg))
        {
            _view.MostrarMensagemJaPossui();
            return true;
        }
        _view.BoasVindas();
        
        var faturamentus = heroi.ItemBatalhaEquipado is Faturamentus 
            ? heroi.ItemBatalhaEquipado 
            : heroi.Inventario.FirstOrDefault(i => i is Faturamentus);

        var guia = heroi.ItemBatalhaEquipado is GuiaDeAtendimento 
            ? heroi.ItemBatalhaEquipado 
            : heroi.Inventario.FirstOrDefault(i => i is GuiaDeAtendimento);

        var capa = heroi.ItemBatalhaEquipado is AzahTransmissao 
            ? heroi.ItemBatalhaEquipado 
            : heroi.Inventario.FirstOrDefault(i => i is AzahTransmissao);

        var colar = heroi.ItemBatalhaEquipado is ColarDaEstatuaSagrada 
            ? heroi.ItemBatalhaEquipado 
            : heroi.Inventario.FirstOrDefault(i => i is ColarDaEstatuaSagrada);
        
        bool temFaturamentus = faturamentus != null;
        bool temGuia = guia != null;
        bool temAzah = capa != null;
        bool temColar = colar != null;
        
        _view.ListarIngredientes(temFaturamentus, temGuia, temAzah, temColar);

        if (temFaturamentus && temGuia && temAzah && temColar)
        {
            if (_view.ConfirmarForja())
            {
                _view.MostrarAnimacaoForja();
                RemoverItemDoHeroi(heroi, faturamentus);
                RemoverItemDoHeroi(heroi, guia);
                RemoverItemDoHeroi(heroi, capa);
                RemoverItemDoHeroi(heroi, colar);

                ItemBatalha espadaZg = new EspadaZg();
                
                heroi.AdicionarItem(espadaZg);
                heroi.TrocarItem(espadaZg);
                
                _view.MostrarSucesso();
            }
        }
        else
        {
            _view.MostrarFalha();
        }
        return true;
    }

    private void RemoverItemDoHeroi(Heroi heroi, ItemBatalha item)
    {
        if (item == null) return;
        if (heroi.ItemBatalhaEquipado == item)
        {
            heroi.ItemBatalhaEquipado = null;
        }
        else
        {
            heroi.Inventario.Remove(item);
        }
    }
}