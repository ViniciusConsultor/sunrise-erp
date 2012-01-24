ALTER VIEW dbo.vwsysDynamicFormMaster
AS
SELECT A.*,B.sDictDataCName AS sFormTypeName,B.sDictDataEName AS sFormTypeEngName
FROM sysDynamicFormMaster A
LEFT JOIN vwbasDataDictDetail B ON A.sFormType=B.sDictDataNo AND b.sDictCategoryNo='1018'