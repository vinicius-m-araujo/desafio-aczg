namespace ACZG.Views;

public class ViewCavernasDeFaturamentus : ViewBase
{
    public bool IniciarFase()
    {
        return ExibirNarrativa("=== 2. CAVERNA DE FATURAMENTUS === \n" +
                               "Existe sempre um preço a se pagar pela cura do corpo e da alma, após a floresta do atendimentus " +
                               "seu preço é calculado de acordo com o tipo de contrato divino que você tem…",
            "Explorando a caverna com uma tocha, Hot Dog ouve sons metálicos ao longe." +
            "Ao alcançar uma área iluminada por minérios misteriosos, encontra três caminhos e um enigma indicando a pista para a escolha certa:");
    }

    public bool IniciarLuta()
    {
        return ExibirNarrativa(
            "Hot Dog alcança um novo local, onde os Anciões do Faturamento trabalham sem dar atenção aos arredores. \n " +
            "De repente, ele encontra o monstro da caverna — um cavaleiro infernal forjado por Glozium, afiando sua espada.",
            "Glozium Administratus - você é o herói deste ano? não me parece grande coisa. \n" +
            "Não sou muito de conversa, venha lutar, irei te fatiar e servir pros lacaios de meu mestre!",
            "Hot Dog - algumas piadas ruins podem até me fazer rir, você é uma dessas, hahaha… se prepare!");
    }

    public void MostrarCenaVitoria()
    {
        ExibirNarrativa(
            "Ansião faturador - muito obrigado, mas tô ocupado demais para agradecimentos longos, tome o artefato sagrado e siga em frente \n",
            "O herói ganha o artefato “Faturamentus”");
    }

    public void MostrarCenaDerrota()
    {
        ExibirNarrativa("Ansião faturador - herói merda, nem para cumprir o trabalho dele, estamos perdidos",
            "O mundo foi destruído por Glozium, uma fatalidade terrível… Fim de jogo!");
    }
}