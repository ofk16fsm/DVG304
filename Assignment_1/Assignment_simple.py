import csv
f = open(r'USCounties.csv','r')
reader = csv.reader(f) #creating the reader object
headers = next(reader) #getting the list of headers
print (headers)

r = list(reader)
uniq = []
for row in r:
	STATE_NAME = row[1]
	if STATE_NAME not in uniq:
		uniq.append(STATE_NAME)
		
for i in uniq:
	print(i)
	
print(len(uniq))