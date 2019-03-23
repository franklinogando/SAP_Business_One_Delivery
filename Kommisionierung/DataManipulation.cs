using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SBOAddonProject5
{
    class DataManipulation
    {


        


        string _packageNumber = String.Empty;

        

        

        static public string get_package_Packnumber_first =
            "select * from [@DRS_PACKAGE] where DocNum={0}";

        static public string insert_pachagecontentPacknumber_first =
        "INSERT INTO  [TS_DFE_20181120].[dbo].[@DRS_PACKAGE]  (DocEntry,DocNum,Period,Instance,Series,Handwrtten,Canceled,Object,LogInst,UserSign,"
        + " Transfered,Status,CreateDate,CreateTime,UpdateDate,UpdateTime,DataSource,RequestStatus,Creator,Remark,"
        + " U_Amount,U_Status,U_UserCreated,U_UserUpdate,U_IsComplete,U_UserUpdated )   "

        + " SELECT top 1 t1.DocEntry, T0.docnum ,null, null ,null,null, null,null,null,null,null,null,null,null,null,null,"
        + " null,null,null,null,null ,t0.DocStatus,null,null, T1.U_CreditAmount,null"
        + " FROM dln1 T1  "

        + " JOIN odln as T0 ON T0.DocEntry = T1.DocEntry "
        + " left JOIN OITL T3 ON T1.DocEntry = T3.DocEntry AND T1.LineNum = T3.DocLine AND T1.ObjType = T3.DocType"
        + " left JOIN ITL1 T6 ON T3.LogEntry = T6.LogEntry and t6.LogEntry=t3.LogEntry "
        + " left JOIN OSRQ T4 ON T6.MdAbsEntry = T4.MdAbsEntry AND T4.WhsCode = T3.LocCode "
        + " left JOIN OSRN T5 ON T5.AbsEntry = T4.MdAbsEntry  "

        + " where  T0.docnum='{0}' and t1.DocEntry  is not NULL";



        static public string GETRECORDPacknumber_first =

          " insert into [TS_DFE_20181120].[dbo].[@DRS_PACKAGE_CONTENT](DocEntry, VisOrder,Object,LogInst,U_ItemCode,U_SerialNumber,U_Debit,U_Credit,U_LineNum,Dscription,ShipDate)"
        + " SELECT distinct    t1.DocEntry,  null,null, null  ,T1.ItemCode,t5.distnumber,T1.quantity,null,T1.VisOrder,T1.Dscription,T1.shipdate"
        + " FROM dln1 T1  "

        + " JOIN odln as T0 ON T0.DocEntry = T1.DocEntry "
        + " left JOIN OITL T3 ON T1.DocEntry = T3.DocEntry AND T1.LineNum = T3.DocLine AND T1.ObjType = T3.DocType "
        + " left JOIN ITL1 T6 ON T3.LogEntry = T6.LogEntry and t6.LogEntry=t3.LogEntry "
        + " left JOIN OSRQ T4 ON T6.MdAbsEntry = T4.MdAbsEntry AND T4.WhsCode = T3.LocCode "
        + " left JOIN OSRN T5 ON T5.AbsEntry = T4.MdAbsEntry  "

        + " where  T0.docnum='{0}'  and t1.DocEntry  is not NULL"
       

        + " update  [@DRS_PACKAGE_CONTENT] set   U_SerialNumber='' where U_SerialNumber IS   NULL"


   //---+" -----------------------------------------------------------------------------  
        + " select distinct  p.DocNum,c.U_ItemCode,c.U_SerialNumber, c.U_Credit as 'Delivery Status' ,c.U_Debit as 'Amount Number',"
        + " c.Dscription,c.ShipDate,p.DocEntry,c.U_LineNum"
        + " from [@DRS_PACKAGE_CONTENT]as c"
        + " join   [@DRS_PACKAGE] as p  on p.DocEntry=c.DocEntry"
        + " update [@DRS_PACKAGE_CONTENT] set U_Debit=1 where U_SerialNumber!='' ";

        static public string GETRECORDPacknumber_secondtime =
           " select distinct  p.DocNum,c.U_LineNum,c.U_ItemCode,c.U_SerialNumber, c.U_Credit as 'Delivery Status' ,c.U_Debit as 'Amount Number',"
           + " c.Dscription,c.ShipDate,p.DocEntry "
           + " ,(ROW_NUMBER() over(PARTITION BY  c.U_ItemCode,c.U_SerialNumber   order by  c.U_SerialNumber ) )rn "
           + " from [@DRS_PACKAGE_CONTENT]as c"
           + " join   [@DRS_PACKAGE] as p  on p.DocEntry=c.DocEntry "

           + " where p.DocNum='{0}'"
           + " order by c.U_LineNum";

       

         



        static public string GETRECORDStatus =
             "SELECT distinct   T0.docnum as 'docnummer',t1.LineNum, T1.ItemCode as 'Artikelnummer', t5.distnumber as 'Seriennummer', T1.Dscription as 'Artikelbeschreibung', "
        + " T1.quantity as 'Soll', T1.U_CreditAmount as 'Lst', T1.shipdate as 'DelivDate', t3.DocEntry,t0.DocStatus"

        + " FROM dln1 T1 "
        + " JOIN odln as T0 ON T0.DocEntry = T1.DocEntry "
            //+ " --join osrn o on o.itemcode= t1.itemcode "

        + " left JOIN OITL T3 ON T1.DocEntry = T3.DocEntry AND T1.LineNum = T3.DocLine AND T1.ObjType = T3.DocType  "
        + " left JOIN ITL1 T6 ON T3.LogEntry = T6.LogEntry and t6.LogEntry=t3.LogEntry"
        + " left JOIN OSRQ T4 ON T6.MdAbsEntry = T4.MdAbsEntry AND T4.WhsCode = T3.LocCode "
        + " left JOIN OSRN T5 ON T5.AbsEntry = T4.MdAbsEntry "
        + " where  t0.DocStatus='{0}' ";



        static public string GETRECORDSeriennummer =
           " select distinct  p.DocNum,c.U_LineNum,c.U_ItemCode,c.U_SerialNumber, c.U_Credit as 'Delivery Status' ,c.U_Debit as 'Amount Number',"
           + " c.Dscription,c.ShipDate,p.DocEntry "
           + " ,(ROW_NUMBER() over(PARTITION BY  c.U_ItemCode,c.U_SerialNumber   order by  c.U_SerialNumber ) )rn "
           + " from [@DRS_PACKAGE_CONTENT]as c"
           + " join   [@DRS_PACKAGE] as p  on p.DocEntry=c.DocEntry "

           + " where c.U_SerialNumber='{0}'";


        static public string GETRECORDItemCode =
           " select distinct  p.DocNum,c.U_LineNum,c.U_ItemCode,c.U_SerialNumber, c.U_Credit as 'Delivery Status' ,c.U_Debit as 'Amount Number',"
           + " c.Dscription,c.ShipDate,p.DocEntry "
           + " ,(ROW_NUMBER() over(PARTITION BY  c.U_ItemCode,c.U_SerialNumber   order by  c.U_SerialNumber ) )rn "
           + " from [@DRS_PACKAGE_CONTENT]as c"
           + " join   [@DRS_PACKAGE] as p  on p.DocEntry=c.DocEntry "

           + " where c.U_ItemCode='{0}' and p.DocEntry={1}";

        static public string GETRECORDSimilarItemCode =
           " select distinct c.U_LineNum, c.U_ItemCode,c.Dscription,c.U_Credit,c.U_Debit, p.DocNum"
           + " ,(ROW_NUMBER() over(PARTITION BY  c.U_ItemCode,c.U_SerialNumber   order by  c.U_SerialNumber ) )rn "
           + " from [@DRS_PACKAGE_CONTENT]as c"
           + " join   [@DRS_PACKAGE] as p  on p.DocEntry=c.DocEntry "

           + " where c.U_ItemCode='{0}'  ";

        static public string UPDATERECORD_Plus = "update  [@DRS_PACKAGE_CONTENT]   set U_Credit=1 where  DocEntry={0} and  U_ItemCode  ='{1}' and   U_SerialNumber='{2}' and   U_LineNum  ={3} ";
        static public string UPDATERECORD_Plus_null = "update  [@DRS_PACKAGE_CONTENT]   set U_Credit={4} where  DocEntry={0} and  U_ItemCode  ='{1}' and   U_SerialNumber='{2}' and   U_LineNum  ={3} ";


        static public string UPDATERECORD_Minus = "update  [@DRS_PACKAGE_CONTENT]   set U_Credit=0 where  DocEntry={0} and  U_ItemCode  ='{1}' and   U_SerialNumber='{2}' and   U_LineNum  ={3} ";
        static public string UPDATERECORD_Minus_null = "update  [@DRS_PACKAGE_CONTENT]   set U_Credit={4} where  DocEntry={0} and  U_ItemCode  ='{1}' and   U_SerialNumber='{2}' and   U_LineNum  ={3} ";


        static public string firstpacknumb = " select top 1 * from [@DRS_PACKAGE] order by DocEntry ";
        static public string lastpacknumb = " select top 1 * from [@DRS_PACKAGE] order by DocEntry desc";

        static public string nextpacknumb_rn = "select   DocEntry,DocNum,rn from (select    ROW_NUMBER() OVER (Order by DocEntry)rn,*  from [@DRS_PACKAGE]  )r  where r.rn={0}";
        static public string previouspacknumb_rn = "select   DocEntry,DocNum,rn from (select    ROW_NUMBER() OVER (Order by DocEntry)rn,*  from [@DRS_PACKAGE]  )r  where r.rn={0}";


        static public string nextpacknumb_pn = "select   DocEntry,DocNum,rn from (select    ROW_NUMBER() OVER (Order by DocEntry)rn,*  from [@DRS_PACKAGE]  )r  where r.DocNum='{0}'";
        static public string previouspacknumb_pn = "select   DocEntry,DocNum,rn from (select    ROW_NUMBER() OVER (Order by DocEntry)rn,*  from [@DRS_PACKAGE]  )r  where r.DocNum='{0}'";

        static public string GETRALLECORDS =
            //" select   * from ("
        "  SELECT distinct   T0.docnum as 'docnummer',t1.LineNum, T1.ItemCode as 'Artikelnummer', t5.distnumber as 'Seriennummer', T1.Dscription as 'Artikelbeschreibung', "
        + " T1.quantity as 'Soll', T1.U_CreditAmount as 'Lst', T1.shipdate as 'DelivDate', t3.DocEntry,t0.DocStatus"
        //+ " ,(ROW_NUMBER() over(PARTITION BY T1.ItemCode,T1.U_CreditAmount order by  T0.docnum  ) )rn"
        + " FROM dln1 T1 "
        + " JOIN odln as T0 ON T0.DocEntry = T1.DocEntry "
            //+ " --join osrn o on o.itemcode= t1.itemcode "

        + " left JOIN OITL T3 ON T1.DocEntry = T3.DocEntry AND T1.LineNum = T3.DocLine AND T1.ObjType = T3.DocType  "
        + " left JOIN ITL1 T6 ON T3.LogEntry = T6.LogEntry and t6.LogEntry=t3.LogEntry"
        + " left JOIN OSRQ T4 ON T6.MdAbsEntry = T4.MdAbsEntry AND T4.WhsCode = T3.LocCode "
        + " left JOIN OSRN T5 ON T5.AbsEntry = T4.MdAbsEntry ";
         



        public static string BuildUpdateQuery(DataGridView dgv, string docEntry, string docNum, int userID, string status) {

            string output = String.Empty;

            string UPDATEPACKAGE = 
             "  UPDATE [@DRS_PACKAGE]" 
            + "  SET U_UserCreated = ISNULL(U_UserCreated, '{1}')," 
            + "  U_UserUpdated = '{1}'," 
            + "  Status = '{2}'" 
            + "  WHERE DocNum = '{0}' ";

            string UPDATERECORD = 
             " UPDATE [@DRS_PACKAGE_CONTENT] " 
            + " SET U_Credit = " 
            + " CASE " 
            + " {1} " 
            + " END " 
            + " WHERE DocEntry IN ('{0}')" ;

            string UPDATERECORDLINE =  
            " WHEN DocEntry = '{0}' AND LineId = '{1}' THEN '{2}' ";

            string lines = String.Empty;

            for (int r = 0; r < dgv.Rows.Count -1; r++) {             
                lines +=  String.Format(UPDATERECORDLINE, docEntry, r.ToString(), dgv.Rows[r].Cells[4].Value.ToString());
            }

            output = String.Format(UPDATEPACKAGE, docNum, userID.ToString(), status);
            output += String.Format(UPDATERECORD, docEntry, lines);

            return output;
        }
    }
}
