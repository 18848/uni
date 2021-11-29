from tree import Tree
from score import state_score
import itertools
import copy
from files import schedule, funcs

workingDays = 5
daysComb = list(itertools.combinations([0, 1, 2, 3, 4, 5, 6], workingDays))
turnsComb = list(itertools.product([0, 1], repeat=workingDays))

d = list(schedule)          # Segunda ...
t = list(schedule[d[0]])    # Manha ...
funcsList = list(funcs)      # António Manel ...


def BreadFirst():
    search = Tree(data='begin')

    for f in funcsList:
        for days in daysComb:           # (0, 1, 2, 3, 4), (0, 1, 2, 3, 5), ...
            for turns in turnsComb:     # (0, 0, 0, 0, 1), (0, 0, 0, 1, 0), ...
                new = copy.deepcopy(schedule)
                for x in range(0, workingDays): 
                    new[d[days[x]]][t[turns[x]]].append(f)
                # search.add_child((new, state_score(new)))
                search.add_child(new)
        break
    input()

    state_score(search.children[0].data)

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
