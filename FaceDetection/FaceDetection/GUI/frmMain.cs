using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FaceDetection.GUI;
using FaceDetection.Config;
namespace FaceDetection.GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void toolStripContainer1_BottomToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void tsAddStudent_Click(object sender, EventArgs e)
        {
            frmStudent frm = new frmStudent();
            frm.ShowDialog();
        }

        public void showTreeView()
        {
            ConnectDB connect = new ConnectDB();
            String sql = "select * from ClassType";
            DataTable table = connect.getTable(sql);
            DataTable nodeSub = new DataTable();
            tvClassList.Nodes.Add(table.Rows[0]["ClassTypeName"].ToString());
            sql = "SELECT * FROM Class WHERE classTypeCode =N'" + table.Rows[0][0] + "'";
            nodeSub = connect.getTable(sql);
            for (int j = 0; j < nodeSub.Rows.Count; j++)
            {
                tvClassList.Nodes[0].Nodes.Add(nodeSub.Rows[j]["ClassName"].ToString());
                tvClassList.Nodes[0].Nodes[j].Tag = "1";
            }

            tvClassList.Nodes.Add(table.Rows[1]["ClassTypeName"].ToString());
            sql = "SELECT * FROM PartClass WHERE classTypeCode =N'" + table.Rows[1][0] + "'";
            nodeSub = connect.getTable(sql);
            for (int j = 0; j < nodeSub.Rows.Count; j++)
            {
                tvClassList.Nodes[1].Nodes.Add(nodeSub.Rows[j]["ClassName"].ToString());
                tvClassList.Nodes[1].Nodes[j].Tag = "2";
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            showTreeView();
        }
    }
}
