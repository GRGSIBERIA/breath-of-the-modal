using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChordScript
{
    public int Value { get; private set; }

    public int[] Series { get; private set; }

    public ChordScript(int register, KeyScript key)
    {
        register %= 8;

        key.GetMajorMinor().CopyTo(Series, 0);

        for (int i = 0; i < Series.Length; ++i)
            Series[i] = (Series[i] + Series[register]) % 12;
    }
}
