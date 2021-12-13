import timeit
import numpy as np
from collections  import defaultdict, deque

DO_TEST = 0

def read_file(filename):
    data = []
    with open(filename, 'r') as file:
        data_string = file.read()
        data_string = data_string.split('\n')
    
    return data_string

def do_part1(file):
    data = read_file(file)

    """ scoring
    ): 3 points.
    ]: 57 points.
    }: 1197 points.
    >: 25137 points.
    """
    scoring = dict()
    scoring[')'] = 3
    scoring[']'] = 57
    scoring['}'] = 1197
    scoring['>'] = 25137

    opens = ['{','<','(','[']
    closes = ['}','>',')',']']
    accumulator = 0
    for line in data:
        syntax = list(line)
        stack = deque()
        error = False
        for symbol in syntax:
            if symbol in opens:
                stack.append(symbol)
            else:
                out_val = stack.pop()
                if opens.index(out_val) != closes.index(symbol):
                    error = True
                    break;

        if error:
            print("adding : ",scoring[symbol])
            accumulator += scoring[symbol]

        error = False

    result = accumulator
    print(f"part 1 = {result}")
    

def do_part2(file):
    data = read_file(file)
    
    """ scoring
    ): 1 points.
    ]: 2 points.
    }: 3 points.
    >: 4 points.
    """
    scoring = dict()
    scoring[')'] = 1
    scoring[']'] = 2
    scoring['}'] = 3
    scoring['>'] = 4

    opens = ['{','<','(','[']
    closes = ['}','>',')',']']
    accumulator = 0
    scores = []
    for line in data:
        syntax = list(line)
        stack = deque()
        error = False
        for symbol in syntax:
            if symbol in opens:
                stack.append(symbol)
            else:
                out_val = stack.pop()
                if opens.index(out_val) != closes.index(symbol):
                    error = True
                    break;

        if error:
            error = False
            continue
        
        score = 0
        while len(stack) >0:
            completer = stack.pop()
            completer = closes[opens.index(completer)]
            score = score * 5 + scoring[completer]
        
        scores.append(score)

    scores.sort()
    result = scores[int(len(scores)/2)]
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