using SBOAddonProject5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Management;
 


using System.Media;
using System.Text.RegularExpressions;
using Kommisionierung.port;

namespace Kommisionierung
{
    public partial class Consignment_Form : Form
    {
        
        bool amountItemcode ;
        SAPbobsCOM.Recordset _recordSet;
        bool flagAmountNumberistsoll = false;
        bool  cleantbscan1 = false;
        bool cleantbscan2 = false;
        string tbscanstring="";
        string scancode = "";
        //static bool _plusIsOn = true;
        static bool _changedContent = false;
        static string packnumberofSeriennumber = string.Empty;
        static string _docNum = "0";
        static string _docEntry;
        static string _status = String.Empty;
        static DateTime _DelivDate = DateTime.Now;

        string _minimumPackageNumber = "";
        string _maximumPackageNumber = "";

        DateTime begin;
        DateTime _lastKeystroke = new DateTime(0);

        string message = String.Empty;
        int _unit = 1;

        SAPConnector _sapConnector;


        public string LinenumAmountArtikelnummer = "";
        public string Artikelnummer2;
        public int AmountNumberist2;
        public string Packnumber = "";
     
        public int AmountNumbersoll2 ;
        string Packlnummer2 = "";

        string checkTableExistence =
        " DECLARE @FirstTable AS INT = -1"
        + " DECLARE @SecondTable AS INT = -1"
        + " "
        + " "
        + " IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES"
        + "            WHERE TABLE_NAME = N'@DRS_PACKAGE')"
        + " BEGIN"
        + "   SET @FirstTable = 0"
        + " END"
        + " "
        + " IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES"
        + "            WHERE TABLE_NAME = N'@DRS_PACKAGE_CONTENT')"
        + " BEGIN"
        + "   SET @SecondTable = 0"
        + " END"
        + " "
        + " "
        + " "
        + " IF @FirstTable = 0 AND @SecondTable = 0 "
        + " 	BEGIN"
        + " 		SELECT 0	"
        + " 	END"
        + " ELSE"
        + " 	BEGIN"
        + " 		SELECT -1"
        + " 	END";


        bool _tableExist = false;

        public bool TableExist {

            get {
                return _tableExist;
            }
        }

        public Consignment_Form(SAPConnector sapConnector)
        {
            InitializeComponent();
            this._sapConnector = sapConnector;
            this._recordSet = sapConnector.GetRecordSet();

            if (!DoesTableExist())
            {
                _tableExist = false;

                MessageBox.Show("Die benötigten Tabellen konnten nicht in der Datenbank gefunden werden.");
            }
            else
            {
                _tableExist = true;
                //tbUnitofQuantity.Text = _unit.ToString();
                //SetupPlusMinusButtons(true);
                //GetMinMaxPackageNumbs();
            }

            //_threadColorRow = new Thread(SetRowBackColor);
        }

        private bool DoesTableExist() {

            this._recordSet.DoQuery(checkTableExistence);
            int result = Int32.Parse(this._recordSet.Fields.Item(0).Value.ToString());

            if (result == 0) return true;
            else return false;
        
        }

        //private void GetMinMaxPackageNumbs() {

        //    try
        //    {
        //        //this._recordSet.DoQuery(DataManipulation.MINMAXPACKAGE);
        //        _minimumPackageNumber = this._recordSet.Fields.Item(0).Value.ToString();
        //        _maximumPackageNumber = this._recordSet.Fields.Item(1).Value.ToString();
        //    }
        //    catch (System.Runtime.InteropServices.COMException ex) {

        //        // Tabellen existieren nicht in DB
        //    }
        //}

        /// <summary>
        /// Prüft ob eine Änderung am Gridinhalt durchgeführt wurde. 
        /// Wenn ja wird gefragt ob diese Änderungen gespeichert werden sollen (z.B. durch vorherigen Belegwechsel augelöst).
        /// </summary>
        private bool CheckForChangedContent() {

            if (_changedContent) {

                DialogResult dialogResult = MessageBox.Show("Es existieren Anpassungen in der Packetliste.\nMöchten Sie fortfahren ohne zu speichern?", "Frage nach Aktualisierung", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    return true;
                }
                else if (dialogResult == DialogResult.No)
                {
                    return false;
                }
            }

            return true;
        }


        private void SetStatus(string status) {

            //switch (status) {             
            //    case "O": // Offen
            //        this.cobStatus.SelectedItem = this.cobStatus.Items[0];
            //        break;

            //    case "B": // (In) Bearbeitung
            //        this.cobStatus.SelectedItem = this.cobStatus.Items[1];
            //        break;

            //    case "c": // Geschlossen
            //        this.cobStatus.SelectedItem = this.cobStatus.Items[2];
            //        break;
            //}
        
        }


