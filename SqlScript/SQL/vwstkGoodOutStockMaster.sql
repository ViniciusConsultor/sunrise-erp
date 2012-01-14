ALTER VIEW dbo.vwstkGoodOutStockMaster
AS
SELECT A.*,A.fSaleAmount-A.fPayMoney AS fPayBackMoney,B.sShopCName, B.sShopEName,C.sEmpCName, C.sEmpEName
FROM stkGoodOutStockMaster A
LEFT JOIN hrCompanyShopInfo B ON A.sShopID=B.sShopID
LEFT JOIN hrEmployee C ON A.sUserID=C.sEmpNo
