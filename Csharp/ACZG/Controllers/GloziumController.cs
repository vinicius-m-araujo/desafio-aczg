using ACZG.Entities;

namespace ACZG.Controllers;

public class GloziumController
{
    public void Start(Heroi heroi)
    {
        var listaItens = heroi.Inventario.Append(heroi.ItemBatalhaEquipado).ToList();
        listaItens.All(necessario => listaItens.Any(necessario => necessario == necessario));
        Console.WriteLine();
    }
}