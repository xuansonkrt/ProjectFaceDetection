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
using FaceDetection.Entity;
using FaceDetection.Controller;
using System.Data.SqlClient;

namespace FaceDetection.GUI
{
    public partial class frmMain : Form
    {
        ConnectDB cn = new ConnectDB();
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
            StudentContrller studentController = new StudentContrller();
            TreeNode theNode = this.tvClassList.SelectedNode;
            if (theNode.Tag == "1")
            {
                frmStudent frm = new frmStudent();
                frm.ShowDialog();
                if(frm.DialogResult==DialogResult.OK)
                {
                    Student student = frm.getStudent();
                    studentController.Insert(student);
                }
            }
            
        }

        public void showTreeView()
        {
            tvClassList.Nodes.Clear();
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
            sql = "SELECT * FROM Class WHERE classTypeCode =N'" + table.Rows[1][0] + "'";
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

        private void tsAddClass_Click(object sender, EventArgs e)
        {
            frmClass frm = new frmClass();
            ClassController classController= new ClassController();
            Class addClass= new Class();
            lap:
            frm.SetInPut(addClass);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                addClass = frm.getClass();
                if(classController.Insert(addClass)==1)
                {

                }
                else
                {
                    MessageBox.Show("Lớp đã tồn tại.");
                    goto lap;
                }
                showTreeView();
            }
            
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void tsUpdateClass_Click(object sender, EventArgs e)
        {
            SqlConnection connect = cn.getConnect();
            connect.Open();
            TreeNode theNode = tvClassList.SelectedNode;
            string sql;
            sql = "select classCode, className from Class where className=N'" + theNode.Text.ToString() + "'";

            SqlDataAdapter da = new SqlDataAdapter(sql, connect);
            DataTable tb = new DataTable();
            da.Fill(tb);
            frmClass frm = new frmClass();
            String classTypeCode;
            if (theNode.Tag == "1")
                classTypeCode = "lcn";
            else
                classTypeCode = "ltc";

            Class updateClass = new Class(tb.Rows[0]["classCode"].ToString(), tb.Rows[0]["className"].ToString(), classTypeCode);
            frm.cbClassType.DropDownStyle = ComboBoxStyle.DropDownList;
          lap2:
            frm.SetInPut(updateClass);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                ClassController classController = new ClassController();
                Class update = frm.getClass();
                if (classController.Update(update, updateClass.ClassCode) == 1)
                {

                }
                else
                {
                    MessageBox.Show("Lớp đã tồn tại.");
                    goto lap2;
                }
                showTreeView();
            }
        }

        private void tsDeleteClass_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                TreeNode theNode = tvClassList.SelectedNode;
                string sql;
                sql = "select classCode, className from Class where className=N'" + theNode.Text.ToString() + "'";
                ClassController classController = new ClassController();
                classController.Delete(theNode.Text.ToString());
                showTreeView();
            }
        }
    }
}
