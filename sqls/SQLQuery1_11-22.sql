 --WITH a as     
        --where x1.rn>=1
  
         
         
 --         right join (select   itemcode ,DistNumber  from OSRN group by ItemCode,DistNumber  ) o on o.ItemCode= t1.itemcode  )
          
 --         select * from CTE_Duplicates where rn>1
          
          
 --     --where o.DistNumber='3805-4-40823'
     
 --         --join ( SELECT distinct itemcode,DistNumber from osrn group by ItemCode,DistNumber  ) as c on c.itemcode= t1.itemcode 
 
   
   
  --SELECT   t0.docnum as 'docnummer', T1.ItemCode as 'Artikelnummer', o.distnumber as 'Seriennummer', T1.Dscription as 'Artikelbeschreibung',  
  --       T1.quantity as 'Soll', T1.U_CreditAmount as 'Lst', T1.shipdate as 'DelivDate',t0.docentry 
  --       FROM dln1 T1 
  --       JOIN odln as T0 ON T0.DocEntry = T1.DocEntry
  --       join osrn o on o.itemcode= t1.itemcode 
  --       join (SELECT  distinct itemcode  from osrn  ) temp on temp.itemcode= t1.itemcode 
  --       where t0.docnum='11010038'
   
--   SELECT item_code, value, item.quantity
--FROM item
--INNER JOIN(
--SELECT quantity
--FROM item
--GROUP BY quantity
--HAVING COUNT(item_code) >1
--)temp ON item.quantity= temp.quantity;

    
--    select  ItemCode,DistNumber 
--    from osrn 
--    GROUP BY ItemCode,DistNumber
--HAVING COUNT(*) > =1
 
    
  
--where a1.=1

    --where    ItemCode='EEZ300001'
    
 --select docnum from ODLN where docnum='17010004'
 
 
 --t0.DocStatus, t0.DocDate 
 
 
  --SELECT distinct   T0.docnum as 'docnummer', T1.ItemCode as 'Artikelnummer', t5.distnumber as 'Seriennummer', T1.Dscription as 'Artikelbeschreibung', 
  --      T1.quantity as 'Soll', T1.U_CreditAmount as 'Lst', T1.shipdate as 'DelivDate', t3.DocEntry,t0.DocStatus
        
  --      FROM dln1 T1 
  --      JOIN odln as T0 ON T0.DocEntry = T1.DocEntry 
  --      --join osrn o on o.itemcode= t1.itemcode 
        
  --      left JOIN OITL T3 ON T1.DocEntry = T3.DocEntry AND T1.LineNum = T3.DocLine AND T1.ObjType = T3.DocType  
  --      left JOIN ITL1 T6 ON T3.LogEntry = T6.LogEntry and t6.LogEntry=t3.LogEntry
  --      left JOIN OSRQ T4 ON T6.MdAbsEntry = T4.MdAbsEntry AND T4.WhsCode = T3.LocCode 
  --      left JOIN OSRN T5 ON T5.AbsEntry = T4.MdAbsEntry 

  
  --where    T0.docnum= 17010004 and t0.DocStatus='b'
  --  --t5.DistNumber='3805-4-40823'  
     
  --select  a.docentry,a.ItemCode,a.U_CreditAmount from  DLN1 as a 
  --   join osrn as o on o.ItemCode=a.ItemCode
  --   where a.ItemCode='vpv200045'
     
     
     
--  update dln1  set U_CreditAmount='+1'   
--  from  dln1,osrn 
--  --right join OSRN on  dln1.itemcode=osrn.itemcode
-- where docentry=6 and dln1.itemcode='VPV200045' and    osrn.distnumber='149-30-6127-9'  and dln1.LineNum=0
 
 
-- select itemcode,distnumber from OSRN where distnumber='149-30-6127-9'
 
 
-- select itemcode,distnumber from OSRN where itemcode='VPV200045'   and distnumber='149-30-6127-9'    
 
 
-- select docentry,itemcode,LineNum from dln1 where itemcode='VPV200074' and LineNum=0
 
 
--update dln1  set U_CreditAmount='-1'  from  dln1,osrn   where  docentry=2 and dln1.itemcode='VPV200074' and osrn.distnumber='3900-2-00249' and dln1.LineNum=0


