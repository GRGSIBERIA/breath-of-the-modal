using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 各モジュールを統合して管理するためのマネージャ
/// </summary>
public class ModuleIntegrationManager : MonoBehaviour
{
    public int concertNote = 36;

    public GameObject scaleModule;
    public GameObject keyModule;
    public GameObject chordModule;
    public GameObject modeModule;
    public GameObject octaveModule;
    public GameObject modulationModule;

    private ModuleManagerScript scaleManager;
    private ModuleManagerScript keyManager;
    private ModuleManagerScript chordManager;
    private ModuleManagerScript modeManager;
    private ModuleManagerScript octaveManager;
    private ModuleManagerScript modulationManager;

    private readonly int[] majorKey = new int[] { 0, 2, 4, 5, 7, 9, 11 };
    private readonly int[] minorKey = new int[] { 0, 2, 3, 5, 7, 8, 10 };

    public int Note { get; private set; }

    // Use this for initialization
    void Start ()
    {
        scaleManager = scaleModule.GetComponent<ModuleManagerScript>();
        keyManager = keyModule.GetComponent<ModuleManagerScript>();
        chordManager = chordModule.GetComponent<ModuleManagerScript>();
        modeManager = modeModule.GetComponent<ModuleManagerScript>();
        octaveManager = octaveModule.GetComponent<ModuleManagerScript>();
        modulationManager = modulationModule.GetComponent<ModuleManagerScript>();
	}

    int GetNote()
    {
        /**
         * 以下の順番で鳴らす音を決める
         * * modulation
         * * key
         * * chord
         * * mode
         * * octave
         * * scale
         * 各クラスのValueを参照して足し合わせた音を演奏する
         */
        int isTonic = (modulationManager.Register & 1) > 0 ? 1 : 0;
        int isRelative = (modulationManager.Register & 2) > 0 ? 1 : 0;

        int keyReg = keyManager.Register % 12;
        int chordReg = chordManager.Register % 7;
        int modeReg = modeManager.Register % 7;
        int octaveReg = Math.Abs(octaveManager.Register);
        int scaleReg = scaleManager.Register % 7;

        // 転調
        int[] basicKey = new int[7];
        if (isTonic > 0)
            minorKey.CopyTo(basicKey, 0);
        else
            majorKey.CopyTo(basicKey, 0);

        // 調を決める
        int addRelative = isRelative > 0 ? 9 : 0;
        int[] key = new int[7];
        for (int i = 0; i < 7; ++i)
            key[i] = basicKey[i] + addRelative + keyReg;

        // コードを決める
        var chordC = new CycleList(key);
        for (int i = 0; i < chordReg; ++i)
            chordC.Next();
        chordC.Previous();

        int[] chord = new int[7];
        for (int i = 0; i < 7; ++i)
            chord[i] = chordC.Next();

        // モードを決める
        var modeC = new CycleList(chord);
        for (int i = 0; i < modeReg; ++i)
            modeC.Next();
        modeC.Previous();

        int[] mode = new int[7];
        for (int i = 0; i < 7; ++i)
            mode[i] = modeC.Next();
        int modeZero = mode[0];
        for (int i = 0; i < 7; ++i)
            mode[i] = (mode[i] - modeZero) % 12;

        // ここで一旦、スケールを決める
        for (int i = 0; i < 3; ++i)
        {
            int id = i * 2;
            if (chord[id + 1] - chord[id] != mode[id + 1] - mode[id])
            {
                chord[id + 1] = chord[id + 1] - (mode[id + 1] - mode[id]);
            }
        }

        int addNote = 12 * octaveReg + concertNote;
        for (int i = 0; i < 7; ++i)
        {
            chord[i] %= 12;
            chord[i] += addNote;
        }
        Array.Sort(chord);

        return chord[scaleReg];
    }

    // Update is called once per frame
    void Update ()
    {
        Note = GetNote();
	}
}
