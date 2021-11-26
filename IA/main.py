from anytree import Node, RenderTree, findall, find_by_attr
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
    search = Node('SearchTree')
    prevLevel = None
    path = list()
    # result = Tree(data='begin')
    scoreMax = -1000
    idMax = 0
    lastBest = -1

    for f in funcsList:
        level = list()
        # Combinações de Dias
        for days in daysComb:           # (0, 1, 2, 3, 4), (0, 1, 2, 3, 5), ...
            # Combinações de Turnos
            for turns in turnsComb:     # (0, 0, 0, 0, 1), (0, 0, 0, 1, 0), ...
                if prevLevel is None:
                    new = copy.deepcopy(schedule)
                else:
                    new = copy.deepcopy(prevLevel[lastBest].state)
                for x in range(0, workingDays): 
                    new[d[days[x]]][t[turns[x]]].append(f)
                # Get state score
                score = state_score(new)
                # If new MAX
                if scoreMax < score:
                    scoreMax = score
                    idMax = len(level)
                # Add new state
                if prevLevel is None:
                    level.append(Node(str(f), parent=search, state=new, score=score))
                else:
                    level.append(Node(str(f), parent=prevLevel[lastBest], state=new, score=score))
                # print(RenderTree(search))if prevLevel is None:
                # input()
        # Save current level and best state
        prevLevel = copy.deepcopy(level)
        # prevLevel = level
        lastBest = idMax

    # 'António Manel/Marília Retorno/João o Cadeirão/Pedro Ribanceira/Mesmeldes Antonieta/Rebinde Coscuvite/Abilio Girandolas/Fazmindo Numquero/Germina Flores/Carpim Teiro/Quim Bestiga/Manel Carrossel/Joana Reboliço/Obrigham Ahir'
    print(RenderTree(search))
    # print(findall(search,filter_=lambda node: prevLevel in node.path))
    # print(find_by_attr(search, name='score', value=802.0833333333334))
    input()
    print(scoreMax)

    # search.show_Tree()
    # print(daysComb)
    # print(turnsComb)
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
