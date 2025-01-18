using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Linq.Expressions;

namespace VLSM
{
    public partial class Form1 : Form
    {
        //ip padre
        string ip;
        StringBuilder ipPadre;
        object[] objPadre;
        //division
        int[] hosts;
        string[] lanes;
        TextBox[] txtH;
        TextBox[] txtL;
        //ext
        int subredes;
        VLSM vlsm;

        public Form1()
        {
            InitializeComponent();
        }
        public static String DecimalBinario(string num)
        {
            return Convert.ToString(int.Parse(num), 2).PadLeft(8, '0');
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Verificacion(this.txt_1.Text, this.txt_2.Text, this.txt_3.Text, this.txt_4.Text,this.txt_red.Text)) {
                    hosts = new int[subredes];
                    lanes = new string[subredes];
                    for (int i = 0; i < subredes; i++)
                    {
                        hosts[i] = Convert.ToInt32(txtH[i].Text);
                        lanes[i] = txtL[i].Text;
                    }
                    ///<IP>
                    this.ip = DecimalBinario(this.txt_1.Text) + DecimalBinario(this.txt_2.Text) + DecimalBinario(this.txt_3.Text) + DecimalBinario(this.txt_4.Text);
                    this.ipPadre = new StringBuilder(ip);
                    int red = Convert.ToInt32(this.txt_red.Text);
                    this.ipPadre = MetodoIni(this.ipPadre, red);
                    this.objPadre = new object[5] { ipPadre, red, false, null, null };
                    vlsm = new VLSM(this.subredes, this.hosts, this.lanes);
                    vlsm.Calculo(objPadre);
                    //activar el scroll de manera vertical
                    this.txt_resultado.ScrollBars = ScrollBars.Vertical;
                    //imprimir resultados en txt_resultado
                    this.txt_resultado.Text = vlsm.Imprimir(" ", objPadre) + "\r\n" + vlsm.Resultados(objPadre);
                }
                else
                {
                    MessageBox.Show(" Tienes dos errores ingreso erroneo de datos y aver nacido ");
                }

            }
            catch (Exception ec)
            {
                MessageBox.Show("Datos ingresados incorrectamente");
            }

        }
        public bool Verificacion(string uno, string dos, string tres, string cuatro, string red)
        {
            int oct1 =Convert.ToInt32(uno);
            int oct2 = Convert.ToInt32(dos);
            int oct3 = Convert.ToInt32(tres);
            int oct4 = Convert.ToInt32(cuatro);
            int redc = Convert.ToInt32(red);
            if (oct1>=0 && oct1 <= 255 && oct2 >= 0 && oct2 <= 255 &&
                oct3 >= 0 && oct3 <= 255 && oct4 >= 0 && oct4 <= 255 && redc >= 0 && redc <= 32)
            {
                return true;
            }
            return false;
        }
        public StringBuilder MetodoIni(StringBuilder ip, int red)
        {
            for (int i = red; i < ip.Length; i++)
            {
                ip[i] = '0';
            }
            return ip;

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //Crear lista de textos para las subredes
                subredes = Convert.ToInt32(this.txt_subredes.Text);
                txtH = new TextBox[subredes];
                txtL = new TextBox[subredes];

                for (int i = 0; i < subredes; i++)
                {
                    txtH[i] = new TextBox();
                    txtH[i].Size = new Size(70, 50);
                    txtH[i].Location = new Point(30, 100 + (50) + (i * 30));
                    //txt[i].BackColor = Color.LightBlue; 
                    txtH[i].Name = $"txt_subH{i}";
                    txtH[i].Text = $"{i}";
                    this.Controls.Add(txtH[i]);
                    ///<Lanes>
                    txtL[i] = new TextBox();
                    txtL[i].Size = new Size(70, 50);
                    txtL[i].Location = new Point(120, 100 + (50) + (i * 30));
                    txtL[i].BackColor = Color.WhiteSmoke;
                    txtL[i].Name = $"txt_subL{i}";
                    txtL[i].Text = $"LAN{i + 1}";
                    this.Controls.Add(txtL[i]);
                }
            }
            catch (Exception ec)
            {
                MessageBox.Show("Datos ingresados incorrectamente");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Crear archivo PDF
                FileStream pdf = new FileStream(@"C:\Users\User\Desktop\PDFVLSM.pdf", FileMode.Create);
                Document doc = new Document(PageSize.LETTER, 20, 20, 20, 20);
                PdfWriter pw = PdfWriter.GetInstance(doc, pdf);
                doc.Open();

                // Título
                iTextSharp.text.Font titleFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                Paragraph title = new Paragraph("Resultados de Subnetting VLSM", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                title.SpacingAfter = 20;
                doc.Add(title);

                // Fuente estándar para texto
                iTextSharp.text.Font textFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                // Agregar la primera sección (binarios y datos)
                string[] lines = txt_resultado.Text.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in lines)
                {
                    if (line.StartsWith("LAN")) break; // Detener antes de la sección LAN
                    Paragraph p = new Paragraph(line, textFont);
                    doc.Add(p);
                }

                // Espaciado
                doc.Add(new Paragraph("\n"));

                // Agregar la sección de detalles por LAN
                iTextSharp.text.Font lanFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD, BaseColor.BLUE);
                foreach (var line in lines)
                {
                    if (line.StartsWith("LAN"))
                    {
                        Paragraph lanTitle = new Paragraph(line, lanFont);
                        lanTitle.SpacingBefore = 10;
                        lanTitle.SpacingAfter = 5;
                        doc.Add(lanTitle);
                    }
                    else if (line.Contains(":"))
                    {
                        Paragraph detail = new Paragraph(line, textFont);
                        doc.Add(detail);
                    }
                }

                // Cerrar documento
                doc.Close();
                pw.Close();
                pdf.Close();

                MessageBox.Show("PDF generado con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pdf no creado");
            }

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.txt_resultado.Text = "";
            this.hosts = null;
            this.lanes= null;
            for (int i = 0; i < this.subredes; i++) {
                this.Controls.Remove(txtH[i]);
                this.Controls.Remove(txtL[i]);
            }
            this.txtH = null;
            this.txtL = null;
        }
    }
}
