ALTER VIEW dbo.vwsysRolesRights
AS
SELECT A.ID, A.RoleID, A.MenuID, A.iAdd, A.iView, A.iEdit, A.iDelete, A.iPrint,
       A.iNum, A.iPrice,A.iProperty, A.iOutPut, B.sRoleNo, B.sRoleCName,C.sMenuName,C.iParentID,
       C.iSort
FROM sysRolesRights A
LEFT JOIN sysRoles B ON B.ID = A.RoleID
LEFT JOIN sysMenu C ON A.MenuID=C.ID