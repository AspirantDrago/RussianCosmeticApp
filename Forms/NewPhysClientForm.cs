using System;
using System.Windows.Forms;
using RussianCosmeticApp.db;

namespace RussianCosmeticApp.Forms
{
    public partial class NewPhysClientForm : Form
    {
        public NewPhysClientForm()
        {
            InitializeComponent();
        }

        private void NewPhysClientForm_Load(object sender, EventArgs e)
        {
            
        }

        private void Clear()
        {
            emailTextBox.Clear();
            passwordlTextBox.Clear();
            repeatPasswordTextBox.Clear();
            surnameTextBox.Clear();
            nameTextBox.Clear();
            patronymicTextBox.Clear();
            birthdayDatTimePicker.Value = DateTime.Now;
            passportTextBox.Clear();
            phoneTextBox.Clear();
        }

        private bool Save()
        {
            try
            {
                string email = emailTextBox.Text.Trim();
                if (email.Length == 0)
                    throw new Exception("Электронная почта не указана");

                string password = passwordlTextBox.Text.Trim();
                if (password.Length < 6)
                    throw new Exception("Длина пароля долждна быть не менее 6 символов");
                string password2 = repeatPasswordTextBox.Text.Trim();
                if (!password.Equals(password2))
                    throw new Exception("Пароли не совпадают");
                password = PhysClientDB.GetHashPassword(password);

                string name = nameTextBox.Text.Trim();
                if (name.Length == 0)
                    throw new Exception("Имя не указано");

                string surname = surnameTextBox.Text.Trim();
                if (surname.Length == 0)
                    throw new Exception("Фамилия не указана");

                string patronymic = patronymicTextBox.Text.Trim();
                if (patronymic.Length == 0)
                    throw new Exception("Отчество не указано");

                DateTime birthday = birthdayDatTimePicker.Value;
                if (birthday > DateTime.Now)
                    throw new Exception("Дата рождения не может быть в будущем");

                if (passportTextBox.Text.Contains("_"))
                    throw new Exception("Паспорт не указан");
                int passportSeria = Convert.ToInt32(passportTextBox.Text.Substring(0, 4));
                int passportNumber = Convert.ToInt32(passportTextBox.Text.Substring(5));

                if (phoneTextBox.Text.Contains("_")) // TODO Fix
                    throw new Exception("Номер телефона не указан");
                string phone = phoneTextBox.Text;

                PhysClientDB client = new PhysClientDB(
                    id: null,
                    email: email,
                    password: password,
                    name: name,
                    surname: surname,
                    patronymic: patronymic,
                    birthday: birthday,
                    passportSeria: passportSeria,
                    passportNumber: passportNumber,
                    phone: phone
                    );
                client.Save();

                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка сохранения клиента", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void saveAndRepeatButton_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                Clear();
                ((NewOrderForm)Application.OpenForms["NewOrderForm"]).UpdateClients();
            }
        }

        private void saveAndCloseButton_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                Close();
                (Owner as NewOrderForm).UpdateClients();
            }
        }
    }
}
