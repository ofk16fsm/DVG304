import csv

def unique_values_counter(csv_file, header_name):
	read_csv = open(csv_file, 'r')
	reader = csv.reader(read_csv) # Create the reader object
	headers = next(reader)
	index_headers = headers.index(header_name)
	uniq = []
	# If statement will check if headername is inside headers
	if header_name in headers:
		for column in list(reader):
			if column[index_headers] not in uniq:
				uniq.append(column[index_headers])
	
	return uniq
	
csv_file = r'USCounties.csv'
for i in unique_values_counter(csv_file, header_name='STATE_NAME'):
	print(i)