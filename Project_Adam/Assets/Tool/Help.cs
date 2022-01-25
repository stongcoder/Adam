using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Help
{
    public static List<Vector2> FourDirs = new List<Vector2>()
    {
        Vector2.up,
        Vector2.down,
        Vector2.left,
        Vector2.right,
    }; 
    public static List<Vector3> SixDirs = new List<Vector3>()
    {
        Vector3.up,
        Vector3.down,
        Vector3.left,
        Vector3.right,
        Vector3.forward,
        Vector3.back,
    };
    public static bool IsCollectionEmpty(ICollection collection)
    {
        return collection != null && collection.Count > 0;
    }
    public static Vector2 GetFourDir(FourDirection dir)
    {
        if (!Help.CheckEnumVal((int)dir))
        {
            return Vector2.zero;
        }
        return FourDirs[((int)dir) - 1];
    }
    public static Vector3 GetSixDir(SixDirection dir)
    {
        if (!Help.CheckEnumVal((int)dir))
        {
            return Vector3.zero;
        }
        return SixDirs[((int)dir) - 1];
    }
    public static bool CheckEnumVal(int num)
    {
        if(num == 0)
        {
            Log.PrintError("Ã¶¾ÙÎªnone");
            return false;
        }
        return true;
    }
}
