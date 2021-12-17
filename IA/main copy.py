from tree import Tree
from score import state_score, state_eval
import itertools
import copy
from files import scheduleJSON, funcsJSON, week, turns, funcs, workingDays
from math import inf

daysComb = list(itertools.combinations([0, 1, 2, 3, 4, 5, 6], workingDays))
turnsComb = list(itertools.product([0, 1], repeat=workingDays))

def test():
    tree = Tree(data="root")
    bestState = scheduleJSON
    lastBest = -1

    aux = tree
    for f in funcs:
        scoreMax = -inf
        idMax = 0

        # Combinações de Dias
        for d in daysComb:           # (0, 1, 2, 3, 4), (0, 1, 2, 3, 5), ...
            # Combinações de Turnos
            for t in turnsComb:     # (0, 0, 0, 0, 1), (0, 0, 0, 1, 0), ...
                # newstate = State(days=d, turns=t, funcID=int(f))
                
            ## Without Class
                new = copy.deepcopy(bestState) # Set Raw State
                # Define New State
                for x in range(0, workingDays):
                    day = week[d[x]]
                    turn = turns[t[x]]
                    new[day][turn].append(int(f))
                    

                # If well defined state
                if state_eval(new):
                    # Get state score
                    score = state_score(new)
                    aux.add_child(data=None, state=new, score=score)

                    # If new MAX
                    if scoreMax < score:
                        # if int(f) + 1 == len(funcs) and scoreMax == score:
                        #     somelist.append(len(level) - 1)
                        scoreMax = score
                        idMax = len(aux.children) - 1
        bestState = aux.children[idMax].state
        aux = aux.children[idMax]

    print(aux.state)
    print(scoreMax)

    # input()


test()
