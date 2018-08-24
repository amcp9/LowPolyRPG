using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 泛型单例模板，需要挂载到游戏物体
/// </summary>
public class SingletonRef<T> : MonoBehaviour where T:SingletonRef<T>,new()
{
    public static object sync = new object();
    private static T instance;
    public static T Instance
    {
        get
        {

            return instance;
        }
    }
}
