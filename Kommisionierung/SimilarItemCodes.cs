using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kommisionierung
{
    public partial class SimilarItemCodes : Form
    {
        public SimilarItemCodes()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             int cr =  dataGridView1.CurrentRow.Index;
             if (cr >= 0)
             {

                
                 SAPConnector sapConnector = new SAPConnector();

                 Consignment_Form con = new Consignment_Form(sapConnector);
                 con.LinenumAmountArtikelnummer = (string)dataGridView1[0, cr].Value;
                con.Artikelnummer2=dataGridView1[1, cr].Value.ToString();
                 Int32.TryParse(dataGridView1[3, cr].Value.ToString(), out  con.AmountNumberist2);
                 Int32.TryParse(dataGridView1[4, cr].Value.ToString(), out  con.AmountNumbersoll2);
            
                 con.Packnumber = (string)dataGridView1[5, cr].Value;

                 con.SelectedItemCodePlus();
                 //con.btnSearch_Click(sender, e);
                 //con.btnSearch_Click(new object(), new EventArgs());
                 //dataGridView1.DoubleClick += new EventHandler(con.btnSearch_Click);
                 this.Close();
             }
        }

        private void SimilarItemCodes_FormClosed(object sender, FormClosedEventArgs e)
        {
            SAPConnector sapConnector = new SAPConnector();

            Consignment_Form con = new Consignment_Form(sapConnector);
            int cr =  dataGridView1.CurrentRow.Index;
            if (cr >= 0)
            {
                con.tbPackageNumber.Text =  dataGridView1[5, cr].Value.ToString() ;
                dataGridView1.DoubleClick += new EventHandler(con.btnSearch_Click);
                //con.btnSearch_Click(sender, e);
                //con.btnSearch_Click(new object(), new EventArgs());
                //con.button1_Click(sender, e);
            }
             
        }
    }
}
