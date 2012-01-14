using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;

using Sunrise.ERP.Lang;

namespace Sunrise.ERP.Controls
{
    [Serializable]
    public partial class SunriseFlowChart : DevExpress.XtraEditors.XtraUserControl
    {
        /// <summary>
        /// Sunrise流程图
        /// </summary>
        public SunriseFlowChart()
        {
            InitializeComponent();
        }
        #region 定义
        List<FlowChartItem> _FlowChartItem = new List<FlowChartItem>();
        FlowChartItem _CurrentItem = null;
        string _CurrentItemName = "";
        int _ItemMinWidth = 20;
        int _ItemMinHeight = 20;
        int _ItemX = 0;
        int _ItemY = 0;
        string _DragSide = "";
        string _DragLine = "";
        Color _CurrentItemColor = Color.Blue;
        FlowChartItem _OnMouseOverItem = null;
        bool IsOnClickEventHander = false;




        List<FlowChartLine> _FlowChartLine = new List<FlowChartLine>();
        FlowChartLine _CurrentLine = null;
        string _CurrentLineName = "";
        Color _CurrentLineColor = Color.Blue;
        FlowChartLine _OnMouseOverLine = null;




        #endregion


        #region 对象定义


        /// <summary>
        /// 流程图节点
        /// </summary>
        [Serializable]
        public class FlowChartItem
        {
            /// <summary>
            /// 节点名称
            /// </summary>
            public string Name = "";
            /// <summary>
            /// 背景颜色
            /// </summary>
            public Color BackColor = Color.White;
            /// <summary>
            /// 字体颜色
            /// </summary>
            public Color ForeColor = Color.Blue;
            /// <summary>
            /// 边框颜色
            /// </summary>
            public Color BorderColor = Color.Black;
            /// <summary>
            /// 节点区域
            /// </summary>
            public Rectangle Rect = new Rectangle(0, 0, 60, 60);
            /// <summary>
            /// 层次
            /// </summary>
            public int Level = 0;
            /// <summary>
            /// 提示信息
            /// </summary>
            public string ToolTip = "";
            /// <summary>
            /// 节点Tag
            /// </summary>
            public string Tag = "";
            /// <summary>
            /// 节点连接窗体模块名称
            /// </summary>
            public string FormModel = "";
            /// <summary>
            /// 节点形状
            /// </summary>
            public FlowChartItemStyleShape Shape = FlowChartItemStyleShape.Oblong;
            /// <summary>
            /// 字体
            /// </summary>
            public Font TextFont = DefaultFont;
            /// <summary>
            /// 节点背景图片
            /// </summary>
            public Image BackImage = null;
        }


        /// <summary>
        /// 流程图连接线
        /// </summary>
        [Serializable]
        public class FlowChartLine
        {
            /// <summary>
            /// 连接线名称
            /// </summary>
            public string LineName = "";
            /// <summary>
            /// 连接颜色
            /// </summary>
            public Color LineColor = Color.BlueViolet;
            /// <summary>
            /// 连接线粗细
            /// </summary>
            public int LineWidth = 2;
            /// <summary>
            /// 连接线起点
            /// </summary>
            public Point LineHead = new Point(10, 10);
            /// <summary>
            /// 连接线终点
            /// </summary>
            public Point LineFoot = new Point(100, 10);
            /// <summary>
            /// 连接线长度
            /// </summary>
            public double LineLength = 0;//Math.Sqrt((LineHead.X - LineFoot.X) * (LineHead.X - LineFoot.X) - (LineHead.Y - LineFoot.Y) * (LineHead.Y - LineFoot.Y));
            /// <summary>
            /// 箭头宽
            /// </summary>
            public float ArrowCapWidth = 10;
            /// <summary>
            /// 箭头高
            /// </summary>
            public float ArrowCapHeight = 10;


        }


        #endregion


        #region 属性
        ///// <summary>
        ///// 当前选择的项 如果为空则没有选中任何项
        ///// </summary>
        //public string CurrentItemName
        //{
        //    get { return _CurrentItemName; }
        //}
        ///// <summary>
        ///// 当前选择的项 如果为空则没有选中任何项
        ///// </summary>
        //public string CurrentLineName
        //{
        //    get { return _CurrentLineName; }
        //}


        ///// <summary>
        ///// 选择的项的颜色
        ///// </summary>
        //public Color CurrentItemColor
        //{
        //    get { return _CurrentItemColor; }
        //    set
        //    {
        //        _CurrentItemColor = value;
        //        DrawItems();
        //    }
        //}
        ///// <summary>
        ///// 选择的项的颜色
        ///// </summary>
        //public Color CurrentLineColor
        //{
        //    get { return _CurrentLineColor; }
        //    set
        //    {
        //        _CurrentLineColor = value;
        //        DrawItems();
        //    }
        //}