        /// <summary>
        /// Befüllt das Grid mit den Inhalten aus der Tabelle: DRS_PACKAGE_CONTENT.
        /// </summary>
        /// <param name="docNum">DocNum aus der Tabelle DRS_PACKAGE.</param>
        /// <param name="mode">Gib an ob der Max/Min DocNum Eintrag oder direkt die DocNum gesucht werden soll.</param>
        public void FillPackageForm(string docNum ){
            packnumberofSeriennumber = "";
            this.dataGridView.Rows.Clear();
            EnablePackagForm(true);
            
            if (!CheckForChangedContent()) return; // Abbruch

            _changedContent = false;
            btnNextRecord.Enabled = true;
            btnPrevRecord.Enabled = true;
            dataGridView.Columns[0].Visible = true;//packnum
            dataGridView.Columns[8].Visible = true;//doentry
            dataGridView.Columns[9].Visible = true;//rn

            if (docNum == "")
            {
                btnNextRecord.Enabled = false;
                btnPrevRecord.Enabled = false;
                dataGridView.Columns[0].Visible = false;//packnum

                dataGridView.Columns[8].Visible = false;//doentry
                dataGridView.Columns[9].Visible = false;//rn
                lblpostdate.Text = "";
                return;
            }

            else
            {
                string querGetRecord1 = String.Format(DataManipulation.get_package_Packnumber_first, docNum);
                this._recordSet.DoQuery(querGetRecord1);

                
                 

                if (this._recordSet.RecordCount == 0)
                {
                    querGetRecord1 = String.Format(DataManipulation.insert_pachagecontentPacknumber_first, docNum);
                    this._recordSet.DoQuery(querGetRecord1);
                }


                string querGetRecord2 = String.Format(DataManipulation.GETRECORDPacknumber_secondtime, docNum);
                this._recordSet.DoQuery(querGetRecord2);
                if (this._recordSet.RecordCount == 0)
                {
                    lblpostdate.Text = "";
                }
                else
                {
                    _DelivDate = Convert.ToDateTime(this._recordSet.Fields.Item(7).Value);
                    lblpostdate.Text = _DelivDate.ToString("dd.MM.yyyy");// dd/MM/yyyy hh:mm tt
                }
                string RowNumber = this._recordSet.Fields.Item(9).Value.ToString();

                //first search packnumber and add to packagecontent table
                if (RowNumber == "0")
                {
                    querGetRecord2 = String.Format(DataManipulation.GETRECORDPacknumber_first, docNum);
                    this._recordSet.DoQuery(querGetRecord2);

                    string querGetRecord3 = String.Format(DataManipulation.GETRECORDPacknumber_secondtime, docNum);
                    this._recordSet.DoQuery(querGetRecord3);

                }

                _docNum = this._recordSet.Fields.Item(0).Value.ToString();
                _docEntry = this._recordSet.Fields.Item(8).Value.ToString();
                //_status = this._recordSet.Fields.Item(8).Value.ToString();


                //SetStatus(_status);



                int statusnumber = 0;
                int sollistnumber = 0;
                bool flagsollistnumber = false;
                bool flagstatusnumber = false;
                int allIstone = 0;

                

                for (int row = 0; row < this._recordSet.RecordCount; row++)
                {
                     
                    int n = this.dataGridView.Rows.Add();
                    for (int f = 0; f < this._recordSet.Fields.Count; f++)
                    {

                        this.dataGridView.Rows[row].Cells[f].Value = this._recordSet.Fields.Item(f).Value.ToString();
                        DateTime date = Convert.ToDateTime(this._recordSet.Fields.Item(7).Value.ToString());
                        this.dataGridView.Rows[row].Cells[7].Value = date.ToString("dd.MM.yyyy");
                    }


                    //Geschlossen
                    if (this.dataGridView.Rows[row].Cells["Ist"].Value.ToString() == this.dataGridView.Rows[row].Cells["soll"].Value.ToString())
                    {
                        sollistnumber += 1;
                        if (sollistnumber == this._recordSet.RecordCount)
                        {

                            cobStatus.SelectedIndex = cobStatus.Items.IndexOf("Geschlossen");
                            flagsollistnumber = true;

                        }


                    }

                    if (this.dataGridView.Rows[row].Cells["Ist"].Value.ToString() == "1")
                    {
                        allIstone += 1;
                        if (allIstone == this._recordSet.RecordCount && this._recordSet.RecordCount != 1 && sollistnumber == this._recordSet.RecordCount)
                        {

                            cobStatus.SelectedIndex = cobStatus.Items.IndexOf("Geschlossen");
                            flagsollistnumber = true;
                        }
                        //if (allIstone == this._recordSet.RecordCount && this._recordSet.RecordCount != 1 && this.dataGridView.Rows[row].Cells["Ist"].Value.ToString() != this.dataGridView.Rows[row].Cells["soll"].Value.ToString())
                        //{
                        //    cobStatus.SelectedIndex = cobStatus.Items.IndexOf("Offen");
                        //    flagsollistnumber = true;
                        //}
                    }

                    //Offen
                    if (this.dataGridView.Rows[row].Cells["Ist"].Value.ToString() == "0" && flagstatusnumber == false)
                    {

                        cobStatus.SelectedIndex = cobStatus.Items.IndexOf("Offen");

                    }

                    //Bearbeiten
                    if (this.dataGridView.Rows[row].Cells["Ist"].Value.ToString() != "0" && flagsollistnumber == false)
                    {

                        cobStatus.SelectedIndex = cobStatus.Items.IndexOf("In Bearbeitung");
                        flagstatusnumber = true;
                    }



                    _recordSet.MoveNext();
                }

            }
            
                dataGridView.Columns[0].Visible = false;//packnum

                dataGridView.Columns[8].Visible = false;//doentry
                dataGridView.Columns[9].Visible = false;//rn




                if (_status == "G")
                {

                    EnablePackagForm(false);
                }
            
        }


        /// <summary>
        /// Aktiviert / Deaktiviert bestimmte GUI-Elemente.
        /// </summary>
        /// <param name="enable"></param>
        private void EnablePackagForm(bool enable) {

            this.dataGridView.Enabled = enable;
            this.btnMainButton.Enabled = enable;
            this.tbScannedCode2.Enabled = enable;
            this.btnMinus.Enabled = enable;
            this.btnPlus.Enabled = enable;
        }


