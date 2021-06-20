using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Inlupp4
{
    public class ButtonRaster : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public ButtonRaster()
        {
        }

        protected override void OnClick()
        {
            //
            //  TODO: Sample code showing how to access button host
            //
           
            ArcMap.Application.CurrentTool = null;
            View msgView = new View();
            msgView.Show();
        }
        protected override void OnUpdate()
        {
            Enabled = ArcMap.Application != null;
        }
    }

}
