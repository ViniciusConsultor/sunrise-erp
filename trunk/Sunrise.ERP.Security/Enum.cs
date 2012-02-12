using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sunrise.ERP.Security
{
    /// <summary>
    /// 权限操作
    /// </summary>
    public enum SecurityOperation
    {
        /// <summary>
        /// 查询
        /// </summary>
        View = 0,
        /// <summary>
        /// 新增
        /// </summary>
        Add,
        /// <summary>
        /// 编辑
        /// </summary>
        Edit,
        /// <summary>
        /// 删除
        /// </summary>
        Delete,
        /// <summary>
        /// 打印
        /// </summary>
        Print,
        /// <summary>
        /// 数量
        /// </summary>
        Num,
        /// <summary>
        /// 单价
        /// </summary>
        Price,
        /// <summary>
        /// 属性
        /// </summary>
        Property,
        /// <summary>
        /// 导出
        /// </summary>
        OutPut
        
    }

    /// <summary>
    /// 权限值
    /// </summary>
    public enum SecurityOperationValue
    {
        /// <summary>
        /// 无权限-0
        /// </summary>
        None = 0,
        /// <summary>
        /// 个人-1
        /// </summary>
        Self,
        /// <summary>
        /// 下属-2
        /// </summary>
        Underling,
        /// <summary>
        /// 个人及下属-3
        /// </summary>
        SelfAndUnderling,
        /// <summary>
        /// 部门-4
        /// </summary>
        Department,
        /// <summary>
        /// 所有-5
        /// </summary>
        All,
        /// <summary>
        /// 下属部门-6
        /// </summary>
        DeptUnderling,
        /// <summary>
        /// 部门及下属部门-7
        /// </summary>
        DepartmentAndUnderling
    }

    /// <summary>
    /// 数据显示类型
    /// </summary>
    public enum ShowType
    {
        /// <summary>
        /// 窗体显示数据
        /// </summary>
        FormShow = 0,
        /// <summary>
        /// 窗体查询数据
        /// </summary>
        FormQuery
    }
}
