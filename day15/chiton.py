import numpy as np
from operator import itemgetter
from numpy.lib.function_base import flip

def ReadInput():
    with open('Input.txt') as file:
        lines = file.readlines()
        lines = [line.rstrip() for line in lines]
        # print(lines)
    return lines

def SaveInputIntoArray(lines):
    fullArr = []
    for line in lines:
        arr = list(line)
        # print(arr)
        fullArr.append(arr)
        # print(fullArr)

    return fullArr

def CreateMapChart(xmax, ymax):
    chart = np.zeros((xmax, ymax), dtype = int)
    print(chart)
    return chart

def UpdateChart(emptyChart, lowestRisk):
    emptyChart[lowestRisk[1]][lowestRisk[2]]=lowestRisk[0]
    return (emptyChart)

def CheckSurroundingForLowestRisk(lines, indexUrAt_x, indexUrAt_y, xmax, ymax):
    directions = []
    print("I am here: " + lines[indexUrAt_x][indexUrAt_y] + " (" + str(indexUrAt_x) + "," + str(indexUrAt_y) + ")"  )

    print("xmax: " + str(xmax) + "ymax: " + str(ymax))


    if indexUrAt_x != 0:
        above = lines[indexUrAt_x-1][indexUrAt_y]
        directions.append([above,indexUrAt_x-1, indexUrAt_y]) 

    if indexUrAt_x != xmax:
        below = lines[indexUrAt_x+1][indexUrAt_y]
        directions.append([below, indexUrAt_x+1, indexUrAt_y])

    if indexUrAt_y != 0:
        left = lines[indexUrAt_x][indexUrAt_y-1]
        directions.append([left,indexUrAt_x,indexUrAt_y-1])

    if indexUrAt_y != ymax:
        right = lines[indexUrAt_x][indexUrAt_y+1]
        directions.append([right,indexUrAt_x,indexUrAt_y+1])

    lowestRisk = min(directions, key=itemgetter(0))
    print("lowerst risk: ")
    print(lowestRisk)
    return lowestRisk





### Running ###
lines = ReadInput()
arr = SaveInputIntoArray(lines)
xmax = len(lines)-1
ymax = len(lines[0])-1

indexUrAt_x = xmax
indexUrAt_y = ymax

chart = CreateMapChart(xmax, ymax)

for i in range(0,3):
    lowestRisk = CheckSurroundingForLowestRisk(lines,indexUrAt_x, indexUrAt_y, indexUrAt_x, indexUrAt_y)  
    chart = UpdateChart(chart, lowestRisk)
    indexUrAt_x = lowestRisk[1]
    indexUrAt_y = lowestRisk[2]


# print(arr[1][1])