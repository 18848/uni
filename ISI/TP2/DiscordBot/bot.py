import discord
import os
from prettytable import PrettyTable
import dados
import requests

client = discord.Client()

@client.event
async def on_ready():
    print('We have logged in as {0.user}'.format(client))

with open('token.txt', 'r') as f:
    token = f.read()
    f.close

@client.event
async def on_message(message):
    if message.author == client.user:
        return

    msg = message.content

    if msg.startswith("!tempo"):
        precMaxTable = dados.getPrecMaxTable()
        tempMaxTable = dados.getTempMaxTable()
        tempMinTable = dados.getTempMinTable()
        prevTable = dados.getPrevTable()

        await message.channel.send("```" + str(precMaxTable) + "```")
        await message.channel.send("```" + str(tempMaxTable) + "```")
        await message.channel.send("```" + str(tempMinTable) + "```")
        await message.channel.send("```" + str(prevTable) + "```")


    if msg.startswith("!time"):
        response = requests.get('http://wttr.in/barcelos')
        #result = os.popen("curl wttr.in/Barcelos").read()
        print(response.content)
        #await message.channel.send(response.content)

client.run(token)