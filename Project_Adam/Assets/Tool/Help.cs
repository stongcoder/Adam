using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help
{
    public bool IsCollectionEmpty(ICollection collection)
    {
        return collection != null && collection.Count > 0;
    }
}