        /// <summary>
        /// Gibt den Zeilenindex aus, wenn eine komplette Übereinstimmung gefunden wurde.
        /// </summary>
        /// <param name="columnA">Erster Referenz Spaltenindex</param>
        /// <param name="columnB">Zweiter Referenz Spaltenindex</param>
        /// <param name="contentA">Erste Wert</param>
        /// <param name="contentB">Zweiter Wert</param>
        /// <returns></returns>
        private int GetRowIndex(int columnA, int columnB, string contentA, string contentB)
        {
            for (int r = 0; r < this.dataGridView.Rows.Count - 1; r++)
            {

               string valueA = this.dataGridView.Rows[r].Cells[columnA].Value.ToString();
               string valueB = this.dataGridView.Rows[r].Cells[columnB].Value.ToString();
               // Stimmt die erste Spalte überein und die Zweite? Bsp. Artikelnummer und Seriennummer
               if (valueA.Equals(contentA) && valueB.Equals(contentB))
               {
                   return r;
               }
            }
            return -1;
        }

        
        /// <summary>
        /// Prüft den gescannten Eintrag ob die Artikelnummer in der Tabelle vorkommt, sowie auch Seriennummer und erhöht / erniedrigt die Haben-Menge.
        /// </summary>
        /// <param name="scanContent">Der gesamte, gescannte String</param>
        //private void CheckScan(string scanContent)
        //{
        //    string[] columns = scanContent.Split(';');
        //    if (columns.Length == 9)
        //    {
        //        int index = GetRowIndex(0, 1, columns[6].Trim(), columns[7].Trim());
        //        if (index > -1) {
        //            int sollMenge = Int32.Parse(dataGridView.Rows[index].Cells[4].Value.ToString()) + _unit;

        //            //                    if(sollMenge > Int32.Parse(dataGridView.Rows[index].Cells[4].Value.ToString())) SystemSounds.Beep.Play();   
        //            dataGridView.Rows[index].Cells[4].Value = sollMenge;
        //            _changedContent = true;
        //            //CheckLimit(index); 

        //        }
        //    }
        //}


        private String GetSQLResult(string query){
        
            this._recordSet.DoQuery(query);
            return this._recordSet.Fields.Item(0).Value.ToString();
        }
            

        private void SetFocus() {

            //Thread.Sleep(500);
            //this.tbScannedCode.Invoke((MethodInvoker)delegate
            //{
            //    // Running on the UI thread
            //    this.tbScannedCode.Focus();
            //});
            
        }

        
        /// <summary>
        /// Setzt den Plus-/Minus-Button auf ein oder aus
        /// </summary>
        /// <param name="plusIsOn">Addieren ist eingeschaltet</param>
        /// 

        public void SelectedItemCodePlus()
        {
           
                //packnumberofSeriennumber = Packlnummer;

                if (AmountNumberist2 == AmountNumbersoll2)
                {
                    AmountNumberist2 = AmountNumbersoll2;
                    flagAmountNumberistsoll = true;
                }
                else
                {
                    AmountNumberist2 += 1;
                }

                string querGetRecord = String.Format(DataManipulation.UPDATERECORD_Plus_null, _docEntry, Artikelnummer2, "", LinenumAmountArtikelnummer, AmountNumberist2);
                this._recordSet.DoQuery(querGetRecord);


                tbPackageNumber.Text = Packnumber;
                //btnSearch_Click(new object(), new EventArgs());
                //btnSearch_Click(null, null);
                //FillPackageForm(Packnumber);
        }

        private void SetupPlusButton() {
           
            dataGridView.Columns[0].Visible = true;//packnum

            dataGridView.Columns[8].Visible = true;//doentry
            dataGridView.Columns[9].Visible = true;//rn
                DataTable dt = new DataTable();
                dataGridView.Focus();
             
                if ((dataGridView.Rows.Count == 0) || (dataGridView.CurrentRow.Index == -1))
                {
                    dataGridView.Columns[0].Visible = false;//packnum

                    dataGridView.Columns[8].Visible = false;//doentry
                    dataGridView.Columns[9].Visible = false;//rn
                    //MessageBox.Show("did not select row");
                    return;
                    
                }
           

            //************************************************************
               
                //if (flagAmountNumberistsoll) { MessageBox.Show("ist equal soll!!!"); flagAmountNumberistsoll = false; return; }
                int cr =  dataGridView.CurrentRow.Index;
                if (cr >= 0)
                {

                    string DocEntry = (string)dataGridView[8, cr].Value;
                     
                   
                    string Artikelnummer = (string)dataGridView[2, cr].Value;
                    string Seriennummer = (string)dataGridView[3, cr].Value;
                    string Linenum = (string)dataGridView[1, cr].Value;
                    int AmountNumberist = Convert.ToInt32(dataGridView[4, cr].Value);
                    int AmountNumbersoll = Convert.ToInt32(dataGridView[5, cr].Value);
                    string RowNumber = (string)dataGridView[9, cr].Value;
                    string Packlnummer = (string)dataGridView[0, cr].Value;
                    packnumberofSeriennumber = Packlnummer;
                    DialogResult dr;

                    //dr = MessageBox.Show("are you sure?", "Update Row", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    //if (dr == DialogResult.Yes)
                    //{

                        if (Seriennummer == "")
                        {

                            if (AmountNumberist == AmountNumbersoll)
                            {
                                AmountNumberist = AmountNumbersoll;
                                flagAmountNumberistsoll = true;
                            }
                            else
                            {
                                AmountNumberist += 1;
                            }

                            string querGetRecord = String.Format(DataManipulation.UPDATERECORD_Plus_null, DocEntry, Artikelnummer, Seriennummer, Linenum, AmountNumberist);
                            this._recordSet.DoQuery(querGetRecord);
                           //if (cleantbscan1 == true)
                           // {
                           //     tbScannedCode2.Text = "";
                           //     cleantbscan1 = false;
                           // }
                           
                        }
                        else
                        {
                            string querGetRecord = String.Format(DataManipulation.UPDATERECORD_Plus, DocEntry, Artikelnummer, Seriennummer, Linenum);
                            this._recordSet.DoQuery(querGetRecord);
                            //if (cleantbscan2==false)
                            //{
                            //    tbScannedCode2.Text = "";
                            //    cleantbscan2 = true;
                            //}
                             
                        }

                        this.dataGridView.Rows.Clear();

                        if (tbPackageNumber.Text == "")
                        {
                            string querGetRecord2 = String.Format(DataManipulation.GETRECORDPacknumber_secondtime, Packlnummer);
                            this._recordSet.DoQuery(querGetRecord2);
                        }
                        else
                        {
                            string querGetRecord2 = String.Format(DataManipulation.GETRECORDPacknumber_secondtime, tbPackageNumber.Text);
                            this._recordSet.DoQuery(querGetRecord2);
                        }


                        for (int row = 0; row < this._recordSet.RecordCount; row++)
                        {

                            int n = this.dataGridView.Rows.Add();
                            for (int f = 0; f < this._recordSet.Fields.Count; f++)
                            {

                                this.dataGridView.Rows[row].Cells[f].Value = this._recordSet.Fields.Item(f).Value.ToString();
                                DateTime date = Convert.ToDateTime(this._recordSet.Fields.Item(7).Value.ToString());
                                this.dataGridView.Rows[row].Cells[7].Value = date.ToString("dd.MM.yyyy");
                            }

                            _recordSet.MoveNext();
                        }



                    //}
                    //if (dr == DialogResult.No)
                    //{

                    //    dataGridView.Focus();
                    //}


                    //return;
                }//end count

           
                else
                {
                    MessageBox.Show("es gibt diese Zeile nicht");
                }

                
                btnSearch_Click(new object(), new EventArgs());
                 
                dataGridView.Columns[0].Visible = false;//packnum

                dataGridView.Columns[8].Visible = false;//doentry
                dataGridView.Columns[9].Visible = false;//rn

            }
       
        
        
