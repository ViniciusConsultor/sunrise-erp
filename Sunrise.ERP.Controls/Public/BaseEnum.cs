using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sunrise.ERP.Controls
{
    /// <summary>
    /// 流程图节点形状
    /// </summary>
    public enum FlowChartItemStyleShape
    {
        /// <summary>
        /// 长方形
        /// </summary>
        Oblong = 0,
        /// <summary>
        /// 圆形
        /// </summary>
        Ellipse,
        /// <summary>
        /// 菱形
        /// </summary>
        Diamond
    }
    /// <summary>
    /// 流程图Tip显示模式
    /// </summary>
    public enum FlowChartShowTipType
    {
        /// <summary>
        /// Tip为空时显示节点名称
        /// </summary>
        ShowNameIsTipNull = 0,
        /// <summary>
        /// 不显示Tip
        /// </summary>
        NoTip,
        /// <summary>
        /// 只显示Tip
        /// </summary>
        ShowTip
    }
}
