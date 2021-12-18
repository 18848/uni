from files import funcs, daysComb, turnsComb, workingDays, week, turns
from tree import Tree
from copy import deepcopy
from math import inf
from score import state_score, state_eval

best_score = -inf
best_state = None

def search(depth, limit, tree, last_best=None):

    best_score = -inf
    best_state = deepcopy(last_best)
    # for f in funcs:
    # print(last_score, last_state)
    # # input()
    # best_score = -inf
    # best_state = deepcopy(last_state)
    # idMax = 0

    for d in daysComb:          # Combinações de Dias
        for t in turnsComb:     # Combinações de Turnos

            new = deepcopy(tree.state) # Set Raw State
            # Define New State
            for x in range(0, workingDays):
                day = week[d[x]]
                turn = turns[t[x]]
                new[day][turn].append(depth)

            if state_eval(new):
                score = state_score(new)

                if best_score < score:
                    # print(best_score)
                    # print(best_state)
                    # input()
                    best_score = score
                    best_state = deepcopy(new)
                # Add new node
                tree.add_child(data=None, state=new, score=score)

    if depth == limit:
        # print(best_score, best_state)
        # print(len(tree.children))
        # input()
        return (tree)
    elif tree is not None:
        for element in tree.children:
            element.children = list()
            element.children.append((search(depth + 1, limit, element, last_best=deepcopy(best_state))))
    
    return deepcopy(best_state)
    
def simple_search(tree, last_best=None):
    # for f in funcs:
    # print(last_score, last_state)
    # # input()
    # best_score = -inf
    # best_state = deepcopy(last_state)
    # idMax = 0
    for f in funcs:
        best_score = -inf
        best_state = deepcopy(last_best)
        for d in daysComb:          # Combinações de Dias
            for t in turnsComb:     # Combinações de Turnos

                new = deepcopy(tree.state) # Set Raw State
                # Define New State
                for x in range(0, workingDays):
                    day = week[d[x]]
                    turn = turns[t[x]]
                    new[day][turn].append(depth)

                if state_eval(new):
                    score = state_score(new)

                    if best_score < score:
                        # print(best_score)
                        # print(best_state)
                        # input()
                        best_score = score
                        best_state = deepcopy(new)
                    # Add new node
                    tree.add_child(data=None, state=new, score=score)

    return deepcopy(best_state)


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
