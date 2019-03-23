--select a.ItemCode from DLN1 as a where a.DocEntry=2

--select   b.DocNum  from ODLN as b where DocNum=11010002

--select k.U_CreditAmount from DLN1 as k

--select c.DistNumber from OSRN as c  where  c.DistNumber='3900-2-00260'

--select x.ItemCode from dln1 as x   where    x.itemcode='VPV200074'

-- update dln1 set U_CreditAmount='+1'  where  docentry=2 and itemcode='VPV200074' and   EXISTS(select distnumber from osrn where distnumber='3800-2-01875') 
 
-- update dln1 set U_CreditAmount='+1'  where  docentry=2 and itemcode='VPV200074' and   EXISTS(select distnumber from osrn where distnumber='3800-2-01876')
 
-- SELECT t0.docnum as docnummer, T1.ItemCode as 'Artikelnummer', o.distnumber as 'Seriennummer', T1.Dscription as 'Artikelbeschreibung',  
--      T1.quantity as 'Soll', T1.U_CreditAmount as 'Lst', T1.shipdate as 'DelivDate',t0.docentry 
--       FROM dln1 T1 
--        join osrn o on o.itemcode= t1.itemcode
--       JOIN odln as T0 ON T0.DocEntry = T1.DocEntry 
--       where  o.DistNumber='3800-2-01875'

  
  
 SELECT distinct top 100 odln.docnum as 'docnummer', T1.ItemCode as 'Artikelnummer', o.distnumber as 'Seriennummer', T1.Dscription as 'Artikelbeschreibung', 
       T1.quantity as 'Soll', T1.U_CreditAmount as 'Lst', T1.shipdate as 'DelivDate',o.docentry 
        FROM dln1 T1
        
        JOIN   odln as o ON o.DocEntry = T1.DocEntry  
        join osrn o on o.itemcode= t1.itemcode 
 order by o.distnumber
 
 
 
 SELECT top 1000  t0.docnum as 'docnummer', T1.ItemCode as 'Artikelnummer', o.distnumber  , T1.Dscription as 'Artikelbeschreibung', 
         T1.quantity as 'Soll', T1.U_CreditAmount as 'Lst', T1.shipdate as 'DelivDate', t0.DocEntry,t0.DocStatus, t0.DocDate 
         FROM dln1 T1 
         JOIN odln as T0 ON T0.DocEntry = T1.DocEntry 
         join osrn o on o.itemcode= t1.itemcode 
         order by o.distnumber