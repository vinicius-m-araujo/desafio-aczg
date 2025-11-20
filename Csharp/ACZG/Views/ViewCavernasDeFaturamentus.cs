namespace ACZG.Views;

public class ViewCavernasDeFaturamentus : ViewBase
{
    public void IniciarFase()
    {
        ExibirNarrativa("=== 2.Caverna de Faturamentus === \n" +
                        "Existe sempre um preço a se pagar pela cura do corpo e da alma, após a floresta do atendimentus " +
                        "seu preço é calculado de acordo com o tipo de contrato divino que você tem…");
        
        ExibirNarrativa("Explorando a caverna com uma tocha, Hot Dog ouve sons metálicos ao longe." +
                        " Ao alcançar uma área iluminada por minérios misteriosos, encontra três caminhos e um enigma indicando a pista para a escolha certa:");
        
        ExibirNarrativa("Do enfermo vem o início, do registro o meio, do pagamento o fim do anseio. " +
                        "Gira sem parar nos salões do curar — que ciclo é esse a sustentar?\n" +
                        "A) O Ciclum Receitatus Hospitalis\n" +
                        "B) O Rito dos Curandeiros Eternos\n" +
                        "C) A Roda da Vida e da Cura");
        
        
    }

    public void MostrarCenaVitoria()
    {
        ExibirNarrativa("Ansião faturador - muito obrigado, mas tô ocupado demais para agradecimentos longos, tome o artefato sagrado e siga em frente ");
        ExibirNarrativa("O herói ganha o artefato “Faturamentus”");
    }

    public void MostrarCenaDerrota()
    {
        ExibirNarrativa("Ansião faturador - herói merda, nem para cumprir o trabalho dele, estamos perdidos");
        ExibirNarrativa("O mundo foi destruído por Glozium, uma fatalidade terrível… Fim de jogo!");
    }
}