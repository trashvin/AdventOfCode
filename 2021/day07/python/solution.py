import timeit
import numpy as np
from collections  import defaultdict

DO_TEST = 0

def read_file(filename):
    with open(filename, 'r') as file:
        data_string = file.read()

    return data_string.split(',')

def do_part1(file):
    data = read_file(file)

    crabs = np.array(data).astype(int) 

    max = np.amax(crabs)
    min = np.amin(crabs)
    fuels = []
    result = -1
    for in_between in range(min +1,max-1):
        fuel = np.sum(abs(crabs - in_between))

        if result == -1 : result = fuel
        fuels.append(fuel)
        print(in_between, " : ", fuel)
        

    result = np.amin(np.array(fuels)) 
    print(f"part 1 = {result}")
    

def do_part2(file):
    data = read_file(file)

    crabs = np.array(data).astype(int) 

    max = np.amax(crabs)
    min = np.amin(crabs)
    fuels = []
    result = -1
    for in_between in range(min +1,max-1):
        fuel = get_fuel(abs(crabs - in_between))

        if result == -1 : result = fuel
        if result < fuel : break
        fuels.append(fuel)
        print(in_between, " : ", fuel)
        

    result = np.amin(np.array(fuels)) 
    print(f"part 2 = {result}")

def get_fuel(number):
    fuel = 0
    for i in (number):
        for f in range(i+1):
            fuel += f
    return fuel

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