# Name:        Assignment_3
#
# Author:      ofk16fsm
#
# Created:     03-04-2018

# This script runs the Buffer tool. The user supplies the input
#  and output paths, and the buffer distance.
import os
import arcpy
from arcpy.sa import *
import numpy as np
arcpy.env.overwriteOutput = True

try:
    # Get the input parameters for the Buffer tool
    #arcpy.env.workspace = arcpy.GetParameterAsText(0)
    in_featureclass = arcpy.GetParameterAsText(0)
    out_feautreclass = arcpy.GetParameterAsText(1)
    bufferDistance = arcpy.GetParameterAsText(2)
    units = arcpy.GetParameterAsText(3)
    DEM = arcpy.GetParameterAsText(4)

    in_arr = arcpy.RasterToNumPyArray(DEM,nodata_to_value=9999)

    # Run the Buffer tool
    arcpy.Buffer_analysis(in_featureclass, out_feautreclass, bufferDistance + ' ' + units)

    # Report a success message
    arcpy.AddMessage("All done!")

    arcpy.CheckOutExtension("Spatial") # Make sure that Spatial Analyst is active
    
    # Execute ExtractByMask
    outExtractByMask = ExtractByMask(DEM,out_feautreclass)
    
    # Save the output
    outExtractByMask.save(r'H:\Python\Exercise3_data\masked.tif')

    maxR = in_arr.max()
    cutoffElevation = maxR*0.5
    outRaster = Raster(DEM) > cutoffElevation
    outRaster.save(r"H:\Python\Exercise3_data\ArbraDEMHI.tif")


except:
    # Report an error messages
    arcpy.AddError("Could not complete the buffer")

    # Report any error messages that the Buffer tool might have generated
    arcpy.AddMessage(arcpy.GetMessages())
