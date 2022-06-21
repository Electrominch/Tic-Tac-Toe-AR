using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackMusic : MonoBehaviour
{
    private AudioSource m_AudioSource;
    [SerializeField] private AudioClip m_Clip;

    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
        
    }

    private void Start()
    {
        if (PlayerData.Settings.Music)
            StartMusic();
    }

    public void StartMusic()
    {
        if (m_Clip == null)
            return;
        m_AudioSource.Stop();
        m_AudioSource.clip = m_Clip;
        m_AudioSource.time = Random.Range(0, m_Clip.length);
        m_AudioSource.Play();
    }

    public void StopMusic()
    {
        m_AudioSource.Stop();
    }
}
