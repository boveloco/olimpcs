using System.Collections.Generic;
using NETAPI;
using UnityEngine;

namespace NETAPI
{
    public class ControlQueue : MonoBehaviour
    {

        private _BaseObject obj;
        private List<MyQueue> filas;


        void Start()
        {
            filas = new List<MyQueue>();

        }

        public void log()
        {
            foreach (var que in filas)
            {
                Debug.Log(que.toJSON());

            }
        }

        public void log(MyQueue q)
        {
            Debug.Log(q.toJSON());
        }

        public void addQueue(MyQueue queue)
        {
            filas.Add(queue);
        }

    }
}