import discord
import os
from prettytable import PrettyTable
import json
import dados

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
        await message.channel.send("```" + str(precMaxTable) + "```")

client.run(token)