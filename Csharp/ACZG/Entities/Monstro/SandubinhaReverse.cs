using ACZG.Entities.Itens;

namespace ACZG.Entities.Vilao;

public class SandubinhaReverse : Monstro
{
    public ItemBatalha? ItemMimetizado  { get; private set; }
    public SandubinhaReverse() : base("Sandubinha Reverse", 30, 8)
    {
    }
    public void ObservarHeroi(Heroi heroi)
    {
        if (heroi.ItemBatalhaEquipado != null)
        {
            if (ItemMimetizado == null || ItemMimetizado.GetType() != heroi.ItemBatalhaEquipado.GetType())
            {
                
                ItemMimetizado = heroi.ItemBatalhaEquipado; 
            }
        }
    }
}