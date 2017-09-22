using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

    public PuzzleGameSaver puzzleGameSaver;

    private AudioSource music;

    private float musicVolume;

    void Awake()
    {
        music = GetComponent<AudioSource>();
    }


	// Use this for initialization
	void Start () {
        musicVolume = puzzleGameSaver.musicVolume;
        PlayOrTurnOfMusic(musicVolume);
	}

    public void SetMusicVolume(float volume)
    {
        PlayOrTurnOfMusic(volume);

    }
	
    void PlayOrTurnOfMusic(float volume)
    {
        musicVolume = volume;
        music.volume = musicVolume;
        if (music.volume > 0)
        {
            if(!music.isPlaying)
            {
                music.Play();
            }
        }
        else
        {
            music.Stop();
        }

        puzzleGameSaver.musicVolume = musicVolume;
        puzzleGameSaver.SaveGameData();

    }

    public float GetMusicVolume()
    {
        return musicVolume;
    }

}
