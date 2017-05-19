using UnityEngine;

namespace NETAPI
{
    public class _BaseObject
    {
        public string _id;
        
        public _BaseObject(){}
        
        public string toJSON()
        {
            return JsonUtility.ToJson(this);
        }
    }
}