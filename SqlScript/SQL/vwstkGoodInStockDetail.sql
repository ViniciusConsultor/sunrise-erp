CREATE VIEW dbo.vwstkGoodInStockDetail
AS
SELECT A.*,B.sGoodCName, B.sGoodEName,C.sDictDataCName AS sUnitCName,
C.sDictDataEName AS sUnitEName,ISNULL(A.fSalePrice,0)*ISNULL(A.fQuantity,0) AS fAmount
FROM stkGoodInStockDetail A
LEFT JOIN salGoodInfoMaster B ON A.sGoodID=B.sGoodID
LEFT JOIN vwbasDataDictDetail C ON B.sUnitID=C.sDictDataNo AND C.sDictCategoryNo='1015'

