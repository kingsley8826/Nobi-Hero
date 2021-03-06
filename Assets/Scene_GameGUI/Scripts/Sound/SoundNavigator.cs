using UnityEngine;
using System.Collections;

public class SoundNavigator : MonoBehaviour {

    public static SoundNavigator instance;

    [SerializeField]
    public AudioSource audioSource;

    [SerializeField]
    public AudioClip scenceNavigatorClip;

    void Awake()
    {
        if (instance == null)
            instance = this;
        audioSource.clip = scenceNavigatorClip;
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
