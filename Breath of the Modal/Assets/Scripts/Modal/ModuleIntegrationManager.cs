using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 各モジュールを統合して管理するためのマネージャ
/// </summary>
public class ModuleIntegrationManager : MonoBehaviour {

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

    
	
	// Update is called once per frame
	void Update ()
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

        KeyScript key = new KeyScript(keyManager.Register, (modulationManager.Register & 1) > 0 ? 1 : 0, (modulationManager.Register & 2) > 0 ? 1 : 0);
        ChordScript chord = new ChordScript(chordManager.Register, key);
	}
}
