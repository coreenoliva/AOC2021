g=""
s=0
rel={}
pairs={}
chars={}

# parse file and set up data structures
file1 = open('Input.txt', 'r')
for line in file1:
    fields=line.strip().split()
    if len(fields)==1:
        orig=fields[0]
    elif len(fields)==3:
        rel[fields[0]]=fields[2]
        pairs[fields[0]]=0
        chars[fields[2]]=0
pairso=dict(pairs)

print(pairs)

# calculate initial pairs
for r in range(0,len(orig)-1):
    pairs[orig[r:r+2]]+=1
   

# loop through pairs and create new pairs
for c in range(1):
    pairs2=dict(pairso)
    for u in pairs:
        pairs2[u[0]+rel[u]]+=pairs[u]
        pairs2[rel[u]+u[1]]+=pairs[u]
    pairs=pairs2

# work out character counts
for r in pairs:
    chars[r[0]]+=pairs[r]
    chars[r[1]]+=pairs[r]
chars[orig[0]]+=1
chars[orig[-1]]+=1

# answer
print((max(chars.values()) - min(chars.values()))/2)

file1.close()