        Hashtable htFlowChart = null;
        /// <summary>
        /// 流程图对象集合
        /// </summary>   
        [Category("FlowChart设置"), Description("FlowChart")]
        public Hashtable FlowChart
        {
            get
            {
                htFlowChart = new Hashtable();
                htFlowChart.Add("Item", _FlowChartItem);
                htFlowChart.Add("Line", _FlowChartLine);
                return htFlowChart;
            }
            set
            {
                htFlowChart = new Hashtable();
                htFlowChart = value;
                if (htFlowChart != null)
                {
                    _FlowChartItem = (List<FlowChartItem>)htFlowChart["Item"];
                    _FlowChartLine = (List<FlowChartLine>)htFlowChart["Line"];
                }
            }
        }


        private bool _IsDesignMode = true;
        /// <summary>
        /// 是否为设计模式
        /// </summary>
        [Category("FlowChart设置"), Description("是否为设计模式"), DefaultValue(true)]
        public bool IsDesignMode
        {
            get
            {
                return _IsDesignMode;
            }
            set
            {
                _IsDesignMode = value;
            }
        }


        private bool _IsInDesignModeCanOpenForm = true;
        /// <summary>
        /// 是否允许在设计模式中单击节点打开连接窗体
        /// </summary>
        [Category("FlowChart设置"), Description("是否允许在设计模式中单击节点打开连接窗体"), DefaultValue(true)]
        public bool IsInDesignModeCanOpenForm
        {
            get
            {
                return _IsInDesignModeCanOpenForm;
            }
            set
            {
                _IsInDesignModeCanOpenForm = value;
            }
        }
        private FlowChartShowTipType _tipType = FlowChartShowTipType.ShowNameIsTipNull;
        /// <summary>
        /// ToolTip显示类型
        /// </summary>
        [Category("FlowChart设置"), Description("ToolTip显示类型"), DefaultValue(FlowChartShowTipType.ShowNameIsTipNull)]
        public FlowChartShowTipType ShowTipType
        {
            get
            {
                return _tipType;
            }
            set
            {
                _tipType = value;
            }
        }




        #endregion


        #region 事件定义
        /// <summary>
        /// 节点单击事件代理
        /// </summary>
        /// <param name="name">节点名称</param>
        /// <param name="formmodel">节点对应窗体模块</param>
        public delegate void FlowChartItemClickEventHandler(string name, string formmodel);
        /// <summary>
        /// 节点单击事件
        /// </summary>
        public event FlowChartItemClickEventHandler OnItemClick;


        ///// <summary>
        ///// 显示提示事件代理
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="tooltip"></param>
        //public delegate void FlowChartItemShowTipEventHandler(string name,string tooltip,Point p);


        ///// <summary>
        ///// 显示提示
        ///// </summary>
        //public event FlowChartItemShowTipEventHandler ShowTip;


        //public delegate void FlowChartItemMouseLeaveHandler(string name);


        //public event FlowChartItemMouseLeaveHandler OnItemMouseLeave;


        #endregion


        #region 方法处理


