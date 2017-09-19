using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CambiarMusica : MonoBehaviour {

	public List<AudioClip> canciones;
	private int actual = 0;
	public AudioSource origenAudio;
	public float velocidadRotacion = 2.0f;
	
	void Start()
	{
		Input.gyro.enabled = true;
	}

	void Update()
	{
		if (Input.gyro.rotationRateUnbiased.y < -velocidadRotacion)
		{
			// reconocí el movimiento de la cabeza hacia la derecha
			origenAudio.Pause();
			if (actual == canciones.Count - 1)
			{
				actual = 0;
			}
			else
			{
				actual++;
			}
			origenAudio.clip = canciones[actual];
			origenAudio.Play();
		}
	}
}
