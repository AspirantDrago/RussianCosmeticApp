using System;
using System.ComponentModel;
using System.Windows.Forms;
using RussianCosmeticApp.db;
using RussianCosmeticApp.Models;
using RussianCosmeticApp.Sources;

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
                MessageBox.Show("Неверный формат кода лабораторной посуды", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); ; ;
                UpdateOrderID();
            }
        }
    }
}