        /// <summary>
        /// 画节点
        /// </summary>
        /// <param name="item">FlowChartItem节点对象</param>
        private void AddFlowChartItem(FlowChartItem item)
        {
            _FlowChartItem.Add(item);
            BringItemToFront(item);
        }
        /// <summary>
        /// 画节点
        /// </summary>
        /// <param name="name">节点名称</param>
        public void AddFlowChartItem(string name)
        {
            FlowChartItem item = new FlowChartItem();
            item.Name = name;
            AddFlowChartItem(item);
        }
        /// <summary>
        /// 画节点
        /// </summary>
        /// <param name="name">节点名称</param>
        /// <param name="rect">节点区域</param>
        public void AddFlowChartItem(string name, Rectangle rect)
        {
            FlowChartItem item = new FlowChartItem();
            item.Name = name;
            item.Rect = rect;
            AddFlowChartItem(item);
        }
        /// <summary>
        /// 画节点
        /// </summary>
        /// <param name="rect">节点区域</param>
        public void AddFlowChartItem(Rectangle rect)
        {
            FlowChartItem item = new FlowChartItem();
            item.Name = LangCenter.Instance.GetControlLangInfo("SunriseFlowChart", "NewChart") + (_FlowChartItem.Count + 1).ToString();
            item.Rect = rect;
            AddFlowChartItem(item);
        }
        /// <summary>
        /// 画节点
        /// </summary>
        /// <param name="name">节点名称</param>
        /// <param name="rect">节点区域</param>
        /// <param name="tooltip">提示信息</param>
        public void AddFlowChartItem(string name, Rectangle rect, string tooltip)
        {
            FlowChartItem item = new FlowChartItem();
            item.Name = name;
            item.Rect = rect;
            item.ToolTip = tooltip;
            AddFlowChartItem(item);
        }
        /// <summary>
        /// 画节点
        /// </summary>
        /// <param name="name">节点名称</param>
        /// <param name="rect">节点区域</param>
        /// <param name="backcolor">背景颜色</param>
        public void AddFlowChartItem(string name, Rectangle rect, Color backcolor)
        {
            FlowChartItem item = new FlowChartItem();
            item.Name = name;
            item.Rect = rect;
            item.BackColor = backcolor;
            AddFlowChartItem(item);
        }
        /// <summary>
        /// 画节点
        /// </summary>
        /// <param name="name">节点名称</param>
        /// <param name="rect">节点区域</param>
        /// <param name="backcolor">背景颜色</param>
        /// <param name="tooltip">提示信息</param>
        public void AddFlowChartItem(string name, Rectangle rect, Color backcolor, string tooltip)
        {
            FlowChartItem item = new FlowChartItem();
            item.Name = name;
            item.Rect = rect;
            item.BackColor = backcolor;
            item.ToolTip = tooltip;
            AddFlowChartItem(item);
        }
        /// <summary>
        /// 画节点
        /// </summary>
        /// <param name="name">节点名称</param>
        /// <param name="rect">节点区域</param>
        /// <param name="backcolor">背景颜色</param>
        /// <param name="tooltip">提示信息</param>
        /// <param name="tag">节点Tag</param>
        public void AddFlowChartItem(string name, Rectangle rect, Color backcolor, string tooltip, string tag)
        {
            FlowChartItem item = new FlowChartItem();
            item.Name = name;
            item.Rect = rect;
            item.BackColor = backcolor;
            item.ToolTip = tooltip;
            item.Tag = tag;
            AddFlowChartItem(item);
        }
        /// <summary>
        /// 画节点
        /// </summary>
        /// <param name="name">节点名称</param>
        /// <param name="rect">节点区域</param>
        /// <param name="backcolor">背景颜色</param>
        /// <param name="tooltip">提示信息</param>
        /// <param name="tag">节点Tag</param>
        /// <param name="formmodel">节点连接模块</param>
        public void AddFlowChartItem(string name, Rectangle rect, Color backcolor, string tooltip, string tag, string formmodel)
        {
            FlowChartItem item = new FlowChartItem();
            item.Name = name;
            item.Rect = rect;
            item.BackColor = backcolor;
            item.ToolTip = tooltip;
            item.Tag = tag;
            item.FormModel = formmodel;
            AddFlowChartItem(item);
        }
        /// <summary>
        /// 画节点
        /// </summary>
        /// <param name="name">节点名称</param>
        /// <param name="rect">节点区域</param>
        /// <param name="tooltip">提示信息</param>
        /// <param name="formmodel">节点连接模块</param>
        public void AddFlowChartItem(string name, Rectangle rect, string tooltip, string formmodel)
        {
            FlowChartItem item = new FlowChartItem();
            item.Name = name;
            item.Rect = rect;
            item.ToolTip = tooltip;
            item.FormModel = formmodel;
            AddFlowChartItem(item);
        }
        /// <summary>
        /// 画节点
        /// </summary>
        /// <param name="name">节点名称</param>
        /// <param name="formmodel">节点连接模块</param>
        public void AddFlowChartItem(string name, string formmodel)
        {
            FlowChartItem item = new FlowChartItem();
            item.Name = name;
            item.FormModel = formmodel;
            AddFlowChartItem(item);
        }
        /// <summary>
        /// 画节点
        /// </summary>
        /// <param name="name">节点名称</param>
        /// <param name="rect">节点区域</param>
        /// <param name="backcolor">背景颜色</param>
        /// <param name="forecolor">字体颜色</param>
        /// <param name="tooltip">提示信息</param>
        /// <param name="tag">节点Tag</param>
        public void AddFlowChartItem(string name, Rectangle rect, Color backcolor, Color forecolor, string tooltip, string tag)
        {
            FlowChartItem item = new FlowChartItem();
            item.Name = name;
            item.Rect = rect;
            item.BackColor = backcolor;
            item.ForeColor = forecolor;
            item.ToolTip = tooltip;
            item.Tag = tag;
            AddFlowChartItem(item);
        }
        /// <summary>
        /// 画节点
        /// </summary>
        /// <param name="name">节点名称</param>
        /// <param name="rect">节点区域</param>
        /// <param name="backcolor">背景颜色</param>
        /// <param name="forecolor">字体颜色</param>
        /// <param name="tooltip">提示信息</param>
        /// <param name="tag">节点Tag</param>
        /// <param name="backimg">背景图片</param>
        /// <param name="bordercolor">边框颜色</param>
        /// <param name="formmodel">连接窗体</param>
        /// <param name="fnt">字体</param>
        public void AddFlowChartItem(string name, Rectangle rect, Color backcolor, Color forecolor, Color bordercolor, string tooltip, string tag, string formmodel, Image backimg, Font fnt)
        {
            FlowChartItem item = new FlowChartItem();
            item.Name = name;
            item.Rect = rect;
            item.BackColor = backcolor;
            item.ForeColor = forecolor;
            item.ToolTip = tooltip;
            item.Tag = tag;
            item.BorderColor = bordercolor;
            item.FormModel = formmodel;
            item.BackImage = backimg;
            item.TextFont = fnt;
            AddFlowChartItem(item);
        }




        /// <summary>
        /// 画线
        /// </summary>
        /// <param name="line">FlowChartLine对象</param>
        public void AddFlowChartLine(FlowChartLine line)
        {
            _FlowChartLine.Add(line);
            DrawItems();
        }


