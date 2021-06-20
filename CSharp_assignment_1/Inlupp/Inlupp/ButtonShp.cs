using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace Inlupp
{
    public class ButtonShp : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public ButtonShp()
        {
        }

        protected override void OnClick()
        {
            Message msgForm = new Inlupp.Message();
            msgForm.ShowDialog();
        }

        protected override void OnUpdate()
        {
        }
    }
}
