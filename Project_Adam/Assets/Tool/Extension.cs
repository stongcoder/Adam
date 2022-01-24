using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension 
{
    public static List<Transform> GetChildren(this Transform t)
    {
        var children=new List<Transform>();
        for(int i = 0; i < t.childCount; i++)
        {
            children.Add(t.GetChild(i));
        }
        return children;
    }
}