        /// <summary>
        /// 画线
        /// </summary>
        /// <param name="name">连接线对象名称</param>
        public void AddFlowChartLine(string name)
        {
            FlowChartLine line = new FlowChartLine();
            line.LineName = name;
            AddFlowChartLine(line);
        }
        /// <summary>
        /// 画线
        /// </summary>
        /// <param name="name">连接线对象名称</param>
        /// <param name="p1">连接线起点</param>
        /// <param name="p2">连接线终点</param>
        public void AddFlowChartLine(string name, Point p1, Point p2)
        {
            FlowChartLine line = new FlowChartLine();
            line.LineName = name;
            line.LineHead = p1;
            line.LineFoot = p2;
            AddFlowChartLine(line);
        }
        /// <summary>
        /// 画线
        /// </summary>
        /// <param name="p1">连接线起点</param>
        /// <param name="p2">连接线终点</param>
        public void AddFlowChartLine(Point p1, Point p2)
        {
            FlowChartLine line = new FlowChartLine();
            line.LineName = "Line" + (_FlowChartLine.Count + 1).ToString();
            line.LineHead = p1;
            line.LineFoot = p2;
            AddFlowChartLine(line);
        }
        /// <summary>
        /// 画线
        /// </summary>
        /// <param name="p1">连接线起点</param>
        /// <param name="p2">连接线终点</param>
        /// <param name="linecolor">线颜色</param>
        /// <param name="linewidth">线粗细</param>
        public void AddFlowChartLine(Point p1, Point p2, Color linecolor, int linewidth)
        {
            FlowChartLine line = new FlowChartLine();
            line.LineName = "Line" + (_FlowChartLine.Count + 1).ToString();
            line.LineHead = p1;
            line.LineFoot = p2;
            line.LineColor = linecolor;
            line.LineWidth = linewidth;
            AddFlowChartLine(line);
        }


        private void DrawItems()
        {
            foreach (var obj in _FlowChartItem)
            {
                if (obj.Rect.X < 0)
                {
                    obj.Rect.X = 0;
                }
                if (obj.Rect.X + obj.Rect.Width > this.ClientSize.Width)
                {
                    obj.Rect.X = this.ClientSize.Width - obj.Rect.Width;
                }
                if (obj.Rect.Y < 0)
                {
                    obj.Rect.Y = 0;
                }
                if (obj.Rect.Y + obj.Rect.Height > this.ClientSize.Height)
                {
                    obj.Rect.Y = this.ClientSize.Height - obj.Rect.Height;
                }
            }


            foreach (var obj in _FlowChartLine)
            {
                obj.LineLength = Math.Sqrt((obj.LineHead.X - obj.LineFoot.X) * (obj.LineHead.X - obj.LineFoot.X) - (obj.LineHead.Y - obj.LineFoot.Y) * (obj.LineHead.Y - obj.LineFoot.Y));
                if (obj.LineHead.X < 0)
                {
                    obj.LineHead.X = 0;
                }
                if (obj.LineHead.X + obj.LineLength > this.ClientSize.Width)
                {
                    obj.LineHead.X = this.ClientSize.Width - (int)obj.LineLength;
                }
                if (obj.LineHead.Y < 0)
                {
                    obj.LineHead.Y = 0;
                }
                if (obj.LineHead.Y + obj.LineWidth > this.ClientSize.Height)
                {
                    obj.LineHead.Y = this.ClientSize.Height - obj.LineWidth;
                }
            }


            this.Invalidate();
        }


        private void BringItemToFront(FlowChartItem item)
        {
            int max = 0;
            foreach (var obj in _FlowChartItem)
            {
                if (obj.Level > max)
                {
                    max = obj.Level;
                }
            }
            item.Level = max + 1;


            if (max > 1000)
            {
                int n = 0;
                List<FlowChartItem> list = _FlowChartItem.OrderBy(obj => obj.Level).ToList();
                foreach (var obj in list)
                {
                    obj.Level = n++;
                }
            }
            DrawItems();
        }


