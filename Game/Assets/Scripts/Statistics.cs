using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Statistics 
{
    //public static int RecordCount { get; private set;}
    public static int GameCount { get; private set; }
    
    public static Action<int> UpdateGameCount;
    public static void AddCount(int count)
    {
        GameCount += count;
        UpdateGameCount?.Invoke(count);
    }
}
