ALTER VIEW dbo.vwhrEmployee
AS
SELECT A.*,B.sDeptNo, B.sDeptName, B.sDeptEName
FROM hrEmployee A
LEFT JOIN hrDepartment B ON A.iDepartmentID=B.ID