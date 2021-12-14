from files import previsoes, schedule, funcs
from math import inf
import itertools

p = list(previsoes)

d = list(schedule)          # Segunda ...
t = list(schedule[d[0]])    # Manha ...
funcsList = list(funcs)      # António Manel ...

clientesMaximo = -1

for c in previsoes:
    clientesMaximo = max(clientesMaximo, previsoes[c][t[0]] + previsoes[c][t[1]])


def state_score(state):
    score = 0

    for weekdays in d:
        manha = len(state[weekdays][t[0]])
        tarde = len(state[weekdays][t[1]])

        # TO DELETE
        # score += manha
        # score += tarde


        # y = (clientesDia * 2/3 * funcionariosTotal) / clientesMaximo
        # ideal =  (previsoes[weekdays] * 2/3 * len(funcs)) / clientesMaximo
        idealManha =  (previsoes[weekdays][t[0]] * 1 * len(funcs)) / clientesMaximo
        idealTarde =  (previsoes[weekdays][t[1]] * 1 * len(funcs)) / clientesMaximo
        idealManha = int(idealManha)
        idealTarde = int(idealTarde)

        # Calculo valores ideais
        # if tarde != int(idealTarde):
        #     if tarde > idealTarde:
        #         multiplicador = tarde - idealTarde
        #     elif tarde < idealTarde:
        #             multiplicador = idealTarde - tarde
        #     score -= pow(200, (multiplicador/4))
        # else:
        #     score += 200

        # if manha != int(idealManha):
        #     if manha > idealManha:
        #         multiplicador = manha - idealManha
        #     elif manha < idealManha:
        #             multiplicador = idealManha - manha
        #     score -= pow(200, (multiplicador/4))
        # else:
        #     score += 200

        # Pontuacao
        if(manha == idealManha):
            score += 100 * manha
        # if(len(state[weekdays][t[0]]) > idealManha):
        #     score += 50

        if(tarde == idealTarde):
            score += 100 * tarde
        # if(len(state[weekdays][t[1]]) > idealTarde):
        #     score += 50

        # Penalizacao por excesso
        if(manha > idealManha):
            score -= 1000 - 100 * (manha - idealManha)
        if(tarde > idealTarde):
            score -= 1000 - 100 * (tarde - idealTarde)

        # Penalizacao por defeito
        if(manha < idealManha):
            score -= 1000 - 100 * (idealManha - manha)
        if(tarde < idealTarde):
            score -= 1000 - 100 * (idealTarde - tarde)

        if(manha == 0 or tarde == 0):
            score -= 100

    return score


def state_score_test(state):
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
        idealManha =  (previsoes[weekdays][t[0]] * 1 * len(funcs)) / clientesMaximo
        idealTarde =  (previsoes[weekdays][t[1]] * 1 * len(funcs)) / clientesMaximo

        # print(weekdays)
        # print(ideal)
        # input()
        if idealTarde < 3:
            idealManha = 3
            idealTarde = 3
            ideal = 3

        ideal = idealManha + idealTarde
        #
        # Trabalhadores por Turnos
        if tarde != 0:
            if tarde > idealTarde:
                multiplicador = tarde - idealTarde
            else:
                multiplicador = idealTarde / tarde
            score += multiplicador * 200

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