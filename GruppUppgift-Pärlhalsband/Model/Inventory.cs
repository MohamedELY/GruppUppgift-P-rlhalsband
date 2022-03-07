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
        #endregion

        #region Override of methods
        public override string ToString()
        {
            string sRet = " ";
            int counter = 0;
            sRet = "\n~~~~====== Inventory Informatio ======~~~~\n";
            foreach (var item in _ListofNecklace)
            {
                sRet += $"--------------------\n\nNeckles number {counter++} {item}";
            }
            sRet += "\n~~~~====== Inventory Informatio Done ======~~~~\n";
            return sRet;
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
