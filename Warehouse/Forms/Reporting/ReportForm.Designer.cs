using Warehouse.Library;

namespace Warehouse.Forms.Reporting
{
    partial class ReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            statusLabel = new Label();
            transitionDateLabel = new Label();
            statusesComboBox = new ComboBox();
            fromTransitionDateTimePicker = new DateTimePicker();
            reportDataGridView = new DataGridView();
            toTransitionDateTimePicker = new DateTimePicker();
            fromLabel = new Label();
            toLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)reportDataGridView).BeginInit();
            SuspendLayout();
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(12, 15);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(101, 15);
            statusLabel.TabIndex = 0;
            statusLabel.Text = "Выберите статус:";
            // 
            // transitionDateLabel
            // 
            transitionDateLabel.AutoSize = true;
            transitionDateLabel.Location = new Point(12, 48);
            transitionDateLabel.Name = "transitionDateLabel";
            transitionDateLabel.Size = new Size(235, 15);
            transitionDateLabel.TabIndex = 1;
            transitionDateLabel.Text = "Выберите диапазон дат перехода в статус";
            // 
            // statusesComboBox
            // 
            statusesComboBox.FormattingEnabled = true;
            statusesComboBox.Location = new Point(119, 12);
            statusesComboBox.Name = "statusesComboBox";
            statusesComboBox.Size = new Size(121, 23);
            statusesComboBox.TabIndex = 2;
            statusesComboBox.SelectedIndexChanged += StatusesComboBox_SelectedIndexChanged;
            // 
            // fromTransitionDateTimePicker
            // 
            fromTransitionDateTimePicker.Location = new Point(289, 42);
            fromTransitionDateTimePicker.Name = "fromTransitionDateTimePicker";
            fromTransitionDateTimePicker.Size = new Size(200, 23);
            fromTransitionDateTimePicker.TabIndex = 3;
            fromTransitionDateTimePicker.ValueChanged += FromTransitionDateTimePicker_ValueChanged;
            // 
            // reportDataGridView
            // 
            reportDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            reportDataGridView.Location = new Point(12, 71);
            reportDataGridView.Name = "reportDataGridView";
            reportDataGridView.RowTemplate.Height = 25;
            reportDataGridView.Size = new Size(776, 478);
            reportDataGridView.TabIndex = 4;
            // 
            // toTransitionDateTimePicker
            // 
            toTransitionDateTimePicker.Location = new Point(533, 42);
            toTransitionDateTimePicker.Name = "toTransitionDateTimePicker";
            toTransitionDateTimePicker.Size = new Size(200, 23);
            toTransitionDateTimePicker.TabIndex = 5;
            toTransitionDateTimePicker.ValueChanged += ToTransitionDateTimePicker_ValueChanged;
            // 
            // fromLabel
            // 
            fromLabel.AutoSize = true;
            fromLabel.Location = new Point(261, 48);
            fromLabel.Name = "fromLabel";
            fromLabel.Size = new Size(22, 15);
            fromLabel.TabIndex = 6;
            fromLabel.Text = "от:";
            // 
            // toLabel
            // 
            toLabel.AutoSize = true;
            toLabel.Location = new Point(505, 48);
            toLabel.Name = "toLabel";
            toLabel.Size = new Size(23, 15);
            toLabel.TabIndex = 7;
            toLabel.Text = "до:";
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 561);
            Controls.Add(toLabel);
            Controls.Add(fromLabel);
            Controls.Add(toTransitionDateTimePicker);
            Controls.Add(reportDataGridView);
            Controls.Add(fromTransitionDateTimePicker);
            Controls.Add(statusesComboBox);
            Controls.Add(transitionDateLabel);
            Controls.Add(statusLabel);
            Name = "ReportForm";
            Text = "Report";
            ((System.ComponentModel.ISupportInitialize)reportDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private void FillStatusesComboBox()
        {
            string[] statusNames = Enum.GetNames(typeof(ProductStatus));
            foreach (string statusName in statusNames)
            {
                statusesComboBox.Items.Add(statusName);
            }
            statusesComboBox.SelectedIndex = 0;
            selectedStatus = statusesComboBox.SelectedItem.ToString();
        }

        private Label statusLabel;
        private Label transitionDateLabel;
        private ComboBox statusesComboBox;
        private DateTimePicker fromTransitionDateTimePicker;
        private DataGridView reportDataGridView;
        private DateTimePicker toTransitionDateTimePicker;
        private Label fromLabel;
        private Label toLabel;
    }
}