using ACZG.Entities;
using ACZG.Entities.Itens;
using ACZG.Services;

namespace ACZG.Controllers;

public class GameController
{
    private Heroi _heroi;
    private SistemaBatalha _sistema;
    private FlorestaController _floresta = new FlorestaController();
    private CavernaController _caverna = new CavernaController();
    private VilaController _vila = new VilaController();
    private TorreDeContasController _torre = new TorreDeContasController();
    public void IniciarLutaTorre()
    {
        bool jogando = true;

        while (jogando)
        {
            _heroi = new Heroi();
            Console.Clear();
            while (_heroi.EstaVivo && _heroi.Inventario.Count < 5)
            {
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("---  ONDE IR? ---");
                Console.WriteLine(
                    $"Vida: {_heroi.VidaAtual}/{_heroi.VidaMaxima} | Itens Coletados: {_heroi.Inventario.Count}/4");
                Console.WriteLine("1. Floresta do Atendimentus (Região 1)");
                Console.WriteLine("2. Cavernas de Faturamentus (Região 2)");
                Console.WriteLine("3. Vila da Transmissão (Região 3)");
                Console.WriteLine("4. Torre de Contas a Receber (Região 4 - Chefe Final)");
                Console.WriteLine("5. Forjar Espada ZG (Em Hospitalis)");
                Console.WriteLine("6. Abrir inventário");

                Console.WriteLine();
                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        _floresta.IniciarLutaFloresta(_heroi);
                        break;

                    case "2":
                        _caverna.IniciarLutaCaverna(_heroi);
                        break;

                    case "3":
                        _vila.IniciarLutaVila(_heroi);
                        break;
                        
                    case "4":
                        _torre.Start(_heroi);
                        break;
                    
                    case "6":
                        _heroi.AbrirInventario();
                        break;

                    default:
                        Console.WriteLine("Escolha um número correto.");
                        Console.ReadKey();
                        break;
                }
            }
            if (!_heroi.EstaVivo)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("GAME OVER! O herói caiu em combate.");
                Console.ResetColor();
                
                Console.WriteLine("Deseja jogar novamente? [S/N]");
                string resposta = Console.ReadLine().ToUpper();

                if (resposta == "N")
                {
                    jogando = false; 
                    Console.WriteLine("Obrigado por jogar!");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
        }
    }
}

