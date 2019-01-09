using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FaceDetection.Entity;
namespace FaceDetection.GUI
{
    public partial class frmClass : Form
    {
        public frmClass()
        {
            InitializeComponent();
        }
        public void SetInPut(Class addClass)
        {
            loadClassTypeList();
            txtClassCode.Text=addClass.ClassCode;
            txtClassName.Text=addClass.ClassName;
            if (!(addClass.ClassTypeCode == ""))
             {
                 if (addClass.ClassTypeCode=="lcn")
                     cbClassType.SelectedIndex = 0;
                 else
                     cbClassType.SelectedIndex = 1;
             }
            cbClassType.SelectedIndex = 0;
        }
        
        private void loadClassTypeList()
        {
            cbClassType.Items.Add("Lớp chuyên ngành");
            cbClassType.Items.Add("Lớp tín chỉ");
        }
        private void frmAddClass_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        public Class getClass()
        {
            Class value= new Class();
            value.ClassCode = txtClassCode.Text;
            value.ClassName = txtClassName.Text;
            value.ClassTypeCode = cbClassType.SelectedIndex == 0 ? "lcn" : "ltc";
            return value;
        }
    }
}
