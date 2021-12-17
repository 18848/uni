from tree import Tree
from copy import deepcopy
from files import daysComb, turnsComb, scheduleJSON, funcsJSON, week, turns, funcs, workingDays
from math import inf
from search import search, find_best_score

def test():
    tree = Tree(data="root")
    tree.state = scheduleJSON

    state = search(int(funcs[0]), 1, tree)

    # (score, state) = find_best_score(tree)

    # print(best_score)
    print(state)


test()
