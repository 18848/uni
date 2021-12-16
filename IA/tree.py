from files import week, turns


class Tree():
    def __init__(self, data=None, state=None, score=None, parent=None):
        self.children = list()
        self.parent = parent
        self.data   = data
        self.state  = state
        self.score  = score

    def add_child(self, data, state, score):
        self.children.append(Tree(data=data, state=state, score=score, parent=self))

    def show_Tree(self, level=0):
        level += 1
        for t in self.children:
            if t is not None: 
                t.show_Tree(level=level)
        print(str(level*">") + str(self.data))


# class State():
#     def __init__(self, lst=None, turns=None, days=None, funcID=None):
#         if turns is not None and days is not None and funcID is not None:
#             for d in days:
#                 if d == 0:
#                     self.segunda = Turn(day[d])
#                 elif d == 1:
#                     self.terca = Turn(day[d])
#                 elif d == 2:
#                     self.quarta = Turn(day[d])
#                 elif d == 3:
#                     self.quinta = Turn(day[d])
#                 elif d == 4:
#                     self.sexta = Turn(day[d])
#                 elif d == 5:
#                     self.sabado = Turn(day[d])
#                 elif d == 6:
#                     self.domingo = Turn(day[d])
#         elif lst is not None:
#             transform_list(lst)
#         else:
#             self.segunda = None
#             self.terca = None
#             self.quarta = None
#             self.quinta = None
#             self.sexta = None
#             self.sabado = None
#             self.domingo = None

#     def transform_list(self, lst):
#         for d in range(0, len(week)):
#             day = week[d]
#             if d == 0:
#                 self.segunda = Turn()
#             elif d == 1:
#                 self.terca = Turn(day[0], day[1])
#             elif d == 2:
#                 self.quarta = Turn(day[0], day[1])
#             elif d == 3:
#                 self.quinta = Turn(day[0], day[1])
#             elif d == 4:
#                 self.sexta = Turn(day[0], day[1])
#             elif d == 5:
#                 self.sabado = Turn(day[0], day[1])
#             elif d == 6:
#                 self.domingo = Turn(day[0], day[1])


# class Turn():
#     def __init__(self, data=None):
#         if data is None:
#             self.manha = lst()
#             self.tarde = lst()
#         elif data == 0:
#             self.manha.append(data)
#         elif data == 1:
#             self.tarde.append(data)
