ALTER VIEW dbo.vwsysRolesUser
AS
SELECT A.ID, A.RoleID, A.UserID,A.sUserID,
B.sUserID AS sRoleUserID, B.sUserCName AS sRoleUserCName,
C.sRoleNo, C.sRoleCName
FROM sysRolesUser A 
LEFT JOIN sysUser B ON B.ID = A.UserID
LEFT JOIN sysRoles C ON A.RoleID=C.ID