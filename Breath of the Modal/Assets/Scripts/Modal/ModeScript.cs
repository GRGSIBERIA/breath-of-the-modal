using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeScript
{
    public int Register { get; private set; }

    public ModeScript(int register, KeyScript key)
    {
        Register = key.GetMajorMinor()[register];
    }
}