--select   * from 
--(SELECT distinct    T0.docnum as 'docnummer', T1.ItemCode as 'Artikelnummer', t5.distnumber as 'Seriennummer', T1.Dscription as 'Artikelbeschreibung',  
--T1.quantity as 'Soll', T1.U_CreditAmount as 'Lst', T1.shipdate as 'DelivDate', t3.DocEntry,t0.DocStatus,t1.LineNum 
--,(ROW_NUMBER() over(PARTITION BY T1.U_CreditAmount order by  T0.docnum  ) )rn

--FROM dln1 T1 
-- JOIN odln as T0 ON T0.DocEntry = T1.DocEntry
-- left JOIN OITL T3 ON T1.DocEntry = T3.DocEntry AND T1.LineNum = T3.DocLine AND T1.ObjType = T3.DocType  
--  left JOIN ITL1 T6 ON T3.LogEntry = T6.LogEntry and t6.LogEntry=t3.LogEntry 
--left JOIN OSRQ T4 ON T6.MdAbsEntry = T4.MdAbsEntry AND T4.WhsCode = T3.LocCode  left JOIN OSRN T5 ON T5.AbsEntry = T4.MdAbsEntry  where  t0.DocStatus='b' )ranked where ranked.rn =1



-- select   * from 
-- (SELECT  top 10000000   t0.docnum as 'docnummer',T1.ItemCode  as 'Artikelnummer',o.distnumber as 'Seriennummer',  T1.Dscription as 'Artikelbeschreibung', 
--        T1.quantity as 'Soll', T1.U_CreditAmount as 'Lst', T1.shipdate as 'DelivDate',t0.docentry    
--         , row_number() over (partition by  t1.ItemCode   order by t1.ItemCode  ) as rn 
--         FROM dln1 T1 
--         JOIN odln as T0 ON T0.DocEntry = T1.DocEntry
--         join OSRN as o  on  o.itemcode= t1.itemcode  )ranked
         
--         where ranked.rn =1
  

  
  
--  select   * from (SELECT distinct   T0.docnum as 'docnummer', T1.ItemCode as 'Artikelnummer', t5.distnumber as 'Seriennummer', T1.Dscription as 'Artikelbeschreibung', 
--   T1.quantity as 'Soll', T1.U_CreditAmount as 'Lst', T1.shipdate as 'DelivDate', t3.DocEntry,t0.DocStatus,t1.LineNum ,
--   (ROW_NUMBER() over(PARTITION BY T1.U_CreditAmount order by  T0.docnum  ) )rn 
--   FROM dln1 T1  JOIN odln as T0 ON T0.DocEntry = T1.DocEntry  left JOIN OITL T3 ON T1.DocEntry = T3.DocEntry AND T1.LineNum = T3.DocLine AND T1.ObjType = T3.DocType   left JOIN ITL1 T6 ON T3.LogEntry = T6.LogEntry 
--   and t6.LogEntry=t3.LogEntry
--   left JOIN OSRQ T4 ON T6.MdAbsEntry = T4.MdAbsEntry AND T4.WhsCode = T3.LocCode  left JOIN OSRN T5 ON T5.AbsEntry = T4.MdAbsEntry  where  t0.DocStatus='b')ranked where ranked.rn =1
  
-- select   * from (SELECT distinct   T0.docnum as 'docnummer', T1.ItemCode as 'Artikelnummer', t5.distnumber as 'Seriennummer', T1.Dscription as 'Artikelbeschreibung', 
--  T1.quantity as 'Soll', T1.U_CreditAmount as 'Lst', T1.shipdate as 'DelivDate', t3.DocEntry,t0.DocStatus,t1.LineNum ,(ROW_NUMBER() over(PARTITION BY T1.ItemCode,T1.U_CreditAmount order by  T0.docnum  ) )rn 
--  FROM dln1 T1  JOIN odln as T0 ON T0.DocEntry = T1.DocEntry  left JOIN OITL T3 ON T1.DocEntry = T3.DocEntry AND T1.LineNum = T3.DocLine AND T1.ObjType = T3.DocType   left JOIN ITL1 T6 ON T3.LogEntry = T6.LogEntry 
--  and t6.LogEntry=t3.LogEntry
--  left JOIN OSRQ T4 ON T6.MdAbsEntry = T4.MdAbsEntry AND T4.WhsCode = T3.LocCode 
--   left JOIN OSRN T5 ON T5.AbsEntry = T4.MdAbsEntry  )ranked where ranked.rn =1 and ranked.docnummer=11010002
   
   
   
