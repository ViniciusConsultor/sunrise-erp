ALTER VIEW [dbo].[vwsysDynamicFormMaster]
AS
SELECT A.*,B.sDictDataCName AS sFormTypeName,B.sDictDataEName AS sFormTypeEngName,
C.sMenuName,C.sMenuEngName
FROM sysDynamicFormMaster A
LEFT JOIN vwbasDataDictDetail B ON A.sFormType=B.sDictDataNo AND b.sDictCategoryNo='1018'
LEFT JOIN sysMenu C ON A.FormID=C.iFormID
WHERE C.sMenuName IS NOT NULL