from math import inf, ceil
from itertools import chain

from files import previsoesJSON as previsoes, \
     week, turns, funcs, margin, clientesMaximo

def state_score(state, depth):
    score = 0

    # Counters for shifts
    little = 0      # less than 'margin' funcs
    overflow = 0    # more than 'idealShift'
    underflow = 0   # less than 'idealShift'
    maior = 0 
    diaMaior = None

    for day in week:
        manha = len(state[day][turns[0]])
        tarde = len(state[day][turns[1]])
        dia = manha + tarde

        if maior < dia:
            maior = dia
            diaMaior = day

        """
        Estimate on the ideal number of funcionarios per shift (per day)
        """
        # y = (clientesDia * n * funcionariosTotal) / clientesMaximo  # n -> multiplier
        idealManha =  ceil( (previsoes[day][turns[0]] * 1 * len(funcs)) / clientesMaximo )
        idealTarde =  ceil( (previsoes[day][turns[1]] * 1 * len(funcs)) / clientesMaximo )

        if manha == idealManha:
            score += 500

        if tarde == idealTarde:
            score += 500

        # Count 'missing' funcionarios per shift
        if manha < margin or tarde < ceil(margin):
            little += abs(margin - manha)
            little += abs(margin - tarde)

        """
        Count overflow and underflow of funcionarios per shift,
        Given an estimate on the ideal number fo funcionarios for each shift (per day)
        """
        if manha > idealManha:
            overflow += abs(idealManha - manha)
        else:
            underflow += abs(idealManha - manha)
        if tarde > idealTarde:
            overflow += abs(idealTarde - tarde)
        else:
            underflow += abs(idealTarde - tarde)

        """
        If the ideal is having more on one shift than another,
        but it's the other way around, penalize 
        """
        if idealManha < idealTarde and manha > tarde:
            score -= 500
        elif idealManha > idealTarde and manha < tarde:
            score -= 500

        if previsoes[day][turns[0]] + previsoes[day][turns[1]] == clientesMaximo \
            and diaMaior == day:
            score += 100
        else:
            score -= 100

    """
    Penalizing disalignments
    """
    score -= overflow * 50
    score -= underflow * 50
    score -= little * 200

    return score
    

def test(state):
    count = 0       # Number of added Funcionarios
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
                if manha == menor and tarde == menor:
                    return False
                elif dif > 2:
                    if (manha == menor or tarde == menor) and count > margin:
                        return False

            dif = maior - tarde
            if dif > 1:
                if manha == menor and tarde == menor:
                    return False
                elif dif > 2:
                    if (manha == menor or tarde == menor) and count > margin:
                        return False

        elif (count > 1 and count % 2 == 0):
            dif = maior - manha
            if dif > 1:
                if manha == menor and tarde == menor:
                    return False
                elif dif > 2:
                    if (manha == menor or tarde == menor) and count > margin:
                        return False
            
            dif = maior - tarde
            if dif > 1:
                if manha == menor and tarde == menor:
                    return False
                elif dif > 2:
                    if (manha == menor or tarde == menor) and count > margin:
                        return False

    return True
