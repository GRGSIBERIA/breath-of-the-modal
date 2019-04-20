#-*- encoding: utf-8
from copy import copy

class cycle:
    def __init__(self, list):
        self.i = 0
        self.list = list
 
    def next(self):
        self.i = (self.i + 1) % len(self.list)
        return self.list[self.i]
 
    def previous(self):
        self.i = (self.i - 1 + len(self.list)) % len(self.list)
        return self.list[self.i]
 
    def present(self):
        return self.list[self.i]
 
    def reset(self):
        self.i = 0
        return


majorKey = [0, 2, 4, 5, 7, 9, 11]
minorKey = [0, 2, 3, 5, 7, 8, 10]

isTonic = 0
isRelative = 0
keyRegister = 6

basicKey = copy(minorKey) if isTonic > 0 else copy(majorKey)

# ここでキーを作る
addNum = 9 if isRelative > 0 else 0
key = [(x + addNum + keyRegister) % 12 for x in basicKey]
keyC = cycle(key)

print("key:     ",key)

chordRegister = 1
for _ in range(chordRegister):
    keyC.next()
keyC.previous()

#chord = [(x + key[chordRegister]) % 12 for x in basicKey]
chord = [keyC.next() for _ in range(7)]

print("chord:   ",chord)



# モードが直感に反してるので修正する必要がある
modeRegister = 0

mode = [(x + basicKey[modeRegister]) % 12 for x in basicKey]

print("mode:    ",mode)

modeC = cycle(mode)
for _ in range(modeRegister - chordRegister):
    modeC.next()

print(modeC.list)