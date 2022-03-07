using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GruppUppgift_Pärlhalsband.InterfaceModel;

namespace GruppUppgift_Pärlhalsband.Model
{
    internal class Inventory
    {
        #region Class Properties and fields
        private List<INecklace> _ListofNecklace = new List<INecklace>();
        public INecklace this[int idx] => this._ListofNecklace[idx];
        public decimal Price
        {
            get
            {
                //_stringOfPearls.Sum(x => x.Price);
                var price = 0M;
                foreach (var p in _ListofNecklace)
                {
                    price += p.Price;
                }
                return price;
            }
        }
        #endregion

        #region Override and Methods
        public override string ToString()
        {
            string sRet = " ";
            int counter = 0;
            sRet = "\n~~~~====== Inventory Informatio ======~~~~\n";
            foreach (var item in _ListofNecklace)
            {
                sRet += $"--------------------\n\nNeckles number {counter++} {item}";
            }

            sRet += $"\n\nTotal Price of inventory:{this.Price}\n\nMost Expansive Pearl:\n{this.MostExpansivePerl()}\nAmount of black pearls: {this.AmountOfBlackPearls()}";
            sRet += "\n~~~~====== Inventory Informatio Done ======~~~~\n";
            return sRet;
        }
        public Pearl MostExpansivePerl()
        {
            var pearl = new Pearl(5, Colors.Black, Shapes.Dropp, Origins.SweetWater);
            foreach (var necklace in this._ListofNecklace)
            {
                for (int i = 0; i < necklace.Count(); i++)
                {
                    if(necklace[i].Price > pearl.Price)
                        pearl = new Pearl((Pearl)necklace[i]);
                }  
            }
            return pearl;
        }
        public int AmountOfBlackPearls()
        {
            int amountOfBlackPearls = 0;
            foreach (var necklace in this._ListofNecklace)
            {
                for (int i = 0; i < necklace.Count(); i++)
                {
                    if (necklace[i].Color > Colors.Black)
                        amountOfBlackPearls++;
                }
            }
            return amountOfBlackPearls;
        }
        #endregion

        #region Constructer and Factory
        private Inventory(int amountOfNecklaces, int amountOfPerlsPerNecklaces)
        {
            for (int i = 0; i < amountOfNecklaces; i++)
            {
                this._ListofNecklace.Add(Neacklace.Factory.RandomeNecklessData(amountOfPerlsPerNecklaces));
            }
        }
        public Inventory()
        {

        }
        internal static class Factory
        {
            internal static Inventory RandomeInventoryData(int amountOfNecklaces, int amountOfPerlsPerNecklaces)
            {
                var randomeInventory = new Inventory();
                for (int i = 0; i < amountOfNecklaces; i++)
                {
                    randomeInventory._ListofNecklace.Add(Neacklace.Factory.RandomeNecklessData(amountOfPerlsPerNecklaces));
                }
                return randomeInventory;
            }
        }
        #endregion
    }
}
