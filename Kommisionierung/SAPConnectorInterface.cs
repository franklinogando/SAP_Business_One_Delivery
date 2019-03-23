using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SAP.Middleware.Connector;

namespace Kommisionierung
{
    class SAPConnectorInterface
    {

        private RfcDestination rfcDestination;

        public bool TestConnection(string destinationName){        
        
            bool result = false;

            try
            {
                rfcDestination = RfcDestinationManager.GetDestination(destinationName);
                if (rfcDestination != null)
                {

                    rfcDestination.Ping();
                    result = true;
                }
            }
            catch (Exception ex) {

                result = false;
                throw new Exception("Connection Failure Error: " + ex.Message);
            }

            return result;
        }
    }
}
