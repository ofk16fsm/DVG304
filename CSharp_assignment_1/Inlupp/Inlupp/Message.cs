using System;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.ArcMapUI;
using System.Collections.Generic;

namespace Inlupp
{
    public partial class Message : Form
    {
        private IMxDocument pMxDoc = ArcMap.Application.Document as IMxDocument;
        private IMap pMap;
        public Message()
        {
            InitializeComponent();
        }

        private void cmdInlupp_Click(object sender, EventArgs e)
        {
            IActiveView pActiveView = pMxDoc.ActiveView;
            AddShapefileUsingOpenFileDialog(pActiveView);
        }

        
        // ArcGIS Snippet Title:
        // Add Shapefile Using OpenFileDialog
        // 
        // Long Description:
        // Add a shapefile to the ActiveView using the Windows.Forms.OpenFileDialog control.
        // 
        // Add the following references to the project:
        // ESRI.ArcGIS.Carto
        // ESRI.ArcGIS.DataSourcesFile
        // ESRI.ArcGIS.Display
        // ESRI.ArcGIS.Geodatabase
        // ESRI.ArcGIS.Geometry
        // ESRI.ArcGIS.System
        // System
        // System.Windows.Forms
        // 
        // Intended ArcGIS Products for this snippet:
        // ArcGIS Desktop (ArcEditor, ArcInfo, ArcView)
        // ArcGIS Engine
        // 
        // Applicable ArcGIS Product Versions:
        // 9.2
        // 9.3
        // 9.3.1
        // 10.0
        // 
        // Required ArcGIS Extensions:
        // (NONE)
        // 
        // Notes:
        // This snippet is intended to be inserted at the base level of a Class.
        // It is not intended to be nested within an existing Method.
        // 

        ///<summary>Add a shapefile to the ActiveView using the Windows.Forms.OpenFileDialog control.</summary>
        ///
        ///<param name="activeView">An IActiveView interface</param>
        /// 
        ///<remarks></remarks>
        public void AddShapefileUsingOpenFileDialog(IActiveView activeView)
        {
            //parameter check
            if (activeView == null)
            {
                return;
            }

            // Use the OpenFileDialog Class to choose which shapefile to load.
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "h:\\";
            openFileDialog.Filter = "Shapefiles (*.shp)|*.shp";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = true;


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // The user chose a particular shapefile.

                // The returned string will be the full path, filename and file-extension for the chosen shapefile. Example: "C:\test\cities.shp"
                string shapefileLocation = openFileDialog.FileName;

                if (shapefileLocation != "")
                {
                    // Ensure the user chooses a shapefile

                    // Create a new ShapefileWorkspaceFactory CoClass to create a new workspace
                    IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactoryClass();

                    // System.IO.Path.GetDirectoryName(shapefileLocation) returns the directory part of the string. Example: "C:\test\"
                    IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspaceFactory.OpenFromFile(System.IO.Path.GetDirectoryName(shapefileLocation), 0); // Explicit Cast

                    // System.IO.Path.GetFileNameWithoutExtension(shapefileLocation) returns the base filename (without extension). Example: "cities"
                    IFeatureClass featureClass = featureWorkspace.OpenFeatureClass(System.IO.Path.GetFileNameWithoutExtension(shapefileLocation));

                    IFeatureLayer featureLayer = new FeatureLayerClass();
                    featureLayer.FeatureClass = featureClass;
                    featureLayer.Name = featureClass.AliasName;
                    featureLayer.Visible = true;
                    activeView.FocusMap.AddLayer(featureLayer);

                    // Zoom the display to the full extent of all layers in the map
                    activeView.Extent = activeView.FullExtent;
                    activeView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                }
                else
                {
                    // The user did not choose a shapefile.
                    // Do whatever remedial actions as necessary
                    // System.Windows.Forms.MessageBox.Show("No shapefile chosen", "No Choice #1",
                    //                                     System.Windows.Forms.MessageBoxButtons.OK,
                    //                                     System.Windows.Forms.MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                // The user did not choose a shapefile. They clicked Cancel or closed the dialog by the "X" button.
                // Do whatever remedial actions as necessary.
                // System.Windows.Forms.MessageBox.Show("No shapefile chosen", "No Choice #2",
                //                                      System.Windows.Forms.MessageBoxButtons.OK,
                //                                      System.Windows.Forms.MessageBoxIcon.Exclamation);
            }
        }

        private void cmdRst_Click(object sender, EventArgs e)
        {
            Restaurants restaurant = new Restaurants();
            restaurant.Show_Restaurants();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Type_Subsets();
            AddShapefileToMap();
        }
        private void cmdClean_Click(object sender, EventArgs e)
        {
            Restaurants restaurant = new Restaurants();
            restaurant.ClearSelectedMapFeatures();
        }
        public void Type_Subsets()
        {
            //'* Searches the active data frame for a layer called
            //'* "...". When found, creates a new collection of names to pass to another sub
            //'* that creates a new shapefile for each individual search criteria
            //'**** Callls to: Util_Extract
            //'***** Locals: pMxDoc, pMap, pLayers, pLayer, colRivers, strQueryField, i
            IMxDocument pMxDoc = ArcMap.Application.Document as IMxDocument;            
            pMap = pMxDoc.FocusMap;
            IEnumLayer pEnumLayer = pMap.Layers;
            ILayer pLayer;
            pLayer = pMap.Layer[0];
            List<string> colTypes = new List<string>();
            // Skapar en samling av nya platser
            colTypes.Add("restaurant");

            string strQueryField;
            strQueryField = "type";
            Utilities util = new Utilities();

            // För varje item i kollektionen anropa klassen Utilities. Util_Extract med argumenten lager, sökvärdet och sökfältsnamn
            foreach (var attrType in colTypes)
            {
                util.Util_Extract(pLayer, attrType, strQueryField);
                MessageBox.Show("Finished creating type subsets");
            }
        }
        public void AddShapefileToMap()
        {
            pMap = pMxDoc.FocusMap;
            string mapPath = @"H:\CSharp\NewData";
            // Skapa feature class namn för den nya shapefilen
            IWorkspaceFactory shpWorkspaceFactory = new ShapefileWorkspaceFactoryClass();
            IWorkspace shpWorkspace = shpWorkspaceFactory.OpenFromFile(mapPath, 0);

            // Ladda den nya skapade shapefilen till mxd

            IFeatureWorkspace featureWorkspace = shpWorkspace as IFeatureWorkspace;
            IFeatureLayer featureLayerRestaurant = new FeatureLayerClass();
            featureLayerRestaurant.FeatureClass = featureWorkspace.OpenFeatureClass("restaurant");
            ILayer layerRestaurant = (ILayer)featureLayerRestaurant;
            layerRestaurant.Name = featureLayerRestaurant.FeatureClass.AliasName;

            // Lägger lager till mappen
            pMap = pMxDoc.FocusMap;
            pMap.AddLayer(layerRestaurant);
            pMxDoc.UpdateContents();
        }       
    }
}
