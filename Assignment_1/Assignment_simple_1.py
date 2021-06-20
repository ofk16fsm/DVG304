import csv

def unique_values_counter(csv_file, header_name):
    read_file = open(csv_file, 'r')
    reader = csv.reader(read_file)
    headers = next(reader)
    column = {}
    # Jag läser headers namnen och det läggs till en dict.
    for h in headers:
        column[h] = []

    # Jag loopar igenom reader och loopar igenom både headers och rad med hjälp av zip funktionen.
    for row in reader:
        for h, v in zip(headers, row):
            # Jag lägger till raderna till list.
            column[h].append(v)

    return set(column[header_name])

csv_path = r'USCounties.csv'
for i in (unique_values_counter(csv_path, header_name='STATE_NAME')):
    print(i)
    
print(len(unique_values_counter(csv_path, header_name='STATE_NAME')))