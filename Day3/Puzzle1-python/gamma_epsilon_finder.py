import math
import numpy as np
import functools as f

from numpy.core.fromnumeric import resize


inputArray = []
integerArray = []
file1 = open('test.txt', 'r')
Lines = file1.readlines()
 
count = 0
# Strips the newline character
for line in Lines:
    count += 1
    print("Line{}: {}".format(count, line.strip()))
    inputArray.append(line.strip())


print(inputArray)

for input in inputArray:
    intInputArray = int(input, 2)
    print (intInputArray)
    integerArray.append(intInputArray)


print (integerArray)

res = f.reduce(lambda x, y: x ^ y, integerArray)

print(res)

binary = bin(res) 
print (binary)
print("Episilon: {}, Gamma: {}".format(binary, bin(res ^ 1)))