import json
import itertools
from dotenv import load_dotenv
from os import environ

load_dotenv()

with open(environ.get("horario"), "r") as f:
    horarioJSON = json.load(f)

with open(environ.get("funcionarios"), "r") as f:
    funcionariosJSON = json.load(f)

with open(environ.get("previsoes"), "r") as f:
    previsoesJSON = json.load(f)

# Extraction of Keys
week = list(horarioJSON)                # Segunda, Terca, etc.
turns = list(horarioJSON[week[0]])      # manha, tarde
funcs = list(funcionariosJSON)          # 0, 1, 2, 3, 4, etc.

workingDays = int(environ.get("working-days"))

# Generation of possible combinations for each variable
daysComb = list(itertools.combinations(week, workingDays))
shiftsComb = list(itertools.product(turns, repeat=workingDays))

# Finding the busiest day in the week and keep its value
clientesMaximo = -1
for p in previsoesJSON:
    clientesMaximo = max(clientesMaximo, previsoesJSON[p][turns[0]] + previsoesJSON[p][turns[1]])

# The acceptable minimum number of funcionarios for each shift
margin = (1/4) * len(funcs)