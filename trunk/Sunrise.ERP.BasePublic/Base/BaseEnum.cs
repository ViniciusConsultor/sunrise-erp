//***************************************************************************************//
//项目名称：Sunrise ERP System Platform
//模块名称：BaseEnum
//模块类别：系统基础窗体
//模块说明：基础枚举类
//创建人：Belself.Wang
//创建时间：2010-7-14
//备注：
//***************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Sunrise.ERP.BasePublic
{
    /// <summary>
    /// 操作状态
    /// </summary>
    public enum OperateFlag
    {
        /// <summary>
        /// 新增
        /// </summary>
        Insert = 0,
        /// <summary>
        /// 编辑
        /// </summary>
        Edit,
        /// <summary>
        /// 取消
        /// </summary>
        Cancel,
        /// <summary>
        /// 保存
        /// </summary>
        Save,
        /// <summary>
        /// 复制
        /// </summary>
        Copy,
        /// <summary>
        /// 查询
        /// </summary>
        View,
        /// <summary>
        /// 删除
        /// </summary>
        Delete,
        /// <summary>
        /// 空数据
        /// </summary>
        None
    }
    /// <summary>
    /// 数据状态
    /// </summary>
    public enum DataFlag
    {
        /// <summary>
        /// 浏览
        /// </summary>
        dsBrowse = 0,
        /// <summary>
        /// 插入
        /// </summary>
        dsInsert,
        /// <summary>
        /// 编辑
        /// </summary>
        dsEdit
    }

    /// <summary>
    /// 字段数据类型
    /// </summary>
    public enum FiledType
    {
        /// <summary>
        /// 字符串
        /// </summary>
        S=0,
        /// <summary>
        /// 日期类型
        /// </summary>
        D,
        /// <summary>
        /// 字符类型，使用ComboBox
        /// </summary>
        C,
        /// <summary>
        /// 时间类型
        /// </summary>
        T,
        /// <summary>
        /// 数字类型
        /// </summary>
        N
    }
}

