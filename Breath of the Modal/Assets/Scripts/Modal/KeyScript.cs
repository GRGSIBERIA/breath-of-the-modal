using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript
{
    readonly int[] MajorKeys = { 0, 2, 4, 5, 7, 9, 11 };
    readonly int[] MinorKeys = { 0, 2, 3, 5, 7, 8, 10 };

    public int[] Keys { get; private set; }

    int isTonic;
    int isRelative;
    
    public int Value { get; private set; }

    public KeyScript(int register, int isTonic, int isRelative)
    {
        register %= 12;

        this.isTonic = isTonic;
        this.isRelative = isRelative;
        Keys = new int[7];

        for (int i = 0; i < MajorKeys.Length; ++i)
        {
            Keys[i] = isTonic > 0 ? MinorKeys[i] : MajorKeys[i];

            if (isRelative > 0)
                Keys[i] += 9;

            Keys[i] %= 12;
        }

        Value = Keys[register];
    }

    public int[] GetMajorMinor()
    {
        return isTonic > 0 ? MinorKeys : MajorKeys;
    }
}
