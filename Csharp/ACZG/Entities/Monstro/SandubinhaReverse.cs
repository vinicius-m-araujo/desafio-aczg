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
            if (heroi.ItemBatalhaEquipado is Salsichinha)
            {
                if (ItemMimetizado != null)
                {
                    Console.WriteLine("[MÍMICA] Sandubinha tentou copiar o Salsichinha, mas não conseguiu domar a fera!");
                    ItemMimetizado = null; 
                }
                return;
            }

            if (ItemMimetizado == null || ItemMimetizado.GetType() != heroi.ItemBatalhaEquipado.GetType())
            {
                try
                {
                    ItemMimetizado = Activator.CreateInstance(heroi.ItemBatalhaEquipado.GetType()) as ItemBatalha;

                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine($"[MÍMICA] Sandubinha analisou seus movimentos e materializou: {ItemMimetizado.Nome}!");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ERRO MÍMICA] O Sandubinha falhou ao tentar copiar o item. Erro: {ex.Message}");
                    ItemMimetizado = null;
                }
            }
        }
    }
}