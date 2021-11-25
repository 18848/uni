from files import previsoes, schedule, funcs
import itertools

p = list(previsoes)

d = list(schedule)          # Segunda ...
t = list(schedule[d[0]])    # Manha ...
funcsList = list(funcs)      # António Manel ...

clientesMaximo = -1

for c in previsoes:
    clientesMaximo = max(clientesMaximo, previsoes[c])

multiplicador = 0

def state_score(state):
    score = 0
    dia = 0
    maxfunc = -1000
    # Previsao Clientes
    for weekdays in d:
        score = 0
        # score for manha != tarde
        manha = len(state[weekdays][t[0]])
        tarde = len(state[weekdays][t[1]])
        
        if manha == 0:
            score -= 50

        if tarde == 0:
            score -= 50

        # y = (clientesDia * 2/3 * funcionariosTotal) / clientesMaximo
        ideal =  (previsoes[weekdays] * 2/3 * len(funcs)) / clientesMaximo
        
        if manha > tarde:
            score -= 50

        #
        # Trabalhadores por Turnos
        idealTarde = 0.6 * ideal
        if tarde > idealTarde:
            multiplicador = idealTarde / ideal
        else:
            multiplicador = ideal / idealTarde
        score += multiplicador * 200

        #
        # Trabalhadores Diarios
        if ideal > (manha+tarde):
            multiplicador = (manha+tarde) / ideal
        else:
            multiplicador = ideal / (manha+tarde)

        score += multiplicador * 500

        maxfunc = max(maxfunc, manha + tarde)

    # Minimo Funcionarios
    return score
