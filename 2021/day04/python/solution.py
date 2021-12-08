import re
import timeit
from collections  import defaultdict

DO_TEST = 0

def read_file(filename):
    with open(filename, 'r') as file:
        data_string = file.read()

    return data_string.split("\n")

def do_part1(file):
    data = read_file(file)

    randoms = data[0].split(',')
    decks = get_decks(data[2:])
    bingo = False

    for number in randoms:
        deck_number = 0
        for deck in decks:
            card_set_number = 0
            for cards in deck:
                card_number = 0
                for card in cards:
                    if card == number:
                        decks[deck_number][card_set_number][card_number] = '*'
                    card_number += 1
                card_set_number += 1
            bingo = check_win(decks[deck_number])
            if bingo:
                result = number
                break
            deck_number +=1
        if bingo: break
        
    remaining = sum_deck(decks[deck_number])
    result = int(number) * int(remaining)
    print(f"part 1 = {result}")

def do_part2(file):
    data = read_file(file)
    randoms = data[0].split(',')
    decks = get_decks(data[2:])
    bingo = False
    stop = False
    wins = defaultdict(int)
    win_number = 1
    for number in randoms:
        deck_number = 0
        for deck in decks:
            card_set_number = 0
            for cards in deck:
                card_number = 0
                for card in cards:
                    if card == number:
                        decks[deck_number][card_set_number][card_number] = '*'
                    card_number += 1
                card_set_number += 1
            
            bingo = check_win(decks[deck_number])
            if bingo:
                if not deck_number in wins:
                    wins[deck_number] = win_number
                    win_number += 1
                    bingo = False
            if len(wins) == len(decks):
                stop = True
                break
            deck_number +=1
        if stop: break
        
    remaining = sum_deck(decks[deck_number])
    result = int(number) * int(remaining)
    print(f"part 2 = {result}")

def get_decks(data_list):
    cards = []
    decks = []
    for row in data_list:
        if len(row) > 0:
            cards.append(re.split("\s{1,}", row.strip()))
            try:
                cards.remove('')
            except:
                pass
        else:
            decks.append(cards)
            cards = []
    decks.append(cards)
    return decks
  

def sum_deck(deck):
    sum = 0
    for cards in deck:
        for card in cards:
            if card != '*':
                sum += int(card)
    return sum

def check_win(deck):
    for j in range(len(deck)):
        found = 0
        for card in deck[j]:
            if card == '*':
                found += 1
        
        if found == len(deck[j]):
            return True

    
    for j in range(len(deck[0])):
        found = 0
        for i in range(len(deck)):
            if deck[i][j] == '*':
                found += 1

        if found == len(deck):
            return True

    return False

# main
test = "test.txt"
real = "input.txt"
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
    