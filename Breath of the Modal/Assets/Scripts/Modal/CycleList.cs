using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CycleList
{
    int[] list;
    int index;

    public CycleList(int[] array)
    {
        list = array;
        index = 0;
    }

    public int Next()
    {
        index = (index + 1) % list.Length;
        return list[index];
    }

    public int Previous()
    {
        index = (index - 1) % list.Length;
        return list[index];
    }

    public int Reset()
    {
        index = 0;
        return list[index];
    }

    public int Present()
    {
        return list[index];
    }
}
