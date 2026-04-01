using Lab02_AddressApp;
using System;
using System.Windows.Forms;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private PostalAddress currentAddress;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            currentAddress = new PostalAddress(
                txtCountry.Text,
                txtCity.Text,
                txtStreet.Text,
                txtBuilding.Text,
                txtPostalCode.Text
            );
            UpdateUI();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (currentAddress != null)
            {
                // Демонстрація роздільної зміни складових частин через властивості
                currentAddress.Country = txtCountry.Text;
                currentAddress.City = txtCity.Text;
                currentAddress.Street = txtStreet.Text;
                currentAddress.Building = txtBuilding.Text;
                currentAddress.PostalCode = txtPostalCode.Text;
                UpdateUI();
            }
            else
            {
                MessageBox.Show("Спочатку створіть об'єкт!");
            }
        }

        private void btnDestroy_Click(object sender, EventArgs e)
        {
            if (currentAddress != null)
            {
                currentAddress = null; // Прибираємо посилання на об'єкт

                // Примусово викликаємо збирач сміття, щоб продемонструвати 
                // роботу деструктора (зазвичай GC.Collect() не використовують 
                // вручну, але це потрібно для завдання)
                GC.Collect();
                GC.WaitForPendingFinalizers();

                lblInfo.Text = $"Об'єкт знищено.\nВсього адрес у пам'яті: {PostalAddress.TotalAddresses}";
            }
        }
        private void UpdateUI()
        {
            if (currentAddress != null)
            {
                lblInfo.Text = "Поточна адреса:\n" + currentAddress.GetFullAddress() +
                               $"\n\nВсього об'єктів у пам'яті: {PostalAddress.TotalAddresses}";
            }
        }
    }
}