        private void SunriseFlowChart_Paint(object sender, PaintEventArgs e)
        {
            List<FlowChartItem> list = _FlowChartItem.OrderBy(o => o.Level).ToList();
            foreach (var o in list)
            {
                //画节点背景图片
                if (o.BackImage != null)
                {
                    e.Graphics.DrawImage(o.BackImage, o.Rect);
                }
                //画Item形状，如果有背景图片则不需要再重画
                else
                {
                    switch (o.Shape)
                    {
                        case FlowChartItemStyleShape.Ellipse:
                            {
                                e.Graphics.FillEllipse(new SolidBrush(o.BackColor), o.Rect);
                                break;
                            }
                        case FlowChartItemStyleShape.Oblong:
                            {
                                e.Graphics.FillRectangle(new SolidBrush(o.BackColor), o.Rect);
                                break;
                            }
                        case FlowChartItemStyleShape.Diamond:
                            {
                                Point p1 = new Point(o.Rect.X, o.Rect.Y);
                                Point p2 = new Point(o.Rect.X + o.Rect.Width, o.Rect.Y - o.Rect.Height);
                                Point p3 = new Point(o.Rect.X + o.Rect.Width * 2, o.Rect.Y);
                                Point p4 = new Point(o.Rect.X + o.Rect.Width, o.Rect.Y + o.Rect.Height);
                                Point[] p = { o.Rect.Location, p2, p3, p4 };
                                e.Graphics.FillPolygon(new SolidBrush(o.BackColor), p);
                                break;
                            }
                    }
                }
                //Color color = o.ForeColor;
                //if (o.Name.Equals(_CurrentItemName))
                //{
                //    color = _CurrentItemColor;
                //}
                //画Item边框
                switch (o.Shape)
                {
                    case FlowChartItemStyleShape.Ellipse:
                        {
                            e.Graphics.DrawEllipse(new Pen(o.BorderColor), o.Rect);
                            break;
                        }
                    case FlowChartItemStyleShape.Oblong:
                        {
                            e.Graphics.DrawRectangle(new Pen(o.BorderColor), o.Rect);
                            break;
                        }
                    case FlowChartItemStyleShape.Diamond:
                        {
                            Point p1 = new Point(o.Rect.X, o.Rect.Y);
                            Point p2 = new Point(o.Rect.X + o.Rect.Width, o.Rect.Y - o.Rect.Height);
                            Point p3 = new Point(o.Rect.X + o.Rect.Width * 2, o.Rect.Y);
                            Point p4 = new Point(o.Rect.X + o.Rect.Width, o.Rect.Y + o.Rect.Height);
                            Point[] p = { p1, p2, p3, p4 };
                            e.Graphics.DrawPolygon(new Pen(o.BorderColor), p);
                            break;
                        }
                }
                //画文字
                StringFormat sf = new StringFormat(StringFormatFlags.DirectionRightToLeft | StringFormatFlags.LineLimit);
                Brush b = new SolidBrush(o.ForeColor);
                switch (o.Shape)
                {
                    case FlowChartItemStyleShape.Diamond:
                        {
                            e.Graphics.DrawString(o.Name, o.TextFont == null ? DefaultFont : o.TextFont, b, new PointF(o.Rect.X + 5, o.Rect.Y - 5), null);
                            break;
                        }
                    case FlowChartItemStyleShape.Ellipse:
                    case FlowChartItemStyleShape.Oblong:
                        {
                            e.Graphics.DrawString(o.Name, o.TextFont == null ? DefaultFont : o.TextFont, b, new PointF(o.Rect.X + 5, o.Rect.Y + o.Rect.Height / 2), null);
                            break;
                        }
                }
            }
            foreach (var item in _FlowChartLine)
            {
                Pen pen = new Pen(item.LineColor, item.LineWidth);
                AdjustableArrowCap lineCap = new AdjustableArrowCap(item.ArrowCapWidth, item.ArrowCapHeight, true);
                pen.CustomEndCap = lineCap;
                e.Graphics.DrawLine(pen, item.LineHead, item.LineFoot);
            }
        }
        private void SunriseFlowChart_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }


