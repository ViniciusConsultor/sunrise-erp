USE [BWSERP2010]
GO

/****** Object:  View [dbo].[vwbasSupplierMaster]    Script Date: 12/13/2010 23:03:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[vwbasSupplierMaster]
AS
SELECT A.*,B.sDictDataCName AS sSupplierTypeName
FROM basSupplierMaster A
LEFT JOIN vwbasDataDictDetail B ON A.sSupplierTypeID=B.sDictDataNo AND B.sDictCategoryNo='1013'
GO


