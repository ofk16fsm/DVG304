# Name:        Assignment_2
#
# Author:      ofk16fsm Ferhat Sevim
#
# Created:     26-03-2018

import os
import arcpy
import csv

arcpy.env.overwriteOutput = True

# Punkt 1
# Det skriver ut funktion klassen, geometri typ och koordinatsystem.

gdb_path = r'H:\Python\Exercise2_files\Lab2.gdb'
fc_name = 'Countries'
fc_path = os.path.join(gdb_path, fc_name)
print(fc_path)

desc = arcpy.Describe(fc_path)
print(desc.shapeType)
print(desc.spatialReference.name)
print(desc.datasetType)

# Punkt 2
# Här skriver jag ut lista av ländernas namn i kontinent South America
# och har befolkning över 20 miljon människor.

print("\nCountries have population over 20 million in South America:")
fields = ['NAME','CONTINENT','POP_EST']
sql = (None,'ORDER BY POP_EST DESC')
cursor = arcpy.da.SearchCursor(in_table=fc_path, field_names=fields,where_clause="POP_EST > 20000000 AND CONTINENT='South America'",sql_clause=sql)
countries_data = []
for country in cursor:
    countries_data.append(country)

for i in countries_data:
    print(i)

# Punkt 3
# Jag skapar en ny funktionsklass i samma databas.
# Det ska bara innehålla länder som har värdet 1. Developed region: G7 i kolumnen ECONOMY.
cnt = arcpy.GetCount_management(fc_path)
result = arcpy.MakeFeatureLayer_management(in_features=fc_path,out_layer='DevelopedLayer')
sql_1 = "ECONOMY LIKE '%1. Developed region: G7%'"
arcpy.SelectLayerByAttribute_management(in_layer_or_view="DevelopedLayer",selection_type="NEW_SELECTION",where_clause=sql_1)
out_fc = os.path.join(gdb_path,"DevelopedCountries")
arcpy.CopyFeatures_management("DevelopedLayer",out_fc)
cnt = arcpy.GetCount_management(out_fc)
print("1. Developed countries in region: G7",cnt)

# Punkt 4
# Här skriver jag ut Karibien länder.
print("\nCaribbean countries:")
fields_2 = ['NAME','GDP_MD_EST']
sql_2 = (None,'ORDER BY GDP_MD_EST DESC')
cursor_2 = arcpy.da.SearchCursor(in_table=fc_path, field_names=fields_2,where_clause="SUBREGION='Caribbean'",sql_clause=sql_2)
caribbean_countries = []
for country in cursor_2:
    caribbean_countries.append(country)

for i in caribbean_countries:
    print(i)

# Här skapar jag csv fil som sparar Karibien länder.
out_csv = open(r'H:\Python\csv_file.csv', 'wb')
wr = csv.writer(out_csv,delimiter=',')
wr.writerow(['Name','GDP Value'])
for row in caribbean_countries:
    wr.writerow(str(row).strip('()').split(','))
out_csv.close()