using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Music {
	MAIN_MENU,
	GAMEPLAY
}

public enum Sound {
	ULTIMATE,
	GAME_OVER
}

public class SoundManager : Singleton<SoundManager> {
	public AudioClip sndMainMenu;
	public AudioClip sndGameplay;
	public AudioClip sndUltimate;
	public AudioClip sndHit;
	public AudioClip sndHitGirl;
	public AudioClip sndGameOver;

	public AudioSource	source;

	public static bool IsEnable{get{return !Instance.source.mute;}}
	
	protected override void Awake() {
        base.Awake();
        DontDestroyOnLoad(gameObject);

		source.mute = PlayerPrefs.GetInt("mute", 1) == 1 ? false : true;
	}

	public static void PlayMusic(Music music) {
		if (music == Music.MAIN_MENU) {
			Instance.source.clip = Instance.sndMainMenu;
			Instance.source.Play();
		}
		else if (music == Music.GAMEPLAY) {
			Instance.source.clip = Instance.sndGameplay;
			Instance.source.Play();
		}
	}

	public static void PlaySound(Sound sound) {
		if (sound == Sound.ULTIMATE) {
			Instance.source.PlayOneShot(Instance.sndUltimate);
		}
		else if (sound == Sound.GAME_OVER) {
			Instance.source.PlayOneShot(Instance.sndGameOver);
		}
	}

	public static void Stop() {
		Instance.source.Stop();
	}

	public static void OnOff(bool isOn)
	{
		Instance.source.mute = !isOn;
		PlayerPrefs.SetInt("mute", Instance.source.mute == true ? 0 : 1);
	}
}
