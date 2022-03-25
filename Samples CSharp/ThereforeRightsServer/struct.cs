using System;
using System.Collections;

namespace Therefore
{
    public struct TheUserStruct
    {
        public int nUserNo;
        public string strUserName;
        public int[] anGroupList;

        public TheUserStruct(object oUser)
        {
            object[] aoUser = (object[])oUser;
            nUserNo = (int)aoUser[0];
            strUserName = (string)aoUser[1];

            object[] aoGroupList = (object[])(aoUser[2]);

            int[] temp = new int[aoGroupList.Length];
            for (int i = 0; i < aoGroupList.Length;i++ )
                temp[i] = (int)(aoGroupList[i]);
            anGroupList = temp;
        }
    }

    public struct TheIndexDataStruct
    {
        public string strCtgryName;
        public int nCtgryNo;
        public int nDocNo;
        public ArrayList aIndexData;

        public TheIndexDataStruct(object oIndexData)
        {
            object[] aoIndexData = (object[])oIndexData;
            strCtgryName = (string)aoIndexData[0];
            nCtgryNo = (int)aoIndexData[1];
            nDocNo = (int)aoIndexData[2];

            ArrayList temp = new ArrayList();
            //read all index data values
            object[] oaIxDataValues = (object[])aoIndexData[4];
            for (int i = 0; i < oaIxDataValues.Length; i++)
            {
                //get 4.n
                object[] objFieldVal = (object[])oaIxDataValues[i];
                //get 4.n.0
                string strIndexName = (string)objFieldVal[0];

                //get 4.n.1             
                if (objFieldVal[1] == null)
                    objFieldVal[1] = "";

                string strFieldValue = objFieldVal[1].ToString();
                
                string[] pair = {strIndexName,strFieldValue};
                temp.Add(pair);
            }
            aIndexData = temp;
        }
    }
}