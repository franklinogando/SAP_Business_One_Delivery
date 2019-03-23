// TRANSINFO: Option Strict Off
// TRANSINFO: Option Explicit On
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

using SAP;
using SAPbobsCOM;
using SAPbouiCOM;


using SAP.Middleware.Connector;
using System.Threading;

namespace Kommisionierung
{

    public class SAPConnector
    {
        private SAPbobsCOM.Recordset _orec;
        private /* TRANSINFO: WithEvents */ SAPbouiCOM.Application SBO_Application;
        private SAPbobsCOM.Company _oCompany;

        private bool _isConnected = false;
        
        public SAPConnector() {

            if (EnableSAPConnection() == 0) _isConnected = true;
        }

        public int EnableSAPConnection() {

            SAPbouiCOM.SboGuiApi SboGuiApi = null;
            string sCon = String.Empty;
            SboGuiApi = new SAPbouiCOM.SboGuiApi();

            // Mehr zur Verbindugen:  https://archive.sap.com/discussions/thread/1732991, 2018-09-03
            // Verbindung über DEBUG-Modus
            if (Environment.GetCommandLineArgs().Length > 1)
            {
                sCon = System.Convert.ToString(Environment.GetCommandLineArgs().GetValue(1));
            } // Verbindung über Release - Modus
            else {
                sCon = System.Convert.ToString(Environment.GetCommandLineArgs().GetValue(0));
            }


            if (!(SetConnectionContext() == 0))
            {
                return -1;
            }
            
            // //*************************************************************
            // // Connect To The Company Data Base
            // //*************************************************************

            if (!(ConnectToCompany() == 0))
            {
                return -2;
            }
            _orec = (SAPbobsCOM.Recordset) this._oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            return 0;
        }

        public bool IsConnected {

            get {
                return _isConnected;
            }
        }

        public void CloseConnection() {

            _oCompany.Disconnect();
            _isConnected = false;
        }


        public int GetUserId() {

            return this._oCompany.UserSignature;
        }

        private int SetConnectionContext() { 
            int setConnectionContextReturn = 0;            
            string sCookie = null;             
            
            _oCompany = new SAPbobsCOM.Company();
            _oCompany.Server = UserSettings.SERVERNAME;    //"vm-lmk-saptsent";
            _oCompany.language = SAPbobsCOM.BoSuppLangs.ln_German;
            _oCompany.DbServerType = BoDataServerTypes.dst_MSSQL2008;
            _oCompany.LicenseServer = UserSettings.SERVERNAME + ":30000";
            _oCompany.UseTrusted = false;
            _oCompany.CompanyDB = UserSettings.COMPANYDB;  //"DFE_20170803";
            _oCompany.UserName = UserSettings.USERNAME ;//"manager";
            _oCompany.Password = UserSettings.USERPASSWORD ;//"U1Iir23B";
            sCookie = _oCompany.GetContextCookie(); 
            if ( _oCompany.Connected == true ) { 
                _oCompany.Disconnect();
            }             
            return setConnectionContextReturn;
        }

     
        private int ConnectToCompany() { 
            int connectToCompanyReturn = 0;
            
            // // Establish the connection to the company database.
            connectToCompanyReturn = _oCompany.Connect(); 

            return connectToCompanyReturn;
        } 
        
       
        public SAPbobsCOM.Recordset GetRecordSet() {

            return this._orec;
        }
    }
}