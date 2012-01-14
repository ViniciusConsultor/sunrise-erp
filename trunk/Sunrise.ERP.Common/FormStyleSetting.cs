using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

using DevExpress.XtraLayout;
using Sunrise.ERP.DataAccess;

namespace Sunrise.ERP.Common
{
    /// <summary>
    /// 窗体样式控制类
    /// </summary>
    public class FormStyleSetting
    {
        public FormStyleSetting()
        {

        }

        /// <summary>
        /// 加载窗体样式
        /// 请在窗体Load事件中调用此方法
        /// </summary>
        /// <param name="formid">窗体ID</param>
        /// <param name="ctls">要保存样式的控件List，目前只支持LayoutControl和GridControl</param>
        public static void LoadFormStyle(int formid, List<Control> ctls)
        {
            try
            {
                for (int i = 0; i < ctls.Count; i++)
                {
                    //Layout样式保存在服务器
                    if (ctls[i] is DevExpress.XtraLayout.LayoutControl)
                    {
                        //DataSet ds = DbHelperSQL.Query("SELECT TOP 1 StyleFile FROM sysFormStyleSetting WHERE FormID=" + formid.ToString() + " AND ControlName='" + ctls[i].Name + "'");
                        //if (ds.Tables[0].Rows.Count > 0)
                        //{
                        //    byte[] bt = (byte[])ds.Tables[0].Rows[0]["StyleFile"];
                        //    ((DevExpress.XtraLayout.LayoutControl)ctls[i]).RestoreLayoutFromStream(new MemoryStream(bt));

                        //}
                        //string FilePath = Application.StartupPath + @"\Style\" + ctls[i].Name + formid.ToString() + ".xml";
                        //if (File.Exists(FilePath))
                        //{
                        //    ((DevExpress.XtraLayout.LayoutControl)ctls[i]).RestoreLayoutFromXml(FilePath);
                        //}

                    }
                    //Grid样式保存在本地
                    else if (ctls[i] is DevExpress.XtraGrid.GridControl)
                    {
                        string FilePath = Application.StartupPath + @"\Style\" + ctls[i].Name + formid.ToString() + ".xml";
                        if (File.Exists(FilePath))
                        {
                            ((DevExpress.XtraGrid.GridControl)ctls[i]).Views[0].RestoreLayoutFromXml(FilePath);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 保存窗体样式
        /// 请在窗体FormClosed事件中调用此方法
        /// </summary>
        /// <param name="formid">窗体ID</param>
        /// <param name="ctls">要保存样式的控件List，目前只支持LayoutControl和GridControl</param>
        public static void SaveFormStyle(int formid, List<Control> ctls)
        {
            try
            {
                for (int i = 0; i < ctls.Count; i++)
                {
                    if (ctls[i] is DevExpress.XtraLayout.LayoutControl)
                    {
                        //MemoryStream ms = new MemoryStream();
                        //((DevExpress.XtraLayout.LayoutControl)ctls[i]).SaveLayoutToStream(ms);
                        //byte[] file = ms.ToArray();
                        //string sDel = "DELETE FROM sysFormStyleSetting WHERE FormID=" + formid.ToString() + " AND ControlName='" + ctls[i].Name + "'";
                        //string sSql = "INSERT INTO sysFormStyleSetting(FormID,ControlName,StyleFile) VALUES(@FormID,@ControlName,@StyleFile)";
                        //SqlParameter[] para ={
                        //                new SqlParameter("@FormID",SqlDbType.Int,4),
                        //                new SqlParameter("@ControlName",SqlDbType.VarChar,50),
                        //                new SqlParameter("@StyleFile",SqlDbType.Image)};
                        //para[0].Value = formid;
                        //para[1].Value = ctls[i].Name;
                        //para[2].Value = file;
                        ////先删除原来的再保存
                        //DbHelperSQL.ExecuteSql(sDel);
                        //DbHelperSQL.ExecuteSql(sSql, para);
                        //string FilePath = Application.StartupPath + @"\Style\" + ctls[i].Name + formid.ToString() + ".xml";
                        //((DevExpress.XtraLayout.LayoutControl)ctls[i]).SaveLayoutToXml(FilePath);

                    }
                    else if (ctls[i] is DevExpress.XtraGrid.GridControl)
                    {
                        string FilePath = Application.StartupPath + @"\Style\" + ctls[i].Name + formid.ToString() + ".xml";
                        ((DevExpress.XtraGrid.GridControl)ctls[i]).Views[0].SaveLayoutToXml(FilePath);
                    }
                }

            }
            catch
            {                
            }
        }
    }
}

