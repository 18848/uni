#from anytree import Node, RenderTree
#from anytree.exporter import DotExporter
from treelib import Tree, Node
from score import state_score
import itertools
import copy
from files import schedule, funcs

workingDays = 5
daysComb = list(itertools.combinations([0, 1, 2, 3, 4, 5, 6], workingDays))
turnsComb = list(itertools.product([0, 1], repeat=workingDays))

d = list(schedule)          # Segunda ...
print(d)
t = list(schedule[d[0]])    # Manha ...
print(t)
funcsList = list(funcs)      # António Manel ...


def BreadFirst():
    search = Tree()
    search.create_node("SearchTree", "search")
    isRoot = None
    level = None
    # result = Tree(data='begin')
    scoreMax = -1000
    idMax = 0
    lastBest = -1

    for f in range(0, len(funcsList)):
        level = list()
        
        # Combinações de Dias
        for days in daysComb:           # (0, 1, 2, 3, 4), (0, 1, 2, 3, 5), ...
            # Combinações de Turnos
            for turns in turnsComb:     # (0, 0, 0, 0, 1), (0, 0, 0, 1, 0), ...
                
                # Set Raw State
                if levels[f] is None:
                    new = copy.deepcopy(schedule)
                else:
                    new = copy.deepcopy(search.get_node[funcsList[f]] [lastBest].state)

                # Define New State
                for x in range(0, workingDays): 
                    new[d[days[x]]][t[turns[x]]].append(funcsList[f])

                # Get state score
                score = state_score(new)

                # If new MAX
                if scoreMax < score:
                    scoreMax = score
                    idMax = len(level) - 1

                # Add new state
                if levels[f] is None:
                    level.append(Node(str(funcsList[f]), parent=search, state=None, score=score))
                else:
                    level.append(Node(str(funcsList[f]), parent=levels[f][lastBest], state=new, score=score))
            print((RenderTree(search)))
            input()

        # Save current level and best state
        levels[f].append(copy.deepcopy(level))
        lastBest = idMax


    # for x in level:
    #     print(x.score)
    #     input()
    #     if x.score == scoreMax:
    #         print(x.state)

    print(prevLevel[lastBest].score)
    
    # print(RenderTree(search))

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

    # f = open("schedule.json", "r")
    # s = json.load(f)
    # f.close()

    # days = list(s)
    # turns = list(s[days[0]])