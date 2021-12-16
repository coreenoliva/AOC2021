import numpy as np
from numpy.lib.function_base import flip

with open('Input.txt') as file:
    lines = file.readlines()
    lines = [line.rstrip() for line in lines]
    


def CreateBoards():
    boards = list()
    emptyBoards = list()
    counter = 0
    board = np.zeros((5,5), dtype=int)
    numberRolls = ""
    for line in lines:
        if ("," in line):
            numberRolls = line
            continue
        if (line == ''):
            board = np.zeros((5,5), dtype=int)
            emptyBoard = np.zeros((5,5), dtype=int)
            counter=0
        else:
            board[counter] = np.array(line.split())
            counter+= 1
            if(counter == 5):
                boards.append(board)
                emptyBoards.append(emptyBoard)

    return numberRolls, boards, emptyBoards


def Find(element, matrix):
    for i in range(len(matrix)):
        for j in range(len(matrix[i])):
            if matrix[i][j] == element:
                # print(matrix[i][j])
                # print("found")
                return (i, j)
            
    else: 
        # print("not found")
        return -1, -1

def CheckWin(emptyBoard):
    verticalSum = np.sum(emptyBoard, axis = 0)
    horizontalSum = np.sum(emptyBoard, axis = 1)
    for v in verticalSum:
        if v == 5:
            return 1
    for h in horizontalSum:
        if h == 5:
            return 1
    return 0

def CalculateSum(winningBoard, emptyBoard):
    # invert
    inverted = emptyBoard ^ 1

    # get numbers
    remainingBoard = inverted * winningBoard
    total = np.sum(remainingBoard)
    return int(total)



def DoBoard(boards, emptyBoards, roll):
    # print(roll)
    boardCounter = 0
    for board in boards:
        i, j = Find(int(roll), board)

        if (i == -1):
            boardCounter+=1
            continue

        #assign to empty
        emptyBoard = emptyBoards[boardCounter]; 
        
        emptyBoard[i][j]=1

        # print(emptyBoard)
        # print(board)

        win = CheckWin(emptyBoard)

        if (win):
            sum = CalculateSum(board, emptyBoard)

            score = sum * int(roll)

            return score
        
        boardCounter += 1

def ExecutePuzzle1(numberRolls):
    for roll in numberRolls:
        win = DoBoard(boards, emptyBoards, int(roll))
        if win: 
            print("winningroll")
            print(roll)
            print("winningscore")
            print(win)
            break

    
def DoBoardForAllWinnersInRoll(boards, emptyBoards, roll):
    # print(roll)
    boardCounter = 0
    score = 0
    leftOverBoards = boards.copy()
    leftOverEmptyBoards = emptyBoards.copy()
    indexToDelete = list()
    for board in boards:
        print(boardCounter)
        i, j = Find(int(roll), board)

        if (i == -1):
            boardCounter+=1
            continue

        #assign to empty
        emptyBoard = emptyBoards[boardCounter]; 
        
        emptyBoard[i][j]=1

        win = CheckWin(emptyBoard)

        if (win):
            print("we have a winner")
            
            # print("boardCounter")
            # print(boardCounter)

            sum = CalculateSum(board, emptyBoard)
            score = sum * int(roll)
            indexToDelete.append(boardCounter)
            # print("number of boards")
            # print(len(leftOverBoards))
            # leftOverBoards.pop(boardCounter)
            # print("number of empty boards")
            # print(len(leftOverEmptyBoards))
            # leftOverEmptyBoards.pop(boardCounter)
            # print("WIN")
            # print(score)
            # print("roll")
            # print(roll)
            # print(roll)
        
        boardCounter += 1
    for index in sorted(indexToDelete, reverse=True):
        del leftOverEmptyBoards[index]
        del leftOverBoards[index]


    return score, leftOverBoards, leftOverEmptyBoards
    

def ExecutePuzzle2(numberRolls, emptyBoards, boards):
    leftOverBoards = boards.copy()
    leftOverEmptyBoards = emptyBoards.copy()
    for roll in numberRolls:
        print(roll)
        score, leftOverBoards, leftOverEmptyBoards = DoBoardForAllWinnersInRoll(leftOverBoards, leftOverEmptyBoards,int(roll))
        # print(leftOverEmptyBoards)
        if (len(leftOverBoards) == 0):
            print("run completed. score:")
            print(score)
            return roll
        # break


###Running###

numberRolls, boards, emptyBoards = CreateBoards()
numberRolls = numberRolls.split(',')
ExecutePuzzle2(numberRolls, emptyBoards, boards)