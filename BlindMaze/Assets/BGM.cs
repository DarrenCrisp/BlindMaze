using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour {
    private AudioSource bgm;
    private bool finished = false;
    public PlayerCharacter pc;
    private int pitchstage=0;
	// Use this for initialization
	void Start () {
        bgm = GetComponent<AudioSource>();		
	}
	
	// Update is called once per frame
	void Update () {
        if(pc.RemainingGT() >= pc.gameTime)
        {
            finished = true;
            bgm.pitch = 1;
        }
        // bgm.pitch = 1 + (pc.RemainingGT() / pc.gameTime);
        if (!finished)
        {
            if (pc.RemainingGT() >= pc.gameTime / 2)
            {
                if (pitchstage == 0)
                {
                    bgm.pitch = 1 + (pc.RemainingGT() / pc.gameTime);
                    pitchstage++;
                }
            }
            if (pc.RemainingGT() >= pc.gameTime / 1.5)
            {
                if (pitchstage == 1)
                {
                    bgm.pitch = 1.14f + (pc.RemainingGT() / pc.gameTime);
                    pitchstage++;
                }
            }
        }
    }
}
