using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Lesson5.Adapter
{
    public class ExampleWithDictionary : MonoBehaviour
    {
        private Dictionary<int, string> _myDictionary = new Dictionary<int, string>()
        {
            [1] = "Hello",
            [14] = "Buy",
        };
        
        public List<MyIntStringPair> MyDictionary
        {
            get
            {
               return _myDictionary.Select(pair => new MyIntStringPair() {key = pair.Key, value = pair.Value,}).ToList();
            }
            set => _myDictionary = value.ToDictionary(item=> item.key, item => item.value);
        }

        [Serializable]
        public class MyIntStringPair
        {
            public int key;
            public string value;
        }
    }
}