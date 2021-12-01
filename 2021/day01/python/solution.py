# imports here

def read_file(filename):
    with open(filename, 'r') as file:
        data_string = file.read()

    return data_string.split()

def do_part1(file):
    data_list = read_file(file)

    previous = 0
    increase_count = 0
    for data in data_list:
        previous_number = int(data)
        if previous != 0 and previous_number > previous:
            increase_count += 1
        previous = previous_number

    print(f"part 1 = {increase_count}")

def do_part2(file):
    data_list = read_file(file)
    sum_1 = 0
    sum_2 = 0
    increase_count = 0

    true_list = []
    for count in range(len(data_list)-2):    
        true_list.append([count, count+1, count+2])

    previous = 0
    for i in range(len(true_list)-1):
        sum_1 = sum_range(data_list, true_list[i])
        sum_2 = sum_range(data_list, true_list[i+1])
        if sum_2 > sum_1:
            increase_count += 1

    print(f"part2 = {increase_count}")

def sum_range(list, range_list):
    sum = 0
    try:
        for r in range_list:
            sum += int(list[r]) 
        return sum
    except:
        return -1
    

# main
file = "input.txt"
do_part1(file)
do_part2(file)
    
