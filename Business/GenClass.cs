using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHair.Business
{
    class GenClass
    {
        public string strSplit(string strStoreTemp)
        {
            string strResult = "";
            string[] strStore = strStoreTemp.Split(',');
            if (strStore[0] != "" && strStore[0] != null && strStore.Length > 1)
            {
                for (int i = 0; i < strStoreTemp.Length - 1; i++)
                {
                    strResult = strResult + "'" + strStore[i] + "',";
                }
            }
            else
            {
                strResult = strResult + "'" + strStore[0] + "'";
            }
            if(strResult.Substring(strResult.Length - 1)==",")
            {
                strResult = strResult.Substring(0, strResult.Length - 2);
            }
            return strResult;
        }

        public Boolean boolStore(string strStore,string strStoreGroup)
        {
            Boolean boolResult = false;
            string[] strTemp = strStoreGroup.Split(',');
            if(strTemp.Length==1 && strStore==strTemp[0])
            {
                boolResult = true;
            }
            else
            {
                if(strTemp.Length>1)
                {
                    for(int i=0;i<strTemp.Length-1;i++)
                    {
                        if(strTemp[i]==strStore)
                        {
                            boolResult = true;
                            break; 
                        }
                    }
                }
            }
            return boolResult;
        }
    }
}
