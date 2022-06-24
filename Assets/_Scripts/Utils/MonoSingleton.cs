using System;
using System.Linq;
using UnityEngine;

namespace ShockSprint.Utils
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    ////try to find components on scene:
                    T[] instans = FindObjectsOfType<T>();

                    if (instans.Length == 1)
                    {
                        _instance = instans.First();
                    }
                    else if (instans.Length == 0)
                    {
                        //if search fail then we create a gameObject and attach our component to it.
                        GameObject singleton = new GameObject(name: "Singleton");
                        _instance = singleton.AddComponent<T>();
                    }
                    else if (instans.Length > 1)
                    {
                        throw new InvalidOperationException("Too much type of " + typeof(T) + " found on scene. It must be the single!");
                    }

                    //save our singleton
                    DontDestroyOnLoad(_instance.gameObject);
                }

                return _instance;
            }
        }
    }
}