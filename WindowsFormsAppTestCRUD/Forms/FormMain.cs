using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsAppTestCRUD.Controllers;
using WindowsFormsAppTestCRUD.Model;

namespace WindowsFormsAppTestCRUD.Forms
{
    public partial class FormMain : Form
    {
        private FormMainController formMainController;

        public FormMain()
        {
            InitializeComponent();
        }
       
        private void FormMain_Load(object sender, EventArgs e)
        {
            formMainController = new FormMainController(this);
            formMainController.UpdateDataGridViewPatients();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formMainController.ChangeFullName();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formMainController.AddNewPatient();
        }
    }
}
