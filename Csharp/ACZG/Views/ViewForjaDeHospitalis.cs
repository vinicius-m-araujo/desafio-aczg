namespace ACZG.Views;

public class ViewForjaDeHospitalis : ViewBase
{
    public void BoasVindas()
    {
        ExibirNarrativa("Ferreiro: Bem-vindo, viajante.\n" +
                        "Ouvi dizer que você quer derrotar Glozium\n" +
                        "Forjarei a Espada ZG para você.",
            "Traga-me os 4 artefatos sagrados.");
    }

    public void ListarIngredientes(bool temFaturamentus, bool temGuia, bool temCapa, bool temColar)
    {
        Console.WriteLine("\nIngredientes necessários:");
        ExibirStatus("1. Faturamentus", temFaturamentus);
        ExibirStatus("2. Guia de Atendimento", temGuia);
        ExibirStatus("3. Capa Azah Transmissão", temCapa);
        ExibirStatus("4. Colar da estátua", temColar);
        Console.WriteLine();
    }

    private void ExibirStatus(string nomeItem, bool possui)
    {
        if (possui)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            ExibirNarrativa($"[OK] {nomeItem}");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            ExibirNarrativa($"[X]  {nomeItem} (Faltando)");
        }

        Console.ResetColor();
    }

    public bool ConfirmarForja()
    {
        Console.WriteLine("Você possui todos os ingredientes! Eles serão fundidos para criar a espada.");
        Console.ResetColor();
        Console.WriteLine("Deseja forjar a Espada ZG agora? [S/N]");
        string entrada = Console.ReadLine()?.ToUpper();
        return entrada == "S";
    }

    public void MostrarAnimacaoForja()
    {
        ExibirNarrativa("O ferreiro inicia o trabalho...\n" +
                        "CLANG!\n" +
                        "CLANG! ");
    }

    public void MostrarSucesso()
    {
        ExibirNarrativa("ESPADA ZG FORJADA COM SUCESSO!\n" +
                        "Ferreiro: 'Vá e cumpra seu destino!");
    }

    public void MostrarFalha()
    {
        ExibirNarrativa("Ferreiro: 'Você ainda não tem tudo. Volte quando reunir os 4 artefatos.'");
    }

    public void MostrarMensagemJaPossui()
    {
       ExibirNarrativa("Ferreiro: 'Você já porta a Espada ZG. Não há mais nada a fazer aqui.'");
    }
}