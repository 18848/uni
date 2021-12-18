from math import inf, ceil
from copy import deepcopy

from tree import Tree
from score import state_score, margin, test
from files import week, turns, funcs, workingDays, \
    scheduleJSON, daysComb, turnsComb

def main():
    tree = Tree(data="root")
    bestState = scheduleJSON
    lastBest = -1
    levels = list()

    aux = tree
    for f in funcs:
        scoreMax = -inf
        idMax = 0

        # Combinações de Dias
        for d in daysComb:           # (0, 1, 2, 3, 4), (0, 1, 2, 3, 5), ...
            # Combinações de Turnos
            for t in turnsComb:     # (0, 0, 0, 0, 1), (0, 0, 0, 1, 0), ...
                new = deepcopy(bestState) # Set Raw State
                # Define New State
                for x in range(0, workingDays):
                    day = week[d[x]]
                    turn = turns[t[x]]
                    new[day][turn].append(int(f))

                # If well defined state
                if int(f) <= 2 * ceil(margin): 
                    if test(new):
                        score = state_score(new, int(f))
                        aux.add_child(data=None, state=new, score=score)
                        if int(f) % 2 == 0: 
                            if scoreMax <= score:
                                scoreMax = score
                                idMax = len(aux.children) - 1
                        else:
                            if scoreMax < score:
                                scoreMax = score
                                idMax = len(aux.children) - 1
                else:
                    score = state_score(new, int(f))
                    aux.add_child(data=None, state=new, score=score)
                    if scoreMax <= score:
                        scoreMax = score
                        idMax = len(aux.children) - 1
        bestState = aux.children[idMax].state
        aux = aux.children[idMax]

    print(bestState)
    print(scoreMax)


main()
