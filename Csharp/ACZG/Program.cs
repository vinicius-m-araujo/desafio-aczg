using ACZG.Views;

class Program
{
    public static void Main(string[] args)
    {
        var teste = new ViewFlorestaDoAtendimentus();
        while (true)
        {
            var opcao = teste.ExibirMenuInicial();
            if(opcao == 1) teste.IniciarFase();
            if(opcao == 2) teste.FecharPrograma();
            break;
        }
    }
}