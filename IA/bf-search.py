from tree import Tree
from anytree
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
    search = Tree(data={'state':schedule, 'score':0})
    # result = Tree(data='begin')
    scoreMax = -1000
    idMax = 0

    for f in funcsList:
        # Copy best state
        new = copy.deepcopy(search.children[idMax].data[])
        # Combinações de Dias
        for days in daysComb:           # (0, 1, 2, 3, 4), (0, 1, 2, 3, 5), ...
            # Combinações de Turnos
            for turns in turnsComb:     # (0, 0, 0, 0, 1), (0, 0, 0, 1, 0), ...
                for x in range(0, workingDays): 
                    new[d[days[x]]][t[turns[x]]].append(f)
                # Get state score
                score = state_score(new)
                # If new MAX
                if scoreMax < score:
                    scoreMax = score
                    idMax = len(search.children)
                # Add new state
                search.add_child(data={'state':schedule, 'score':score})

        search = search.children[idMax].add_child(data={'state':schedule, 'score':scoreMax})
        search.show_Tree()
        input()
        break

    print(scoreMax)
    input()

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