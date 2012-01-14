--ª„◊‹ø‚¥Ê ”Õº
ALTER VIEW dbo.vwstkGoodStkInfoView
AS
SELECT A.sGoodID, A.sSpec, A.fBasePrice,A.fSalePrice,B.sGoodCName, B.sGoodEName, B.sGoodTypeID,
       B.sUnitID, B.sShopID,C.sDictDataCName AS sGoodTypeName,D.sShopCName,E.sDictDataCName AS sUnitName,
       SUM(A.fQuantity) AS fQuantity, SUM(A.fStkInQty) AS fStkInQty, SUM(A.fStkOutQty) AS fStkOutQty,
       SUM(A.fTotal) AS fTotal
FROM vwstkGoodStockInfo A
LEFT JOIN salGoodInfoMaster B ON A.sGoodID=B.sGoodID
LEFT JOIN vwbasDataDictDetail C ON B.sGoodTypeID=C.sDictDataNo AND C.sDictCategoryNo='1014'
LEFT JOIN hrCompanyShopInfo D ON B.sShopID=D.sShopID
LEFT JOIN vwbasDataDictDetail E ON B.sUnitID=E.sDictDataNo AND E.sDictCategoryNo='1015'
GROUP BY A.sGoodID, A.sSpec, A.fBasePrice,A.fSalePrice ,B.sGoodCName, B.sGoodEName, B.sGoodTypeID,
       B.sUnitID, B.sShopID,C.sDictDataCName,D.sShopCName,E.sDictDataCName
