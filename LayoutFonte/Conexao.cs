using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LayoutFonte
{
    class Conexao
    {
        private static string _filial = "06";
        public static string filial
        {
            get { return _filial; }
            set { _filial = value; }
        }
        private static string _ROTA = "Data Source = 192.168.108.16\\SQLEXPRESS; Initial Catalog = ROTA; Persist Security Info=True;User ID = crud; Password=2B2XWXMV";
        public static string ROTA
        {
            get { return _ROTA; }
            set { _ROTA = value; }
        }
        /*
       
        private static string _filial = "49";
        public static string filial
        {
            get { return _filial; }
            set { _filial = value; }
        } 
              private static string _ROTA = "Data Source = 192.168.149.5\\SQLEXPRESSMAO49; Initial Catalog = SMT; Persist Security Info=True;User ID = crud1; Password=2B2XWXMV";
              public static string ROTA
              {
                  get { return _ROTA; }
                  set { _ROTA = value; }
              }
         */
    }
}
