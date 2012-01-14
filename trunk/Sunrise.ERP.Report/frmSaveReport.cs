using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

using Sunrise.ERP.DataAccess;
namespace Sunrise.ERP.Report
{
    public partial class frmSaveReport : Sunrise.ERP.BaseForm.frmForm
    {
        private string rpguid;
        private string DataFlag;
        private FastReport.Report report;
        private DataTable dtReport;
        private int CurrentReportID;
        public frmSaveReport()
        {
            InitializeComponent();
        }
        public frmSaveReport(FastReport.Report rp, string rpGUID,int reportid)
        {
            InitializeComponent();
            report = rp;
            rpguid = rpGUID;
            CurrentReportID = reportid;
            GetReportData();
        }

        private void GetReportData()
        {
            dtReport = DbHelperSQL.Query("SELECT * FROM sysReport WHERE sReportGUID='" + rpguid + "' ORDER BY sReportName").Tables[0];
            dtReport.ColumnChanged += new DataColumnChangeEventHandler(dtReport_ColumnChanged);
            dsReport.DataSource = dtReport;
        }

        void dtReport_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            e.Row.EndEdit();
        }

        /// <summary>
        /// 设置控制按钮初始状态
        /// </summary>
        /// <param name="Sunrise.ERP.BasePublic.OperateFlag">操作状态</param>       
        private void initButtonsState(string OperateFlag)
        {
            switch (OperateFlag)
            {
                case "View":
                    {
                        btnAdd.Enabled = true;
                        btnEdit.Enabled = true;
                        btnCancel.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = true;
                        btnClose.Enabled = true;
                        btnSetDefault.Enabled = true;
                        txtReportName.Properties.ReadOnly = true;
                        txtRemark.Properties.ReadOnly = true;
                        DataFlag = "View";
                        break;
                    }
                case "Add":
                    {
                        btnAdd.Enabled = false;
                        btnEdit.Enabled = false;
                        btnCancel.Enabled = true;
                        btnSave.Enabled = true;
                        btnDelete.Enabled = false;
                        btnClose.Enabled = true;
                        btnSetDefault.Enabled = false;
                        txtReportName.Properties.ReadOnly = false;
                        txtRemark.Properties.ReadOnly = false;
                        gcReport.Enabled = false;
                        DataFlag = "Add";
                        break;
                    }
                case "Edit":
                    {
                        btnAdd.Enabled = false;
                        btnEdit.Enabled = false;
                        btnCancel.Enabled = true;
                        btnSave.Enabled = true;
                        btnDelete.Enabled = false;
                        btnClose.Enabled = true;
                        btnSetDefault.Enabled = false;
                        txtReportName.Properties.ReadOnly = false;
                        txtRemark.Properties.ReadOnly = false;
                        gcReport.Enabled = false;
                        DataFlag = "Edit";
                        break;
                    }
                case "Cancel":
                    {
                        btnAdd.Enabled = true;
                        btnEdit.Enabled = true;
                        btnCancel.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = true;
                        btnClose.Enabled = true;
                        btnSetDefault.Enabled = true;
                        txtReportName.Properties.ReadOnly = true;
                        txtRemark.Properties.ReadOnly = true;
                        gcReport.Enabled = true;
                        DataFlag = "View";
                        break;
                    }
                case "Save":
                    {
                        btnAdd.Enabled = true;
                        btnEdit.Enabled = true;
                        btnCancel.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = true;
                        btnClose.Enabled = true;
                        btnSetDefault.Enabled = true;
                        txtReportName.Properties.ReadOnly = true;
                        txtRemark.Properties.ReadOnly = true;
                        gcReport.Enabled = true;
                        DataFlag = "View";
                        break;
                    }
                case "Delete":
                    {
                        btnAdd.Enabled = true;
                        btnEdit.Enabled = true;
                        btnCancel.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = true;
                        btnClose.Enabled = true;
                        btnSetDefault.Enabled = true;
                        txtReportName.Properties.ReadOnly = true;
                        txtRemark.Properties.ReadOnly = true;
                        DataFlag = "View";
                        break;
                    }
                default:
                    {
                        btnAdd.Enabled = true;
                        btnEdit.Enabled = true;
                        btnCancel.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = true;
                        btnClose.Enabled = true;
                        btnSetDefault.Enabled = true;
                        txtReportName.Properties.ReadOnly = true;
                        txtRemark.Properties.ReadOnly = true;
                        DataFlag = "View";
                        break;
                    }
            }
        }

