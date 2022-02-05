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
    class FormMainController
    {
        private FormMain formMain;
        private CovidDBEntities covidDBEntities;

        public FormMainController(FormMain formMain)
        {
            this.formMain = formMain;
            covidDBEntities = new CovidDBEntities();
        }

        public void UpdateDataGridViewPatients()
        {
            try
            {
                formMain.dataGridViewPatients.DataSource = null;
                formMain.dataGridViewPatients.DataSource = covidDBEntities.Pacients.ToList();

                formMain.dataGridViewPatients.Columns["fullname"].HeaderText = "ФИО";
                formMain.dataGridViewPatients.Columns["login"].Visible = false;
            }
            catch
            {
                MessageBox.Show("ошибка подключения к БД");
            }
        }

        public void ChangeFullName()
        {
            try
            {


                if (formMain.dataGridViewPatients.SelectedRows.Count == 0)
                {
                    return;
                }

                Pacient selectedPacient = (Pacient)formMain.dataGridViewPatients.SelectedRows[0].DataBoundItem;

                selectedPacient.fullname = formMain.textBoxFullName.Text;

                covidDBEntities.SaveChanges();

                UpdateDataGridViewPatients();
            }
            catch
            {
                MessageBox.Show("ошибка подключения к БД");
            }
        }

        public void AddNewPatient()
        {
            try
            {
                if (formMain.dataGridViewPatients.SelectedRows.Count == 0)
                {
                    return;
                }

                Pacient selectedPacient = (Pacient)formMain.dataGridViewPatients.SelectedRows[0].DataBoundItem;

                Pacient newPacient = new Pacient()
                {
                    id = 0,
                    fullname = "AAAAAAAA",
                    login = selectedPacient.login,
                    pwd = selectedPacient.pwd,
                    guid = selectedPacient.guid,
                    email = selectedPacient.email,
                    social_sec_number = selectedPacient.social_sec_number,
                    ein = selectedPacient.ein,
                    social_type = selectedPacient.social_type,
                    phone = selectedPacient.phone,
                    passport_s = selectedPacient.passport_s,
                    passport_n = selectedPacient.passport_n,
                    birthdate_timestamp = selectedPacient.birthdate_timestamp,

                    country = selectedPacient.country,
                    insurance_name = selectedPacient.insurance_name,
                    insurance_address = selectedPacient.insurance_address,
                    insurance_inn = selectedPacient.insurance_inn,
                    ipadress = selectedPacient.ipadress,
                    insurance_pc = selectedPacient.insurance_pc,
                    insurance_bik = selectedPacient.insurance_bik,
                    ua = selectedPacient.ua,
                };

                covidDBEntities.Pacients.Add(newPacient);

                covidDBEntities.SaveChanges();

                UpdateDataGridViewPatients();
            }
            catch
            {
                MessageBox.Show("ошибка подключения к БД");
            }
        }
    }
}
