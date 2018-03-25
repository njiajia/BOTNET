using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetAudioLevels : MonoBehaviour {
	
	public AudioMixer mainMixer;					//Used to hold a reference to the AudioMixer mainMixer
	public Slider sfx, music;

	void Start(){
		sfx.value = PlayerPrefs.GetFloat("sfxSave");
		music.value = PlayerPrefs.GetFloat("musicSave");
	}

	//Call this function and pass in the float parameter musicLvl to set the volume of the AudioMixerGroup Music in mainMixer
	public void SetMusicLevel(float musicLvl)
	{
		mainMixer.SetFloat("musicVol", musicLvl);
		PlayerPrefs.SetFloat("musicSave", musicLvl);
		PlayerPrefs.Save();
	}
	
	//Call this function and pass in the float parameter sfxLevel to set the volume of the AudioMixerGroup SoundFx in mainMixer
	public void SetSfxLevel(float sfxLevel)
	{
		mainMixer.SetFloat("sfxVol", sfxLevel);
		PlayerPrefs.SetFloat("sfxSave", sfxLevel);
		PlayerPrefs.Save();
	}
}
