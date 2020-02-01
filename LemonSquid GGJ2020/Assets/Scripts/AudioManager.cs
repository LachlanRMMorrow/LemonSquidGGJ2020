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
    [SerializeField] private AudioClip m_BGM1;
    [SerializeField] private AudioClip m_BGM2;
    [SerializeField] private AudioClip m_winkazoo;

    [SerializeField] private AudioClip m_recordScreech;



    [SerializeField] private AudioSource m_source;
    [SerializeField] private AudioSource m_BGMsource;

    // Start is called before the first frame update
    void Start()
    {
        
        m_BGMsource.loop = true;
        //m_source = GetComponent<AudioSource>();
        BGMManager(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerScreech()
    {
        StartCoroutine(DelayPlay());
    }

    IEnumerator DelayPlay()
    {
        yield return new WaitForSeconds(1);
        m_source.PlayOneShot(m_recordScreech);
        BGMManager(2);
    }

    public void PlayKazooForRealzies() 
    {
        WinAudio();
    }

    IEnumerator WinAudio() 
    {
        m_source.PlayOneShot(m_winkazoo);
        yield return new WaitForSeconds(3);
        Application.Quit();
    }

    public void BGMManager (int BGMTrack) 
    {
        switch (BGMTrack) 
        {
            case 1:
                m_BGMsource.clip = m_BGM1;
                break;
            case 2:
                m_BGMsource.clip = m_BGM2;
                break;
        }
        m_BGMsource.Play();
    }
}
