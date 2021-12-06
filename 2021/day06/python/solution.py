import timeit
from collections  import defaultdict

def read_file(filename):
    with open(filename, 'r') as file:
        data_string = file.read()

    return data_string.split(',')

# this is the brute force approach, innefficient for larger data set
def do_part1(file, days_to_propagate):
    data = read_file(file)
    
    for day in range(1,80 + 1):
        new_data = []
        add = 0
        for timer in data:
            timer = int(timer)
            if timer > 0:
                new_time = timer -1     
            elif timer == 0:
                new_time = 6
                add += 1

            new_data.append(new_time)
            
        for i in range(add):
            new_data.append(8)
        data = new_data[:]

    result = len(data)
    print(f"part 1 = {result}")

#  this the the best way, grouping the fishes by timer
def do_part2(file, days_to_propagate):
    data = read_file(file)

    # each fish timer will be divided into schools 
    school = defaultdict(int)

    for fish_timer in data:
        school[int(fish_timer)] += 1
    
    for day in range(days_to_propagate):
        new_school_set = defaultdict(int)
        for timer, count in school.items():
            if timer == 0:
                new_school_set[6] += count
                new_school_set[8] = count
            else:
                new_school_set[timer-1] += count

        school = new_school_set

    fishes = 0
    for timer, count in school.items():
        fishes += count

    result = fishes
    print(f"part 2 = {result}")


# main

file = "input.txt"

test = ("test.txt", 80, 256)
real = ("input.txt", 80, 256)

data = test

print('results : ')
starttime_1 = timeit.default_timer()
do_part1(data[0], data[1])
endtime_1 = timeit.default_timer()

starttime_2 = timeit.default_timer()
do_part2(data[0], data[2])
endtime_2 = timeit.default_timer()

print('performance :')
print('part1 = ', (endtime_1-starttime_1), " sec")
print('part2 = ', (endtime_2-starttime_2), " sec")