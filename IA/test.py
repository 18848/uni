from treelib import Tree, Node
from score import state_score
import itertools
import copy
from files import schedule, funcs
from math import inf
from schedule import Schedule

workingDays = 5
daysComb = list(itertools.combinations([0, 1, 2, 3, 4, 5, 6], workingDays))
turnsComb = list(itertools.product([0, 1], repeat=workingDays))

d = list(schedule)          # Segunda ...
print(d)
t = list(schedule[d[0]])    # Manha ...
print(t)
funcsList = list(funcs)      # António Manel ...

def main():
    tree = new_tree(state=schedule)

    tree.show()


def new_level(origin, func):
    level = list()

    # Combinações de Dias
    for days in daysComb:           # (0, 1, 2, 3, 4), (0, 1, 2, 3, 5), ...
        # Combinações de Turnos
        for turns in turnsComb:     # (0, 0, 0, 0, 1), (0, 0, 0, 1, 0), ...
            # Set Raw State
            new = copy.deepcopy(origin)

            # Define New State
            for x in range(0, workingDays):
                new[d[days[x]]][t[turns[x]]].append(int(func))
            
            level.append(new)
            # # Get state score
            # score = state_score(new)

            # # If new MAX
            # if scoreMax < score:
            #     scoreMax = score
    return level


    # tree.create_node(funcs[0], 0, parent="root")
def new_tree(tree=None, state=None, depth=0, curparrent=None, idx=1):
    # New Tree
    if tree is None:
        tree = Tree()
        tree.create_node("Root", "root")
        curparrent=depth
        tree.create_node(depth, curparrent, parent="root")

    # Each func possible states
    level = new_level(state, depth)

    for l in level:
        # s = Schedule(l)
        tree.create_node(identifier=idx, parent=curparrent, data=l)
        # tree.add_node(l, parent=idx)
        if (depth + 1) != len(funcsList):
            subtree = tree.subtree(idx)
            node = subtree.get_node(idx)
            newTree = new_tree(tree=subtree, state=node.data, depth=depth + 1, curparrent=idx ,idx=idx + 1)
        idx += 1
    return tree

    # for node in tree.get_node(f):
    #     level.append(new_tree(tree, node, f + 1))

