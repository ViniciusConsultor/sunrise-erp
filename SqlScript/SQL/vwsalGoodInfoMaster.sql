ALTER VIEW dbo.vwsalGoodInfoMaster
AS
SELECT A.*,B.sDictDataCName AS sGoodTypeName,C.sDictDataCName AS sUnitCName,
C.sDictDataEName AS sUnitEName,D.sShopCName,D.sShopEName 
FROM salGoodInfoMaster A
LEFT JOIN vwbasDataDictDetail B ON A.sGoodTypeID=B.sDictDataNo AND B.sDictCategoryNo='1014'
LEFT JOIN vwbasDataDictDetail C ON A.sUnitID=C.sDictDataNo AND C.sDictCategoryNo='1015'
LEFT JOIN hrCompanyShopInfo D ON A.sShopID=D.sShopID