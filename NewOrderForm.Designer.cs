
namespace RussianCosmeticApp
{
    partial class NewOrderForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.OrderIdTextBox = new System.Windows.Forms.MaskedTextBox();
            this.servicesGroupBox = new System.Windows.Forms.GroupBox();
            this.servicesGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.totalDurationTextBox = new System.Windows.Forms.TextBox();
            this.totalPriceTextBox = new System.Windows.Forms.TextBox();
            this.ResetOrderButton = new System.Windows.Forms.Button();
            this.SaveOrderButton = new System.Windows.Forms.Button();
            this.ClientGroupBox = new System.Windows.Forms.GroupBox();
            this.phisClientRadioButton = new System.Windows.Forms.RadioButton();
            this.urClientRadioButton = new System.Windows.Forms.RadioButton();
            this.clientComboBox = new System.Windows.Forms.ComboBox();
            this.addClientButton = new System.Windows.Forms.Button();
            this.clinetInfoLabel = new System.Windows.Forms.Label();
            this.ColumnServiceCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnServiceTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnServicePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnServiceDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceSourceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.servicesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.servicesGridView)).BeginInit();
            this.ClientGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serviceSourceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Код лабораторной посуды:";
            // 
            // OrderIdTextBox
            // 
            this.OrderIdTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OrderIdTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OrderIdTextBox.Location = new System.Drawing.Point(218, 6);
            this.OrderIdTextBox.Mask = "0000";
            this.OrderIdTextBox.Name = "OrderIdTextBox";
            this.OrderIdTextBox.Size = new System.Drawing.Size(480, 24);
            this.OrderIdTextBox.TabIndex = 2;
            this.OrderIdTextBox.Text = "0";
            this.OrderIdTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.OrderIdTextBox.ValidatingType = typeof(int);
            this.OrderIdTextBox.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.OrderIdTextBox_TypeValidationCompleted);
            // 
            // servicesGroupBox
            // 
            this.servicesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.servicesGroupBox.Controls.Add(this.servicesGridView);
            this.servicesGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.servicesGroupBox.Location = new System.Drawing.Point(15, 192);
            this.servicesGroupBox.Name = "servicesGroupBox";
            this.servicesGroupBox.Size = new System.Drawing.Size(686, 198);
            this.servicesGroupBox.TabIndex = 4;
            this.servicesGroupBox.TabStop = false;
            this.servicesGroupBox.Text = "Выберите слуги:";
            // 
            // servicesGridView
            // 
            this.servicesGridView.AllowUserToAddRows = false;
            this.servicesGridView.AllowUserToDeleteRows = false;
            this.servicesGridView.AllowUserToResizeRows = false;
            this.servicesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.servicesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnServiceCheckBox,
            this.ColumnServiceTitle,
            this.ColumnServicePrice,
            this.ColumnServiceDuration});
            this.servicesGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.servicesGridView.Location = new System.Drawing.Point(3, 18);
            this.servicesGridView.Name = "servicesGridView";
            this.servicesGridView.Size = new System.Drawing.Size(680, 177);
            this.servicesGridView.TabIndex = 0;
            this.servicesGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.servicesGridView_CurrentCellDirtyStateChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(67, 393);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Длительность, ч:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(67, 421);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Стоимость, руб:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // totalDurationTextBox
            // 
            this.totalDurationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalDurationTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.totalDurationTextBox.Location = new System.Drawing.Point(218, 393);
            this.totalDurationTextBox.Name = "totalDurationTextBox";
            this.totalDurationTextBox.ReadOnly = true;
            this.totalDurationTextBox.Size = new System.Drawing.Size(480, 22);
            this.totalDurationTextBox.TabIndex = 7;
            this.totalDurationTextBox.Text = "0";
            this.totalDurationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // totalPriceTextBox
            // 
            this.totalPriceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalPriceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.totalPriceTextBox.Location = new System.Drawing.Point(218, 421);
            this.totalPriceTextBox.Name = "totalPriceTextBox";
            this.totalPriceTextBox.ReadOnly = true;
            this.totalPriceTextBox.Size = new System.Drawing.Size(480, 22);
            this.totalPriceTextBox.TabIndex = 8;
            this.totalPriceTextBox.Text = "0";
            this.totalPriceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ResetOrderButton
            // 
            this.ResetOrderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ResetOrderButton.BackColor = System.Drawing.Color.LightCoral;
            this.ResetOrderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResetOrderButton.Location = new System.Drawing.Point(591, 452);
            this.ResetOrderButton.Name = "ResetOrderButton";
            this.ResetOrderButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ResetOrderButton.Size = new System.Drawing.Size(107, 31);
            this.ResetOrderButton.TabIndex = 9;
            this.ResetOrderButton.Text = "Очистить";
            this.ResetOrderButton.UseVisualStyleBackColor = false;
            this.ResetOrderButton.Click += new System.EventHandler(this.ResetOrderButton_Click);
            // 
            // SaveOrderButton
            // 
            this.SaveOrderButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveOrderButton.BackColor = System.Drawing.Color.MediumAquamarine;
            this.SaveOrderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveOrderButton.Location = new System.Drawing.Point(18, 452);
            this.SaveOrderButton.Name = "SaveOrderButton";
            this.SaveOrderButton.Size = new System.Drawing.Size(567, 31);
            this.SaveOrderButton.TabIndex = 10;
            this.SaveOrderButton.Text = "Сохранить";
            this.SaveOrderButton.UseVisualStyleBackColor = false;
            // 
            // ClientGroupBox
            // 
            this.ClientGroupBox.Controls.Add(this.clinetInfoLabel);
            this.ClientGroupBox.Controls.Add(this.addClientButton);
            this.ClientGroupBox.Controls.Add(this.clientComboBox);
            this.ClientGroupBox.Controls.Add(this.urClientRadioButton);
            this.ClientGroupBox.Controls.Add(this.phisClientRadioButton);
            this.ClientGroupBox.Location = new System.Drawing.Point(18, 36);
            this.ClientGroupBox.Name = "ClientGroupBox";
            this.ClientGroupBox.Size = new System.Drawing.Size(680, 150);
            this.ClientGroupBox.TabIndex = 11;
            this.ClientGroupBox.TabStop = false;
            this.ClientGroupBox.Text = "Клиент";
            // 
            // phisClientRadioButton
            // 
            this.phisClientRadioButton.AutoSize = true;
            this.phisClientRadioButton.Checked = true;
            this.phisClientRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phisClientRadioButton.Location = new System.Drawing.Point(7, 20);
            this.phisClientRadioButton.Name = "phisClientRadioButton";
            this.phisClientRadioButton.Size = new System.Drawing.Size(142, 20);
            this.phisClientRadioButton.TabIndex = 0;
            this.phisClientRadioButton.TabStop = true;
            this.phisClientRadioButton.Text = "физическое лицо";
            this.phisClientRadioButton.UseVisualStyleBackColor = true;
            // 
            // urClientRadioButton
            // 
            this.urClientRadioButton.AutoSize = true;
            this.urClientRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.urClientRadioButton.Location = new System.Drawing.Point(7, 43);
            this.urClientRadioButton.Name = "urClientRadioButton";
            this.urClientRadioButton.Size = new System.Drawing.Size(149, 20);
            this.urClientRadioButton.TabIndex = 1;
            this.urClientRadioButton.Text = "юридическое лицо";
            this.urClientRadioButton.UseVisualStyleBackColor = true;
            // 
            // clientComboBox
            // 
            this.clientComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.clientComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clientComboBox.FormattingEnabled = true;
            this.clientComboBox.Location = new System.Drawing.Point(184, 29);
            this.clientComboBox.Name = "clientComboBox";
            this.clientComboBox.Size = new System.Drawing.Size(447, 24);
            this.clientComboBox.TabIndex = 2;
            // 
            // addClientButton
            // 
            this.addClientButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addClientButton.Location = new System.Drawing.Point(637, 23);
            this.addClientButton.Name = "addClientButton";
            this.addClientButton.Size = new System.Drawing.Size(38, 33);
            this.addClientButton.TabIndex = 3;
            this.addClientButton.Text = "+";
            this.addClientButton.UseVisualStyleBackColor = true;
            // 
            // clinetInfoLabel
            // 
            this.clinetInfoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clinetInfoLabel.Location = new System.Drawing.Point(7, 70);
            this.clinetInfoLabel.Name = "clinetInfoLabel";
            this.clinetInfoLabel.Size = new System.Drawing.Size(668, 77);
            this.clinetInfoLabel.TabIndex = 4;
            this.clinetInfoLabel.Text = "Информация о клиенте";
            // 
            // ColumnServiceCheckBox
            // 
            this.ColumnServiceCheckBox.DataPropertyName = "selected";
            this.ColumnServiceCheckBox.Frozen = true;
            this.ColumnServiceCheckBox.HeaderText = "";
            this.ColumnServiceCheckBox.Name = "ColumnServiceCheckBox";
            this.ColumnServiceCheckBox.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnServiceCheckBox.Width = 20;
            // 
            // ColumnServiceTitle
            // 
            this.ColumnServiceTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnServiceTitle.DataPropertyName = "title";
            this.ColumnServiceTitle.HeaderText = "Наименование";
            this.ColumnServiceTitle.Name = "ColumnServiceTitle";
            this.ColumnServiceTitle.ReadOnly = true;
            this.ColumnServiceTitle.Width = 132;
            // 
            // ColumnServicePrice
            // 
            this.ColumnServicePrice.DataPropertyName = "price";
            this.ColumnServicePrice.HeaderText = "Стоимость, руб.";
            this.ColumnServicePrice.MinimumWidth = 150;
            this.ColumnServicePrice.Name = "ColumnServicePrice";
            this.ColumnServicePrice.ReadOnly = true;
            this.ColumnServicePrice.Width = 150;
            // 
            // ColumnServiceDuration
            // 
            this.ColumnServiceDuration.DataPropertyName = "duration";
            this.ColumnServiceDuration.HeaderText = "Длительность, ч";
            this.ColumnServiceDuration.MinimumWidth = 150;
            this.ColumnServiceDuration.Name = "ColumnServiceDuration";
            this.ColumnServiceDuration.ReadOnly = true;
            this.ColumnServiceDuration.Width = 150;
            // 
            // serviceSourceBindingSource
            // 
            this.serviceSourceBindingSource.DataSource = typeof(RussianCosmeticApp.Sources.ServiceSource);
            // 
            // NewOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 492);
            this.Controls.Add(this.ClientGroupBox);
            this.Controls.Add(this.SaveOrderButton);
            this.Controls.Add(this.ResetOrderButton);
            this.Controls.Add(this.totalPriceTextBox);
            this.Controls.Add(this.totalDurationTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.servicesGroupBox);
            this.Controls.Add(this.OrderIdTextBox);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(400, 450);
            this.Name = "NewOrderForm";
            this.Text = "Создание заказа";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.servicesGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.servicesGridView)).EndInit();
            this.ClientGroupBox.ResumeLayout(false);
            this.ClientGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serviceSourceBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox OrderIdTextBox;
        private System.Windows.Forms.GroupBox servicesGroupBox;
        private System.Windows.Forms.DataGridView servicesGridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox totalDurationTextBox;
        private System.Windows.Forms.TextBox totalPriceTextBox;
        private System.Windows.Forms.Button ResetOrderButton;
        private System.Windows.Forms.Button SaveOrderButton;
        private System.Windows.Forms.BindingSource serviceSourceBindingSource;
        private System.Windows.Forms.GroupBox ClientGroupBox;
        private System.Windows.Forms.Label clinetInfoLabel;
        private System.Windows.Forms.Button addClientButton;
        private System.Windows.Forms.ComboBox clientComboBox;
        private System.Windows.Forms.RadioButton urClientRadioButton;
        private System.Windows.Forms.RadioButton phisClientRadioButton;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnServiceCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnServiceTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnServicePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnServiceDuration;
    }
}

