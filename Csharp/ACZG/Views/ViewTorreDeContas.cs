namespace ACZG.Views;

public class ViewTorreDeContas : ViewBase
{
    public bool IniciarFaseSandubinha()
    {
        return ExibirNarrativa("=== 4. TORRE DE CONTAS A RECEBER === \n" +
                               "A terrível torre é onde seres mágicos recebem o pagamento por seu árduo trabalho.\n" +
                               " Dizem que a ruína perto da torre era a cidade mais próxima do “grito”, terra natal dos Analyticaes di Glosium",
            "Hot Dog chega ao primeiro andar da torre. Seu mascote sente uma energia mágica mortífera vindo do topo.\n" +
            " Sem dúvidas, Glozium estava lá…",
            "A parede se abre e sai dela o penúltimo monstro a ser enfrentado",
            "Hot Dog - Uma estátua na forma de meu pai quando jovem, por que?",
            "Sandubinha reverse - então você chegou até aqui, sou a estátua do último herói, você é forte mas será que consegue derrotar um herói lendário?\n");
    }

    public void MostrarCenaVitoriaSandubinha()
    {
        ExibirNarrativa("Sandubinha reverse - …\n" +
                        "Hot Dog - É assustador olhar para essa estátua despedaçada e ver a forma do meu pai\n" +
                        "Sandubinha ganha o artefato “Colar da estátua sagrada”");
    }

    public void MostrarCenaDerrotaSandubinha()
    {
        ExibirNarrativa("Sandubinha reverse - a vitória é minha!\n" +
                        "O mundo foi destruído por Glozium, uma fatilidade terrível... Fim de jogo!");
    }

    public bool IniciarFaseGlozium()
    {
        return ExibirNarrativa(
            "Hot Dog sente que no topo da Torre de Contas a Receber reside Glozium, é uma habilidade dos Analyticaes di Glosium. \n",
            "Hot Dog sente que no topo da Torre de Contas a Receber reside Glozium, é uma habilidade dos Analyticaes di Glosium.",
            "Hot dog entra na sala do chefe e se depara com a presença arrepiante de Glozium sentado no trono",
            "Glozium - Novamente um rato invadiu meu recinto; desta vez irá servir de alimento para meus escravos",
            "Hot Dog - Você é como meu pai descreveu. Não cansa de ser terrivelmente molestado por gerações?",
            "Glozium - ha ha ha ha! que petulante",
            "Glozium - Chegou a época, mas mandaram outro pobre coitado; péssima ideia",
            "Hot Dog - Vou te destruir, Glozium, e garantir sua aniquilação total e permanente, já me diga onde está minha mãe!",
            "Glozium - E o que um garoto com cabeça de cachorro quente pode fazer contra um monstro milenar, \n" +
            "Que presenciou eventos tão singulares, que caminhou sobre a superfície de vulcões e subjugou a humanidade?",
            "Hot Dog lança sua espada girando no ar que fere o monstro e retorna a sua mão",
            "Hot Dog - não subestime alguém com cabeça de cachorro quente, sou um descendente dos Analyticaes di Glosium.\n" +
            "Te procurei em cada canto do inferno para reduzir você a Zero e finalmente resgatar minha mãe!",
            "Glozium - interessante, aceito seu pedido de batalha, me derrote e você poderá ver sua mãe");
    }

    public void MostrarFinal(bool vitoria, bool temEspadaZG, bool desistencia)
    {
        if (desistencia)
        {
            ExibirNarrativa("Glozium liberta herói e mascote, que sobrevivem, mas desonrados.",
                "Glozium destrói o mundo.",
                "BAD ENDING (COVARDE)");
        }
        else if (!vitoria)
        {
            ExibirNarrativa("Glozium: 'Finalmente! um herói bosta que apenas aumentou meus poderes'",
                "O mundo foi destruído. FIM DE JOGO.");
        }
        else
        {
            ExibirNarrativa(" Hot Dog golpeia Glozium no peito. O monstro sorri em agonia",
                "Glozium - você conseguiu… vou cumprir minha promessa, aqui está sua mãe, aproveite seus últimos momentos hahaha!",
                "O corpo de Glozium se desfigura, revelando ser a mãe de Hot Dog.",
                "Hot Dog - não pode ser… mãe? o que foi que eu fiz!",
                "Hot Dog segura a mãe nos braços com a espada ainda em seu peito",
                "Mãe: 'Você apenas cumpriu seu dever filho...");

            if (temEspadaZG)
            {
                ExibirNarrativa(
                    "Quando parecia que tudo havia acabado, o poder milagroso da Espada ZG - acumulado ao longo de todo o ciclo hospitales\n" +
                    " - se funde a mãe de Hot Dog, a curando… a espada cumpriu seu dever…",
                    "O herói derrotou Glozium e a paz retornou ao mundo.",
                    "Ele viverá feliz com sua família \n" + "Muito obrigado, herói!",
                    "Texto: Fim de jogo!");
            }
            else
            {
                ExibirNarrativa(
                    "A mãe de Hot Dog falece, o herói a repousa gentilmente no chão e se levanta…",
                    "O silêncio preenche a sala. Glozium foi detido por mais um ano, mas a que custo?",
                    "Sob forte pressão mental pelas perdas, e com o sangue da mãe nas mãos, o herói, em profunda tristeza e decepção, caminha silenciosamente até a janela",
                    "E se joga da torre…",
                    "Glozium foi derrotado ao custo mais alto possível, o mundo seguirá normalmente por mais 1 ano… Fim de Jogo!");
            }
        }
    }
}