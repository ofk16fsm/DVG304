# Name:        Exercise_2
#
# Author:      ofk16fsm Ferhat Sevim
#
# Created:     26-03-2018

import os
import arcpy

arcpy.env.overwriteOutput = True
gdb_path = r'H:\Python\Exercise2_files\Lab2.gdb'
fc_name = 'Airports'
fc_path = os.path.join(gdb_path,fc_name)
print(fc_path)
cnt = arcpy.GetCount_management(fc_path)
print("All airports", cnt)

result = arcpy.MakeFeatureLayer_management(in_features=fc_path,out_layer="AirportsLayer")
sql = "type LIKE '%military%'"
arcpy.SelectLayerByAttribute_management(in_layer_or_view="AirportsLayer",selection_type="NEW_SELECTION",where_clause=sql)
out_fc = os.path.join(gdb_path,"MilitaryAirports")
arcpy.CopyFeatures_management("AirportsLayer",out_fc)
cnt=arcpy.GetCount_management(out_fc)
print("Military airports",cnt)