using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 泛型单例模板,不需要挂载至游戏物体
/// </summary>
public class Singleton <T> : MonoBehaviour where T:MonoBehaviour
{
    public static object sync = new object();
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                lock (sync)
                {
                    T[] instances = FindObjectsOfType<T>();
                    if (instances != null)
                    {
                        for (int i = 0; i < instances.Length; i++)
                        {
                            Destroy(instances[i].gameObject);
                        }
                    }
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    instance = obj.AddComponent<T>();
                    DontDestroyOnLoad(obj);
                }
            }
            return instance;
        }
    }
}