        private void SetupMinusButton( )
        {
            dataGridView.Columns[0].Visible = true;//packnum

            dataGridView.Columns[8].Visible = true;//doentry
            dataGridView.Columns[9].Visible = true;//rn
            dataGridView.Focus();
                DataTable dt = new DataTable();
                if ((dataGridView.Rows.Count == 0) || (dataGridView.CurrentRow.Index == -1))
                {
                    dataGridView.Columns[0].Visible = false;//packnum

                    dataGridView.Columns[8].Visible = false;//doentry
                    dataGridView.Columns[9].Visible = false;//rn
                    //MessageBox.Show("did not select row");
                    return;
                }
                //if (flagAmountNumberistsoll) { MessageBox.Show("Ist is  Zero!!!"); flagAmountNumberistsoll = false; return; }
                int cr = dataGridView.CurrentRow.Index;
                if (cr >= 0)
                {
                     
                    string DocEntry = (string)dataGridView[8, cr].Value;
                    
                    string Artikelnummer = (string)dataGridView[2, cr].Value;
                    string Seriennummer = (string)dataGridView[3, cr].Value;
                    string Linenum = (string)dataGridView[1, cr].Value;
                    int AmountNumberist = Convert.ToInt32(dataGridView[4, cr].Value);
                    int AmountNumbersoll = Convert.ToInt32(dataGridView[5, cr].Value);
                    string Packlnummer = (string)dataGridView[0, cr].Value;
                    packnumberofSeriennumber = Packlnummer;
                    //DialogResult dr;
                    //dr = MessageBox.Show("are you sure?", "Update Row", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    //if (dr == DialogResult.Yes)
                    //{


                        if (Seriennummer == "")
                        {

                            if (AmountNumberist == 0)
                            {
                                 
                                flagAmountNumberistsoll = true;
                                AmountNumberist = 0;
                            }
                            else
                            {
                                AmountNumberist -= 1;
                            }

                            string querGetRecord = String.Format(DataManipulation.UPDATERECORD_Minus_null, DocEntry, Artikelnummer, Seriennummer, Linenum, AmountNumberist);
                            this._recordSet.DoQuery(querGetRecord);
                        }
                        else
                        {
                            string querGetRecord = String.Format(DataManipulation.UPDATERECORD_Minus, DocEntry, Artikelnummer, Seriennummer, Linenum);
                            this._recordSet.DoQuery(querGetRecord);
                        }

                        this.dataGridView.Rows.Clear();
                        
                        string querGetRecord2 = String.Format(DataManipulation.GETRECORDPacknumber_secondtime, packnumberofSeriennumber);
                        this._recordSet.DoQuery(querGetRecord2);
                

                        for (int row = 0; row < this._recordSet.RecordCount; row++)
                        {

                            int n = this.dataGridView.Rows.Add();
                            for (int f = 0; f < this._recordSet.Fields.Count; f++)
                            {

                                this.dataGridView.Rows[row].Cells[f].Value = this._recordSet.Fields.Item(f).Value.ToString();
                                DateTime date = Convert.ToDateTime(this._recordSet.Fields.Item(7).Value.ToString());
                                this.dataGridView.Rows[row].Cells[7].Value = date.ToString("dd.MM.yyyy");
                            }

                            _recordSet.MoveNext();
                        }



                    //}
                    //if (dr == DialogResult.No)
                    //{

                    //    dataGridView.Focus();
                    //}


                    //return;
                }//end count
                else
                {
                    MessageBox.Show("es gibt diese Zeile nicht");
                }
                btnSearch_Click(new object(), new EventArgs());
                dataGridView.Columns[0].Visible = false;//packnum

                dataGridView.Columns[8].Visible = false;//doentry
                dataGridView.Columns[9].Visible = false;//rn
             
        }


       


