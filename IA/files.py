import json

with open("schedule.json", "r") as f:
    scheduleJSON = json.load(f)

with open("funcs.json", "r") as f:
    funcsJSON = json.load(f)

with open("previsoes.json", "r") as f:
    previsoesJSON = json.load(f)

week = list(scheduleJSON)          # Segunda ...
turns = list(scheduleJSON[days[0]])    # Manha ...
funcs = list(funcsJSON)      # António Manel ...