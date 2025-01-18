using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comandos
{
    internal class Cmd
    {
        string command;

        public Cmd(string command)
        {
            this.command = command;
        }

        public string ExecuteCommand()
        {            
            ProcessStartInfo processInfo = new ProcessStartInfo("cmd", "/c " + this.command);
            processInfo.RedirectStandardOutput = true; 
            processInfo.RedirectStandardError = true;  
            //processInfo.UseShellExecute = false;       
            processInfo.CreateNoWindow = true;         
            
            Process process = new Process();
            process.StartInfo = processInfo;
            process.Start();
            
            string output = "";
            while (!process.StandardOutput.EndOfStream)
            {
                string line = process.StandardOutput.ReadLine();
                output += line + "\r\n";  
               //Console.WriteLine(line); 
            }

            process.WaitForExit(); 
            return output; 
        }
    }
}