        private String GetStatus() { 
        
            switch(cobStatus.SelectedIndex){
            
                case 0:
                    return "O";
                case 1:
                    return "B";
                case 2:
                    return "c";
                default:
                    return "";
            }        
        }




        #region Eventhandler

        


        private void btnMinus_Click(object sender, EventArgs e)
        {
            SetupMinusButton( );
        }

        public void btnPlus_Click(object sender, EventArgs e)
        {
              SetupPlusButton();
        }

        private void btnFirstRecord_Click(object sender, EventArgs e)
        {
            btnNextRecord.Enabled = true;
            btnPrevRecord.Enabled = true;
            dataGridView.Columns[0].Visible = true;//packnum

            dataGridView.Columns[8].Visible = true;//doentry
            dataGridView.Columns[9].Visible = true;//rn

            string querGetRecord1 = String.Format(DataManipulation.firstpacknumb );
            this._recordSet.DoQuery(querGetRecord1);
            _docNum = this._recordSet.Fields.Item(1).Value.ToString();

            this.dataGridView.Rows.Clear();
            string querGetRecord2 = String.Format(DataManipulation.GETRECORDPacknumber_secondtime,_docNum);
            this._recordSet.DoQuery(querGetRecord2);

            tbPackageNumber.Text = _docNum;

            
           
            for (int row = 0; row < this._recordSet.RecordCount; row++)
            {

                int n = this.dataGridView.Rows.Add();
                for (int f = 0; f < this._recordSet.Fields.Count; f++)
                {

                    this.dataGridView.Rows[row].Cells[f].Value = this._recordSet.Fields.Item(f).Value.ToString();
                    DateTime date = Convert.ToDateTime(this._recordSet.Fields.Item(7).Value.ToString());
                    this.dataGridView.Rows[row].Cells[7].Value = date.ToString("dd.MM.yyyy");
                }
                _recordSet.MoveNext();
            }
            btnSearch_Click(sender, e);
            dataGridView.Columns[0].Visible = false;//packnum

            dataGridView.Columns[8].Visible = false;//doentry
            dataGridView.Columns[9].Visible = false;//rn
            
        }

        private void btnPrevRecord_Click(object sender, EventArgs e)
        {
            dataGridView.Columns[0].Visible = true;//packnum

            dataGridView.Columns[8].Visible = true;//doentry
            dataGridView.Columns[9].Visible = true;//rn
            string docNum1 = "";
            string docNumprev = "";
            dataGridView.Focus();
            if ((dataGridView.Rows.Count == 0) || (dataGridView.CurrentRow.Index == -1))
            {
                dataGridView.Columns[0].Visible = false;//packnum

                dataGridView.Columns[8].Visible = false;//doentry
                dataGridView.Columns[9].Visible = false;//rn 
                //MessageBox.Show("did not select row");
                return;
            }
            dataGridView.Focus();
            int cr = dataGridView.CurrentRow.Index;
            if (cr >= 0)
            {

                docNum1 = dataGridView[0, cr].Value.ToString();
            }

            string querGetRecord1 = String.Format(DataManipulation.previouspacknumb_pn, docNum1);
            this._recordSet.DoQuery(querGetRecord1);
            int rn = Convert.ToInt32(this._recordSet.Fields.Item(2).Value);
            rn -= 1;

            string querGetRecord2 = String.Format(DataManipulation.previouspacknumb_rn, rn);
            this._recordSet.DoQuery(querGetRecord2);
            docNumprev = this._recordSet.Fields.Item(1).Value.ToString();
            if ( docNumprev=="0")
            {
                dataGridView.Columns[0].Visible = false;//packnum

                dataGridView.Columns[8].Visible = false;//doentry
                dataGridView.Columns[9].Visible = false;//rn 
                return;
            }
            this.dataGridView.Rows.Clear();
            string querGetRecord3 = String.Format(DataManipulation.GETRECORDPacknumber_secondtime, docNumprev);
            this._recordSet.DoQuery(querGetRecord3);

            tbPackageNumber.Text = docNumprev;
            for (int row = 0; row < this._recordSet.RecordCount; row++)
            {

                int n = this.dataGridView.Rows.Add();
                for (int f = 0; f < this._recordSet.Fields.Count; f++)
                {

                    this.dataGridView.Rows[row].Cells[f].Value = this._recordSet.Fields.Item(f).Value.ToString();
                    DateTime date = Convert.ToDateTime(this._recordSet.Fields.Item(7).Value.ToString());
                    this.dataGridView.Rows[row].Cells[7].Value = date.ToString("dd.MM.yyyy");
                }
                _recordSet.MoveNext();
            }
            btnSearch_Click(sender, e);
            dataGridView.Columns[0].Visible = false;//packnum

            dataGridView.Columns[8].Visible = false;//doentry
            dataGridView.Columns[9].Visible = false;//rn
        }
       
