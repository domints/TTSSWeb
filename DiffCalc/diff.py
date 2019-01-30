import csv

old = {}
new = {}

with open('older.csv') as olderFile:
    csvReader = csv.reader(olderFile)
    for row in csvReader:
        old[int(row[0][2:])] = int(row[1])

with open('newer.csv') as newerFile:
    csvReader = csv.reader(newerFile)
    for row in csvReader:
        new[int(row[0][2:])] = int(row[1])

for tramNo, id in new.items():
    if tramNo in old:
        print('{} => {}'.format(tramNo, id - old[tramNo]))
    else:
        closest = -1
        actual = tramNo - 1
        while actual > 99:
            if actual in old and tramNo - actual < tramNo - closest:
                closest = actual
                actual = 0
            else:
                actual -= 1
        actual = tramNo + 1
        while actual < 1000:
            if actual in old and actual - tramNo < tramNo - closest:
                closest = actual
                actual = 1000
            else:
                actual += 1
        if closest > -1:
            print('{} => {}'.format(tramNo, id - (old[closest] + ((tramNo - closest) * 4))))