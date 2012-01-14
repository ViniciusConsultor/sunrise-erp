--Create By Belself.Wang 2011-1-2
--≤÷ø‚ø‚¥Ê ”Õº
ALTER VIEW dbo.vwstkGoodStockInfo
AS
SELECT A.sGoodID, A.sSpec, A.fBasePrice, A.fSalePrice,A.fQuantity AS fQuantity,
A.fQuantity AS fStkInQty,0 AS fStkOutQty,A.fBasePrice*A.fQuantity AS fTotal
FROM stkGoodInStockDetail A
LEFT JOIN stkGoodInStockMaster B ON A.MainID=B.ID
WHERE B.iFlag=4
UNION ALL
SELECT A.sGoodID, A.sSpec, A.fBasePrice,A.fSalePrice,-A.fQuantity AS fQuantity, 
0 AS fStkInQty,A.fQuantity AS fStkOutQty,-A.fQuantity*A.fBasePrice AS fTotal
FROM stkGoodOutStockDetail A
LEFT JOIN stkGoodOutStockMaster B ON A.MainID=B.ID
WHERE B.iFlag=4


