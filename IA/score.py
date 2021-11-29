from files import previsoes, schedule, funcs
import itertools

p = list(previsoes)

d = list(schedule)          # Segunda ...
t = list(schedule[d[0]])    # Manha ...
funcsList = list(funcs)      # António Manel ...


def state_score(state):
    score = 0
    maxfunc = -1000
    # Previsao Clientes
    for weekdays in d:
        for x in range(0, 7):
            diario = 0
            for turns in t:
                diario += len(state[weekdays][turns])     # Total funcionarios diario
            score += diario
            maxfunc = max(maxfunc, diario)

    # Minimo Funcionarios
    pass
