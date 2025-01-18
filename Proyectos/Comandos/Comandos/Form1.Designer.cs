namespace Comandos
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txt_1 = new TextBox();
            button1 = new Button();
            rd_1 = new RadioButton();
            rd_2 = new RadioButton();
            cb_1 = new ComboBox();
            cb_2 = new ComboBox();
            txt_2 = new TextBox();
            button2 = new Button();
            rd_4 = new RadioButton();
            rd_3 = new RadioButton();
            panel1 = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            txt_3 = new TextBox();
            label2 = new Label();
            panel4 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // txt_1
            // 
            txt_1.Location = new Point(534, 109);
            txt_1.Multiline = true;
            txt_1.Name = "txt_1";
            txt_1.Size = new Size(642, 443);
            txt_1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(534, 45);
            button1.Name = "button1";
            button1.Size = new Size(117, 45);
            button1.TabIndex = 2;
            button1.Text = "Enviar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // rd_1
            // 
            rd_1.AutoSize = true;
            rd_1.Location = new Point(12, 13);
            rd_1.Name = "rd_1";
            rd_1.Size = new Size(59, 24);
            rd_1.TabIndex = 3;
            rd_1.TabStop = true;
            rd_1.Text = "Ping";
            rd_1.UseVisualStyleBackColor = true;
            rd_1.CheckedChanged += rd_1_CheckedChanged;
            // 
            // rd_2
            // 
            rd_2.AutoSize = true;
            rd_2.Location = new Point(12, 43);
            rd_2.Name = "rd_2";
            rd_2.Size = new Size(75, 24);
            rd_2.TabIndex = 4;
            rd_2.TabStop = true;
            rd_2.Text = "Tracert";
            rd_2.UseVisualStyleBackColor = true;
            rd_2.CheckedChanged += rd_2_CheckedChanged;
            // 
            // cb_1
            // 
            cb_1.FormattingEnabled = true;
            cb_1.Items.AddRange(new object[] { "-t", "-n", "-l" });
            cb_1.Location = new Point(161, 87);
            cb_1.Name = "cb_1";
            cb_1.Size = new Size(42, 28);
            cb_1.TabIndex = 5;
            cb_1.SelectedIndexChanged += cb_1_SelectedIndexChanged;
            // 
            // cb_2
            // 
            cb_2.FormattingEnabled = true;
            cb_2.Items.AddRange(new object[] { "-d", "-h" });
            cb_2.Location = new Point(161, 123);
            cb_2.Name = "cb_2";
            cb_2.Size = new Size(42, 28);
            cb_2.TabIndex = 6;
            cb_2.SelectedIndexChanged += cb_2_SelectedIndexChanged;
            // 
            // txt_2
            // 
            txt_2.Location = new Point(17, 45);
            txt_2.Name = "txt_2";
            txt_2.Size = new Size(174, 27);
            txt_2.TabIndex = 7;
            txt_2.TextChanged += txt_2_TextChanged;
            // 
            // button2
            // 
            button2.Location = new Point(668, 45);
            button2.Name = "button2";
            button2.Size = new Size(117, 45);
            button2.TabIndex = 8;
            button2.Text = "Limpiar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // rd_4
            // 
            rd_4.AutoSize = true;
            rd_4.Location = new Point(86, 10);
            rd_4.Name = "rd_4";
            rd_4.Size = new Size(57, 24);
            rd_4.TabIndex = 10;
            rd_4.TabStop = true;
            rd_4.Text = "IPv6";
            rd_4.UseVisualStyleBackColor = true;
            rd_4.CheckedChanged += rd_4_CheckedChanged;
            // 
            // rd_3
            // 
            rd_3.AutoSize = true;
            rd_3.Location = new Point(12, 10);
            rd_3.Name = "rd_3";
            rd_3.Size = new Size(57, 24);
            rd_3.TabIndex = 9;
            rd_3.TabStop = true;
            rd_3.Text = "IPv4";
            rd_3.UseVisualStyleBackColor = true;
            rd_3.CheckedChanged += rd_3_CheckedChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(rd_2);
            panel1.Controls.Add(rd_1);
            panel1.Location = new Point(57, 81);
            panel1.Name = "panel1";
            panel1.Size = new Size(98, 78);
            panel1.TabIndex = 13;
            // 
            // panel2
            // 
            panel2.Controls.Add(rd_4);
            panel2.Controls.Add(rd_3);
            panel2.Location = new Point(57, 33);
            panel2.Name = "panel2";
            panel2.Size = new Size(160, 42);
            panel2.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 15);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 16;
            label1.Text = "Direccion ";
            // 
            // panel3
            // 
            panel3.Controls.Add(label1);
            panel3.Controls.Add(txt_2);
            panel3.Location = new Point(324, 94);
            panel3.Name = "panel3";
            panel3.Size = new Size(204, 82);
            panel3.TabIndex = 17;
            // 
            // txt_3
            // 
            txt_3.Location = new Point(14, 40);
            txt_3.Name = "txt_3";
            txt_3.Size = new Size(73, 27);
            txt_3.TabIndex = 21;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 13);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 22;
            label2.Text = "Cantidad";
            // 
            // panel4
            // 
            panel4.Controls.Add(label2);
            panel4.Controls.Add(txt_3);
            panel4.Location = new Point(221, 94);
            panel4.Name = "panel4";
            panel4.Size = new Size(97, 82);
            panel4.TabIndex = 23;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1209, 612);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(button2);
            Controls.Add(cb_2);
            Controls.Add(cb_1);
            Controls.Add(button1);
            Controls.Add(txt_1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txt_1;
        private Button button1;
        private RadioButton rd_1;
        private RadioButton rd_2;
        private ComboBox cb_1;
        private ComboBox cb_2;
        private TextBox txt_2;
        private Button button2;
        private RadioButton rd_4;
        private RadioButton rd_3;
        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Panel panel3;
        private NumericUpDown num_1;
        private NumericUpDown num_2;
        private NumericUpDown num_3;
        private TextBox txt_3;
        private Label label2;
        private Panel panel4;
    }
}
