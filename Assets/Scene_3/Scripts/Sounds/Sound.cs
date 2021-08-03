using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {

	public static Sound instance;

	[SerializeField]
	public AudioSource audioSource;

	[SerializeField]
	public AudioClip playerShootClip, playerDeadClip, honeyDeadClip, SenceClip, honeyShootClip, beanExplosionClip,
                    playerEatCoinclip;

	void Awake() {
		if (instance == null)
			instance = this;
		////audioSource.clip = SenceClip;
		//audioSource.loop = true;
		//audioSource.Play();
	}

	/*void Update() {
		if (Type.isSenceMute)
			audioSource.volume = 0.3f;
		else
			audioSource.volume = 0f;
	}*/

    public void playPlayerEatCoinClip()
    {
        if (Type.isEffectMute)
        {
            audioSource.PlayOneShot(playerEatCoinclip);
        }
    }

    public void playBeanExplosionClip() {
		if (Type.isEffectMute) {
			audioSource.PlayOneShot (beanExplosionClip);
		}
	}

	public void playPlayerShootClip() {
		if (Type.isEffectMute) {
			audioSource.PlayOneShot (playerShootClip);
		}
	}

	public void playPlayerDeadClip() {
		if (Type.isEffectMute) {
			audioSource.PlayOneShot (playerDeadClip);
		}
	}

	public void playEnemyDeadClip() {
		if (Type.isEffectMute) {
			audioSource.PlayOneShot (honeyDeadClip);
		}
	}

	public void playEnemyShootClip() {
		if (Type.isEffectMute) {
			audioSource.PlayOneShot (honeyShootClip);
		}
	}

	// Use this for initialization
	void Start () {

	}
		
}