--   update dln1  set U_CreditAmount='-1'  from  dln1,osrn   where  docentry={0} and dln1.itemcode='vpv200074' and osrn.distnumber='3900-2-00249' and dln1.LineNum={3}
   
   
--   select docentry,itemcode,LineNum from dln1 where itemcode='VPV200074'
   
 
--select   * from ( isnull(R.P, '0')
       
         
 
          --)ranked where ranked.rn =1
 --and ranked.docnummer=11010002
  --and ranked.Seriennummer='3900-2-00249'
 
  --select ItemCode,DistNumber  from osrn where DistNumber='3802-0-01277'
 
 
--update dln1  set U_CreditAmount='-1'  from  dln1,osrn   where  docentry=6221 and dln1.itemcode='VPV200075' and osrn.distnumber='3805-4-40823' and dln1.LineNum=1


--select DocNum from ODLN where DocNum=11010002


--SELECT distinct   T0.docnum as 'docnummer', T1.ItemCode as 'Artikelnummer', t5.distnumber as 'Seriennummer', T1.Dscription as 'Artikelbeschreibung',  
--       T1.quantity as 'Soll', T1.U_CreditAmount as 'Lst', T1.shipdate as 'DelivDate', t3.DocEntry,t0.DocStatus,t1.LineNum 
--       --,(ROW_NUMBER() over(PARTITION BY  T1.ItemCode   order by  T1.ItemCode  ) )rn 
--       FROM dln1 T1 
--       JOIN odln as T0 ON T0.DocEntry = T1.DocEntry  
        
--       left JOIN OITL T3 ON T1.DocEntry = T3.DocEntry AND T1.LineNum = T3.DocLine AND T1.ObjType = T3.DocType  
--       left JOIN ITL1 T6 ON T3.LogEntry = T6.LogEntry and t6.LogEntry=t3.LogEntry 
--       left JOIN OSRQ T4 ON T6.MdAbsEntry = T4.MdAbsEntry AND T4.WhsCode = T3.LocCode  
--       left JOIN OSRN T5 ON T5.AbsEntry = T4.MdAbsEntry  
--        where  T0.docnum='17010004'

