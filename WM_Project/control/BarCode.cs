using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionPlus
{
    class BarCode
    {
        private string Prfix;
        private string TAC;
        private string TacSequnceNumber;
        private string CountryCode;
        private string Zero;
        private string DepotNumber;
        private string FullName;
        public BarCode(string TACSequnceNumber)
        {
              /*
             * 1 PREFIX
             * 234 TAC
             * 5  6  7  8  9  10  11  12  TACSequnceNumber
             * 13 CountryCode
             * 14  
             *15  16 DepotNumber
             */


            //ROUTE DEPOT NUMBER
            //025

            //DEPOT SHORT NAME
            //SAND

            //BARCODE CHARACTERS 1 TO 4
            //8M6W

            //BARCODE CHARACTERS 5 TO 12
            //INCREMENTING RAND FROM 10000000 TO 89999999

            //BARCODE CHARACTER 13
            //A

            //BARCODE CHARACTER 14 TO 16
            //025

            int temp;
            if (TACSequnceNumber != null)
            {
                 temp = int.Parse(TACSequnceNumber);
              if (temp < 10000000 || temp > 89999999)
              {
                  Console.WriteLine("Illegal TacSequnceNumber input");
              }

              else
              {
                  Prfix = "8";
                  TAC = "M6W";
                  TacSequnceNumber = TACSequnceNumber;
                  CountryCode = "A";
                  Zero = "0";
                  DepotNumber = "25";
                  this.FullName = this.Prfix + this.TAC + this.TacSequnceNumber + this.CountryCode + this.Zero + this.DepotNumber;
                  
                  Console.WriteLine(this.FullName);
              }
            }            

        }

        public string getBarcodeString()
        {
            return this.FullName;
        }
    }
}
