from anytree import Node, RenderTree

level = list()

root = Node('root')

level.append(Node('a', parent=root))
level.append(Node('b', parent=root))
level.append(Node('c', parent=root))

prevlevel = level

level = list()

level.append(Node('a', parent=prevlevel[1]))
level.append(Node('b', parent=prevlevel[1]))
level.append(Node('c', parent=prevlevel[1]))

prevlevel = level

level = list()

level.append(Node('d', parent=prevlevel[0]))
level.append(Node('e', parent=prevlevel[0]))
level.append(Node('f', parent=prevlevel[0]))

print(RenderTree(root))