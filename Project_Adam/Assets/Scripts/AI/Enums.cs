using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 namespace AI
{
    public enum TickResult
    {
        Running,
        Ended,
    }
    public enum ActionStatus
    {
        Ready,
        Running,
    }

}

public enum FourDirection
{
    None,
    Up,
    Down,
    Left,
    Right,
}
public enum EightDirection
{
    None,
    Up,
    Down,
    Left,
    Right,
    UpLeft,
    UpRight,
    DownLeft,
    DownRight,
}
public enum SixDirection
{
    None,
    Up,
    Down,
    Left,
    Right,
    Foward,
    Backward,
}
public enum NumCompare
{
    LessThan,
    LessEqualThan,
    GreaterThan,
    GreaterEqualThan,
    EqualTo,
    NotEqualTo,
}
public enum NullCompare
{
    IsNull,
    NotNull,
}
public enum EqualCompare
{
    Equal,
    NotEqual,
}