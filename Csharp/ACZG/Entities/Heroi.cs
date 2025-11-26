using ACZG.Entities.Itens;
using ACZG.Entities.Vilao;

namespace ACZG.Entities;

public class Heroi : Personagem
{
    public List<ItemBatalha> Inventario { get; } = new List<ItemBatalha>();
    public ItemBatalha ItemBatalhaEquipado { get; set; }
    public ItemBatalha Salsichinha { get; set; }
    public int QtdJogadasPorRodada { get; set; } = 1;
    public bool ModoBerserker { get; set; } = false;

    public Heroi()
    {
        Nome = "Hot Dog";
        VidaMaxima = 20;
        VidaAtual = 20;
        ItemBatalhaEquipado = new EspadaSimples();
        Salsichinha = new Salsichinha();
        PetAtivo = true;
    }

    public void AumentarVidaMaxima(int bonus)
    {
        VidaMaxima += bonus;
        VidaAtual += bonus;
    }

    public void CurarVida(int vida)
    {
        VidaAtual += vida;
        if (VidaAtual >= VidaMaxima) VidaAtual = VidaMaxima;
    }

    public void AdicionarItem(ItemBatalha itemBatalha)
    {
        Inventario.Add(itemBatalha);
    }

    public void PagarComVida(int custo)
    {
        if (VidaAtual > custo)
        {
            VidaAtual -= custo;
        }
        else
        {
            Console.WriteLine("Você não tem vitalidade suficiente para este sacrifício!");
        }
    }

    public void RealizarTrocaFisica(ItemBatalha novoItemBatalha)
    {
        if (ItemBatalhaEquipado != null)
        {
            ItemBatalhaEquipado.RemoverBeneficio(this);
            Inventario.Add(ItemBatalhaEquipado);
            ItemBatalhaEquipado = null;
        }

        ItemBatalhaEquipado = novoItemBatalha;
        Inventario.Remove(novoItemBatalha);
        Console.WriteLine($"Item equipado com sucesso! {novoItemBatalha.Nome}");
    }

    public void TrocarItem(ItemBatalha novoItemBatalha)
    {
        if (!Inventario.Contains(novoItemBatalha))
        {
            Console.WriteLine("Erro: Você não possui este item no inventário para equipar.");
            return;
        }

        RealizarTrocaFisica(novoItemBatalha);
        novoItemBatalha.AtivarBeneficio(this);
    }

    public void TrocarItem(ItemBatalha novoItemBatalha, Monstro monstroAlvo)
    {
        if (!Inventario.Contains(novoItemBatalha))
        {
            Console.WriteLine("Erro: Você não possui este item no inventário para equipar.");
            return;
        }

        RealizarTrocaFisica(novoItemBatalha);
        novoItemBatalha.AtivarBeneficio(this, monstroAlvo);
    }

    public void AbrirInventario()
    {
        ExibirMenuInventario();
        ProcessarEscolhaInventario(null);
    }
    public void AbrirInventario(Monstro monstroContexto)
    {
        ExibirMenuInventario();
        ProcessarEscolhaInventario(monstroContexto);
    }

    private void ExibirMenuInventario()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Item equipado: {ItemBatalhaEquipado.Nome}");
        Console.WriteLine("Itens no inventário: ");
        for (int i = 0; i < Inventario.Count; i++)
        {
            Console.WriteLine($"[{i + 1}] [{Inventario[i].Nome}]");
        }

        Console.WriteLine("[0] Manter item atual");
    }

    private void ProcessarEscolhaInventario(Monstro? monstroContexto)
    {
        while (true)
        {
            Console.Write("Escolha o item: ");
            string entrada = Console.ReadLine();
            if (int.TryParse(entrada, out int escolha))
            {
                if (escolha == 0) return;

                int indice = escolha - 1;
                if (indice >= 0 && indice < Inventario.Count)
                {
                    var novoItem = Inventario[indice];

                    if (monstroContexto != null)
                    {
                        TrocarItem(novoItem, monstroContexto);
                    }
                    else
                    {
                        TrocarItem(novoItem);
                    }

                    Console.WriteLine("Pressione qualquer tecla...");
                    Console.ReadKey();
                    return;
                }
            }

            Console.WriteLine("Opção inválida.");
            Console.ReadKey();
            Console.Clear();
            ExibirMenuInventario();
        }
    }
}