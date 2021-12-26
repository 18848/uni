import os
from prettytable import PrettyTable
import json


#Obter dados de locais de precipitação Máxima e formatar em tabela
def getPrecMaxTable():

    path = os.getcwd()
    path = path.replace("DiscordBot", "")
    path = path + "KNIME\\Json"
        
    precMaxFile = open(str(path) + "\\File_0PrecMax.json")
    precMaxData = json.load(precMaxFile)
    precMaxTable = PrettyTable(["Data", "Quantidade", "Local"])
    precMaxTable.title = 'Precipitação Máxima'
    
    for element in precMaxData:
        precMaxTable.add_row([precMaxData[element]['date'], precMaxData[element]['maximum'], precMaxData[element]['local']])

    return precMaxTable