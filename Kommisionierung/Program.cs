using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SAP.Middleware.Connector;
using System.Text;
using System.Threading;

namespace Kommisionierung
{
    static class Program
    {

        const string ABAP_APP_SERVER = "vm-lmk-saptsent";
        const string ABAP_MESSAGE_SERVER = "vm-lmk-saptsent";
        //const string ABAP_APP_SERVER = "DMS2010";
        //const string ABAP_MESSAGE_SERVER = "DMS2010";

        static Login_Form loginForm;
        static Consignment_Form confirmForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            loginForm = new Login_Form();
//          confirmForm = new Consignment_Form(null);
//          loginForm.Show();

            
            

            Application.Run(loginForm);
            
            
//            Application.Run(new Login_Form());
//            Application.Run(new Consignment_Form());
        }

        
         

        public static void ShowConsignmentForm(SAPConnector sapConnector) {

            confirmForm = new Consignment_Form(sapConnector);
            if (confirmForm.TableExist)
            {
                loginForm.Hide();
                confirmForm.Show();
            }
        }


        public static void ShowLoginForm() {

        
            loginForm.Show();
        }

        /// <summary>
        /// Schließt auch die Login-Maske und beendet somit die gesamte Applikation, 
        /// falls das FormClosed-Event ausgelöst wird von der Kommissionier-Form.
        /// </summary>
        public static void CloseEverything() {

          //  confirmForm.Close();
            loginForm.Close();
        }
    }
}
