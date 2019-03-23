SELECT distinct top 10000 t0.docnum as docnummer, T1.ItemCode as 'Artikelnummer', o.itemcode as 'Seriennummer', T1.Dscription as 'Artikelbeschreibung', 
     T1.quantity as 'Soll', T1.U_CreditAmount as 'Lst', T1.shipdate as 'DelivDate',t0.docentry 
        FROM dln1 T1
         join osrn o on o.itemcode= t1.itemcode
         JOIN odln as T0 ON T0.DocEntry = T1.DocEntry
         
  update dln1 set U_CreditAmount=-1  where  docentry=10 and itemcode='VPV100011' and   EXISTS(select distnumber from osrn where distnumber='3802-0-01084')    
  
  
  
   select * from dln1  where   itemcode='VPV100011'  
     select * from odln  where   docentry=577 
      
     select * from osrn where DistNumber=''
  
   update dln1 set U_CreditAmount=-1  where  docentry=15 and itemcode='VPV200076' and   EXISTS(select * from osrn where distnumber=NULL) 
          
  
 SELECT distinct top 3000 t0.docnum as docnummer, T1.ItemCode as 'Artikelnummer', o.DistNumber as 'Seriennummer', T1.Dscription as 'Artikelbeschreibung',
  T1.quantity as 'Soll', T1.U_CreditAmount as 'Lst',
  T1.shipdate as 'DelivDate',t0.docentry FROM dln1 T1, osrn as o, ODln as t0
    
  
  
  select  *  from OSRN where DistNumber='82-2-10011'
  
    select  *  from odln where DistNumber='82-2-10011' 
    
     select  *  from dln1 where itemcode='EBM200004'
  
  
  
  
  SELECT   t0.docnum as docnummer, T1.ItemCode as 'Artikelnummer', o.distnumber as 'Seriennummer', T1.Dscription as 'Artikelbeschreibung',
   T1.quantity as 'Soll', T1.U_CreditAmount as 'Lst', T1.shipdate as 'DelivDate', t0.DocEntry,t0.DocStatus, t0.DocDate FROM dln1 T1
   JOIN odln as T0 ON T0.DocEntry = T1.DocEntry 
   join osrn o on o.itemcode= t1.itemcode
    where o.distnumber='82-2-10011' 
  
  
  
  
DECLARE @i int = 1

WHILE @i < 59379
BEGIN
    SET @i = @i + 1
    update OSRN set DistNumber=@i
    /* do some work */
END


SELECT top 1000  t0.docnum as docnummer, T1.ItemCode as 'Artikelnummer', o.distnumber as 'Seriennummer', T1.Dscription as 'Artikelbeschreibung', 
         T1.quantity as 'Soll', T1.U_CreditAmount as 'Lst', T1.shipdate as 'DelivDate', t0.DocEntry,t0.DocStatus, t0.DocDate 
         FROM dln1 T1 
         JOIN odln as T0 ON T0.DocEntry = T1.DocEntry 
         join osrn o on o.itemcode= t1.itemcode 
          where o.distnumber=5 \
          
          
SELECT top 1000  t0.docnum as docnummer, T1.ItemCode as 'Artikelnummer', o.distnumber as 'Seriennummer', T1.Dscription as 'Artikelbeschreibung', T1.quantity as 'Soll', T1.U_CreditAmount as 'Lst', T1.shipdate as 'DelivDate', t0.DocEntry,t0.DocStatus, t0.DocDate FROM dln1 T1
 JOIN odln as T0 ON T0.DocEntry = T1.DocEntry join osrn o on o.itemcode= t1.itemcode where o.distnumber=