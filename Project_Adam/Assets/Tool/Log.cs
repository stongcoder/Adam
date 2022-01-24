using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Log
{
    public static void Print(System.Object mes)
    {
        Debug.Log(mes);
    }
    public static void PrintError(System.Object mes)
    {
        Debug.LogError(mes);
    }
}
