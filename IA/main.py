#from anytree import Node, RenderTree
#from anytree.exporter import DotExporter
#from treelib import Tree, Node
from score import state_score
import itertools
import copy
from files import schedule, funcs
from math import inf

workingDays = 5
daysComb = list(itertools.combinations([0, 1, 2, 3, 4, 5, 6], workingDays))
turnsComb = list(itertools.product([0, 1], repeat=workingDays))

d = list(schedule)          # Segunda ...
print(d)
t = list(schedule[d[0]])    # Manha ...
print(t)
funcsList = list(funcs)      # António Manel ...

def test():
    bestState = schedule
    level = None
    # result = Tree(data='begin')
    scoreMax = -inf
    idMax = 0
    lastBest = -1

    for f in funcsList:
        scoreMax = 0
        level = list()
        scoreMax = -inf

        # Combinações de Dias
        for days in daysComb:           # (0, 1, 2, 3, 4), (0, 1, 2, 3, 5), ...
            # Combinações de Turnos
            for turns in turnsComb:     # (0, 0, 0, 0, 1), (0, 0, 0, 1, 0), ...
                
                # Set Raw State
                new = copy.deepcopy(bestState)

                # Define New State
                for x in range(0, workingDays): 
                    new[d[days[x]]][t[turns[x]]].append(int(f))

                # Get state score
                score = state_score(new)

                level.append((new, score))

                # If new MAX
                if scoreMax < score:
                    scoreMax = score
                    idMax = len(level) - 1


                # Add new state
        bestState = copy.deepcopy(level[idMax][0])
        # input()
    for l in level:
        if l[1] == -3000:
            print(l[0])
            print()

    print(level[idMax][0])


    # 'António Manel/Marília Retorno/João o Cadeirão/Pedro Ribanceira/Mesmeldes Antonieta/Rebinde Coscuvite/Abilio Girandolas/Fazmindo Numquero/Germina Flores/Carpim Teiro/Quim Bestiga/Manel Carrossel/Joana Reboliço/Obrigham Ahir'
    input()
    print(scoreMax)

    print("done")


# def transition():
#     days = 7
#     turns = 2
#     lst = list()

#     for x in range(0, days - 1):
#         for y in range(0, turns - 1):
#             lst.append(f"{x},{y}")


def iter():

    daycomb = list(itertools.combinations([0, 1, 2, 3, 4, 5, 6], 5))
    turnscomb = list(itertools.product([0, 1], repeat=5))

    print(daycomb[0][0])