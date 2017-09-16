using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CambiarMusica : MonoBehaviour {

	public List<AudioClip> canciones;
	private int actual = 0;
	public AudioSource source;
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
			source.Pause();
			if (actual == canciones.Count - 1)
			{
				actual = 0;
			}
			else
			{
				actual++;
			}
			source.clip = canciones[actual];
			source.Play();
		}
	}
}
