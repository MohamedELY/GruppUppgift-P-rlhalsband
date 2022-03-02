using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GruppUppgift_Pärlhalsband.InterfaceModel;
using GruppUppgift_Pärlhalsband.Model;

namespace GruppUppgift_Pärlhalsband.Model
{
    internal class Neackless
    {
        private List<IPearl> _listOfPearls = new List<IPearl>();
        public IPearl this [int idx] => this._listOfPearls[idx];
        public override string ToString()
        {
            string sRet = " ";
            int counter = 0;
            sRet = "\n~~~~ Neckles Informatio ~~~~\n";
            foreach (var item in _listOfPearls)
            {
                sRet += $"--------------------\nPearl number {counter++} {item}"; 
            }

            return sRet;
        }
        private Neackless(int amountOfPearls)
        {
            for (int i = 0; i < amountOfPearls; i++)
            {
                this._listOfPearls.Add(new Pearl());
            }
        }
        internal static class Factory
        {
            internal static Neackless RandomeNecklessData(int amountOfPearls)
            {
                return new Neackless(amountOfPearls);
            }
        }
        public void Sort()
        {
            _listOfPearls.Sort();
        }
        public int Search(Pearl pearl)
        {
            return _listOfPearls.IndexOf(pearl);
        }
    }
}
