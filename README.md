# 🌭 A Jornada Épica de Sir Hot Dog - Desafio ACZG

![Status do Projeto](https://img.shields.io/badge/Status-Concluído-brightgreen)

## 📖 Sobre o Projeto
Este projeto é a solução desenvolvida para o desafio técnico **"ACZG-RPG 2 (Son)"**, proposto pela ZG Soluções.

O objetivo foi desenvolver um programa interativo (RPG textual) onde o jogador assume o papel do guerreiro **Sir Hot Dog**. Através de escolhas e comandos, o herói deve avançar por diferentes regiões, resolver enigmas e enfrentar criaturas para salvar a província de **Hospitalis** das forças sombrias de **Glozium**.

## ⚔️ Enredo
A província de Hospitalis, famosa por seus médicos mágicos, está sob ameaça. O vilão imortal Glozium retornou para espalhar o caos financeiro e doenças.

Para enfraquecê-lo, a guilda **Zerum Glozium** convocou o último descendente da linhagem dos *Analyticaes di Glosium*: **Sir Hot Dog**. Acompanhado de seu fiel escudeiro **Salsichinha**, ele deve percorrer o "Ciclum Receitatus Hospitalis" para obter os itens necessários e desafiar o vilão na Torre de Contas a Receber.

### 🗺️ Fases do Jogo
O jogo é dividido em regiões com desafios únicos:
1.  **Floresta do Atendimentus:** Onde o herói busca o "Guia de Atendimento" e enfrenta o monstro *Anti-authorizatus*
2.  **Cavernas de Faturamentus:** Um local de enigmas e minérios onde reside o *Glozium Administratus*.
3.  **Vila da Transmissão:** Onde o monstro *Worm* se esconde no subsolo.
4.  **Torre de Contas a Receber:** O palco da batalha final contra *Glozium*.

## 🎮 Mecânicas Implementadas

### Sistema de Batalha (Sorteio)
A mecânica central de combate é baseada em números secretos e sorteios:
* Tanto o Herói quanto o Monstro possuem um **Número Secreto** fixo.
* A cada rodada, números aleatórios são sorteados dentro do intervalo de vida do oponente.
* **Dano:** Se o número sorteado for igual ao número secreto do oponente, o dano é aplicado.
* **Evolução:** A cada vitória, o herói ganha +5 de vida máxima.

### Itens e Artefatos
O jogador pode utilizar itens estratégicos que alteram a dinâmica do sorteio:
* **Salsichinha (Mascote):** Realiza ataques combinados (+1 dano) e possui *skills* especiais.
* **Espada ZG:** Item lendário necessário para o final verdadeiro, permite sortear 40 números de uma vez.
* **Outros Artefatos:** Guia de Atendimento, Faturamentus, Bomba Mágica, etc.

## ✅ Requisitos do Desafio
A solução atende aos seguintes critérios estabelecidos no enunciado:
- [x] Implementação de pelo menos 2 fases do roteiro.
- [x] Interatividade do usuário via console/terminal.
- [x] Lógica de batalha baseada em RNG (Random Number Generator).
- [x] Possibilidade de jogar novamente ou desistir.