        private void frmSaveReport_Load(object sender, EventArgs e)
        {
            txtReportName.DataBindings.Add("EditValue", dsReport, "sReportName");
            txtRemark.DataBindings.Add("EditValue", dsReport, "sRemark");
            gcReport.DataSource = dsReport;
            initButtonsState("View");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            initButtonsState("Add");
            dsReport.AddNew();
            dsReport.EndEdit();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dsReport.Current != null)
            {
                initButtonsState("Edit");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dsReport.Current != null)
            {
                if (Sunrise.ERP.BaseControl.Public.SystemInfo("是否删除该报表？", 4) == DialogResult.Yes)
                {
                    SqlTransaction trans = Sunrise.ERP.BaseControl.ConnectSetting.SysSqlConnection.BeginTransaction();
                    try
                    {
                        DbHelperSQL.ExecuteSql("DELETE FROM SysReport WHERE ID=" + ((DataRowView)dsReport.Current)["ID"].ToString(), trans);
                        trans.Commit();
                        dsReport.RemoveCurrent();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        Sunrise.ERP.BaseControl.Public.SystemInfo("删除失败！" + ex.Message, true);
                    }
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            initButtonsState("Cancel");
            GetReportData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MemoryStream stream = new MemoryStream();
            report.Save(stream);
            byte[] bt = stream.ToArray();
            SqlTransaction trans = Sunrise.ERP.BaseControl.ConnectSetting.SysSqlConnection.BeginTransaction();
            try
            {
                if (DataFlag == "Add")
                {
                    string InsertSql = "INSERT INTO sysReport(sReportGUID,sReportName,mReport,bIsDefault,sRemark) VALUES(@sReportGUID,@sReportName,@mReport,@bIsDefault,@sRemark)";
                    SqlParameter[] parameters = {
                                                    new SqlParameter("@sReportGUID", SqlDbType.VarChar ,50),
                                                    new SqlParameter("@sReportName", SqlDbType.VarChar,50),
                                                    new SqlParameter("@mReport", SqlDbType.Image),
                                                    new SqlParameter("@bIsDefault", SqlDbType.Bit),
                                                    new SqlParameter("@sRemark", SqlDbType.VarChar,500)
                                                };
                    parameters[0].Value = rpguid;
                    parameters[1].Value = txtReportName.Text;
                    parameters[2].Value = bt;
                    parameters[3].Value = 0;
                    parameters[4].Value = txtRemark.Text;
                    DbHelperSQL.ExecuteSql(InsertSql, trans, parameters);
                    trans.Commit();
                    initButtonsState("Save");
                    GetReportData();
                    Sunrise.ERP.BaseControl.Public.SystemInfo("保存成功");


                }
                else if (DataFlag == "Edit")
                {
                    if (((DataRowView)dsReport.Current)["ID"].ToString() == "")
                    {
                        return;
                    }
                    else
                    {
                        string UpdateSql = "UPDATE sysReport SET sReportName=@sReportName,mReport=@mReport,sRemark=@sRemark WHERE ID=" + ((DataRowView)dsReport.Current)["ID"].ToString();
                        SqlParameter[] parameters = {
                                                    new SqlParameter("@sReportName", SqlDbType.VarChar,50),
                                                    new SqlParameter("@mReport", SqlDbType.Image),
                                                    new SqlParameter("@sRemark", SqlDbType.VarChar,500)
                                                };
                        parameters[0].Value = txtReportName.Text;
                        parameters[1].Value = bt;
                        parameters[2].Value = txtRemark.Text;
                        DbHelperSQL.ExecuteSql(UpdateSql, trans, parameters);
                        trans.Commit();
                        initButtonsState("Save");
                        GetReportData();
                        Sunrise.ERP.BaseControl.Public.SystemInfo("保存成功");
                    }
                }
            }
            catch (Exception ex)
            {
                trans.Rollback();
                Sunrise.ERP.BaseControl.Public.SystemInfo("保存失败！" + ex.Message, true);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSetDefault_Click(object sender, EventArgs e)
        {
            if (dsReport.Current != null)
            {
                if (Sunrise.ERP.BaseControl.Public.SystemInfo("是否设置为默认报表？", 4) == DialogResult.Yes)
                {
                    SqlTransaction trans = Sunrise.ERP.BaseControl.ConnectSetting.SysSqlConnection.BeginTransaction();
                    try
                    {
                        DbHelperSQL.ExecuteSql("UPDATE sysReport SET bIsDefault=0 WHERE sReportGUID='" + rpguid + "'", trans);
                        DbHelperSQL.ExecuteSql("UPDATE sysReport SET bIsDefault=1 WHERE ID=" + ((DataRowView)dsReport.Current)["ID"].ToString(), trans);
                        trans.Commit();
                        GetReportData();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        Sunrise.ERP.BaseControl.Public.SystemInfo("设置错误," + ex.Message, true);
                    }
                }
            }
        }

        private void gvReport_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (gvReport.RowCount > 0 && e.RowHandle>=0)
            {
                if (gvReport.GetDataRow(e.RowHandle)["ID"].ToString() == CurrentReportID.ToString())
                {
                    e.Appearance.BackColor = Color.Red;
                }
            }
        }

    }
}
