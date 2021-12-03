# imports here

def read_file(filename):
    with open(filename, 'r') as file:
        data_string = file.read()

    return data_string.split("\n")

def do_part1(file):
    data = read_file(file)
    
    acc = []

    for cons in data:
        ctr = 0
        for bit in cons:
            if len(acc) == ctr:
                if bit == "0": acc.append(0)
                else: acc.append(1)
            else:
                if bit == "0": acc[ctr] -= 1
                else: acc[ctr] +=1

            ctr += 1   

    epsilon = ""
    gamma = ""
    for val in acc:
        if val >0: 
            epsilon += "1"
            gamma += "0"
        else:
            epsilon += "0"
            gamma += "1"
    
    ep = int(epsilon,2)
    gm = int(gamma,2)

    result = ep * gm
    print(f"part 1 = {result}")

def do_part2(file):
    data = read_file(file)

    o2_rate = process(data, True)
    c2_rate = process(data, False)
    
    result = o2_rate * c2_rate
    print(f"part 2 = {result}")
    
def process(data_list, is_oxigen):
    temp_data = data_list[:]
    
    for bit_count in range(len(data_list[0])):
        zeros = []
        ones = []
        
        ctr = 0
        z = 0
        o = 0
        
        for bits in temp_data:

            if len(temp_data) == 1 : break

            if bits[bit_count] == "0":
                zeros.append(temp_data[ctr])
                z += 1
            else:
                ones.append(temp_data[ctr])
                o += 1
            ctr += 1

        if is_oxigen:
            if z>o:
                for i in ones:
                    temp_data.remove(i)
            else:
                for i in zeros:
                    temp_data.remove(i)
        else:
            if z<o or z == o :
                for i in ones:
                    temp_data.remove(i)
            else:
                for i in zeros:
                    temp_data.remove(i)

    return int(temp_data[0],2)
    

# main
file = "input.txt"
do_part1(file)
do_part2(file)
    
