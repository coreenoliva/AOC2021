import numpy as np
from operator import itemgetter
from numpy.lib.function_base import flip

def ReadInput():
    with open('Input.txt') as file:
        lines = file.readlines()
        lines = [line.rstrip() for line in lines]
        # print(lines)
    return lines

def GetItems(lines):
    template = lines[0]
    manual = lines[2:]
    # print(manual)
    manualList = list()
    for line in manual:
        splitItems = line.split()
        manualList.append(splitItems)
    # print(manualList)

    return template, manualList


def SearchPairInManual(pair, manualList):
    for manual in manualList:
        if manual[0] == pair:
            return(manual[2])
    

def InsertNewChar(template, insert, index):
    # print("inserting new char " + insert + " into " + template + " at index " + str(index))

    # print("first half: " + template[:index] + " second half: " + template[index:])
    template = template[:index] + insert + template[index:]
    # print("new template: " + template)
    return template

def RunStep(template, manualList):
    newTemplate = template
    counter = 1
    for pairIndex in range(0, len(template)-1):
        pair = template[pairIndex] + template[pairIndex+1]
        insert = SearchPairInManual(pair, manualList)
        newTemplate = InsertNewChar(newTemplate, insert, pairIndex+counter)
        counter+=1
    return newTemplate

def GetUniqueList(polymer):
    uniqueList = []
    for x in polymer:
        if x not in uniqueList:
            uniqueList.append(x)
    return uniqueList

def CountCharacters(polymer):
    countList = []
    uniqueList = GetUniqueList(polymer)
    for item in uniqueList:
        countList.append((item, polymer.count(item)))
    return countList

def Puzzle1(countList):
    getMax = max(countList,key=itemgetter(1))
    getMin = min(countList, key=itemgetter(1))
    print("max - min = " + getMax[0] + "-" + getMin[0] + " = " + str(getMax[1]) + " - " + str(getMin[1]))
    print(getMax[1]-getMin[1])

### Running ###
lines = ReadInput()
template, manualList = GetItems(lines)
numberofSteps = 40
newTemplate = template
for steps in range(0, numberofSteps):
    print("step: " + str(steps+1))
    newTemplate = RunStep(newTemplate, manualList)
    # print("polymer")
    # print(newTemplate)

# print("final polymer")
# print(newTemplate)
print("final polymer length: " + str(len(newTemplate)))
countList = CountCharacters(newTemplate)
print(countList)
Puzzle1(countList)