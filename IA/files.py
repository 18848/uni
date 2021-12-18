import json
import itertools


with open("./data/schedule.json", "r") as f:
    scheduleJSON = json.load(f)

with open("./data/funcs.json", "r") as f:
    funcsJSON = json.load(f)

with open("./data/previsoes.json", "r") as f:
    previsoesJSON = json.load(f)

week = list(scheduleJSON)               # Segunda ...
turns = list(scheduleJSON[week[0]])     # Manha ...
funcs = list(funcsJSON)                 # António Manel ...
previsoes = list(previsoesJSON)

workingDays = 5

daysComb = list(itertools.combinations([0, 1, 2, 3, 4, 5, 6], workingDays))
turnsComb = list(itertools.product([0, 1], repeat=workingDays))


clientesMaximo = -1

for c in previsoesJSON:
    clientesMaximo = max(clientesMaximo, previsoesJSON[c][turns[0]] + previsoesJSON[c][turns[1]])

margin = (1/4) * len(funcs)