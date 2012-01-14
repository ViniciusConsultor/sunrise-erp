ALTER VIEW dbo.vwstkGoodOutStockDetail  
AS  
SELECT A.*,B.sGoodCName, B.sGoodEName,  
CAST(ISNULL(A.fSalePrice,0)*ISNULL(A.fQuantity,0)*ISNULL(A.fDiscount,0)/100 AS decimal(18,2)) AS fAmount,  
CAST(ISNULL(A.fSalePrice,0)*ISNULL(A.fQuantity,0)*(1-ISNULL(A.fDiscount,0)/100) AS decimal(18,2)) AS fDiscountMoney  
FROM stkGoodOutStockDetail A  
LEFT JOIN salGoodInfoMaster B ON A.sGoodID=B.sGoodID