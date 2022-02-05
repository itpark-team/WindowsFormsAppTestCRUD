using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsAppTestCRUD.Forms;
using WindowsFormsAppTestCRUD.Model;

namespace WindowsFormsAppTestCRUD.Controllers
{
    class FormAuthController
    {
        private FormAuth formAuth;

        public FormAuthController(FormAuth formAuth)
        {
            this.formAuth = formAuth;
        }

        public void Auth()
        {
            try
            {
                CovidDBEntities covidDBEntities = new CovidDBEntities();

                User foundUser = covidDBEntities.Users.FirstOrDefault(user => user.Login == formAuth.textBoxLogin.Text && user.Password == formAuth.textBoxPassword.Text);

                if (foundUser == null)
                {
                    MessageBox.Show("error");
                    return;
                }

                MessageBox.Show("ok");

                formAuth.textBoxLogin.Clear();
                formAuth.textBoxPassword.Clear();


                formAuth.Hide();
                new FormMain().ShowDialog();
                formAuth.Show();
            }
            catch
            {
                MessageBox.Show("ошибка подключения к БД");
            }
        }
    }
}
