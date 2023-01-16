using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ConsultaCEP.Data
{
    public class Connection
    {
        public string GetPath() =>
            Program.Configuration.GetValue<string>("txt_Filepath");


        public string[] ReadFile()
        {
            try
            {
                var path = GetPath();

                return File.ReadAllLines(path);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao ler arquivo: " + ex.Message, ex);
            }
        }
    }
}