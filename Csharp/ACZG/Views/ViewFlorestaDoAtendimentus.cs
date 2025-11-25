namespace ACZG.Views;

public class ViewFlorestaDoAtendimentus : ViewBase
{
    public bool IniciarFase()
    {
        return ExibirNarrativa("=== 1. FLORESTA DO ATENDIMENTUS === \n" +
                               "Um lugar encantado, dizem que pessoas doentes ou com almas feridas podem ir a floresta para serem curadas" +
                               "A floresta parece mais sinistra que nunca, " +
                               "Hot Dog percorre lugares sombrios e neblinados enquanto fala com seu pai Sandubinha, " +
                               "que o instrui telepaticamente:" +
                               "Sandubinha - na floresta de Atendimentus, encontre o ser “Processus” ele irá te mostrar o monstro a ser enfrentado" +
                               "Porém Hot Dog se perde na floresta, mas de repente seu cachorro fareja " +
                               "algo e começa a correr, o herói o segue pois confia totalmente em seu querido animal" +
                               "Mergulhando nos arbustos de espinhos que rasgavam a pele, eles correm até um campo limpo e se deparam com algo terrível…" +
                               "Processus estava morto, caído aos pés de uma criatura humanoide com um olhar nojento e arrogante, como um demônio:" +
                               "Hot Dog - não há dúvidas, você é o inimigo, como você feriu o Processus? não era para seu poder afetar seres mágicos do tipo dele!" +
                               "Monstro - não afeta diretamente, mas interfere no equilíbrio, " +
                               "eu impeço o atendimento das almas, eu sou Anti-authorizatus! \n" +
                               "e mesmo esses seres precisam passar pelo Ciclo de Hospitales HAHAHA \n" +
                               "que pena, esse já era, agora é sua vez e depois matarei esse pirralho assustado nos arbustos, filho desse aqui" +
                               "Hot Dog - não se preocupe jovem, irei me vingar pelo amigo de meu pai!");
    }

    public void MostrarCenaVitoria()
    {
        ExibirNarrativa(
            "O filho de processus surge - muito obrigado, tome o artefato “Guia de atendimento” e vá para o próximo desafio, vou sepultar meu pai");
    }

    public void MostrarCenaDerrota()
    {
        ExibirNarrativa(
            " O monstro matou o filho de processus e o mundo foi destruído por Glozium, uma fatalidade terrível… Fim de jogo!");
    }
}