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
    public partial class FormAuth : Form
    {
        private FormAuthController formAuthController;
        public FormAuth()
        {
            InitializeComponent();
        }

        private void buttonAuth_Click(object sender, EventArgs e)
        {
            formAuthController.Auth();
        }

        private void FormAuth_Load(object sender, EventArgs e)
        {
            formAuthController = new FormAuthController(this);
        }
    }
}
