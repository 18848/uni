from files import previsoes, schedule, funcs
from math import inf
import itertools

p = list(previsoes)

d = list(schedule)          # Segunda ...
t = list(schedule[d[0]])    # Manha ...
funcsList = list(funcs)      # António Manel ...

clientesMaximo = -1

for c in previsoes:
    clientesMaximo = max(clientesMaximo, previsoes[c])


def state_score(state):
    multiplicador = 0
    score = 0
    dia = 0
    maxfunc = -1000
    # Previsao Clientes
    for weekdays in d:
        count = 0
        score = 0
        # score for manha != tarde
        manha = len(state[weekdays][t[0]])
        tarde = len(state[weekdays][t[1]])
        
        if manha != 0:
            score += 500
        
        # print("1")
        # print(score)
        # input()

        if tarde != 0:
            score += 500

        # print("2")
        # print(score)
        # input()
        
        if manha > tarde:
            score -= 200

        # print("3")
        # print(score)
        # input()

        # y = (clientesDia * 2/3 * funcionariosTotal) / clientesMaximo
        # ideal =  (previsoes[weekdays] * 2/3 * len(funcs)) / clientesMaximo
        ideal =  (previsoes[weekdays] * 1 * len(funcs)) / clientesMaximo
        # print(weekdays)
        # print(ideal)
        # input()
        if ideal < 3:
            ideal = 3

        #
        # Trabalhadores por Turnos
        idealTarde = 0.8 * ideal
        if tarde != 0:
            if tarde > idealTarde:
                multiplicador = tarde / idealTarde
            else:
                multiplicador = idealTarde / tarde
            score += multiplicador * 200

        idealManha = ideal - idealTarde
        if manha != 0:
            if manha > idealManha:
                multiplicador = manha / idealManha
            else:
                multiplicador = idealManha / manha
            score += multiplicador * 200

        # print("ideal")
        # print(ideal)
        # input()

        # print("4")
        # print(score)
        # input()

        
        # Trabalhadores Diarios
        if ideal > (manha+tarde):
            multiplicador = (manha+tarde) / ideal
        else:
            multiplicador = ideal / (manha+tarde)

        score += multiplicador * 500

        maxfunc = max(maxfunc, manha + tarde)

    # print("ultimo")
    # print(score)
    # input()

    # Minimo Funcionarios
    return score