#! .\venv\Scripts\python.exe
from math import inf, ceil
from copy import deepcopy

from tree import Tree
from score import state_score, margin, test
from files import funcs, workingDays, \
    horarioJSON as horario, daysComb, shiftsComb

def main():
    tree = Tree(data="root")
    bestState = horario

    aux = tree
    # Foreach funcionario
    for f in funcs:
        scoreMax = -inf
        idMax = 0

        # Days Combinations         # (0, 1, 2, 3, 4), (0, 1, 2, 3, 5), ...
        for day in daysComb:
            # Shifts Combinations   # (0, 0, 0, 0, 1), (0, 0, 0, 1, 0), ...
            for shift in shiftsComb:
                new = deepcopy(bestState)       # Set Raw State

                for x in range(0, workingDays): # Define New State
                    new[day[x]][shift[x]].append(int(f))

                """
                Given a variable number of funcionarios,
                it's calculated a 'margin' wich is defined
                as the acceptable minimum for each shift
                """
                if int(f) <= 2 * ceil(margin):
                    if test(new):   # If well defined state
                        score = state_score(new, int(f))   # Calculate Score 

                        aux.add_child(data=None, state=new, score=score)
                        if int(f) % 2 == 0:
                            """
                            Alternate saving rule for each funcionario
                            """
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
