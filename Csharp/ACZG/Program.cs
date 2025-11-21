using ACZG.Entities;
using ACZG.Entities.Itens;
using ACZG.Views;

class Program
{
    public static void Main(string[] args)
    {
        // var teste = new ViewFlorestaDoAtendimentus();
        // while (true)
        // {
        //     var opcao = teste.ExibirMenuInicial();
        //     if(opcao == 1) teste.IniciarFase();
        //     if(opcao == 2) teste.FecharPrograma();
        //     break;
        // }

        Console.WriteLine("=== INICIANDO TESTE DE INVENTÁRIO ===\n");

        // 1. Criando o Herói (No seu construtor ele vira "Hot Dog" com 5 de vida)
        Heroi meuHeroi = new Heroi("TesteMan", 100); 
        
        Console.WriteLine($"Herói: {meuHeroi.Nome}");
        Console.WriteLine($"Jogadas por Rodada (Inicial): {meuHeroi.QtdJogadasPorRodada}");
        Console.WriteLine("--------------------------------------------------");

        // 2. Criando os Itens
        var placaPedra = new Faturamentus();
        var espadinha = new GuiaDeAtendimento();

        // 3. Adicionando ao inventário (Necessário para poder equipar)
        meuHeroi.AdicionarItem(placaPedra);
        meuHeroi.AdicionarItem(espadinha);

        // --- TESTE A: EQUIPAR FATURAMENTUS ---
        Console.WriteLine("\n>>> TESTE 1: Equipando Faturamentus...");
        meuHeroi.TrocarItem(placaPedra);

        Console.WriteLine($"STATUS ATUAL -> Jogadas por Rodada: {meuHeroi.QtdJogadasPorRodada}");
        // EXPECTATIVA: Deve ser 4
        if(meuHeroi.QtdJogadasPorRodada == 4) Console.WriteLine("Check: SUCESSO (Ganhou bônus)");
        else Console.WriteLine("Check: FALHA");

        Console.WriteLine("--------------------------------------------------");

        // --- TESTE B: TROCAR PELO ITEM COMUM (A Lógica de Swap) ---
        Console.WriteLine("\n>>> TESTE 2: Trocando Faturamentus pela Espada...");
        // Aqui o Faturamentus deve rodar o 'RemoverBeneficio' antes da espada entrar
        meuHeroi.TrocarItem(espadinha);

        Console.WriteLine($"STATUS ATUAL -> Jogadas por Rodada: {meuHeroi.QtdJogadasPorRodada}");
        // EXPECTATIVA: Deve voltar para 1 (já que a espada não dá bônus de jogada)
        if (meuHeroi.QtdJogadasPorRodada == 1) Console.WriteLine("Check: SUCESSO (Bônus removido corretamente)");
        else Console.WriteLine($"Check: FALHA (Ainda está com {meuHeroi.QtdJogadasPorRodada})");

        Console.WriteLine("--------------------------------------------------");

        // --- TESTE C: VERIFICAR INVENTÁRIO ---
        Console.WriteLine("\n>>> TESTE 3: Verificando Inventário");
        // O Faturamentus deve estar de volta na mochila, e a Espada fora
        bool temPedra = meuHeroi.Inventario.Contains(placaPedra);
        bool temEspada = meuHeroi.Inventario.Contains(espadinha);

        Console.WriteLine($"Pedra está na mochila? {temPedra} (Esperado: True)");
        Console.WriteLine($"Espada está na mochila? {temEspada} (Esperado: False)");
        
        Console.ReadKey();
    }
}