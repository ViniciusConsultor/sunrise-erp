using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sunrise.ERP.BasePublic;
using Sunrise.ERP.Security;

namespace Sunrise.ERP.Module.Test
{
    public partial class frmBasPRDT : Sunrise.ERP.BaseForm.frmDynamicMasterDetail
    {
        #region<<构造函数>>

        public frmBasPRDT(int formid, string formtext)
            : base(formid, "PRDT")
        {
            InitializeComponent();
            this.Text = formtext;
            CreateDynamicControl();
            CreateMasterGridColumn(gvMain);
        }

        #endregion

        #region<<重载方法>>

        public override void DataStateChange(object sender, EventArgs e)
        {
            base.DataStateChange(sender, e);
            if (FormDataFlag == DataFlag.dsEdit || FormDataFlag == DataFlag.dsInsert)
            {
                gvCust.OptionsBehavior.Editable = true;
                pnlDetailMenu.Enabled = true;
            }
            else
            {
                gvCust.OptionsBehavior.Editable = false;
                pnlDetailMenu.Enabled = false;
            }
        }

        #endregion

        #region<<自定义方法>>

        private DataTable LoadTree()
        {
            string sql = "select INDX_NO,INDX_UP,NAME from INDX";
            DataSet dataset = DataAccess.DbHelperSQL.Query(sql);
            DataTable db = dataset.Tables[0];
            if (dataset != null)
                return db;
            else return null;
        }

        #endregion

        #region<<窗体事件>>

        private void frmBasPRDT_Load(object sender, EventArgs e)
        {
            //LoadTree();
            //DataTable db = LoadTree();
            //if (db != null) this.treeList.DataSource = db;
            ShowLeft();
            AddDetailData("PRDT_CUS", "MID", "ID");
            CreateDetailGridColumn(gvCust, "PRDT_CUS");
            gcCust.DataSource = LDetailBindingSource[LDetailTableName.IndexOf("PRDT_CUS")];
            DataStateChange(sender, e);
        }

        private void gvCust_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvCust.GetFocusedDataRow()["sUserID"] = SecurityCenter.CurrentUserID;
        }

        private void treeList_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            //string inxno = string.Empty;
            //DataRowView rowview = this.treeList.GetDataRecordByNode(e.Node) as DataRowView;
            //DataRow row = rowview.Row;
            //inxno = row["INDX_NO"].ToString();
            //if (!string.IsNullOrEmpty(inxno))
            //{
            //    string sql = string.Format("select b.* from INDX a left join PRDT b on a.INDX_NO=b.IDX1 where a.INDX_NO={0} and b.IDX1 is not null and a.INDX_NO is not null", inxno);
            //    DataSet data = DataAccess.DbHelperSQL.Query(sql);
            //    DataTable db = data.Tables[0];
            //    //if (db != null)
            //    //    this.dsMain.DataSource = db;//我在这里用树的 treeList_FocusedNodeChanged的时候 给dsMain.DataSource的赋值了
            //}


            /* wzt 2012-02-21 说明
             * 这里如果需要根据选择的树的节点进行过滤，就只需要将需要过滤的条件生成
             * 例如选择的树的节点（INDX_NO）的值是1，那么就拼接的过滤SQL就是INDX_NO=1，就只需要把这个条件传给BaseForm中的一个属性MasterFilterSQL
             * 注意SQL语句的拼接（可以参照基窗里面创建查询过滤条件的方法的写法）
             * 过滤SQL就写成 MasterFilterSQL = " AND INDX_NO=1";
             * 然后再调用基窗的查询方法 DoView();即可
             */
        }

        private void gcMain_DoubleClick(object sender, EventArgs e)
        {
            if (gvMain.GetFocusedDataRow() != null)
                ShowRight();
        }

        #endregion

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gvCust.AddNewRow();
        }

        private void btnDetailDelete_Click(object sender, EventArgs e)
        {
            if (gvCust.FocusedRowHandle >= 0)
                gvCust.DeleteRow(gvCust.FocusedRowHandle);
        }
    }
}
