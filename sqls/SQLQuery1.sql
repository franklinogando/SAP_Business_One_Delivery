select a.SerialNum from dln1 as a
join ODLN as b on a.DocEntry=b.DocEntry

where DocNum='11010510'

select * from OSRN as o
where o.ItemCode='vpv200074'


SELECT top 1000  t0.docnum as docnummer, T1.ItemCode as 'Artikelnummer', o.distnumber as 'Seriennummer', T1.Dscription as 'Artikelbeschreibung', 
         T1.quantity as 'Soll', T1.U_CreditAmount as 'Lst', T1.shipdate as 'DelivDate', t0.DocEntry,t0.DocStatus, t0.DocDate 
         FROM dln1 T1 
         JOIN odln as T0 ON T0.DocEntry = T1.DocEntry 
         join osrn o on o.itemcode= t1.ItemCode
          where t0.docnum='11010510' and o.itemcode='vpv200075'
          
          
select 