using UnityEngine;
using System.Collections;

public class SoundSence : MonoBehaviour
{
    public static SoundSence instance;

    [SerializeField]
    public AudioSource audioSource;

    [SerializeField]
    public AudioClip SenceClip;

    void Awake()
    {
        if (instance == null)
            instance = this;
        audioSource.clip = SenceClip;
        audioSource.loop = true;
        audioSource.Play();
    }

    void Update()
    {
        if (Type.isSenceMute)
            audioSource.volume = 0.3f;
        else
            audioSource.volume = 0f;
    }

}
