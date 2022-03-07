using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GruppUppgift_Pärlhalsband.InterfaceModel;
using GruppUppgift_Pärlhalsband.Model;

namespace GruppUppgift_Pärlhalsband.Model
{
    internal class Neacklace : INecklace
    {
        #region Class Properties and fields
        private List<IPearl> _stringOfPearls = new List<IPearl>();
        public IPearl this [int idx] => this._stringOfPearls[idx];
        public decimal Price
        {
            get
            {
                //_stringOfPearls.Sum(x => x.Price);
                var price = 0M;
                foreach (var p in _stringOfPearls)
                {
                    price += p.Price;
                }
                return price;
            }
        }
        #endregion    

        #region Methods
        public void Sort()
        {
            _stringOfPearls.Sort();
        }
        public int Search(Pearl pearl)
        {
            return _stringOfPearls.IndexOf(pearl);
        }
        public int Count() => _stringOfPearls.Count;

        #endregion

        #region Override of methods
        public override string ToString()
        {
            string sRet = " ";
            int counter = 0;
            sRet = "\n~~~~ Neckles Informatio ~~~~\n";
            foreach (var item in _stringOfPearls)
            {
                sRet += $"--------------------\nPearl number {counter++} {item}"; 
            }

            return sRet;
        }
        #endregion

        #region Constructer and Factory
        private Neacklace(int amountOfPearls)
        {
            for (int i = 0; i < amountOfPearls; i++)
            {
                this._stringOfPearls.Add(new Pearl());
            }
        }
        internal static class Factory
        {
            internal static Neacklace RandomeNecklessData(int amountOfPearls)
            {
                return new Neacklace(amountOfPearls);
            }
        }
        #endregion
    }
}
