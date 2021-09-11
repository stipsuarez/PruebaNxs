using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaNxs.Webapi.Exeptions
{
    public class NoExistAutorException : Exception
    {
        public NoExistAutorException() : base("El autor no está registrado")
        {

        }

    }
}

    