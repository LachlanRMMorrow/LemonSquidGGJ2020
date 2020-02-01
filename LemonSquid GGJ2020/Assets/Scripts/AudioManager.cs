using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonBase<AudioManager>
{
    [SerializeField] private AudioClip m_approachinghomeonwner;
    [SerializeField] private AudioClip m_ceramicbreaking;
    [SerializeField] private AudioClip m_glassbreaking;
    [SerializeField] private AudioClip m_woodsplintering;
    [SerializeField] private AudioClip m_carapproaching;
    [SerializeField] private AudioClip[] m_dooropening = new AudioClip[2];
    [SerializeField] private AudioClip[] m_doorclosing = new AudioClip[4];
    [SerializeField] private AudioClip m_electricalsparking;
    [SerializeField] private AudioClip m_ducttapebeingapplied;
    [SerializeField] private AudioClip m_dundunaudio;
    [SerializeField] private AudioClip m_breadbreaking;
    [SerializeField] private AudioClip m_gasp;
    [SerializeField] private AudioClip m_BGM;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
