using ACZG.Entities.Itens;

namespace ACZG.Entities;

public class Heroi : Personagem
{
    public List<ItemBatalha> Inventario { get; set; } 
    public ItemBatalha ItemBatalhaEquipado { get; set; }
    public int QtdJogadasPorRodada { get; set; } = 1;
    public bool ModoBerserker { get; set; } = false;
    
    public Heroi()
    {
        Nome = "Hot Dog";
        VidaMaxima = 5;
        VidaAtual = 5;
        Inventario = new List<ItemBatalha> { new EspadaSimples() };
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
    
    public void PagarComVida(int vida)
    {
        if(VidaAtual > vida) VidaAtual -= vida;
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
            ItemBatalhaEquipado.RemoverBeneficio(this);
            Inventario.Add(ItemBatalhaEquipado);
            ItemBatalhaEquipado = null;
        }
        ItemBatalhaEquipado = novoItemBatalha;
        Inventario.Remove(novoItemBatalha);
        Console.WriteLine("Item equipado com sucesso!");
        novoItemBatalha.AtivarBeneficio(this);
    }
}