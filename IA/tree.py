
class Tree():
    def __init__(self, data):
        self.children = list()
        self.data = data

    def add_child(self, data):
        self.children.append(Tree(data))

    def show_Tree(self, level=0):
        print(str(level*">") + str(self.data))
        level += 1
        for t in self.children:
            if t is not None: 
                t.show_Tree(level=level)


# t = Tree(0)
# t.add_child(1)
# t.add_child(2)
# t.add_child(3)
# t.add_child(4)
# for x in t.children:
#     x.add_child("a")
# t.show_Tree()