namespace Comandos
{
    public partial class Form1 : Form
    {
        Cmd c;
        public Form1()
        {
            InitializeComponent();
            this.txt_3.Enabled = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //falta ipv64 el stop de -t
            string command;
            string exclusion = "";
            string cant = " " + this.txt_3.Text+" ";
            string ipv = "";

            //ipv
            if (this.rd_3.Checked) { ipv = "-4 "; }
            else if(this.rd_4.Checked) { ipv = "-6 "; }
            //caso extra
            
            //acumulador
            if (this.rd_1.Checked)
            {
                if (cant=="") { cant = ""; }
                command = "ping "  +ipv+ this.cb_1.Text + cant + this.txt_2.Text;
                c = new Cmd(command);
                this.txt_1.Text = c.ExecuteCommand();
            }
            else if (this.rd_2.Checked)
            {
                command = "tracert " + ipv + this.cb_2.Text + cant + this.txt_2.Text;
                c = new Cmd(command);
                this.txt_1.Text = c.ExecuteCommand();
            }
        }

        private void txt_2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.txt_1.Text = "";
            this.txt_2.Text = "";
            this.txt_3.Text = "";
            this.cb_1.Text = "";
            this.cb_2.Text = "";
        }

        private void rd_3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cb_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_1.Text == "-n" || this.cb_1.Text == "-l" || this.cb_2.Text == "-h")
            {
                this.txt_3.Enabled = true;
            }
            else
            {
                this.txt_3.Enabled = false;
            }
        }

        private void cb_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_1.Text == "-n" || this.cb_1.Text == "-l" || this.cb_2.Text == "-h")
            {
                this.txt_3.Enabled = true;
            }
            else
            {
                this.txt_3.Enabled = false;
            }
        }

        private void rd_2_CheckedChanged(object sender, EventArgs e)
        {
            this.txt_3.Text = "";
            this.txt_2.Text = "";
            this.txt_1.Text = "";
            this.rd_3.Checked = false;
            this.rd_4.Checked = false;
            this.cb_2.Text = "";
            this.txt_3.Enabled = false;
        }

        private void rd_1_CheckedChanged(object sender, EventArgs e)
        {
            this.txt_3.Text = "";
            this.txt_2.Text = "";
            this.txt_1.Text = "";
            this.rd_3.Checked = false;
            this.rd_4.Checked = false;
            this.cb_1.Text = "";
            this.txt_3.Enabled=false;
        }

        private void rd_4_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
