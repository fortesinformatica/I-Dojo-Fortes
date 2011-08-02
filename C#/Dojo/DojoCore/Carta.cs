using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DojoCore
{
    public class Carta
    {
        public Carta(NumeroCarta numero, char naipe)
        {
            this.Numero = numero;
            this.Naipe = naipe;
        }
        public NumeroCarta Numero { get; set; }
        public char Naipe { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Carta)
            {
                var c = (Carta) obj;
                return this.Numero == c.Numero && this.Naipe == c.Naipe;
            }
            return base.Equals(obj);
        }
    }
}