        private void btnNextRecord_Click(object sender, EventArgs e)
        {
            dataGridView.Columns[0].Visible = true;//packnum

            dataGridView.Columns[8].Visible = true;//doentry
            dataGridView.Columns[9].Visible = true;//rn 
            string docNum1 = "";
            string docNumnext="";
            dataGridView.Focus();
            if ((dataGridView.Rows.Count == 0) || (dataGridView.CurrentRow.Index == -1))
            {
                dataGridView.Columns[0].Visible = false;//packnum

                dataGridView.Columns[8].Visible = false;//doentry
                dataGridView.Columns[9].Visible = false;//rn 
                //MessageBox.Show("did not select row");
                return;
            }
            
            
           
            
            int cr = dataGridView.CurrentRow.Index;
            if (cr >= 0)
            {

                docNum1 =  dataGridView[0, cr].Value.ToString();
            }

            string querGetRecord1 = String.Format(DataManipulation.nextpacknumb_pn, docNum1);
            this._recordSet.DoQuery(querGetRecord1);
            int rn = Convert.ToInt32(this._recordSet.Fields.Item(2).Value);
            rn += 1;

            string querGetRecord2 = String.Format(DataManipulation.nextpacknumb_rn, rn);
            this._recordSet.DoQuery(querGetRecord2);
            docNumnext = this._recordSet.Fields.Item(1).Value.ToString();
            if (docNumnext == "0")
            {
                dataGridView.Columns[0].Visible = false;//packnum

                dataGridView.Columns[8].Visible = false;//doentry
                dataGridView.Columns[9].Visible = false;//rn 
                return;
            }
            this.dataGridView.Rows.Clear();
            string querGetRecord3 = String.Format(DataManipulation.GETRECORDPacknumber_secondtime, docNumnext);
            this._recordSet.DoQuery(querGetRecord3);

            tbPackageNumber.Text = docNumnext;
            for (int row = 0; row < this._recordSet.RecordCount; row++)
            {

                int n = this.dataGridView.Rows.Add();
                for (int f = 0; f < this._recordSet.Fields.Count; f++)
                {

                    this.dataGridView.Rows[row].Cells[f].Value = this._recordSet.Fields.Item(f).Value.ToString();
                    DateTime date = Convert.ToDateTime(this._recordSet.Fields.Item(7).Value.ToString());
                    this.dataGridView.Rows[row].Cells[7].Value = date.ToString("dd.MM.yyyy");
                }
                _recordSet.MoveNext();
            }
            btnSearch_Click(sender, e);
            dataGridView.Columns[0].Visible = false;//packnum

            dataGridView.Columns[8].Visible = false;//doentry
            dataGridView.Columns[9].Visible = false;//rn 
        }

        private void btnLastRecord_Click(object sender, EventArgs e)
        {
            btnNextRecord.Enabled = true;
            btnPrevRecord.Enabled = true;
            dataGridView.Columns[0].Visible = true;//packnum

            dataGridView.Columns[8].Visible = true;//doentry
            dataGridView.Columns[9].Visible = true;//rn

            string querGetRecord1 = String.Format(DataManipulation.lastpacknumb);
            this._recordSet.DoQuery(querGetRecord1);
            _docNum = this._recordSet.Fields.Item(1).Value.ToString();

            this.dataGridView.Rows.Clear();
            string querGetRecord2 = String.Format(DataManipulation.GETRECORDPacknumber_secondtime, _docNum);
            this._recordSet.DoQuery(querGetRecord2);

            tbPackageNumber.Text = _docNum;

            for (int row = 0; row < this._recordSet.RecordCount; row++)
            {

                int n = this.dataGridView.Rows.Add();
                for (int f = 0; f < this._recordSet.Fields.Count; f++)
                {

                    this.dataGridView.Rows[row].Cells[f].Value = this._recordSet.Fields.Item(f).Value.ToString();
                    DateTime date = Convert.ToDateTime(this._recordSet.Fields.Item(7).Value.ToString());
                    this.dataGridView.Rows[row].Cells[7].Value = date.ToString("dd.MM.yyyy");

                }
                _recordSet.MoveNext();
            }
            btnSearch_Click(sender, e);
            dataGridView.Columns[0].Visible = false;//packnum

            dataGridView.Columns[8].Visible = false;//doentry
            dataGridView.Columns[9].Visible = false;//rn
        }


        /// <summary>
        /// Sofern eine DocEntry vorhanden bzw. Zeilen in der Maske enthalten sind, so sollen diese komplett aktualisiert werden.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Button-Klickevent</param>
        private void btnMainButton_Click(object sender, EventArgs e)
        {
            //if (_status == "G") EnablePackagForm(false);
            cobStatus.SelectedIndex = -1;
            this.dataGridView.Rows.Clear();
            tbPackageNumber.Text = "";
            lblpostdate.Text = "";
            tbScannedCode2.Text = string.Empty;
            btnNextRecord.Enabled = false;
            btnPrevRecord.Enabled = false;
            dataGridView.Columns[0].Visible = false;//packnum

            dataGridView.Columns[8].Visible = false;//doentry
            dataGridView.Columns[9].Visible = false;//rn 

            MessageBox.Show("Zeilen wurden erfolgreich aktualisiert.", "Aktualisierungsstatus");
        
        }

        public void btnSearch_Click(object sender, EventArgs e)
        {
            FillPackageForm(tbPackageNumber.Text);
            //if (packnumberofSeriennumber != "")
            //{
            //    FillPackageForm(packnumberofSeriennumber );
            //}
            //else
            //{
            //    FillPackageForm(tbPackageNumber.Text );
            //}

            //if (tbPackageNumber.Text == "")
            //{
            //    MessageBox.Show("please enter packnumber");
            //}
            //else
            //{
                

            //}
        }


        private void Consignment_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.CloseEverything();
        }


        private void cobStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private static void timer_Tick(object sender, EventArgs e)
        {

          
        }