        private void SunriseFlowChart_MouseMove(object sender, MouseEventArgs e)
        {
            IsOnClickEventHander = false;


            if (e.Button == MouseButtons.None)
            {
                FlowChartItem overItem = GetMouseOverItemRect(e.X, e.Y);
                FlowChartLine overLine = GetMouseOverLineRect(e.X, e.Y);

                if (overItem != _OnMouseOverItem && _OnMouseOverItem != null)
                {
                    //if (OnItemMouseLeave != null)
                    //{
                    //    OnItemMouseLeave(_OnMouseOverItem.Name);
                    //}
                    //_OnMouseOverItem = null;

                }
                if (overItem != null && overItem != _OnMouseOverItem)
                {
                    if (ShowTipType != FlowChartShowTipType.NoTip)
                    {
                        if (ShowTipType == FlowChartShowTipType.ShowTip && overItem.ToolTip != "")
                        {
                            tipMsg.Rounded = true;
                            tipMsg.ShowBeak = true;
                            tipMsg.ShowHint(overItem.ToolTip, DevExpress.Utils.ToolTipLocation.TopRight, Cursor.Position);
                            tipMsg.Active = true;
                        }
                        else if (ShowTipType == FlowChartShowTipType.ShowNameIsTipNull)
                        {
                            tipMsg.Rounded = true;
                            tipMsg.ShowBeak = true;
                            tipMsg.ShowHint(overItem.ToolTip == "" ? overItem.Name : overItem.ToolTip, DevExpress.Utils.ToolTipLocation.TopRight, Cursor.Position);
                            tipMsg.Active = true;
                        }

                    }
                    //_OnMouseOverItem = overItem;
                    //if (ShowTip != null)
                    //{
                    //    ShowTip(overItem.Name, overItem.ToolTip, new Point(e.X, e.Y));
                    //}
                }
                else
                {
                    tipMsg.Active = false;
                }


                if (overLine != _OnMouseOverLine && _OnMouseOverLine != null)
                {
                    _OnMouseOverLine = null;
                }
                if (overLine != null && overLine != _OnMouseOverLine)
                {
                    _OnMouseOverLine = overLine;
                }




                _DragSide = "";
                if (overItem != null)
                {
                    Cursor = Cursors.Hand;
                }
                else
                {
                    Cursor = Cursors.Default;
                }


                if (_CurrentItem != null)
                {
                    if (e.X - _CurrentItem.Rect.Left >= 0 && e.X - _CurrentItem.Rect.Left < 4)
                    {
                        _DragSide = "left";
                        Cursor = Cursors.VSplit;
                    }
                    else if (_CurrentItem.Rect.Right - e.X >= 0 && _CurrentItem.Rect.Right - e.X < 4)
                    {
                        _DragSide = "right";
                        Cursor = Cursors.VSplit;
                    }
                    else if (e.Y - _CurrentItem.Rect.Top >= 0 && e.Y - _CurrentItem.Rect.Top < 4)
                    {
                        _DragSide = "top";
                        Cursor = Cursors.HSplit;
                    }
                    else if (_CurrentItem.Rect.Bottom - e.Y >= 0 && _CurrentItem.Rect.Bottom - e.Y < 4)
                    {
                        _DragSide = "bottom";
                        Cursor = Cursors.HSplit;
                    }
                    else
                    {
                        //_DragSide = "";
                        //Cursor = Cursors.Hand;                        
                    }
                }
                else
                {
                    //_DragSide = "";
                    //Cursor = Cursors.Default;
                }
                if (_CurrentLine != null && IsDesignMode)
                {
                    if (e.X - _CurrentLine.LineHead.X >= 0 && e.X - _CurrentLine.LineHead.X < 4)
                    {
                        _DragLine = "head";
                        Cursor = Cursors.SizeWE;
                    }
                    else if (_CurrentLine.LineFoot.X - e.X >= 0 && _CurrentLine.LineFoot.X - e.X < 4)
                    {
                        _DragLine = "foot";
                        Cursor = Cursors.SizeWE;
                    }
                    else if (_CurrentLine.LineHead.Y - e.Y >= 0 && _CurrentLine.LineHead.Y - e.Y < 4)
                    {
                        _DragLine = "head";
                        Cursor = Cursors.SizeWE;
                    }
                    else if (_CurrentLine.LineFoot.Y - e.Y >= 0 && _CurrentLine.LineFoot.Y - e.Y < 4)
                    {
                        _DragLine = "foot";
                        Cursor = Cursors.SizeWE;
                    }
                    else
                    {
                        //_DragLine = "";
                        //Cursor = Cursors.Default;
                    }
                }
                else
                {
                    //_DragLine = "";
                    //Cursor = Cursors.Default;
                }
            }
            else
            {
                if (_OnMouseOverItem != null)
                {
                    //if (OnItemMouseLeave != null)
                    //{
                    //    OnItemMouseLeave(_mouseOverItem.Name);
                    //}
                    _OnMouseOverItem = null;
                }
                if (_OnMouseOverLine != null)
                {
                    _OnMouseOverLine = null;
                }
            }


            if (e.Button == MouseButtons.Left && IsDesignMode)
            {
                if (_CurrentItem != null)
                {
                    if (_DragSide.Equals("left"))
                    {
                        if (e.X + _ItemMinWidth <= _CurrentItem.Rect.Right)
                        {
                            int right = _CurrentItem.Rect.Right;
                            _CurrentItem.Rect.X = e.X;
                            _CurrentItem.Rect.Width = right - e.X;
                            DrawItems();
                        }
                    }
                    if (_DragSide.Equals("right"))
                    {
                        if (e.X - _CurrentItem.Rect.Left >= _ItemMinWidth)
                        {
                            _CurrentItem.Rect.Width = e.X - _CurrentItem.Rect.Left;
                            DrawItems();
                        }
                    }
                    if (_DragSide.Equals("top"))
                    {
                        if (e.Y + _ItemMinHeight <= _CurrentItem.Rect.Bottom)
                        {
                            int bottom = _CurrentItem.Rect.Bottom;
                            _CurrentItem.Rect.Y = e.Y;
                            _CurrentItem.Rect.Height = bottom - e.Y;
                            DrawItems();
                        }
                    }
                    if (_DragSide.Equals("bottom"))
                    {
                        if (e.Y - _CurrentItem.Rect.Top >= _ItemMinHeight)
                        {
                            _CurrentItem.Rect.Height = e.Y - _CurrentItem.Rect.Top;
                            DrawItems();
                        }
                    }


                    if (_DragSide.Equals(""))
                    {
                        _CurrentItem.Rect.X += e.X - _ItemX;
                        _CurrentItem.Rect.Y += e.Y - _ItemY;
                        _ItemX = e.X;
                        _ItemY = e.Y;
                        DrawItems();
                    }
                }
                if (_CurrentLine != null)
                {
                    if (_DragLine.Equals("head"))
                    {
                        _CurrentLine.LineHead.X = e.X;
                        _CurrentLine.LineHead.Y = e.Y;
                        DrawItems();
                    }
                    if (_DragLine.Equals("foot"))
                    {
                        _CurrentLine.LineFoot.X = e.X;
                        _CurrentLine.LineFoot.Y = e.Y;
                        DrawItems();
                    }
                    if (_DragLine.Equals(""))
                    {
                        //_CurrentItem.Rect.X += e.X - _ItemX;
                        //_CurrentItem.Rect.Y += e.Y - _ItemY;
                        //_ItemX = e.X;
                        //_ItemY = e.Y;
                        //DrawItems();
                    }
                }
            }

        }


