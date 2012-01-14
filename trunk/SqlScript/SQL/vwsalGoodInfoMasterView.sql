ALTER VIEW dbo.vwsalGoodInfoMasterView
AS
SELECT TOP 100 PERCENT A.*,B.fBasePrice, B.fSupplierSalePrice, B.fDiscount, B.fSalePrice,B.dPriceDate
FROM vwsalGoodInfoMaster A
LEFT JOIN salGoodInfoDetail B ON A.ID=B.MainID AND B.bIsStop=0
ORDER BY B.dPriceDate DESC