--update dln1  set U_CreditAmount='-1'  from  dln1,osrn   where  docentry=2 and dln1.itemcode='VPV200074' and osrn.distnumber='3900-2-00251' and dln1.LineNum=0



 
--WITH a1 AS(
--select * from(

 --INSERT INTO  [TS_DFE_20181120].[dbo].[@DRS_PACKAGE]  (DocEntry,DocNum,Period,Instance,Series,Handwrtten,Canceled,Object,LogInst,UserSign,
 --Transfered,Status,CreateDate,CreateTime,UpdateDate,UpdateTime,DataSource,RequestStatus,Creator,Remark,
 --U_Amount,U_Status,U_UserCreated,U_UserUpdate,U_IsComplete,U_UserUpdated )   
 
 --     SELECT   top 1   t3.DocEntry, T0.docnum ,null, null ,null,null, null,null,null,null,null,null,null,null,null,null,
 --                null,null,null,null,null ,t0.DocStatus,null,null, T1.U_CreditAmount,null
 --         FROM dln1 T1  
        
 --       --(ROW_NUMBER() over(PARTITION BY    T1.ItemCode     order by  t5.distnumber  )  )rn
     
        
        
 --       JOIN odln as T0 ON T0.DocEntry = T1.DocEntry 
 --       left JOIN OITL T3 ON T1.DocEntry = T3.DocEntry AND T1.LineNum = T3.DocLine AND T1.ObjType = T3.DocType 
 --       left JOIN ITL1 T6 ON T3.LogEntry = T6.LogEntry and t6.LogEntry=t3.LogEntry 
 --       left JOIN OSRQ T4 ON T6.MdAbsEntry = T4.MdAbsEntry AND T4.WhsCode = T3.LocCode  
 --       left JOIN OSRN T5 ON T5.AbsEntry = T4.MdAbsEntry  
        
 --       where  T0.docnum='11010002' 
 
 --insert into [TS_DFE_20181120].[dbo].[@DRS_PACKAGE_CONTENT](DocEntry, VisOrder,Object,LogInst,U_ItemCode,U_SerialNumber,U_Debit,U_Credit,U_LineNum,Dscription,ShipDate)
 
 
 --     SELECT     t3.DocEntry,  null,null, null  ,T1.ItemCode,t5.distnumber,T1.quantity,null,T1.LineNum,T1.Dscription,T1.shipdate
 --     FROM dln1 T1  
        
 --       --(ROW_NUMBER() over(PARTITION BY    T1.ItemCode     order by  t5.distnumber  )  )rn
     
        
        
 --       JOIN odln as T0 ON T0.DocEntry = T1.DocEntry 
 --       left JOIN OITL T3 ON T1.DocEntry = T3.DocEntry AND T1.LineNum = T3.DocLine AND T1.ObjType = T3.DocType 
 --       left JOIN ITL1 T6 ON T3.LogEntry = T6.LogEntry and t6.LogEntry=t3.LogEntry 
 --       left JOIN OSRQ T4 ON T6.MdAbsEntry = T4.MdAbsEntry AND T4.WhsCode = T3.LocCode  
 --       left JOIN OSRN T5 ON T5.AbsEntry = T4.MdAbsEntry  
        
 --       where  T0.docnum='11010002' 
        
        
      select p.DocEntry,p.DocNum,c.U_ItemCode,c.U_SerialNumber,p.U_Status,p.U_IsComplete,
             c.U_Debit,c.U_LineNum,c.Dscription,c.ShipDate
             --,rn
             --(ROW_NUMBER() over(PARTITION BY  p.DocNum,c.U_SerialNumber, U_IsComplete     order by  p.DocNum  )  )rn
             
      from  [@DRS_PACKAGE_CONTENT]as c
      --(select *,
      --(ROW_NUMBER() over(PARTITION BY  U_SerialNumber   order by  U_SerialNumber  )  )rn  from [@DRS_PACKAGE_CONTENT])as c
      
       --from [@DRS_PACKAGE])as p
      join  [@DRS_PACKAGE] as p on p.DocEntry=c.DocEntry
          
        
        
      update [TS_DFE_20181120].[dbo].[@DRS_PACKAGE]  set [TS_DFE_20181120].[dbo].[@DRS_PACKAGE].U_IsComplete='-1' 
      from  [TS_DFE_20181120].[dbo].[@DRS_PACKAGE_CONTENT]
     
      where   [TS_DFE_20181120].[dbo].[@DRS_PACKAGE_CONTENT].U_ItemCode='VPV200087' and  [TS_DFE_20181120].[dbo].[@DRS_PACKAGE_CONTENT].U_SerialNumber='3802-0-01274'       
       
       
        --and dln1.LineNum=3   docentry=2 and  
        --)ranked
        
       --where  ranked.rn>=1)
       
       --select * from a1
        
       
       --group by a1.docnummer,a1.Artikelnummer,a1.Seriennummer,a1.Artikelbeschreibung,a1.Soll,a1.Lst
       --,a1.DelivDate,a1.DocEntry,a1.DocStatus,a1.LineNum,a1.rn
       
       --having  COUNT(a1.rn) >1
       
       
        
 --SELECT     T0.docnum as 'docnummer', T1.ItemCode as 'Artikelnummer', t5.distnumber as 'Seriennummer', T1.Dscription as 'Artikelbeschreibung', 
 --       T1.quantity as 'Soll', T1.U_CreditAmount as 'Lst', T1.shipdate as 'DelivDate', t3.DocEntry,t0.DocStatus,t1.LineNum,
 --       (ROW_NUMBER() over(PARTITION BY  T1.ItemCode   order by  t5.distnumber  ) )rn
 --       FROM dln1 T1  
 --       JOIN odln as T0 ON T0.DocEntry = T1.DocEntry 
 --       left JOIN OITL T3 ON T1.DocEntry = T3.DocEntry AND T1.LineNum = T3.DocLine AND T1.ObjType = T3.DocType 
 --       left JOIN ITL1 T6 ON T3.LogEntry = T6.LogEntry and t6.LogEntry=t3.LogEntry 
 --       left JOIN OSRQ T4 ON T6.MdAbsEntry = T4.MdAbsEntry AND T4.WhsCode = T3.LocCode  
 --       left JOIN OSRN T5 ON T5.AbsEntry = T4.MdAbsEntry  where  T0.docnum='11010002'       