        private FlowChartItem GetPointItemName(int x, int y)
        {
            for (int i = _FlowChartItem.Count - 1; i >= 0; i--)
            {
                FlowChartItem obj = _FlowChartItem[i];
                if (x >= obj.Rect.Left && x <= obj.Rect.Right && y >= obj.Rect.Top && y <= obj.Rect.Bottom)
                {
                    Cursor = Cursors.Hand;
                    return obj;
                }
            }
            return null;
        }


        private FlowChartItem GetMouseOverItemRect(int x, int y)
        {
            for (int i = _FlowChartItem.Count - 1; i >= 0; i--)
            {
                FlowChartItem obj = _FlowChartItem[i];
                if (x >= obj.Rect.Left + 3 && x <= obj.Rect.Right - 3 && y >= obj.Rect.Top + 3 && y <= obj.Rect.Bottom - 3)
                {
                    Cursor = Cursors.Hand;
                    return obj;
                }
            }
            return null;
        }


        private FlowChartLine GetPointLineName(int x, int y)
        {
            for (int i = _FlowChartLine.Count - 1; i >= 0; i--)
            {
                FlowChartLine obj = _FlowChartLine[i];
                if (CheckPointOnLine(new Point(x, y), obj.LineHead, obj.LineFoot))
                {
                    return obj;
                }
            }
            return null;
        }


        private FlowChartLine GetMouseOverLineRect(int x, int y)
        {
            for (int i = _FlowChartLine.Count - 1; i >= 0; i--)
            {
                FlowChartLine obj = _FlowChartLine[i];
                if (CheckPointOnLine(new Point(x, y), obj.LineHead, obj.LineFoot))
                {
                    return obj;
                }
            }
            return null;
        }


        /// <summary>
        /// 判断当前某点是否在直线上，考虑鼠标问题，正负3都表示在直线上
        /// </summary>
        /// <param name="p1">需要判断的点</param>
        /// <param name="p2">直线起点</param>
        /// <param name="p3">直线终点</param>
        /// <returns></returns>
        private bool CheckPointOnLine(Point p1, Point p2, Point p3)
        {
            //求的直线方程式中A，B，C三个参数  直线方程式 Ax+By+C=0
            //直线两点P1(x1,y1)，P2(x2,y2)  直线方程式中A=y2-y1，B=x1-x2，C=x2*y1-x1*y2
            int a, b, c;
            a = (p3.Y - p2.Y);
            b = (p2.X - p3.X);
            c = p3.X * p2.Y - p2.X * p3.Y;
            //求点到直线的距离公式 点(x0,y0)到直线Ax+By+C=0的距离是：d=|Ax0+By0+C|/根号(A²+B²)
            //先判断点是否在直线上，排除在当前所画直线的延长线上
            //X轴
            if (p2.X < p3.X)
            {
                if (p1.X > p3.X + 3 || p1.X < p2.X - 3)
                {
                    return false;
                }
            }
            else
            {
                if (p1.X > p2.X + 3 || p1.X < p3.X - 3)
                {
                    return false;
                }
            }
            //Y轴
            if (p2.Y < p3.Y)
            {
                if (p1.Y > p3.Y + 3 || p1.Y < p2.Y - 3)
                {
                    return false;
                }
            }
            else
            {
                if (p1.Y > p2.Y + 3 || p1.Y < p3.Y - 3)
                {
                    return false;
                }
            }
            return Math.Abs(a * p1.X + b * p1.Y + c) / Math.Sqrt(a * a + b * b) <= 3;
        }


        private void SunriseFlowChart_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            string oldName = _CurrentItemName;
            _CurrentItem = GetPointItemName(e.X, e.Y);
            _CurrentLine = GetPointLineName(e.X, e.Y);
            if (_CurrentItem != null)
            {
                IsOnClickEventHander = true;
                _CurrentItemName = _CurrentItem.Name;
                BringItemToFront(_CurrentItem);
                _ItemX = e.X;
                _ItemY = e.Y;
            }
            else
            {
                _CurrentItemName = "";
            }


