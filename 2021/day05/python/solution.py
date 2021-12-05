import numpy as np

def read_file(filename):
    with open(filename, 'r') as file:
        data_string = file.read()

    lines = data_string.split("\n")
    coordinates = []
    for line in lines:
        coor1 = line.split('->')[0].strip()
        coor2 = line.split('->')[1].strip()
        p1 = (int(coor1.split(',')[0]), int(coor1.split(',')[1]))
        p2 = (int(coor2.split(',')[0]), int(coor2.split(',')[1]))
        coordinates.append((p1,p2))
    return coordinates

def do_part1(file):
    data = read_file(file)
    
    map = np.zeros((MAX_X,MAX_Y))

    for coords in data:
        x1,y1 = coords[0]
        x2,y2 = coords[1]
        start = 0
        if x1==x2:
            start = min(y1, y2)
            end = max(y1,y2)
            while start <= end:
                if map[x1,start] == 0:
                    map[x1,start] = 1
                else:
                    map[x1,start] = 2

                start +=1
        elif y1==y2:
            start = min(x1, x2)
            end = max(x1,x2)
            while start <= end:
                if map[start,y1] == 0:
                    map[start,y1] = 1
                else:
                    map[start,y1] = 2

                start +=1

    result = np.count_nonzero(map >= 2)
    print(f"part 1 = {result}")

def do_part2(file):
    data = read_file(file)
    
    map = np.zeros((MAX_X,MAX_Y))

    for coords in data:
        x1,y1 = coords[0]
        x2,y2 = coords[1]
        start = 0
        if x1==x2:
            start = min(y1, y2)
            end = max(y1,y2)
            while start <= end:
                if map[x1,start] == 0:
                    map[x1,start] = 1
                else:
                    map[x1,start] = 2

                start +=1
        elif y1==y2:
            start = min(x1, x2)
            end = max(x1,x2)
            while start <= end:
                if map[start,y1] == 0:
                    map[start,y1] = 1
                else:
                    map[start,y1] = 2

                start +=1
        elif abs(x1-x2)==abs(y1-y2):

            d = abs(x1 - x2)
            e = abs(y1-y2)
            
            mx = 1 if x1 < x2 else -1
            my = -1 if y1 > y2 else 1

            c = 0
            while c<=d:
                if map[x1,y1] == 0:
                   map[x1,y1] = 1
                else:
                    map[x1,y1] = 2

                x1 += mx
                y1 += my

                c += 1


    result = np.count_nonzero(map == 2)
    print(f"part 2 = {result}")


# main
file = "input.txt"
MAX_X = 999
MAX_Y = 999
do_part1(file)
do_part2(file)
    