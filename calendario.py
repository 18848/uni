import json 


f = open("schedule.json", "r")
c = json.load(f)
print(c)



def calendarPrint(week):
    for day in week:
        print(f"\t{day.key}")









# funcionariosTotal = 10 
# acrescimo = funcionariosTotal / 10
# clientesDia = c["segunda"]
# clientesMaximo = max(c)
# clientesMinimo = min(c)
# # Abordagem 1
# y = 3 + (clientesDia - clientesMinimo)/100 + acrescimo
# # Abordagem 2
# y = (clientesDia * 2/3 * funcionariosTotal) / clientesMaximo
