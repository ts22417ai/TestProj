select p.fPID,p.[f項目評級 ],p.f項目名稱,p.f項目內容,k.f服務種類,u.f姓名,p.f價格,p.f項目照片,s.f風格 ,q.數量
                from (select top 5 o.fPID, count(*) 數量 from t訂單 as o
                inner join t販售項目 p on p.fPID = o.fPID 
                inner join t服務種類 k on k.fKID = p.fKID 
                where k.fKID= 1 or k.fKID=2
                group by o.fPID order by count(*) desc) q   
                inner join t販售項目 p on p.fPID = q.fPID 
                inner join t私廚 c on c.fCID = p.fCID 
                inner join t會員 u on c.fUID = u.fUID          
                inner join t風格 s on s.fSID = p.fSID 
                inner join t服務種類 k on k.fKID = p.fKID


                select * from
                (select top 5 o.fPID, count(*) 數量 from t訂單 as o
                inner join t販售項目 p on p.fPID = o.fPID 
                inner join t服務種類 k on k.fKID = p.fKID 
                where k.fKID= 1 or k.fKID=2
                group by o.fPID order by count(*) desc) q   
                inner join t販售項目 p on p.fPID = q.fPID              
                inner join t服務種類 k on k.fKID = p.fKID
                inner join t風格 s on s.fSID = p.fSID 
                


                

               