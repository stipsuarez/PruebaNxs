using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaNxs.Webapi.Exeptions
{
    public class ToMuchLibrosException : Exception
    {
        public ToMuchLibrosException() : base("No es posible registrar el libro, se alcanzó el máximo permitido.")
        {

        }

    }
}

    