        private void Consignment_Form_Load(object sender, EventArgs e)
        {
            cobStatus.SelectedIndex = -1;
            this.dataGridView.Rows.Clear();
            btnNextRecord.Enabled = false;
            btnPrevRecord.Enabled = false;
            tbScannedCode2.Focus();
            
            TextBox textBox = new TextBox();

            //var usbDevices = GetUSBDevices();

            //foreach (var usbDevice in usbDevices)
            //{
            //    string s1 = string.Format("Device ID: {0}, PNP Device ID: {1}, Description: {2}---",
            //        usbDevice.DeviceID, usbDevice.PnpDeviceID, usbDevice.Description);
            //    richTextBox1.Text += s1;
            //}

            //SerialPort serialPort = new SerialPort("HID\\VID_05F9&PID_2218\\6&1e330dbc&0&0000", 9600, Parity.None, 8, StopBits.One);
            //if (!serialPort.IsOpen)
            //{ serialPort.Open(); }

            //int length = serialPort.BytesToRead;
            //char[] buf = new char[length];

            //serialPort.Read(buf, 0, length);
            //if (buf.Length != 0)
            //{
            //    //Consignment_Form f = new Consignment_Form(sapConnector);
            //    //f.tbScannedCode.Text = "";
            //    MessageBox.Show(buf.ToString());

            //}
            //serialPort.Close();
 

            //ManagementObjectSearcher searcher =
            //        new ManagementObjectSearcher("root\\WMI",
            //        "SELECT * FROM MSWmi_PnPInstanceNames");

            //foreach (ManagementObject queryObj in searcher.Get())
            //{
            //    string s= string.Format("InstanceName: {0}", queryObj["InstanceName"]);
            //    richTextBox1.Text += s;
            //}


            //textBox.TextChang += new EventHandler(tbScannedCode2_KeyPress);
            //textBox.TextChanged += new EventHandler(tbScannedCode_TextChanged2);
                       
             
        }
        //protected void tbScannedCode_TextChanged2(object sender, EventArgs e)
        //{
        //    tbScannedCode2.Text="";
        //}

