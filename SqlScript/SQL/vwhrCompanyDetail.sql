ALTER VIEW dbo.vwhrCompanyDetail
AS
SELECT A.ID, A.MainID, A.sCurrency, A.sBankName, A.sBankAccount, A.sBankAddr,
       A.sRemark, A.iFlag, A.sUserID, A.dInputDate,B.sCurrencyCName,B.sCurrencyEName
FROM hrCompanyDetail A
LEFT JOIN basCurrency B ON A.sCurrency=B.sCurrencyID
