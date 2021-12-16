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

def CalculatePairOutput(pair, insert):
    return(pair[0] + insert, insert + pair[1] )

def SearchElementInCounterList(counterList, element):
    for item in counterList:
        # print("looking for " + element + " in " + "item" + str(item))
        if element in item[0]:
            # print("element: " + element + " item: " + item[0], " count: " + str(item[1]))
            item[1] += 1
            return counterList
    counterList.append(([element, 1]))        
    # print("element " + element + " not found")
    # print(counterList)
    return(counterList)

def UpdateValueCounter(pairProduct, list):
    for item in pairProduct:
        for element in item:
            SearchElementInCounterList(list, element)
    return list

def AddPairProductToList(pairProduct, list):
    for item in pairProduct:
        # print(pairProduct)
        # print(item)
        list.append(item)

    return list

def GetUniqueList(polymer):
    uniqueList = []
    for x in polymer:

        if x not in uniqueList:
            uniqueList.append(x)
    return uniqueList

def UpdateCounter(counterList, element):
    counterList = SearchElementInCounterList(counterList, element)
    return counterList

def StepSetup(pairProductList, countList, template):
    # print("template: " + template)
    for element in template:
        countList = SearchElementInCounterList(countList, element)

    for pairIndex in range(0, len(template)-1):
        # print("pairindex " + str(pairIndex))
        pair = template[pairIndex] + template[pairIndex+1]
        pairProductList.append(pair)
    return countList, pairProductList
        

def RunStep(manualList, pairProductList, countList):
    updatePairProductList = []

    for pair in pairProductList:
        
        insert = SearchPairInManual(pair, manualList)
        pairProduct = CalculatePairOutput(pair, insert)
        updatePairProductList = AddPairProductToList(pairProduct, updatePairProductList)
        countList = SearchElementInCounterList(countList, insert)
        # print("inserting: " + insert + " in between " + pair)
        # print(countList)
        # print(pairProduct)    
    # count characters


    # print(updatePairProductList)

        
    return countList, updatePairProductList

def DoMaths(countList):
    getMax = max(countList,key=itemgetter(1))

    getMin = min(countList, key=itemgetter(1))
    return getMax[1] - getMin[1]

### Running ###
lines = ReadInput()
template, manualList = GetItems(lines)
numberofSteps = 40
pairProductList =[]
countList = []
newTemplate = template

countList, pairProductList = StepSetup(pairProductList, countList, template)
print(pairProductList)
for steps in range(0, numberofSteps):
    print("step: " + str(steps+1))
    countList, pairProductList = RunStep(manualList, pairProductList, countList)
    # print("polymer")
    # print(newTemplate)

# print("final polymer")
# print(pairProductList)
print("countList")
print(countList)

puzzle2 = DoMaths(countList)
print(puzzle2)
# print("final polymer length: " + str(len(newTemplate)))
# countList = CountCharacters(newTemplate)
# print(countList)
# Puzzle1(countList)