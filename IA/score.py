from files import previsoes, schedule, funcs
from math import inf
import itertools

p = list(previsoes)

week = list(schedule)          # Segunda ...
t = list(schedule[week[0]])    # Manha ...
funcsList = list(funcs)      # António Manel ...

clientesMaximo = -1

for c in previsoes:
    clientesMaximo = max(clientesMaximo, previsoes[c][t[0]] + previsoes[c][t[1]])


def state_score(state):
    score = 0
    empty = 0

    for day in week:
        manha = len(state[day][t[0]])
        tarde = len(state[day][t[1]])

        # TO DELETE
        # score += manha
        # score += tarde

        # y = (clientesDia * 2/3 * funcionariosTotal) / clientesMaximo
        # ideal =  (previsoes[day] * 2/3 * len(funcs)) / clientesMaximo
        idealManha =  (previsoes[day][t[0]] * 1 * len(funcs)) / clientesMaximo
        idealTarde =  (previsoes[day][t[1]] * 1 * len(funcs)) / clientesMaximo
        idealManha = int(idealManha)
        idealTarde = int(idealTarde)

        # Pontuacao
        if manha + tarde <= (2/3) * len(funcs) and manha + tarde >= (1/3) * len(funcs):
            score-= 100

        if manha < 3 or tarde < 3:
            score -= 200
        else:
            score += 500
            # if manha > 3 and tarde > 3:
            #     score += 500

        if(manha == idealManha):
            score += 100

        if(tarde == idealTarde):
            score += 100

        # Penalizacao por excesso
        if(manha > idealManha):
            score -= 500 - 100 * (manha - idealManha)
        if(tarde > idealTarde):
            score -= 500 - 100 * (tarde - idealTarde)

        # Penalizacao por defeito
        if(manha < idealManha):
            score -= 500 - 100 * (idealManha - manha)
        if(tarde < idealTarde):
            score -= 500 - 100 * (idealTarde - tarde)

        if manha == 0:
            empty += 1
            score -= 1000
        if tarde == 0:
            empty += 1
            score -= 1000

    score -= empty * 200

    return score

def state_score_test(state):
    multiplicador = 0
    score = 0
    dia = 0
    maxfunc = -1000
    # Previsao Clientes
    for day in week:
        count = 0
        score = 0
        # score for manha != tarde
        manha = len(state[day][t[0]])
        tarde = len(state[day][t[1]])
        
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
        # ideal =  (previsoes[day] * 2/3 * len(funcs)) / clientesMaximo
        idealManha =  (previsoes[day][t[0]] * 1 * len(funcs)) / clientesMaximo
        idealTarde =  (previsoes[day][t[1]] * 1 * len(funcs)) / clientesMaximo

        # print(day)
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

def state_eval(state):
    """
    Returns wether or not a state is worth saving or not
    """
    count = 0

    # Find number of Funcs in state
    for day in week:
        manha = state[day][t[0]]
        tarde = state[day][t[1]]
        for x in manha:
            count = max(count, x)
        for x in tarde:
            count = max(count, x)

    # For more than 2 Funcs, check empty days
    if count + 1 >= int(1/3 * len(funcsList)) + 1:
        for day in week:
            manha = len(state[day][t[0]])
            tarde = len(state[day][t[1]])
            if manha == 0 or tarde == 0:
                return False
    elif count + 1 >= 1:
        return True
    else:
        return False

    return True