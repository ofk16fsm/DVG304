# Name:        Assignment_3
#
# Author:      ofk16fsm
#
# Created:     03-04-2018

import os
import arcpy
import arcpy.mapping as mp

mxd_file = r"H:\Python\Exercise3_data\Lab3_data\Lab3_assignment.mxd"
mxd = mp.MapDocument(mxd_file)
src_gdb = r"H:\Python\Exercise3_data\Lab3_data\Lab3.gdb"
prod_gdb= r"Lab3Copy.gdb"

out_gdb_dir = os.path.dirname(mxd.filePath)
print(out_gdb_dir)
out_gdb_path = os.path.join(out_gdb_dir,prod_gdb)


if arcpy.Exists(out_gdb_path):
    arcpy.Delete_management(out_gdb_path)

arcpy.CreateFileGDB_management(out_gdb_dir,prod_gdb)

#arcpy.Copy_management(src_gdb,prod_gdb)


print(mxd.author)
print(mxd.credits)
print(mxd.description)

map_layers = mp.ListLayers(mxd,'')

print("Total numbers of layers:",len(mp.ListLayers(mxd)))

for lyr in map_layers:
    if lyr.supports('DATASOURCE'):
        print("Layer name: {}\nData source: {}".format(lyr.name,lyr.dataSource))

'''
for lyr in map_layers:
    if not lyr.isGroupLayer:
        lyr.findAndReplaceWorkspacePath(src_gdb,prod_gdb)
'''
mxd.findAndReplaceWorkspacePaths(src_gdb,prod_gdb)
target_mxd = r"H:\Python\Exercise3_data\Lab3_data\Lab3_assignment_2.mxd"
mxd.saveACopy(target_mxd)
del mxd

mxd_1 = mp.MapDocument(target_mxd)
map_layers = mp.ListLayers(mxd_1,'')
print("\nGet layers sourse for the {}".format(target_mxd))
print("-"*80)

for lyr in map_layers:
    if lyr.supports("DATASOURCE"):
        print(lyr.name, ">>", lyr.dataSource)
del mxd_1
