using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Sound_Active : MonoBehaviour
{

    public AudioSource BGM;
    public AudioSource SFX;
    public AudioSource[] BGMList;
    public AudioSource[] SFXList;

    // Start is called before the first frame update
    void Start()
    {
        PlayBGM(1);
    }

    // Update is called once per frame
    void Update()
    {
        PlayBGM(1);
    }

    public void PlayBGM(int order)
    {
        //BGMList[order].Play();
    }

    public void PlaySFX(int order)
    {
        //SFXList.PlayOneShot();
    }
}
