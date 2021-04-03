using System.Reflection;
using System;
using System.Collections.Generic;

namespace General.MessageBroker
{
    public static class SimpleMessageBroker
    {
        private static readonly Dictionary<string, Dictionary<string, Dictionary<int, SubscriberInfo>>> messageBrokerMap
            = new Dictionary<string, Dictionary<string, Dictionary<int, SubscriberInfo>>>();
        
        public static void Subscribe<T>(string id, Action<T> callback) => SubscribeInternal<T>(id, callback);

        public static void Subscribe<T>(Action<T> callback) => SubscribeInternal<T>(String.Empty, callback);

        private static void SubscribeInternal<T>(string id, Action<T> callback)
        {
            var typeKey = typeof(T).ToString();
            if (!messageBrokerMap.ContainsKey(typeKey))
            {
                messageBrokerMap.Add(typeKey, new Dictionary<string, Dictionary<int, SubscriberInfo>>());
            }

            if (!messageBrokerMap[typeKey].ContainsKey(id))
            {
                messageBrokerMap[typeKey].Add(id, new Dictionary<int, SubscriberInfo>());
            }

            var callbackHashCode = callback.GetHashCode();
            if (!messageBrokerMap[typeKey][id].ContainsKey(callbackHashCode))
            {
                var subData = new SubscriberInfo()
                {
                    target = callback.Target,
                    methodCallback = callback.Method
                };

                messageBrokerMap[typeKey][id].Add(callbackHashCode, subData);
            }
        }
        
        public static void Publish<T>(string id, T data) => PublishInternal<T>(id, data);

        public static void Publish<T>(T data) => PublishInternal<T>(String.Empty, data);

        private static void PublishInternal<T>(string id, T data)
        {
            var typeKey = typeof(T).ToString();
            if (!messageBrokerMap.ContainsKey(typeKey)) return;
            if (!messageBrokerMap[typeKey].ContainsKey(id)) return;
            
            Dictionary<int, SubscriberInfo> subscribers = messageBrokerMap[typeKey][id];
            foreach (var item in subscribers.Values)
            {
                item.methodCallback.Invoke(item.target, new object[] { data });
            }
        }

        public static void Unsubscribe<T>(string id, Action<T> callback) => UnsubscribeInternal<T>(id, callback);

        public static void Unsubscribe<T>(Action<T> callback) => UnsubscribeInternal<T>(String.Empty, callback);

        private static void UnsubscribeInternal<T>(string id, Action<T> callback)
        {
            var typeKey = typeof(T).ToString();
            if (!messageBrokerMap.ContainsKey(typeKey)) return;
            if (!messageBrokerMap[typeKey].ContainsKey(id)) return;
            
            var callbackHashCode = callback.GetHashCode();
            if (messageBrokerMap[typeKey][id].ContainsKey(callbackHashCode))
            {
                messageBrokerMap[typeKey][id].Remove(callbackHashCode);
            }
        }
    }

    internal class SubscriberInfo
    {
        public object target;
        public MethodInfo methodCallback;
    }
}