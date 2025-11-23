using ACZG.Entities;
using ACZG.Services;

namespace ACZG.Controllers;

public class GameController
{
    private Heroi _heroi;
    private SistemaBatalha  _sistema;
    private FlorestaController _floresta = new FlorestaController();

    
    public GameController()
    {
        _heroi = new Heroi();
    }

    public void Start()
    {
        while (_heroi.EstaVivo && _heroi.Inventario.Count < 5)
        {
            Console.WriteLine("\n--- 🧭 ONDE IR? ---");
            Console.WriteLine($"Vida: {_heroi.VidaAtual}/{_heroi.VidaMaxima} | Itens Coletados: {_heroi.Inventario.Count}/4");
            Console.WriteLine("1. Floresta do Atendimentus (Região 1)");
            Console.WriteLine("2. Cavernas de Faturamentus (Região 2)");
            Console.WriteLine("3. Vila da Transmissão (Região 3)");
            Console.WriteLine("4. Torre de Contas a Receber (Região 4 - Chefe Final)");
            Console.WriteLine("5. Forjar Espada ZG (Em Hospitalis)");
            Console.WriteLine("6. Loja de itens");
            
            if (_heroi.Inventario.Any(item => item.Nome == "Pearl of the Send"))
                Console.WriteLine("7. Usar Pearl of the Send e ir direto para Glozium!");
            
            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    _floresta.IniciarLutaFloresta(_heroi);
                    break;
                
                case "2":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Escolha um número correto.");
                    break;
            }
        }
    }
}