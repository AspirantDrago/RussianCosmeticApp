using System;
using System.ComponentModel;
using System.Windows.Forms;
using RussianCosmeticApp.db;
using RussianCosmeticApp.Models;
using RussianCosmeticApp.Sources;
using RussianCosmeticApp.Forms;
using System.Collections.Generic;

namespace RussianCosmeticApp
{
    public partial class NewOrderForm : Form
    {
        private BindingList<ServiceSource> services;

        public OrderDB currentOrder = null;


        public NewOrderForm()
        {
            InitializeComponent();
        }

        private void UpdateServices()
        {
            services = new BindingList<ServiceSource>();
            foreach(ServiceModel service in ServiceDB.GetAll())
            {
                services.Add(new ServiceSource(
                    service, this
                ));
            }
            servicesGridView.DataSource = services;
        }

        public void UpdateClients()
        {
            clientComboBox.Items.Clear();
            clientComboBox.Text = "";
            List<AbsClientModel> clients = new List<AbsClientModel>();
            if (phisClientRadioButton.Checked)
            {
                clients = new List<AbsClientModel>(PhysClientDB.GetAll());
            }
            else
            {
                // TODO
            }
            if (clients.Count > 0)
            {
                clientComboBox.Items.AddRange(clients.ToArray());
                clientComboBox.SelectedIndex = 0;
            }
            else
            {
                clientInfoLabel.Text = "Список клиентов пуст";
            }
        }
        
        private int UpdateOrderID()
        {
            int result = OrderDB.GetNewId();
            OrderIdTextBox.Text = result.ToString();
            return result;
        }

        public void UpdateOrderTotal()
        {
            services.ResetBindings();
            totalDurationTextBox.Text = currentOrder.duration.ToString();
            totalPriceTextBox.Text = currentOrder.price.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResetOrder();
        }

        private void ResetOrder()
        {
            UpdateServices();
            phisClientRadioButton.Checked = true;
            UpdateClients();
            currentOrder = new OrderDB(
                id: UpdateOrderID(),
                dataCreate: DateTime.Now,
                status: null,
                duration: null
            );
            UpdateOrderTotal();
        }

        private void ResetOrderButton_Click(object sender, EventArgs e)
        {
            ResetOrder();
        }

        private void servicesGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (servicesGridView.CurrentCell is DataGridViewCheckBoxCell)
                servicesGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void OrderIdTextBox_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(OrderIdTextBox.Text);
                if (OrderDB.GetByID(id) != null)
                {
                    MessageBox.Show($"Код товара {id} уже существует", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    UpdateOrderID();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неверный формат кода лабораторной посуды", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateOrderID();
            }
        }

        private void addClientButton_Click(object sender, EventArgs e)
        {
            Form form;
            if (phisClientRadioButton.Checked)
            {
                form = new NewPhysClientForm();
                form.Show(this);
            }
            else
            {
                // TODO
            }
        }

        private void phisClientRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateClients();
        }

        private void clientComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AbsClientModel client = clientComboBox.SelectedItem as AbsClientModel;
            if (client != null)
            {
                clientInfoLabel.Text = client.GetInfo();
            }
        }
    }
}
