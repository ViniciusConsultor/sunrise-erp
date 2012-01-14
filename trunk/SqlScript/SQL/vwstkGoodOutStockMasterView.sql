CREATE VIEW dbo.vwstkGoodOutStockMasterView
AS
SELECT A.sStockInNo, A.dStockInDate, A.sSupplierID, A.sStockInType,
       A.sBussinessManID, A.sTradeBillNo, A.fTotalQuantity, A.fTotalAmount,
       A.sStockInTypeName, A.sSupplierSName, A.sSupplierCName, A.sBussinessManName,
       B.sGoodID, B.sSpec, B.fSalePrice, B.fBasePrice, B.sGoodCName, B.sGoodEName,
       B.sUnitCName, B.sUnitEName,A.iFlag,A.sFlagName
FROM vwstkGoodInStockMaster A
RIGHT JOIN vwstkGoodInStockDetail B ON A.ID=B.MainID
LEFT JOIN vwsalGoodInfoMaster C ON B.sGoodID=C.sGoodID 

SELECT * FROM vwsalGoodInfoMasterView 