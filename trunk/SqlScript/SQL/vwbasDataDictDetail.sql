ALTER VIEW [dbo].[vwbasDataDictDetail]
AS
SELECT A.ID, A.MainID, A.sDictDataNo, A.sDictDataCName, A.sDictDataEName,
       A.sRemark,A.bIsStop,B.sDictCategoryNo, B.sDictCategoryCName
FROM basDataDictDetail A
LEFT JOIN basDataDictMaster B ON B.ID = A.MainID
GO


