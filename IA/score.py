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
# homogeneity = ceil(int(margin) * len(turns) * len(week) / workingDays)

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
    diaMaior = None

    # if depth < 15:
    #     return score

    for day in week:
        manha = len(state[day][turns[0]])
        tarde = len(state[day][turns[1]])
        dia = manha + tarde
        if maior < dia:
            maior = dia
            diaMaior = day

        # y = (clientesDia * n * funcionariosTotal) / clientesMaximo  # n -> multiplier
        # ideal =  (previsoesJSON[day] * 2/3 * len(funcs)) / clientesMaximo
        idealManha =  ceil( (previsoesJSON[day][turns[0]] * 1 * len(funcs)) / clientesMaximo )
        idealTarde =  ceil( (previsoesJSON[day][turns[1]] * 1 * len(funcs)) / clientesMaximo )

        """
        Pontuacao
        """

        if manha == idealManha:
            score += 500

        if tarde == idealTarde:
            score += 500

        if manha < margin or tarde < ceil(margin):  # Evaluate and Count small shifts
            little += abs(margin - manha)
            little += abs(margin - tarde)

        if manha > idealManha:
            overflow += abs(idealManha - manha)
        else:
            underflow += abs(idealManha - manha)
        if tarde > idealTarde:
            overflow += abs(idealTarde - tarde)
        else:
            underflow += abs(idealTarde - tarde)

        if idealManha < idealTarde and manha > tarde:
            score -= 500
        elif idealManha > idealTarde and manha < tarde:
            score -= 500

    if diaMaior == previsoesJSON[day][turns[0]] + previsoesJSON[day][turns[1]]:
        score += 1000
    else:
        score -= 100

    # General punishments
    score -= overflow * 20 # pow(5, (overflow))
    score -= underflow * 20
    score -= little * 200

    return score
    

def test(state):
    count = 0
    maior = -inf
    menor = inf

    # Find count, maior, menor
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

    # Validate State
    for day in week:
        manha = len(state[day][turns[0]])
        tarde = len(state[day][turns[1]])

        if(count > 1 and count % 2 != 0):
            dif = maior - manha
            if dif > 1:
                # if count == 5 and dif < 2:
                #     print("exists")
                #     print(state)
                #     input()
                if manha == menor and tarde == menor:
                    # if count == 5:
                    #     print("1")
                    #     input()
                    return False
                elif dif > 2:
                    if (manha == menor or tarde == menor) and count > 3:
                        return False

            dif = maior - tarde
            if dif > 1:
                if manha == menor and tarde == menor:
                    return False
                elif dif > 2:
                    if (manha == menor or tarde == menor) and count > 3:
                        return False

        elif (count > 1 and count % 2 == 0):
            # if count == 4:
            #     print(menor)
            #     print(state)
            #     input()
            dif = maior - manha
            if dif > 1:
                if(count == 6): print("here")
                if manha == menor and tarde == menor:
                    return False
                elif dif > 2:
                    if (manha == menor or tarde == menor) and count > 4:
                        return False
            
            dif = maior - tarde
            if dif > 1:
                if manha == menor and tarde == menor:
                    return False
                elif dif > 2:
                    if (manha == menor or tarde == menor) and count > 4:
                        return False

    return True
