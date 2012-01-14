ALTER VIEW dbo.vwstkGoodInStockMaster
AS
SELECT A.*,B.sDictDataCName AS sStockInTypeName,C.sSupplierSName,C.sSupplierCName,
C.sSupplierEName,D.sEmpCName AS sBussinessManName,E.sFlagName
FROM stkGoodInStockMaster A
LEFT JOIN vwbasDataDictDetail B ON A.sStockInType=B.sDictDataNo AND B.sDictCategoryNo='1016'
LEFT JOIN basSupplierMaster C ON A.sSupplierID=C.sSupplierID
LEFT JOIN hrEmployee D ON A.sBussinessManID=D.sEmpNo
LEFT JOIN basBillState E ON A.iFlag=E.iFlag

