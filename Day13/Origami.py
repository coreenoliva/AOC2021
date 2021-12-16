import numpy as np
from numpy.lib.function_base import flip

with open('Input.txt') as file:
    lines = file.readlines()
    lines = [line.rstrip() for line in lines]

coordinateLines = []

foldLines = []

for line in lines:
    if ("," in line):
        coordinateLines.append(line)
    if ("fold" in line):
        foldLines.append(line)

# print(coordinateLines)
# print(foldLines)

xCoordinates = []
yCoordinates = []
#store x coordinates
for coordinate in coordinateLines:
    x = coordinate.split(",")
    xCoordinates.append(int(x[0]))
    yCoordinates.append(int(x[1]))

instructions = []

for instruction in foldLines:
    fold = instruction.split(" ")
    instructions.append((fold[2]).split("="))


gridSizeX = max(xCoordinates)+1
gridSizeY = max(yCoordinates)+1


# create grid 
xAxis = np.arange(0, gridSizeX)

grid = np.zeros((gridSizeY, gridSizeX), dtype=int)

for line in coordinateLines:
    splits = line.split(",")
    x = int(splits[0])
    y = int(splits[1])
    grid[y][x] = 1
        
# print(grid)

# print(instructions)
operatingMatrix = grid

for instruction in instructions:
    cut = int(instruction[1])

    if ("y" in instruction[0]):


        split = operatingMatrix[:cut]
        remaining = operatingMatrix[cut+1:gridSizeY]

        # flip bottom
        flipRemaining = np.flipud(remaining)
        
        # fold
        operatingMatrix = split | flipRemaining
        

    else: 
        print("foldx")
        counter = 0
        split=np.zeros((len(operatingMatrix),cut), dtype=int)
        remaining  =np.zeros((len(operatingMatrix),cut), dtype=int)
        for row in operatingMatrix:
          
            rowSplit = row[:cut]
            rowremaining = row[cut+1:gridSizeX]
            remaining[counter] = rowremaining
            split[counter] = rowSplit
            counter += 1
        # split = operatingMatrix[:cut]
        # remaining = operatingMatrix[cut+1:gridSizeY]

        # flip bottom
        flipRemaining = np.fliplr(remaining)

        # print("split")
        # print(split)
        # print("remaining")
        # print(remaining)
        # fold
        operatingMatrix = split | flipRemaining
        

    
    print("instruction: ")
    print(instruction)
    print("matrix")
    print(operatingMatrix)
    print("visible dots")
    print(np.count_nonzero(operatingMatrix))






