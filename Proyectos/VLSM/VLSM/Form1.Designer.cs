namespace VLSM
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
            txt_resultado = new TextBox();
            txt_1 = new TextBox();
            txt_red = new TextBox();
            btn_1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txt_2 = new TextBox();
            txt_3 = new TextBox();
            txt_4 = new TextBox();
            txt_subredes = new TextBox();
            label7 = new Label();
            btn_2 = new Button();
            btn_pdf = new Button();
            btn_del = new Button();
            SuspendLayout();
            // 
            // txt_resultado
            // 
            txt_resultado.Location = new Point(581, 12);
            txt_resultado.Multiline = true;
            txt_resultado.Name = "txt_resultado";
            txt_resultado.Size = new Size(728, 573);
            txt_resultado.TabIndex = 0;
            // 
            // txt_1
            // 
            txt_1.Location = new Point(97, 66);
            txt_1.Name = "txt_1";
            txt_1.Size = new Size(59, 27);
            txt_1.TabIndex = 1;
            txt_1.Text = "170";
            // 
            // txt_red
            // 
            txt_red.Location = new Point(381, 66);
            txt_red.Name = "txt_red";
            txt_red.Size = new Size(82, 27);
            txt_red.TabIndex = 5;
            txt_red.Text = "20";
            // 
            // btn_1
            // 
            btn_1.BackColor = Color.PowderBlue;
            btn_1.Location = new Point(245, 208);
            btn_1.Name = "btn_1";
            btn_1.Size = new Size(121, 57);
            btn_1.TabIndex = 7;
            btn_1.Text = "Calcular";
            btn_1.UseVisualStyleBackColor = false;
            btn_1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.DarkViolet;
            label1.Location = new Point(97, 43);
            label1.Name = "label1";
            label1.Size = new Size(40, 20);
            label1.TabIndex = 8;
            label1.Text = "Oct1";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.DarkViolet;
            label2.Location = new Point(162, 43);
            label2.Name = "label2";
            label2.Size = new Size(40, 20);
            label2.TabIndex = 9;
            label2.Text = "Oct2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.DarkViolet;
            label3.Location = new Point(227, 43);
            label3.Name = "label3";
            label3.Size = new Size(40, 20);
            label3.TabIndex = 10;
            label3.Text = "Oct3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.DarkViolet;
            label4.Location = new Point(296, 43);
            label4.Name = "label4";
            label4.Size = new Size(40, 20);
            label4.TabIndex = 11;
            label4.Text = "Oct4";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(392, 43);
            label5.Name = "label5";
            label5.Size = new Size(60, 20);
            label5.TabIndex = 12;
            label5.Text = "Pre Red";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = SystemColors.ActiveCaptionText;
            label6.Location = new Point(234, 118);
            label6.Name = "label6";
            label6.Size = new Size(134, 20);
            label6.TabIndex = 13;
            label6.Text = "Cantidad Subredes";
            // 
            // txt_2
            // 
            txt_2.Location = new Point(162, 66);
            txt_2.Name = "txt_2";
            txt_2.Size = new Size(59, 27);
            txt_2.TabIndex = 14;
            txt_2.Text = "44";
            // 
            // txt_3
            // 
            txt_3.Location = new Point(227, 66);
            txt_3.Name = "txt_3";
            txt_3.Size = new Size(59, 27);
            txt_3.TabIndex = 15;
            txt_3.Text = "48";
            // 
            // txt_4
            // 
            txt_4.Location = new Point(296, 66);
            txt_4.Name = "txt_4";
            txt_4.Size = new Size(59, 27);
            txt_4.TabIndex = 16;
            txt_4.Text = "0";
            // 
            // txt_subredes
            // 
            txt_subredes.Location = new Point(245, 148);
            txt_subredes.Name = "txt_subredes";
            txt_subredes.Size = new Size(112, 27);
            txt_subredes.TabIndex = 17;
            txt_subredes.Text = "9";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(360, 69);
            label7.Name = "label7";
            label7.Size = new Size(15, 20);
            label7.TabIndex = 18;
            label7.Text = "/";
            label7.Click += label7_Click;
            // 
            // btn_2
            // 
            btn_2.BackColor = Color.Gold;
            btn_2.Location = new Point(382, 136);
            btn_2.Name = "btn_2";
            btn_2.Size = new Size(119, 51);
            btn_2.TabIndex = 19;
            btn_2.Text = "+";
            btn_2.UseVisualStyleBackColor = false;
            btn_2.Click += button2_Click;
            // 
            // btn_pdf
            // 
            btn_pdf.BackColor = Color.Plum;
            btn_pdf.Location = new Point(382, 208);
            btn_pdf.Name = "btn_pdf";
            btn_pdf.Size = new Size(119, 57);
            btn_pdf.TabIndex = 20;
            btn_pdf.Text = "PDF";
            btn_pdf.UseVisualStyleBackColor = false;
            btn_pdf.Click += button1_Click_1;
            // 
            // btn_del
            // 
            btn_del.BackColor = Color.Salmon;
            btn_del.ForeColor = SystemColors.ControlLightLight;
            btn_del.Location = new Point(246, 285);
            btn_del.Name = "btn_del";
            btn_del.Size = new Size(255, 67);
            btn_del.TabIndex = 21;
            btn_del.Text = "DELETE";
            btn_del.UseVisualStyleBackColor = false;
            btn_del.Click += button1_Click_2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(1321, 597);
            Controls.Add(btn_del);
            Controls.Add(btn_pdf);
            Controls.Add(btn_2);
            Controls.Add(label7);
            Controls.Add(txt_subredes);
            Controls.Add(txt_4);
            Controls.Add(txt_3);
            Controls.Add(txt_2);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_1);
            Controls.Add(txt_red);
            Controls.Add(txt_1);
            Controls.Add(txt_resultado);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_resultado;
        private TextBox txt_1;
        private TextBox txt_red;
        private Button btn_1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txt_2;
        private TextBox txt_3;
        private TextBox txt_4;
        private TextBox txt_subredes;
        private Label label7;
        private Button btn_2;
        private Button btn_pdf;
        private Button btn_del;
    }
}
