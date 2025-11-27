namespace ACZG.Views;

public class ViewTorreDeContas : ViewBase
{
    public bool IniciarFase()
    {
        return ExibirNarrativa("=== 4. TORRE DE CONTAS A RECEBER === \n" + "A terrível torre é onde seres mágicos recebem o pagamento por seu árduo trabalho.\n" +
                               " Dizem que a ruína perto da torre era a cidade mais próxima do “grito”, terra natal dos Analyticaes di Glosium",
            "Hot Dog chega ao primeiro andar da torre. Seu mascote sente uma energia mágica mortífera vindo do topo.\n" +
            " Sem dúvidas, Glozium estava lá…",
            "A parede se abre e sai dela o penúltimo monstro a ser enfrentado",
            "Hot Dog - Uma estátua na forma de meu pai quando jovem, por que?",
            "Sandubinha reverse - então você chegou até aqui, sou a estátua do último herói, você é forte mas será que consegue derrotar um herói lendário?\n");
    }

    public void MostrarCenaVitoria()
    {
        ExibirNarrativa("Sandubinha reverse - …\n" +
                        "Hot Dog - É assustador olhar para essa estátua despedaçada e ver a forma do meu pai\n" +
                        "Sandubinha ganha o artefato “Colar da estátua sagrada”");
    }

    public void MostrarCenaDerrolta()
    {
        ExibirNarrativa("Sandubinha reverse - a vitória é minha!\n" +
                        "O mundo foi destruído por Glozium, uma fatilidade terrível... Fim de jogo!");
    }
}