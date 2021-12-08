import timeit
import numpy as np
from collections  import defaultdict

DO_TEST = 0

def read_file(filename):
    data = []
    with open(filename, 'r') as file:
        data_string = file.read()
    
    for line in data_string.split('\n'):
        combs =  line.split('|')[0]
        outs = line.split('|')[1]
        data.append((combs, outs))
    
    return data

def do_part1(file):
    data = read_file(file)

    one = 0
    four = 0
    seven = 0
    eight = 0

    for line in data:
        for out in line[1].strip().split():
            if len(out) == 2: one += 1
            if len(out) == 4 : four += 1
            if len(out) == 3 : seven += 1
            if len(out) == 7 : eight += 1 

    # print(one, four, seven, eight)
    result = one + four + seven + eight
    print(f"part 1 = {result}")
    

def do_part2(file):
    data = read_file(file)

    unknown = []
    sum = 0
    for line in data:
        # get the combinations
        digits = defaultdict(str)
        for combs in line[0].strip().split():
            if len(combs) == 2:
                digits[1] = combs
            elif len(combs) == 3:
                digits[7] = combs
            elif len(combs) == 4:
                digits[4]= combs
            elif len(combs) == 7:
                digits[8] = combs
            else:
                unknown.append(combs)
        # detect unknown
        for combs in unknown:
            if len(combs) == 6:
                combined = combs + digits[4]
                # set_combined = remove_dups(combined)
                if count_unique(combined) == 2:
                    digits[9] = combs
                else:
                    combined = combs + digits[4] + digits[7]
                    # set_combined = list(set(combined))
                    if count_unique(combined) == 2:
                        digits[6] = combs
                    else:
                        digits[0] = combs
            if len(combs) == 5:
                combined = combs + digits[1]             
                # set_combined = list(set(combined))
                if count_unique(combined)== 3:
                    digits[3]= combs
                else:
                    combined = combs +digits[4]
                    # set_combined = list(set(combined))
                    if count_unique(combined) == 3:
                        digits[5] = combs
                    else:
                        digits[2] = combs
        # convert
        str_num = ""
        for out in  line[1].strip().split():
            str_num += str(get_key(digits,out))
        
        sum += int(str_num)
                    


        

    result = sum
    print(f"part 2 = {result}")

def get_key(dict, val):
    for key, value in dict.items():
        combined = value + val
        if count_unique(combined) == 0:
             return key
    return -1

def count_unique(str_val):
    single = []
    double = []
    for let in str_val:
        if let in single:
            if let not in double:
                double.append(let)
        else:
            single.append(let)

    for d in double:
        single.remove(d)

    return len(single)

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