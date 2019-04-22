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
keyRegister = 0

basicKey = copy(minorKey) if isTonic > 0 else copy(majorKey)

# ここでキーを作る
addNum = 9 if isRelative > 0 else 0
key = [(x + addNum + keyRegister)%12 for x in basicKey]

print("key:     ",key)


# ここでコードを作る
chordRegister = 1
chordC = cycle(key)

chordC.previous()
for _ in range(chordRegister):
    chordC.next()

chord = [chordC.next() for _ in range(7)]

print("chord:   ",chord)

# ここでモードを作る
modeRegister = 2

modeC = cycle(chord)
modeC.previous()
for _ in range(modeRegister):
    modeC.next()

mode = [modeC.next() for _ in range(7)]
mode = [(x - mode[0]) % 12 for x in mode]

print("mode:    ", mode)

for i in range(3):
    if (chord[i*2+1] - chord[i*2]) != (mode[i*2+1] - mode[i*2]):
        chord[i*2+1] = chord[i*2+1] - (mode[i*2+1] - mode[i*2])

print("chord:   ", chord)

chord = [x % 12 for x in chord]

chord.sort()
print(chord)