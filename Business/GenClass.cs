using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHair.Business
{
    class GenClass
    {
        public string[] strSplit(string strStoreTemp)
        {
            string strTemp = "";
            string[] strStore = strStoreTemp.Split(',');
            //int intCurrent = 0;
            if (strStoreTemp.Substring(0, 1) != null && strStoreTemp.Substring(0, 1) != "")
            {
                for (int i = 0; i < strStoreTemp.Length; i++)
                {
                    if (strStoreTemp.Substring(i, 1) != ",")
                    {
                        strTemp = strTemp + strStoreTemp.Substring(i, 1);
                        //intCurrent = intCurrent + 1;
                    }
                    else
                    {
                        if (strTemp != "")
                        {
                            for (int x = 0; x < strStoreTemp.Length; x++)
                            {
                                //strStore[x] = strTemp;
                            }
                        }
                        strTemp = "";
                    }
                }
            }
            return strStore;
        }
    }
}
