import csv

def unique_values_counter(input_csv_file, top, header_name):
    # Jag använder set() som är en orörd samling med icke dubbla elementer.
    #unique_values = set()
    with open(input_csv_file, 'r') as read_csv:
        reader = csv.reader(read_csv)
        # Next gör att det läser nästa raden i filen.
        if header_name in next(reader):
        	return set([row[1] for row in reader if reader.line_num <= top])
        '''
        for row in reader:
            # row[1] är lika med STATE_NAME
            header_name = row[1]
            unique_values.add(header_name)
            # line_num är rad numrena för filen
            if reader.line_num == top:
                break
        return unique_values
		'''
csv_path = r"USCounties.csv"
print(unique_values_counter(csv_path, top=100, header_name='STATE_NAME'))
