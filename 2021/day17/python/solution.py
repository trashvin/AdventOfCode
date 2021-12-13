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
    
    result = 0
    print(f"part 1 = {result}")
    

def do_part2(file):
    data = read_file(file)
    
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