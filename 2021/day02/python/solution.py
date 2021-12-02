# imports here

def read_file(filename):
    with open(filename, 'r') as file:
        data_string = file.read()

    return data_string.split("\n")

def do_part1(file):
    data = read_file(file)
    x = 0
    y = 0
  
    for direction in data:
        command, step = (direction.split()[0], int(direction.split()[1]))
        if command == "up" : y -= step
        if command == "down" : y += step
        if command == "forward" : x += step


    print(f"part 1 = {x * y}")

def do_part2(file):
    data = read_file(file)
    x = 0
    y = 0
    result = 0
    aim = 0

    for direction in data:
        command, step = (direction.split()[0], int(direction.split()[1]))
        if command == "up" : 
            # y -= step
            aim -= step
        if command == "down" : 
            # y += step
            aim += step
        if command == "forward" : 
            x += step
            y += aim * step


    print(f"part2 = {x*y}")
    

# main
file = "input.txt"
do_part1(file)
do_part2(file)
    