        private void tbPackageNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
       //     if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       //(e.KeyChar != '.'))
       //     {
       //         e.Handled = true;
       //     }

             
        }

       

        private void tbScannedCode2_TextChanged(object sender, EventArgs e)
        {
            cleantbscan1 = false;
            cleantbscan2 = false;
            if (tbScannedCode2.Text == tbscanstring)
            {

                if (cleantbscan1 == false)
                {
                    tbscanstring = "";

                    scancode = tbScannedCode2.Text + '\u0009';
                    tbScannedCode2.Text = scancode;
                    cleantbscan1 = true;
                }

                else
                {
                    scancode = "";
                    scancode = tbScannedCode2.Text + '\u0009' + '\u0009';
                    cleantbscan1 = false;
                }
                var count1 = scancode.Count(x => x == '\u0009');
                if (count1 > 1)
                {
                    tbScannedCode2.Text = "";
                    scancode = scancode.Replace("\u0009", string.Empty);
                    tbScannedCode2.Text = scancode;
                    scancode = "";
                    cleantbscan1 = false;
                }


            }
             
         
        }
        private void form_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (tbPackageNumber.Focused == false)
            {
                //dataGridView.Focus();
                //tbScannedCode2_Leave(sender, e);

                tbScannedCode2.Focus();
                //tbScannedCodeNew.Focus();
              
            }
          
              
            
        }



        private void tbScannedCode2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //if (_docEntry == "")
            //{
            //    MessageBox.Show("please at first search pack number abd after that scan code!");
            //    tbScannedCode2.Text = "";
            //    return;
            //} 



        }

        private void tbScannedCode2_KeyUp(object sender, KeyEventArgs e)
        {
           if (e.KeyData == Keys.Enter)
            {
                SetupPlusButton();
            }
        }
        
        
        
        private void tbScannedCode2_Leave(object sender, EventArgs e)
        {
           
         
        }

        private void tbScannedCode2_ParentChanged(object sender, EventArgs e)
        {
          
        }

        private void tbScannedCode2_AcceptsTabChanged(object sender, EventArgs e)
        {
            
        }

        private void tbScannedCode2_BindingContextChanged(object sender, EventArgs e)
        {
          
        }

        private void tbScannedCode2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void tbScannedCode2_ModifiedChanged(object sender, EventArgs e)
        {
           
        }

        private void tbScannedCode2_Validated(object sender, EventArgs e)
        {
            
        }

      

        private void tbScannedCode2_Validating(object sender, CancelEventArgs e)
        {
          
        }

        private void tbScannedCode2_CursorChanged(object sender, EventArgs e)
        {
         
        }

        private void tbScannedCode2_CausesValidationChanged(object sender, EventArgs e)
        {
          
        }

        private void Consignment_Form_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void tbScannedCodeNew_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            


            if (tbScannedCode2.Text == "")
            {
                return;
            }

            int countsimicolun = 0;
            string[] words;
            List<string> l1 = new List<string>();

            //countsimicolun = tbScannedCode2.Text.Count(x => x == ';');
            //int count1 = tbScannedCode2.Text.Count(x => x == '\u0009');
            //string a = tbScannedCode2.Text.Replace('\u0009', ' ');
           words = tbScannedCode2.Text.Split(';');
          
           if ( words[words.Length-1]=="\t")
           {
               words[words.Length - 1].Replace("\t", "");
           }
            foreach (string item in words)
            {
             l1.Add(item);

            }
            if (words[words.Length - 1] == "")
            {
                l1.RemoveAt(words.Length - 1);
            }
           
            if (l1.Count == 4 )
               {
               // MessageBox.Show("vp");
                tbScannedCode2.Text = "";
                tbScannedCode2.Text = l1[3] ;
                dataGridView.Columns[0].Visible = true;//packnum

                dataGridView.Columns[8].Visible = true;//doentry
                dataGridView.Columns[9].Visible = true;//rn 
                //this.dataGridView.Rows.Clear();
                tbscanstring = tbScannedCode2.Text.Replace("\u0009", "");


                string querGetRecord = String.Format(DataManipulation.GETRECORDItemCode, tbScannedCode2.Text.Replace("\u0009", ""), _docEntry);
                this._recordSet.DoQuery(querGetRecord);

               

                _docNum = this._recordSet.Fields.Item(0).Value.ToString();
                _docEntry = this._recordSet.Fields.Item(8).Value.ToString();

                int CountItemcode = this._recordSet.RecordCount;


                if (CountItemcode > 1)
                {
                    string querGetRecord2 = String.Format(DataManipulation.GETRECORDSimilarItemCode, tbScannedCode2.Text.Replace("\u0009", ""));
                    this._recordSet.DoQuery(querGetRecord2);

                    amountItemcode = true;
                    SimilarItemCodes sic = new SimilarItemCodes();
              
                   //sic.MdiParent = this;
                   

                    for (int row = 0; row < this._recordSet.RecordCount; row++)
                    {
                        int n = sic.dataGridView1.Rows.Add();
                        for (int f = 0; f < 6; f++)
                        {

                            sic.dataGridView1.Rows[row].Cells[f].Value = this._recordSet.Fields.Item(f).Value.ToString();
                            //Artikelnummer2 = this._recordSet.Fields.Item(1).Value.ToString();
                            //LinenumAmountArtikelnummer = this._recordSet.Fields.Item(8).Value.ToString();
                            //AmountNumberist2 = this._recordSet.Fields.Item(3).Value.ToString();
                            //AmountNumbersoll2 = this._recordSet.Fields.Item(4).Value.ToString();
                            //Packlnummer2 = this._recordSet.Fields.Item(0).Value.ToString();
                            //btnPlus_Click(sender, e);
                        }
                        this._recordSet.MoveNext();
                    }
                    dataGridView.Columns[0].Visible = false;//packnum

                    dataGridView.Columns[8].Visible = false;//doentry
                    dataGridView.Columns[9].Visible = false;//rn 
                    sic.ShowDialog(this);

                }
                else
                {
                    amountItemcode = false;
                    for (int row = 0; row < this._recordSet.RecordCount; row++)
                    {

                        int n = this.dataGridView.Rows.Add();
                        for (int f = 0; f < 9; f++)
                        {

                            this.dataGridView.Rows[row].Cells[f].Value = this._recordSet.Fields.Item(f).Value.ToString();
                            DateTime date = Convert.ToDateTime(this._recordSet.Fields.Item(7).Value.ToString());
                            this.dataGridView.Rows[row].Cells[7].Value = date.ToString("dd.MM.yyyy");
                        }


                        this._recordSet.MoveNext();
                    }
                }




                if (_status == "G")
                {

                    EnablePackagForm(false);
                }
                packnumberofSeriennumber = _docNum;
                if(amountItemcode==false)
                btnPlus_Click(sender, e);

                dataGridView.Columns[0].Visible = false;//packnum

                dataGridView.Columns[8].Visible = false;//doentry
                dataGridView.Columns[9].Visible = false;//rn 

             
            }
            //*********************************************************************
            else if (l1.Count == 5  )
            {
                amountItemcode = false;
                //MessageBox.Show("sn");
                tbScannedCode2.Text = "";
                tbScannedCode2.Text = l1[4];
           
                dataGridView.Columns[0].Visible = true;//packnum

                dataGridView.Columns[8].Visible = true;//doentry
                dataGridView.Columns[9].Visible = true;//rn 
                this.dataGridView.Rows.Clear();
                tbscanstring = tbScannedCode2.Text;
                string querGetRecord = String.Format(DataManipulation.GETRECORDSeriennummer, tbScannedCode2.Text);
                this._recordSet.DoQuery(querGetRecord);


                _docNum = this._recordSet.Fields.Item(0).Value.ToString();
                _docEntry = this._recordSet.Fields.Item(8).Value.ToString();

                for (int row = 0; row < this._recordSet.RecordCount; row++)
                {

                    int n = this.dataGridView.Rows.Add();
                    for (int f = 0; f < 9; f++)
                    {

                        this.dataGridView.Rows[row].Cells[f].Value = this._recordSet.Fields.Item(f).Value.ToString();
                        DateTime date = Convert.ToDateTime(this._recordSet.Fields.Item(7).Value.ToString());
                        this.dataGridView.Rows[row].Cells[7].Value = date.ToString("dd.MM.yyyy");
                    }


                    this._recordSet.MoveNext();
                }


                if (_status == "G")
                {

                    EnablePackagForm(false);
                }
                packnumberofSeriennumber = _docNum;

                btnPlus_Click(sender, e);

                dataGridView.Columns[0].Visible = false;//packnum

                dataGridView.Columns[8].Visible = false;//doentry
                dataGridView.Columns[9].Visible = false;//rn 
              
            }
          
        }

        private void lbPackageNumber_Click(object sender, EventArgs e)
        {

        }

        private void tbPackageNumber_TextChanged(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void Consignment_Form_Activated(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }
        }
    //static List<USBDeviceInfo> GetUSBDevices()
    //{
    //  List<USBDeviceInfo> devices = new List<USBDeviceInfo>();
 
    //  ManagementObjectCollection collection;
    //  using (var searcher = new ManagementObjectSearcher(@"SELECT * FROM Win32_PnPEntity where DeviceID Like ""USB%"""))
    //    collection = searcher.Get();      

    //  foreach (var device in collection)
    //  {
    //    devices.Add(new USBDeviceInfo(
    //    (string)device.GetPropertyValue("DeviceID"),
    //    (string)device.GetPropertyValue("PNPDeviceID"),
    //    (string)device.GetPropertyValue("Description")
    //    ));
    //  }

    //  collection.Dispose();
    //  return devices;
    //}
  
        
    }

