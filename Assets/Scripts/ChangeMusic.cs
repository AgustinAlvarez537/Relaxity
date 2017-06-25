using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangeMusic : MonoBehaviour {

	public List<AudioClip> canciones;
	private int currentMusic = 0;
	public AudioSource audioSource;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	public void ChangeMusicPls () {
		audioSource.Pause();
		if (currentMusic == canciones.Count - 1) {
			currentMusic = 0;
		}else{
			currentMusic++;
		}
		audioSource.clip = canciones[currentMusic];
		audioSource.Play();
	}
}
