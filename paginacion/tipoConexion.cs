using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaFalda
{
    class tipoConexion
    {
        private static int variable = 0;

        public static int tipoconn
        {
            get { return variable; }
            set { variable = value; }
        }
    }
}