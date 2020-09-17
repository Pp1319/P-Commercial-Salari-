using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace P001_V2
{
    public class Commercial : Salarie
    {
        private double _ca;
        private decimal _commission;
        public Commercial(string nom, string prenom, string matricule, decimal salaireBrut, double ca, decimal commission)
            : base (nom, prenom, matricule)
        {
           : this(

        }
        public Commercial(Commercial commercial)
        {

        }
        public double Ca
        {
            get { return (this._ca); }
            set
            {
                _ca = value;

            }


        }
        public decimal Commission
        {
            get { return (this._commission); }
            set
            {
                _commission = value;

            }
        }
    }
}
