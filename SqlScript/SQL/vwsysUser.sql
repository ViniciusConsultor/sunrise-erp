ALTER VIEW [dbo].[vwsysUser]
AS
SELECT A.*,CASE WHEN A.iUserType=0 THEN 'һ���û�' ELSE '�����û�' END AS sUserTypeName,
       C.sDeptNo, C.sDeptName, C.sDeptEName,D.sUserID AS sParentUserID,
       D.sUserCName AS sParentCName
FROM SysUser A
LEFT JOIN hrEmployee B ON A.EmpID=B.ID
LEFT JOIN hrDepartment C ON B.iDepartmentID=C.ID
LEFT JOIN sysUser D ON A.ParentID=D.ID



