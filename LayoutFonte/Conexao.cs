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
        private static string _ROTA = "";
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
              private static string _ROTA = "";
              public static string ROTA
              {
                  get { return _ROTA; }
                  set { _ROTA = value; }
              }
         */
    }
}
