ALTER VIEW [dbo].[vwsysUser]
AS
SELECT A.*,CASE WHEN A.iUserType=0 THEN 'һ���û�' ELSE '�����û�' END AS sUserTypeName,
       B.sDeptNo, B.sDeptName, B.sDeptEName,C.sUserID AS sParentUserID,
       C.sUserCName AS sParentCName
FROM SysUser A
LEFT JOIN hrDepartment B ON A.DeptID =B.ID
LEFT JOIN sysUser C ON A.ParentID=C.ID