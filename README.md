#  RogueLike (Fase 06)

###  Projeto de Recurso para Linguagens de Programação

Trabalho realizado por:

* Hugo Feliciano (a21805809)

* Pedro Fernandes (a21803791)

* Rita Saraiva (a21807278)

>Desenvolvido num [repositório git público][repo].

##  Divisão de Tarefas

* Hugo Feliciano

   -- Fase 01 e 02.

   -- Ajudou na Fase 03, 04, 06 e no UML.

* Pedro Fernandes

    -- Fase 04, 06. Fluxograma.

    -- Ajudou na Fase 01, 03 e 05.

(Grande parte das sessões de código por parte dos alunos Hugo Feliciano
e Pedro Fernandes foram realizadas em conjunto.)

* Rita Saraiva

    -- Fase 03, 05. UML, Relatório e Doxyfile.

    -- Ajudou na Fase 01 e 02.

##  Algoritmos e Soluções

* Level Difficulty: 
  - levelDifficulty = currentLevel + gameDifficulty

* Number Of Traps:
  - numberOfTraps = numberOfCells * levelDifficulty / 25.
  
     Increases as the player progresses through the game  

* Number Of Weapons:
  - numberOfWeapons = numberOfCells / (levelDifficulty / 0.9).
  
     Decreases as the player progresses through the game 

* Number Of Foods:
  - numberOfFoods = numberOfCells / (levelDifficulty / 1.9).
  
     Decreases as the player progresses through the game 

* Número da Cell de acordo com a sua posição no Board:
 -- cellNumber = cellRow * numberOfColumns + cellColumn +1.

###  UML
---

![UML][#img1]

###  Fluxograma
---
![Fluxograma][#img2]

##  Conclusões e matéria aprendida

Ao contrário da maioria da turma, o grupo tomou a decisão de desenvolver este

projeto antes de realizar o segundo trabalho prático, sendo que o grupo previu

 que não seria capaz de passar à disciplina na área prática. Sendo assim,

foi possível começar a desenvolver este antes dos outros grupos, sendo que ao

mesmo tempo o grupo tratava das outras disciplinas. O grupo, foi então capaz de

dar mais atenção e dedicar mais tempo a este projeto, especialmente quando

comparado com o primeiro que realizou (onde não se geriu corretamente a atenção

do grupo a esse mesmo).

Mais uma vez verificou-se conhecimentos adquiridos em aula, tendo o grupo sido

desafiado a implementar estes conhecimentos da forma mais eficiente possível.

Aplicou-se então hereditariedade, e diversas relações entre classes, de modo a

tornar a estrutura deste mais compacta e racional (refletindo assim sobre as

falhas cometidas no primeiro trabalho), criou-se um UML mais detalhado e

correto, aprendendo das falhas cometidas no anteriormente feito, corrigiu-se a

realização do relatório (respeitando agora o limite de caracteres). Fez-se

também por aplicar uma ética de trabalho mais organizada que permitiu igual

atenção a todos os elementos do trabalho que seriam avaliados, desta maneira

mantendo a qualidade do trabalho mais uniforme.


##  Referências

1. “Stack Overflow”, "help.Github" e “Medium.com” - Utilizados para esclarecer

dúvidas em relação ao Git e GitHub.

2. Troca de ideias entre membros deste grupo e Pedro Inácio e Rodrigo Pinheiro
   
(colegas de turma) em relaçãoà implementação de certas mecânicas.

3. PDF’s de aulas passadas - utilizados como referência e esclarecimento para
   
dúvidas em Git e C#.

4. Utilização da biblioteca de comandos .NET e API da Microsoft.

5. Aproveitamento da sugestão de resolução da fase 05, por parte do professor.


[#img1]:UML.png
[#img2]:Fluxograma.png
[repo]:https://github.com/Xx-hugo-xX/lp1_p2ep