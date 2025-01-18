using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLSM
{
    internal class VLSM
    {

        //usado en visual para el tamaño de los lanes y hosts
        public int subredes;
        public string[] lanes;
        public int[] hosts;
        public object[] numh;

        public VLSM(int subredes, int[] hosts, string[] lanes)
        {
            this.hosts = hosts;
            this.lanes = lanes;
            numh = new object[subredes];
            Burbuja(numh);
            CalcularBits();
        }
        public object[] Calculo(object[] arreglo)
        {
            int a = (int)((object[])numh[Escoger()])[0];
            if (((int)arreglo[1]) + a == 32 && Comprobar())
            {
                (arreglo[2]) = true;
                ((object[])numh[Escoger()])[1] = true;
            }
            else if (((int)arreglo[1]) + a < 32 && Comprobar())
            {
                if ((arreglo[3] == null) && (arreglo[4] == null))
                {
                    NuevaIp(arreglo);
                }
            }
            return arreglo;
        }
        public void NuevaIp(object[] arreglo)
        {
            if (Comprobar())
            {
                //Crear dos ip 
                ///<Aumentar> el bit asignado a la siguiente ip
                int redExt = ((int)((object)arreglo[1]) + 1);
                ///<Colocar> bits de 0 a 1 en la 2da ip hija
                int redExt1 = ((int)((object)arreglo[1]));
                ///<Copiar> la ip padre sin pasar la direccion de memoria directamente
                StringBuilder cop1 = new StringBuilder((arreglo[0]).ToString());
                StringBuilder cop2 = new StringBuilder((arreglo[0]).ToString());
                //cambiar bit de 2da hija 
                StringBuilder ext = (cop2);
                ext[redExt1] = '1';

                arreglo[3] = Crear(cop1, redExt);
                arreglo[4] = Crear(ext, redExt);

                if (arreglo[3] != null && (bool)((object[])arreglo[3])[2] == false) { Calculo(((object[])arreglo[3])); }
                if (arreglo[4] != null && (bool)((object[])arreglo[4])[2] == false) { Calculo(((object[])arreglo[4])); }
            }

        }
        public void Burbuja(Object[] obj)
        {
            // Console.WriteLine(((Object[])obj[0])[0]);
            int auxI;
            string auxS;
            for (int i = 0; i < this.hosts.GetLength(0) - 1; i++)
            {
                auxI = 0;
                auxS = "";
                for (int j = i + 1; j < this.hosts.GetLength(0); j++)
                {
                    if (hosts[j] > hosts[i])
                    {
                        //cambio de lanes y hosts
                        auxI = hosts[i]; auxS = lanes[i];
                        hosts[i] = hosts[j]; lanes[i] = lanes[j];
                        hosts[j] = auxI; lanes[j] = auxS;
                        i = 0;

                    }
                }
            }
        }
        public object[] Crear(StringBuilder ip, int red)
        {
            return new object[5] { ip, red, false, null, null };
        }
        public int Escoger()
        {
            //Metodo que devuelve la potencia siguiente a ser cogida  
            int num = 0;
            for (int i = 0; i < numh.GetLength(0); i++)
            {
                if ((bool)((object[])numh[i])[1] == false)
                {
                    num = i; return num;
                }
            }
            return num;
        }
        //ip red cogido siguiente0 siguiente1
        public bool Comprobar()
        {
            //Meotod que devuelve la potencia siguiente a ser cogida              
            for (int i = 0; i < numh.GetLength(0); i++)
            {
                if ((bool)((object[])numh[i])[1] == false)
                {
                    return true;
                }
            }
            return false;
        }


        public void CalcularBits()
        {
            int a, b;
            bool com;
            //metodo que da los bits por escoger dentro de cada ip 
            for (int i = 0; i < this.numh.Length; i++)
            {
                a = 1;
                b = 0;
                com = true;
                while (com)
                {
                    ///bit,cogido,nombreLan
                    if (a - 2 >= ((int)this.hosts[i]))
                    {
                        numh[i] = new object[3] { b, false, lanes[i] };
                        com = false;
                    }
                    a *= 2;
                    b++;
                }
            }
        }
        //ip red cogido siguiente0 siguiente1/
        string res1="";
        public string Imprimir(string esp, object[] obj)
        {
            //Metodo para imprimir en visual con recursividad
            if (obj != null)
            {
                this.res1 += ($"{esp} {Puntos(obj[0].ToString())} {BinariDecimalCompleto((StringBuilder)obj[0])}   /{obj[1]}   {Verificado(obj[2])} \r\n");                
                esp += " ";                
                Imprimir(esp, (object[])obj[3]);
                Imprimir(esp, (object[])obj[4]);
            }            
            
            return res1;
        }
        public string Verificado(object obj)
        {
            if (((bool)obj)==true) { return "COGIDA"; }
            return "";
        }
        public StringBuilder Puntos(String str)
        {
            //metodo que separa por puntos
            StringBuilder str2 = new StringBuilder(str);
            for (int i = 0;i< str.Length; i++)
            {
                if (i == 8 || i == 17 || i == 26) {
                    str2.Insert(i,'.');
                }
            }
            return str2;
        }
        string res2 = "";
        int lim = 0;
        public string Resultados(object[] obj)
        {
            //imprime para visual
            if ((bool)obj[2] == true)
            {
                res2 += ($"{lanes[lim]}        {((object[])numh[lim])[0]}  \r\n" +
                    $"Red:            {BinariDecimalCompleto(Limites(obj)[0])} \r\n" +
                    $"Primera Ip: {BinariDecimalCompleto(Limites(obj)[1])} \r\n" +
                    $"Ultima Ip:   {BinariDecimalCompleto(Limites(obj)[2])} \r\n" +
                    $"Broadcast:  {BinariDecimalCompleto(Limites(obj)[3])} \r\n"+
                    $"Mascara:  {BinariDecimalCompleto(Limites(obj)[4])} \r\n" +
                    $"\r\n");
                lim++;
            }
            else if ((object[])obj[3] != null && (object[])obj[4] != null)
            {
                Resultados((object[])obj[3]);
                Resultados((object[])obj[4]);
            }
            return res2;
        }

        public StringBuilder[] Limites(object[] obj)
        {
            //saca los limites de cada ip 
            StringBuilder[] met = new StringBuilder[5];

            //inicializacion
            for (int i = 0; i < met.Length; i++)
            {
                met[i] = new StringBuilder(obj[0].ToString());
                if (i== met.Length-1) { met[i] = new StringBuilder("00000000000000000000000000000000"); }
            }
            
            //red
            for (int j = (int)obj[1]; j < ((StringBuilder)obj[0]).Length; j++)
            {
                met[0][j] = '0';
            }
            //ip inicial
            for (int j = (int)obj[1]; j < ((StringBuilder)obj[0]).Length; j++)
            {
                met[1][j] = '0';
                if (j >= 31) { met[1][j] = '1'; }
            }
            //ip final
            for (int j = (int)obj[1]; j < ((StringBuilder)obj[0]).Length; j++)
            {
                met[2][j] = '1';
                if (j >= 31) { met[2][j] = '0'; }
            }
            //brodcast
            for (int j = (int)obj[1]; j < ((StringBuilder)obj[0]).Length; j++)
            {
                met[3][j] = '1';
            }
            //Mascara
            for (int j = 0; j < (int)obj[1]; j++)
            {
                met[4][j] = '1';
            }

            return met;
        }


        public StringBuilder BinariDecimalCompleto(StringBuilder str)
        {
            int ext;
            string uno = "";
            string dos = "";
            //metodo que devulve todo el string de binario a denical los 4 octetos
            for (int i = 0; i < str.Length; i++)
            {
                uno += str[i];
                if (i == 7 || i == 15 || i == 23 || i == 31)
                {
                    ext = Convert.ToInt32(uno, 2);
                    dos += ext;
                    if (i < 31) { dos += "."; }
                    uno = "";
                }
            }
            return new StringBuilder(dos);
        }
    }
}