            if (!oldName.Equals(_CurrentItemName))
            {
                DrawItems();
            }
            //}
            if (e.Button == MouseButtons.Right)
            {
                if (_CurrentItem != null && IsDesignMode)
                {
                    cmsMenu.Show(this, e.X, e.Y);
                }
                if (_CurrentLine != null && IsDesignMode)
                {
                    cmsLine.Show(this, e.X, e.Y);
                }
            }
        }


        /// <summary>
        /// 根据名称删除节点
        /// </summary>
        /// <param name="name">节点名称</param>
        public void DeleteItem(string name)
        {
            FlowChartItem di = _FlowChartItem.FirstOrDefault(o => o.Name.Equals(name));
            if (di != null)
            {
                _FlowChartItem.Remove(di);
                if (di.Name.Equals(_CurrentItemName))
                {
                    _CurrentItemName = "";
                    _CurrentItem = null;
                }
            }
            DrawItems();
        }
        /// <summary>
        /// 删除所有节点
        /// </summary>
        public void DeleteItem()
        {
            for (int i = 0; i < _FlowChartItem.Count; i++)
            {
                FlowChartItem di = _FlowChartItem.FirstOrDefault(o => o.Name.Equals(_FlowChartItem[i].Name));
                if (di != null)
                {
                    _FlowChartItem.Remove(di);
                    if (di.Name.Equals(_CurrentItemName))
                    {
                        _CurrentItemName = "";
                        _CurrentItem = null;
                    }
                }
                DrawItems();
            }
            if (_FlowChartItem.Count > 0)
            {
                DeleteItem();
            }
        }
        /// <summary>
        /// 根据名称删除线
        /// </summary>
        /// <param name="name">线名称</param>
        public void DeleteLine(string name)
        {
            FlowChartLine di = _FlowChartLine.FirstOrDefault(o => o.LineName.Equals(name));
            if (di != null)
            {
                _FlowChartLine.Remove(di);
                if (di.LineName.Equals(_CurrentLineName))
                {
                    _CurrentLineName = "";
                    _CurrentLine = null;
                }
            }
            DrawItems();
        }
        /// <summary>
        /// 删除全部线
        /// </summary>
        public void DeleteLine()
        {
            for (int i = 0; i < _FlowChartLine.Count; i++)
            {
                FlowChartLine di = _FlowChartLine.FirstOrDefault(o => o.LineName.Equals(_FlowChartLine[i].LineName));
                if (di != null)
                {
                    _FlowChartLine.Remove(di);
                    if (di.LineName.Equals(_CurrentLineName))
                    {
                        _CurrentLineName = "";
                        _CurrentLine = null;
                    }
                }
                DrawItems();
            }
            if (_FlowChartLine.Count > 0)
            {
                DeleteLine();
            }
        }
        private void tsmSetItem_Click(object sender, EventArgs e)
        {
            if (_CurrentItem != null)
            {
                frmFlowChartItemSet frm = new frmFlowChartItemSet(_CurrentItem.Name,
                    _CurrentItem.Shape, _CurrentItem.FormModel, _CurrentItem.ForeColor, _CurrentItem.BackColor,
                    _CurrentItem.Rect.Width, _CurrentItem.Rect.Height, _CurrentItem.BorderColor, _CurrentItem.TextFont, _CurrentItem.ToolTip, _CurrentItem.BackImage);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _CurrentItem.Name = frm.ItemName;
                    _CurrentItem.Shape = frm.ItemShape;
                    _CurrentItem.FormModel = frm.ItemFormModel;
                    _CurrentItem.ForeColor = frm.ItemForeColor;
                    _CurrentItem.BackColor = frm.ItemBackColor;
                    _CurrentItem.Rect.Width = frm.ItemWidth;
                    _CurrentItem.Rect.Height = frm.ItemHeight;
                    _CurrentItem.BorderColor = frm.ItemBorderColor;
                    _CurrentItem.TextFont = frm.ItemFont;
                    _CurrentItem.ToolTip = frm.ItemToolTip;
                    _CurrentItem.BackImage = frm.ItemBackImage;
                    DrawItems();
                }
            }
        }


        private void tsmDeleteItem_Click(object sender, EventArgs e)
        {
            if (_CurrentItem != null)
            {
                DeleteItem(_CurrentItem.Name);
            }
        }
        private void tsmDeleteLine_Click(object sender, EventArgs e)
        {
            if (_CurrentLine != null)
            {
                DeleteLine(_CurrentLine.LineName);
            }
        }
        private void SunriseFlowChart_Click(object sender, EventArgs e)
        {
            if (OnItemClick != null && _CurrentItem != null && IsOnClickEventHander && ((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                if (IsDesignMode)
                {
                    if (IsInDesignModeCanOpenForm)
                    {
                        if (!String.IsNullOrEmpty(_CurrentItem.FormModel))
                        {
                            OnItemClick(_CurrentItem.Name, _CurrentItem.FormModel);
                        }
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(_CurrentItem.FormModel))
                    {
                        OnItemClick(_CurrentItem.Name, _CurrentItem.FormModel);
                    }
                }
            }
        }
        private void tsbLineSet_Click(object sender, EventArgs e)
        {
            if (_CurrentLine != null)
            {
                frmFlowChartItemSet frm = new frmFlowChartItemSet(_CurrentLine.LineColor, _CurrentLine.LineWidth, _CurrentLine.ArrowCapWidth, _CurrentLine.ArrowCapHeight);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _CurrentLine.LineColor = frm.LineColor;
                    _CurrentLine.LineWidth = frm.LineWidth;
                    _CurrentLine.ArrowCapWidth = frm.LineCapWidth;
                    _CurrentLine.ArrowCapHeight = frm.LineCapHeight;
                    DrawItems();
                }
            }
        }
        #endregion               

    }
}
