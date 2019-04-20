using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeScript
{
    public int[] Series { get; private set; }

    public ModeScript(int register, KeyScript key, ChordScript chord)
    {
        register %= 8;

        int[] majmin = key.GetMajorMinor();
        int[] source = new int[majmin.Length];
        
        majmin.CopyTo(source, 0);

        // キーを回転させる
        for (int i = 0; i < Series.Length; ++i)
        {
            Series[i] = source[(i + register) % Series.Length];
        }

        // キーを回転させてコードと足し合わせる

        // 全部間違えてるから作り直したほうがいいかもしれない
    }
}
