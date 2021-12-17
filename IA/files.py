import json
import itertools


with open("schedule.json", "r") as f:
    scheduleJSON = json.load(f)

with open("funcs.json", "r") as f:
    funcsJSON = json.load(f)

with open("previsoes.json", "r") as f:
    previsoesJSON = json.load(f)

week = list(scheduleJSON)          # Segunda ...
turns = list(scheduleJSON[week[0]])    # Manha ...
funcs = list(funcsJSON)      # António Manel ...
workingDays = 5

daysComb = list(itertools.combinations([0, 1, 2, 3, 4, 5, 6], workingDays))
turnsComb = list(itertools.product([0, 1], repeat=workingDays))