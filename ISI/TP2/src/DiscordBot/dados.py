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
        precMaxTable.add_row([element['date'], element['maximum'], element['local']])

    return precMaxTable

#Obter dados de locais de Máxima temperatura e formatar em tabela
def getTempMaxTable():

    path = os.getcwd()
    path = path.replace("DiscordBot", "")
    path = path + "KNIME\\Json"
        
    tempMaxFile = open(str(path) + "\\File_0TempMax.json")
    tempMaxData = json.load(tempMaxFile)
    tempMaxTable = PrettyTable(["Data", "Temp (Cº) ", "Local"])
    tempMaxTable.title = 'Temperatura Máxima nos Últimos 10 dias'
    
    for element in tempMaxData:
        tempMaxTable.add_row([element['date'], element['maximum'], element['local']])

    return tempMaxTable

#Obter dados de locais de Mínima temperatura e formatar em tabela
def getTempMinTable():

    path = os.getcwd()
    path = path.replace("DiscordBot", "")
    path = path + "KNIME\\Json"
        
    tempMinFile = open(str(path) + "\\File_0TempMin.json")
    tempMinData = json.load(tempMinFile)
    tempMinTable = PrettyTable(["Data", "Temp (Cº) ", "Local"])
    tempMinTable.title = 'Temperatura Mínima nos Últimos 10 dias'
    
    for element in tempMinData:
        tempMinTable.add_row([element['date'], element['minimum'], element['local']])

    return tempMinTable

#Obter dados das previsoes do tempo e formatar em tabela
def getPrevTable():

    path = os.getcwd()
    path = path.replace("DiscordBot", "")
    path = path + "KNIME\\Json"

    prevFile = open(str(path) + "\\File_0PrevBraga.json")
    prevData = json.load(prevFile)
    prevTable = PrettyTable(["Data", "Temp Max.(Cº)", "Temp Min.(Cº)", "Tempo",
     "Vento", "Direção do Vento", "Precipitação", "Probabilidade"])
    prevTable.title = 'Previsão do tempo para os próximos 5 dias'

    for element in prevData:
        prevTable.add_row([element['forecastDate'], element['tMax'], element['tMin'],
        element['descIdWeatherTypePT'], element['descClassWindSpeedDailyPT'],
        element['predWindDir'],element['descClassPrecIntPT'], element['precipitaProb']])
    return prevTable