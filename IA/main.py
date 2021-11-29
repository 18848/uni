import json

s = open("schedule.json", "r")
schedule = json.load(s)
s.close()

f = open("funcs.json", "r")
funcs = json.load(f)
f.close()

p = open("previsoes.json", "r")
predictions = json.load(p)
p.close()


print(schedule)
print(funcs)
print(predictions)

