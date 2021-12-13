import timeit
import numpy as np
from collections  import defaultdict

DO_TEST = 1

def read_file(filename):
    data = []
    with open(filename, 'r') as file:
        data_string = file.read()
        data_string = data_string.split('\n')
    
    data = []
    for line in data_string:
        row = list(line)
        data.append(row)
    
    
    return data

def do_part1(file):
    data = read_file(file)
    x = 0
    y = 0
    low = []
    for x in range(len(data)):
        ok = 0
        valid = 4
        for y in range(len(data[x])):
            if y-1 >= 0:
                if data[x][y-1] > data[x][y]: ok += 1
            else: 
                valid -= 1

            if x-1 >= 0:
                if data[x-1][y] > data[x][y] : ok += 1
            else:
                valid -= 1

            if y+1 <len(data[x]):
                if data[x][y+1] > data[x][y]: ok += 1
            else:
                valid -= 1

            if x+1 <len(data):
                if data[x+1][y] > data[x][y]: ok += 1
            else:
                valid -= 1

            if ok == valid:
                low.append(data[x][y])

            valid = 4
            ok = 0

    risk = 0
    [risk := risk + (int(x) + 1) for x in low]          

    result = risk
    print(f"part 1 = {result}")
    

def do_part2(file):
    data = read_file(file)
    map = read_file(file)
    region = 10
    x = 0
    y = 0
    
    for x in range(len(data)):
        for y in range(len(data[x])):
            if int(data[x][y]) == 9: continue

            val = str(region)
            if y-1 >= 0:
                if int(data[x][y]) -int(data[x][y-1])== 1: 
                    if len(map[x][y-1]) > 1: val = map[x][y-1]
                    else: 
                        if len(map[x][y])<2:
                            region += 1
                            val = str(region)
                        else:
                            val = map[x][y]
                        

                    map[x][y-1] = val
                    map[x][y] = val

            if x-1 >= 0:
                if int(data[x][y])  - int(data[x-1][y]) == 1: 
                    if len(map[x-1][y]) > 1: val = map[x-1][y]
                    else: 
                        if len(map[x][y])<2:
                            region += 1
                            val = str(region)
                        else:
                            val = map[x][y]

                    map[x-1][y] = val
                    map[x][y] = val

            if y+1 <len(data[x]):
                if int(data[x][y])  -int(data[x][y+1])== 1: 
                    if len(map[x][y+1]) > 1: val = map[x][y+1]
                    else: 
                        if len(map[x][y])<2:
                            region += 1
                            val = str(region)
                        else:
                            val = map[x][y]

                    map[x][y+1] = val 
                    map[x][y] = val
            

            if x+1 <len(data):
                if int(data[x][y])  - int(data[x+1][y]) == 1: 
                    if len(map[x+1][y]) > 1: val = map[x+1][y]
                    else: 
                        if len(map[x][y])<2:
                            region += 1
                            val = str(region)
                        else:
                            val = map[x][y]

                    map[x+1][y] = val
                    map[x][y] = val
      

    result = 0
    print(f"part 2 = {result}")


# main
test = ("test.txt")
real = ("input.txt")
data = real

if DO_TEST == 1:
    data = test

print('results : ')
starttime_1 = timeit.default_timer()
do_part1(data)
endtime_1 = timeit.default_timer()

starttime_2 = timeit.default_timer()
do_part2(data)
endtime_2 = timeit.default_timer()

print('performance :')
print('part1 = ', (endtime_1-starttime_1), " sec")
print('part2 = ', (endtime_2-starttime_2), " sec")