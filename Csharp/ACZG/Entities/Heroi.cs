using ACZG.Entities.Itens;

namespace ACZG.Entities;

public class Heroi : Personagem
{
    public List<ItemBatalha> Inventario { get; set; } = new List<ItemBatalha>();
    public ItemBatalha ItemBatalhaEquipado { get; set; }
    public int QtdDadosPorRodada { get; set; }
    
    public Heroi(string nome, int vidaMaxima) : base(nome, vidaMaxima)
    {
        Nome = "Hot Dog";
        VidaMaxima = 5;
    }

    public void AumentarVidaMaxima(int bonus)
    {
        VidaMaxima += bonus;
        VidaAtual += bonus;
    }
    public void CurarVida(int vida)
    {
        VidaAtual += vida;
        if(VidaAtual >= VidaMaxima) VidaAtual = VidaMaxima;
    }

    public void AdicionarItem(ItemBatalha itemBatalha)
    {
        Inventario.Add(itemBatalha);
    }

    public void AtualizarItem(ItemBatalha itemBatalha)
    {
        Inventario.Remove(itemBatalha);
    }

    public void PagarComVida(int vida)
    {
        if(VidaAtual >= vida) VidaAtual = vida;
    }

    public void TrocarItem(ItemBatalha novoItemBatalha)
    {
        if (!Inventario.Contains(novoItemBatalha))
        {
            Console.WriteLine("Erro: Você não possui este item no inventário para equipar.");
            return;
        }

        if (ItemBatalhaEquipado != null)
        {
            Inventario.Add(ItemBatalhaEquipado);
            ItemBatalhaEquipado = null;
        }
        ItemBatalhaEquipado = novoItemBatalha;
        Inventario.Remove(novoItemBatalha);
        Console.WriteLine("Item equipado com sucesso!");
    }
}