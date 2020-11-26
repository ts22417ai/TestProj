select top 10 o.fPID, count(*) 數量 from t訂單 o 
group by o.fPID
order by count(*) desc

select p.fPID,p.[f項目評級 ],p.f項目名稱,p.f項目內容,u.f姓名,p.f價格,p.f項目照片
from (select top 10 o.fPID, count(*) 數量 from t訂單 o 
group by o.fPID
order by count(*) desc) o inner join t販售項目 p on p.fPID = o.fPID
inner join t私廚 c on c.fCID = p.fCID
inner join t會員 u on c.fUID = u.fUID


select p.fCID,p.fPID, u.f姓名,p.f項目名稱, p.[f項目評級], p.f價格, p.f項目照片--, case when x.fPID is null then 0 else 1 end is我的最愛
                from t販售項目 p inner join t私廚 c on p.fCID=c.fCID
                inner join t會員 u on u.fUID = c.fUID
                --inner join t私廚可預訂時間 as t on t.fCID = p.fCID
                inner join t風格 as s on s.fSID = p.fSID
                inner join t服務種類 as k on k.fKID = p.fKID

                inner join (select top 10 o.fPID, count(*) 數量 from t訂單 o group by o.fPID
                order by count(*) desc) x on x.fPID = p.fPID
                ; 


