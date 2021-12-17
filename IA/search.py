from files import funcs, daysComb, turnsComb, workingDays, week, turns
from tree import Tree
from copy import deepcopy
from math import inf
from score import state_score, state_eval


def search(depth, limit, tree):

    # for f in funcs:
    scoreMax = -inf
    idMax = 0

    for d in daysComb:          # Combinações de Dias
        for t in turnsComb:     # Combinações de Turnos

            new = deepcopy(tree.state) # Set Raw State
            # Define New State
            for x in range(0, workingDays):
                day = week[d[x]]
                turn = turns[t[x]]
                new[day][turn].append(depth)

            # If well defined state
            if state_eval(new):
                # Get state score
                score = state_score(new)
                tree.add_child(data=None, state=new, score=score)

    if depth == limit:
        return tree
    elif tree is not None:
        for element in tree.children:
            element.children = list()
            element.children.append((search(depth + 1, limit, element)))
    

def find_best_score(tree):
    best_score = -inf
    best_state = None
    for node in tree.children:
        if node.children is None:
            if best_score <= node.score:
                best_score = node.score
                best_state = deepcopy(node.state)
            return (best_score, best_state)
        elif node is not None:
            find_best_score(node)
    return (best_score, best_state)
