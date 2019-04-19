using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChordScript
{
    public int Value { get; private set; }

    public ChordScript(int register, KeyScript key)
    {
        Value = key.GetMajorMinor()[register];
    }
}
