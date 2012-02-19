using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using Sunrise.ERP.Lang;

namespace Sunrise.ERP.BaseControl
{
    /// <summary>
    /// 窗体公共操作类
    /// </summary>
    public class Public
    {
        public Public()
        { }

        #region 系统提示操作
        /// <summary>
        /// 系统提示信息
        /// </summary>
        /// <param name="msg">信息内容</param>
        /// <returns>DialogResult</returns>
        public static DialogResult SystemInfo(string msg)
        {
            XtraMessageBox.AllowCustomLookAndFeel = false;
            DevExpress.LookAndFeel.UserLookAndFeel ul = new DevExpress.LookAndFeel.UserLookAndFeel(null);
            ul.SkinName = "Blue";
            ul.UseDefaultLookAndFeel = false;
            return XtraMessageBox.Show(ul, msg, LangCenter.Instance.GetSystemMessage("SystemInfo"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// 系统提示信息
        /// </summary>
        /// <param name="msg">信息内容</param>
        /// <param name="button">按钮模式,0-OK,1-OKCancel,2-AbortRetryIgnore,3-YesNoCancel,4-YesNo,5-RetryCancel</param>
        /// <returns>DialogResult</returns>
        public static DialogResult SystemInfo(string msg, MessageBoxButtons button)
        {
            if (button == 0)
            {
                DevExpress.LookAndFeel.UserLookAndFeel ul = new DevExpress.LookAndFeel.UserLookAndFeel(null);
                ul.SkinName = "Blue";
                ul.UseDefaultLookAndFeel = false;
                return XtraMessageBox.Show(ul, msg, LangCenter.Instance.GetSystemMessage("SystemInfo"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (button == MessageBoxButtons.OKCancel)
            {
                DevExpress.LookAndFeel.UserLookAndFeel ul = new DevExpress.LookAndFeel.UserLookAndFeel(null);
                ul.SkinName = "Blue";
                ul.UseDefaultLookAndFeel = false;
                return XtraMessageBox.Show(ul, msg, LangCenter.Instance.GetSystemMessage("SystemInfo"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            else if (button == MessageBoxButtons.AbortRetryIgnore)
            {
                DevExpress.LookAndFeel.UserLookAndFeel ul = new DevExpress.LookAndFeel.UserLookAndFeel(null);
                ul.SkinName = "Blue";
                ul.UseDefaultLookAndFeel = false;
                return XtraMessageBox.Show(ul, msg, LangCenter.Instance.GetSystemMessage("SystemInfo"), MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Question);
            }
            else if (button == MessageBoxButtons.YesNoCancel)
            {
                DevExpress.LookAndFeel.UserLookAndFeel ul = new DevExpress.LookAndFeel.UserLookAndFeel(null);
                ul.SkinName = "Blue";
                ul.UseDefaultLookAndFeel = false;
                return XtraMessageBox.Show(ul, msg, LangCenter.Instance.GetSystemMessage("SystemInfo"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            }
            else if (button == MessageBoxButtons.YesNo)
            {
                DevExpress.LookAndFeel.UserLookAndFeel ul = new DevExpress.LookAndFeel.UserLookAndFeel(null);
                ul.SkinName = "Blue";
                ul.UseDefaultLookAndFeel = false;
                return XtraMessageBox.Show(ul, msg, LangCenter.Instance.GetSystemMessage("SystemInfo"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else if (button == MessageBoxButtons.RetryCancel)
            {
                DevExpress.LookAndFeel.UserLookAndFeel ul = new DevExpress.LookAndFeel.UserLookAndFeel(null);
                ul.SkinName = "Blue";
                ul.UseDefaultLookAndFeel = false;
                return XtraMessageBox.Show(ul, msg, LangCenter.Instance.GetSystemMessage("SystemInfo"), MessageBoxButtons.RetryCancel, MessageBoxIcon.Question);
            }
            else
            {
                DevExpress.LookAndFeel.UserLookAndFeel ul = new DevExpress.LookAndFeel.UserLookAndFeel(null);
                ul.SkinName = "Blue";
                ul.UseDefaultLookAndFeel = false;
                return XtraMessageBox.Show(ul, msg, LangCenter.Instance.GetSystemMessage("SystemInfo"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// 系统提示信息
        /// </summary>
        /// <param name="msg">信息内容</param>
        /// <param name="iswrong">是否为错误类型</param>
        /// <returns>DialogResult</returns>
        public static DialogResult SystemInfo(string msg, bool iswrong)
        {
            if (iswrong)
            {
                DevExpress.LookAndFeel.UserLookAndFeel ul = new DevExpress.LookAndFeel.UserLookAndFeel(null);
                ul.SkinName = "Blue";
                ul.UseDefaultLookAndFeel = false;
                return XtraMessageBox.Show(ul, msg, LangCenter.Instance.GetSystemMessage("SystemInfo"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DevExpress.LookAndFeel.UserLookAndFeel ul = new DevExpress.LookAndFeel.UserLookAndFeel(null);
                ul.SkinName = "Blue";
                ul.UseDefaultLookAndFeel = false;
                return XtraMessageBox.Show(ul, msg, LangCenter.Instance.GetSystemMessage("SystemInfo"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// 系统提示信息
        /// </summary>
        /// <param name="msg">信息内容</param>
        /// <param name="caption">提示标题</param>
        /// <param name="button">按钮模式</param>
        /// <returns>DialogResult</returns>
        public static DialogResult SystemInfo(string msg, string caption, MessageBoxButtons button)
        {
            if (button == 0)
            {
                DevExpress.LookAndFeel.UserLookAndFeel ul = new DevExpress.LookAndFeel.UserLookAndFeel(null);
                ul.SkinName = "Blue";
                ul.UseDefaultLookAndFeel = false;
                return XtraMessageBox.Show(ul,msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (button == MessageBoxButtons.OKCancel)
            {
                DevExpress.LookAndFeel.UserLookAndFeel ul = new DevExpress.LookAndFeel.UserLookAndFeel(null);
                ul.SkinName = "Blue";
                ul.UseDefaultLookAndFeel = false;
                return XtraMessageBox.Show(ul,msg, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            else if (button == MessageBoxButtons.AbortRetryIgnore)
            {
                DevExpress.LookAndFeel.UserLookAndFeel ul = new DevExpress.LookAndFeel.UserLookAndFeel(null);
                ul.SkinName = "Blue";
                ul.UseDefaultLookAndFeel = false;
                return XtraMessageBox.Show(ul,msg, caption, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Question);
            }
            else if (button == MessageBoxButtons.YesNoCancel)
            {
                DevExpress.LookAndFeel.UserLookAndFeel ul = new DevExpress.LookAndFeel.UserLookAndFeel(null);
                ul.SkinName = "Blue";
                ul.UseDefaultLookAndFeel = false;
                return XtraMessageBox.Show(ul,msg, caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            }
            else if (button == MessageBoxButtons.YesNo)
            {
                DevExpress.LookAndFeel.UserLookAndFeel ul = new DevExpress.LookAndFeel.UserLookAndFeel(null);
                ul.SkinName = "Blue";
                ul.UseDefaultLookAndFeel = false;
                return XtraMessageBox.Show(ul,msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else if (button == MessageBoxButtons.RetryCancel)
            {
                DevExpress.LookAndFeel.UserLookAndFeel ul = new DevExpress.LookAndFeel.UserLookAndFeel(null);
                ul.SkinName = "Blue";
                ul.UseDefaultLookAndFeel = false;
                return XtraMessageBox.Show(ul,msg, caption, MessageBoxButtons.RetryCancel, MessageBoxIcon.Question);
            }
            else
            {
                DevExpress.LookAndFeel.UserLookAndFeel ul = new DevExpress.LookAndFeel.UserLookAndFeel(null);
                ul.SkinName = "Blue";
                ul.UseDefaultLookAndFeel = false;
                return XtraMessageBox.Show(ul,msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region 系统基础操作方法

        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="str">字符串数组</param>
        /// <param name="count">第几个字符串</param>
        /// <returns>String</returns>
        public static string GetSubString(string[] str, int count)
        {
            return str[count];
        }

        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="split">分割字符串</param>
        /// <param name="count">第几个字符串</param>
        /// <returns>String</returns>
        public static string GetSubString(string str, string split, int count)
        {
            return GetSubString(str.Split(new string[] { split }, StringSplitOptions.RemoveEmptyEntries), count);
        }

        /// <summary>
        /// 截取字符串中最后一个
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="split">分割字符串</param>
        /// <returns></returns>
        public static string GetLastSubString(string str, string split)
        {
            string[] s = str.Split(new string[] { split }, StringSplitOptions.RemoveEmptyEntries);
            return GetSubString(s, s.Length - 1);
        }

        /// <summary>
        /// 截取字符串中第一个
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="split">分割字符串</param>
        /// <returns></returns>
        public static string GetFirstSubString(string str, string split)
        {
            string[] s = str.Split(new string[] { split }, StringSplitOptions.RemoveEmptyEntries);
            return GetSubString(s, 0);
        }

        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="split">分隔符</param>
        /// <returns></returns>
        public static string[] GetSplitString(string str, string split)
        {
            return str.Replace("\r\n","").Split(new string[] { split }, StringSplitOptions.RemoveEmptyEntries);
        }
        #endregion


    }
}
