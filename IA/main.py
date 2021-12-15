#from anytree import Node, RenderTree
#from anytree.exporter import DotExporter
#from treelib import Tree, Node
from score import state_score, state_eval
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
    lastBest = -1
    somelist = list()

    for f in funcsList:
        level = list()
        scoreMax = -inf
        idMax = 0

        # Combinações de Dias
        for days in daysComb:           # (0, 1, 2, 3, 4), (0, 1, 2, 3, 5), ...
            # Combinações de Turnos
            for turns in turnsComb:     # (0, 0, 0, 0, 1), (0, 0, 0, 1, 0), ...
                new = copy.deepcopy(bestState) # Set Raw State
                # Define New State
                for x in range(0, workingDays): 
                    new[d[days[x]]][t[turns[x]]].append(int(f))

                # If well defined state
                if state_eval(new):
                    # Get state score
                    score = state_score(new)
                    level.append((new, score))

                    # If new MAX
                    if scoreMax <= score:
                        if int(f) + 1 == len(funcsList) and scoreMax == score:
                            somelist.append(len(level) - 1)
                        scoreMax = score
                        idMax = len(level) - 1
                        
        bestState = copy.deepcopy(level[idMax][0])
    # for l in somelist:
    #     print(level[l][0])
    #     print()
    
    # print(len(somelist))

    print(level[idMax][0])
    print(scoreMax)
    input()

    print("done")


test()