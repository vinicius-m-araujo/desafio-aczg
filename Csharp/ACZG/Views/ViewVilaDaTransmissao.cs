namespace ACZG.Views;

public class ViewVilaDaTransmissao : ViewBase
{
    public bool IniciarFase()
    {
        return ExibirNarrativa("=== 3. VILA DA TRANSMISSÃO === \n" +
                               "Uma vila mágica que recebe cobranças vindas das cavernas de Faturamentus.\n" +
                               "Os moradores entregam as mensagens na Torre.",
            "Hot Dog é bem recebido em sua chegada. Ele é convidado para um jantar ritualístico com comidas típicas",
            "Enquanto Salsichinha saboreava um delicioso bife de calango, os moradores contavam a Hot Dog que o monstro a ser enfrentado é um ser que se enterra.",
            "Para atacá-lo, ele terá que desenterrar o monstro e usar sua espada. Então, dão a ele um item a  “Bomba Mágica”",
            "Logo, um monstro em forma de verme surge do chão:\n" +
            "worm da transmissão - Você já tem sua arma… fui amigo do guardião dessas terras e transmitia as mensagens à torre após seu falecimento.\n" +
            "Mas Glozium me tornou seu escravo, sou obrigado a lutar com toda fúria. Assim como foi antes, livre-me do sofrimento…",
            "Hot Dog - Você também está preso a um destino que não escolheu, vou te libertar!");
    }

    public void MostrarCenaVitoria()
    {
        ExibirNarrativa(
            "Worm - muito obrigado, todo herói evitava essa batalha e seguia para a torre, agora sou livre!",
            "Hot Dog - evitava? E dá para seguir sem lutar? como assim?",
            "O herói ganha o artefato “Azah Transmissão”");
    }

    public void MostrarCenaDerrota()
    {
        ExibirNarrativa("Worm  - Sinto muito herói, que sua alma seja livre…",
            "O mundo foi destruído por Glozium, uma fatalidade terrível… Fim de jogo!");
    }
}