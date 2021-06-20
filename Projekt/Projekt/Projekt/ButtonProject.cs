using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Projekt
{
    public class ButtonProject : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public ButtonProject()
        {
        }

        protected override void OnClick()
        {
            //
            //  TODO: Sample code showing how to access button host
            //
            View msgView = new View();
            msgView.Show();
            ArcMap.Application.CurrentTool = null;
        }
        protected override void OnUpdate()
        {
            Enabled = ArcMap.Application != null;
        }
    }

}
