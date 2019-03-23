using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using System.Data.SqlClient;
using SAP.Middleware.Connector;

using Kommisionierung;


namespace Kommisionierung
{
    public partial class Login_Form : Form
    {


        public Login_Form()
        {
            InitializeComponent();

            // Ermittle vorhandene Firmen
            LoadCompanies();

            cobCompanies.SelectedIndex = 0;

        }

        /// <summary>
        /// Lädt alle vorhanden Datenbanken über eine SQL-Abfrage in das Combobox-Datenfeld. 
        /// </summary>
        private void LoadCompanies() {

            //Password verschlüsseln
            string connectionString = "Data Source=VM-LMK-SAPTSENT;User ID=sa;Password=SAPB1Admin";      
            //string connectionString = "Data Source=DMS2010;User ID=sa;Password=SAPB1Admin";  
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection();
            con.ConnectionString = connectionString;
            con.Open();
            if (con.State == System.Data.ConnectionState.Open) {

                // Finde SERVERNAME
                SqlCommand command = new SqlCommand("SELECT @@SERVERNAME AS 'Server Name'", con);
                //SqlCommand command = new SqlCommand("SELECT 'DMS2010'", con);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                UserSettings.SERVERNAME = reader[0].ToString();
                reader.Close();

                // Finde vorhandene SAP-Companies
                command = new SqlCommand("SELECT dbName FROM [SBO-COMMON].[dbo].SRGC", con);
                //command = new SqlCommand("SELECT 'DFE_20170803'", con);
                using (reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        cobCompanies.Items.Add(reader[0].ToString());
                    }
                    reader.Close();
                    command.Dispose();
                }
            }
            con.Close();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserSettings.COMPANYDB      = cobCompanies.Text;
            UserSettings.USERNAME       = tbUserName.Text;
            UserSettings.USERPASSWORD   = tbPassword.Text;

            // Benutzer muss kurz warten bis SAP-Company verbunden ist
            WaitForm waitingForm = new WaitForm();
            waitingForm.Show();
            SAPConnector sapConnector = new SAPConnector();
            waitingForm.Close();

            if (sapConnector.IsConnected)
            {
                UserSettings.USERSIGNATUR = sapConnector.GetUserId();
                Program.ShowConsignmentForm(sapConnector);
            }
            else
            {
                MessageBox.Show("Es konnte keine Verbindung zum SAP-System hergestellt werden.\nÜberprüfen Sie bitte ihre Anmeldedaten.");
            }
        }

        private void cobCompanies_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Login_Form_Load(object sender, EventArgs e)
        {

        }        
    }
}
