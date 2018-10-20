using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public Sound[] sounds;

	public void Awake() {

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.loop = s.loop;
		}
	}

	public void Play(string name) {
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if (s != null)
		{
			s.source.Play();
		}
	}

	public void SetMusicVolume(float volume) {
		Sound s = Array.Find(sounds, sound => sound.name == "MainMenuTheme");
		s.source.volume = volume;
	}
}
