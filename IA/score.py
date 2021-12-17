from files import previsoesJSON, scheduleJSON, funcsJSON, week, turns, workingDays
from math import inf, ceil
from itertools import chain

p = list(previsoesJSON)

turns = list(scheduleJSON[week[0]])    # Manha ...
funcs = list(funcsJSON)      # António Manel ...

clientesMaximo = -1

for c in previsoesJSON:
    clientesMaximo = max(clientesMaximo, previsoesJSON[c][turns[0]] + previsoesJSON[c][turns[1]])

margin = (1/4) * len(funcs)
homogeneity = ceil(int(margin) * len(turns) * len(week) / workingDays)

def state_score(state, depth):
    score = 0
    # Counters for shifts
    empty = 0       # 0 funcs
    little = 0      # less than '3' funcs
    overflow = 0    # more than idealShift funcs
    underflow = 0   # less than idealShift funcs
    trend = None
    trend_dict = dict()
    maximum = -1
    maior = 0

    # if depth < 15:
    #     return score

    for day in week:
        manha = len(state[day][turns[0]])
        tarde = len(state[day][turns[1]])
        dia = manha + tarde
        if maior < dia:
            maior = dia

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

        if dia < 2 * margin:
            if manha < margin or tarde < ceil(margin):  # Evaluate and Count small shifts
                little += abs(margin - manha)
                little += abs(margin - tarde)
        elif dia >= margin:
            overflow += abs(idealManha - manha)
            overflow += abs(idealTarde - tarde)
        else:
            underflow += abs(idealManha - manha)
            underflow += abs(idealTarde - tarde)

    # General punishments
    score -= overflow * 20 # pow(5, (overflow))
    score -= underflow * 20
    # score -= empty * 300 
    score -= little * 200

    return score
    

def test(state):
    count = 0
    maior = -inf
    menor = inf

    # Find number of funcs in state
    for day in week:
        manha = state[day][turns[0]]
        tarde = state[day][turns[1]]
        for x in manha:
            count = max(count, int(x))
        for x in tarde:
            count = max(count, int(x))

        manha = len(state[day][turns[0]])
        tarde = len(state[day][turns[1]])

        if maior < manha or maior < tarde:
                if maior < manha:
                    maior = manha
                elif maior < tarde:
                    maior = tarde
        if menor > manha or menor > tarde:
                if menor > manha:
                    menor = manha
                elif menor > tarde:
                    menor = tarde

    count = count + 1

    for day in week:
            manha = len(state[day][turns[0]])
            tarde = len(state[day][turns[1]])
    
            # if count == 7 and manha == 3 and tarde == 3:
            #     print(state)
            #     input()

            if maior - menor < 1:
                return True

            if(count > 1 and count % 2 != 0):

                dif = maior - manha
                if dif > 1:
                    if manha == menor and tarde == menor:
                        return False
                    elif manha == menor or tarde == menor and count > 3:
                        return False

                dif = maior - tarde
                if dif > 1:
                    if manha == menor and tarde == menor:
                        return False
                    elif manha == menor or tarde == menor and count > 3:
                        return False

            elif (count > 1 and count % 2 == 0):
                # if count == 6:
                #     print(menor)
                #     print(state)
                #     input()
                dif = maior - manha
                if dif > 1:
                    if manha == menor and tarde == menor:
                        return False
                    elif manha == menor or tarde == menor and count > 2:
                        return False
                
                dif = maior - tarde
                if dif > 1:
                    if manha == menor and tarde == menor:
                        return False
                    elif manha == menor or tarde == menor and count > 2:
                        return False

    return True
"""
Returns wether or not a state is worth keeping
"""
def state_eval(state):
    count = 0
    maior = 0

    # Find number of funcs in state
    for day in week:
        manha = state[day][turns[0]]
        tarde = state[day][turns[1]]
        for x in manha:
            count = max(count, int(x))
        for x in tarde:
            count = max(count, int(x))
        manha = len(state[day][turns[0]])
        tarde = len(state[day][turns[1]])
        if maior < manha or maior < tarde:
                if maior < manha:
                    maior = manha
                elif maior < tarde:
                    maior = tarde

    count = count + 1

    # For more than 4 funcs, check empty days
    if count >= ceil(margin):
        for day in week:
            manha = len(state[day][turns[0]])
            tarde = len(state[day][turns[1]])
            if manha == 0 or tarde == 0:
                return False
        # if count + 1 <= homogeneity:
        #     for i in (0, len(week) - 2):
        #         for j in (1, len(week) - 1):
        #             mh = len(state[week[i]][turns[0]])
        #             th = len(state[week[i]][turns[1]])
        #             ma = len(state[week[j]][turns[0]])
        #             ta = len(state[week[j]][turns[1]])
        #             if abs(mh - ma) > 1:
        #                 return False
        #             if abs(th - ta) > 1:
        #                 return False
    elif count > 1:
        # flag = False

        # for day in week:
        #     manha = len(state[day][turns[0]])
        #     tarde = len(state[day][turns[1]])
        #     if manha > 1 or tarde > 1:
        #         flag = True

        for day in week:
            manha = len(state[day][turns[0]])
            tarde = len(state[day][turns[1]])

            # if manha == 0 or tarde == 0 and flag is True:
            #     return False

            if maior - manha > 1:
                return False

            if maior - tarde > 1:
                return False

        return True
    elif count == 1:
        return True
    else:
        return False

    return True
