using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

namespace CreateRow
{
    public class Button1 : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public Button1()
        {
        }

        protected override void OnClick()
        {
            //
            //  TODO: Sample code showing how to access button host
            //
            IMxDocument pMxDoc = ArcMap.Application.Document as IMxDocument;
            IFeatureLayer pFLayer = pMxDoc.ActiveView.FocusMap.Layer[0] as IFeatureLayer;
            IDataset pDS = pFLayer.FeatureClass as IDataset;
            IFeatureWorkspace pFWS = pDS.Workspace as IFeatureWorkspace;
            ITable pTable = pFWS.OpenTable("Inlupp2");

            IWorkspaceEdit pWSE = pFWS as IWorkspaceEdit;
            pWSE.StartEditing(true);
            pWSE.StartEditOperation();
            IRow pRow = pTable.CreateRow();
            pRow.Value[pRow.Fields.FindField("STATS")] = 16;
            pRow.Value[pRow.Fields.FindField("STATS")] = 23;
            pRow.Store();
            pWSE.StopEditOperation();
            pWSE.StopEditing(true);

            ArcMap.Application.CurrentTool = null;
        }
        protected override void OnUpdate()
        {
            Enabled = ArcMap.Application != null;
        }
    }

}
