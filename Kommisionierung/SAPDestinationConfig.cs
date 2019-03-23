using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SAP.Middleware.Connector; // your sap connector


namespace Kommisionierung
{
    public class SAPDestinationConfig : IDestinationConfiguration
    {
        public bool ChangeEventsSupported()
        {
            return false;
        }

        public event RfcDestinationManager.ConfigurationChangeHandler ConfigurationChanged;

        public RfcConfigParameters GetParameters(string destinationName)
        {
            RfcConfigParameters parms = new RfcConfigParameters();

            if (destinationName.Equals("vm-lmk-saptsent"))
            //if (destinationName.Equals("DMS2010"))
            {
                parms.Add(RfcConfigParameters.AppServerHost, "vm-lmk-saptsent");
              //parms.Add(RfcConfigParameters.AppServerHost, "DMS2010");
                parms.Add(RfcConfigParameters.SystemNumber, "00");
                parms.Add(RfcConfigParameters.User, "manager");
                parms.Add(RfcConfigParameters.Password, "U1Iir23B");
                parms.Add(RfcConfigParameters.Client, "001");
                parms.Add(RfcConfigParameters.Language, "DE");
            }
            return parms;

        }
    }
}
