using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
