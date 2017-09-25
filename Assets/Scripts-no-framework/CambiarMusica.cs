using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CambiarMusica : MonoBehaviour {

	public List<AudioClip> canciones;
	private int actual = 0;
	public AudioSource origenAudio;
	public float velocidadRotacion = 2.0f;

	public float segundosEntreLlamadas = 2f;
	bool reconocido = false;
	float tiempoReconocido = 0f;


	void Start()
	{
		Input.gyro.enabled = true;
		origenAudio.clip = canciones[actual];
		origenAudio.Play();
	}

	void Update()
	{
		if (!reconocido)
		{

			if (Input.gyro.rotationRateUnbiased.y < -velocidadRotacion)
			{
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
				reconocido = true;
				tiempoReconocido = Time.time;
			}
		}
		else
		{
			if (Time.time - tiempoReconocido < segundosEntreLlamadas)
			{
				reconocido = false;
			}
		}
	}
}
