from files import previsoesJSON, scheduleJSON, funcsJSON, week, turns
from math import inf
import itertools

p = list(previsoesJSON)

turns = list(scheduleJSON[week[0]])    # Manha ...
funcs = list(funcsJSON)      # António Manel ...

clientesMaximo = -1

for c in previsoesJSON:
    clientesMaximo = max(clientesMaximo, previsoesJSON[c][turns[0]] + previsoesJSON[c][turns[1]])

margin = (1/3) * len(funcs)

def state_score(state):
    score = 0
    ## Counters for shifts
    empty = 0       # 0 funcs
    little = 0      # less than '3' funcs
    overflow = 0    # more than idealShift funcs
    underflow = 0   # less than idealShift funcs

    for day in week:
        manha = len(state[day][turns[0]])
        tarde = len(state[day][turns[1]])
        dia = manha + tarde

        # Count empty shifts
        if manha == 0:
            empty += 1
            score -= 1000
        if tarde == 0:
            empty += 1
            score -= 1000

        # TO DELETE
        # score += manha
        # score += tarde

        # y = (clientesDia * 2/3 * funcionariosTotal) / clientesMaximo
        # ideal =  (previsoesJSON[day] * 2/3 * len(funcs)) / clientesMaximo
        idealManha =  int( (previsoesJSON[day][turns[0]] * 1 * len(funcs)) / clientesMaximo )
        idealTarde =  int( (previsoesJSON[day][turns[1]] * 1 * len(funcs)) / clientesMaximo )

        """
        Pontuacao
        """

        if(manha == idealManha):
            score += 500

        if(tarde == idealTarde):
            score += 500

        if dia <= 2 * margin and dia >= margin:
            little += 1
            if manha < margin or tarde < margin:  # Evaluate and Count small shifts
                little += abs(margin - manha)
                little += abs(margin - tarde)
        else:
            falta = idealManha - manha
            underflow += abs(falta)

            falta = idealTarde - tarde
            underflow += abs(falta)

        # # Penalizacao por excesso
        # if(manha > idealManha):
        #     score -= 100 * pow(5, (manha - idealManha))
        # if(tarde > idealTarde):
        #     score -= 100 * pow(5, (tarde - idealTarde))

        # # Penalizacao por defeito
        # if(manha < idealManha):
        #     score -= 100 * pow(5, (idealManha - manha))
        # if(tarde < idealTarde):
        #     score -= 100 * pow(5, (idealTarde - tarde))

    # General punishments
    score -= overflow * pow(5, (overflow))
    score -= underflow * 200 * pow(5, (underflow))
    score -= empty * 300 
    score -= little * 200

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
        manha = len(state[day][turns[0]])
        tarde = len(state[day][turns[1]])
        
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
        # ideal =  (previsoesJSON[day] * 2/3 * len(funcsJSON)) / clientesMaximo
        idealManha =  (previsoesJSON[day][turns[0]] * 1 * len(funcsJSON)) / clientesMaximo
        idealTarde =  (previsoesJSON[day][turns[1]] * 1 * len(funcsJSON)) / clientesMaximo

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

    # Find number of funcs in state
    for day in week:
        manha = state[day][turns[0]]
        tarde = state[day][turns[1]]
        for x in manha:
            count = max(count, x)
        for x in tarde:
            count = max(count, x)

    # For more than 2 funcs, check empty days
    if count + 1 >= int(1/3 * len(funcs)) + 1:
        for day in week:
            manha = len(state[day][turns[0]])
            tarde = len(state[day][turns[1]])
            if manha == 0 or tarde == 0:
                return False
    elif count + 1 >= 1:
        return True
    else:
        return False

    return True
