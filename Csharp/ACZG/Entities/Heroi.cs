using ACZG.Entities.Itens;

namespace ACZG.Entities;

public class Heroi : Personagem
{
    public List<ItemBatalha> Inventario { get; } = new List<ItemBatalha>();
    public ItemBatalha ItemBatalhaEquipado { get; set; }
    public int QtdJogadasPorRodada { get; set; } = 1;
    public bool ModoBerserker { get; set; } = false;
    
    public Heroi()
    {
        Nome = "Hot Dog";
        VidaMaxima = 5;
        VidaAtual = 5;
        ItemBatalhaEquipado = new EspadaSimples();
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
    
    public void PagarComVida(int custo)
    {
        if(VidaAtual > custo) 
        {
            VidaAtual -= custo;
        }
        else
        {
            Console.WriteLine("Você não tem vitalidade suficiente para este sacrifício!");
        }    
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

    public void AbrirInventario()
    {
        Console.Clear();
        Console.WriteLine($"Item equipado: {ItemBatalhaEquipado.Nome}");
        Console.WriteLine("Itens no inventário: ");
        for (int i = 0; i < Inventario.Count; i++)
        {
            Console.WriteLine($"[{i + 1}] {Inventario[i].Nome}]");
        }
        Console.WriteLine("[0] Manter item atual");
        
        string entrada = Console.ReadLine();

        if (int.TryParse(entrada, out int escolha))
        {
            if (escolha == 0)
                return;
            
            int indice = escolha - 1;

            if (indice>= 0 && indice < Inventario.Count)
            {
                var itemBatalha = Inventario[indice];
                TrocarItem(itemBatalha);

                return;
            }
        }
        
        Console.WriteLine("Opção inválida.");
    }
}