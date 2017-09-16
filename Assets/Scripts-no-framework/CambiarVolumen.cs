﻿using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class CambiarVolumen : MonoBehaviour {

	public AudioMixer mainMixer;					//Used to hold a reference to the AudioMixer mainMixer
	float aux = 0f;

	public float inclinacionDerecha;
	public float inclinacionIzquierda;
	Vector3 posicionInicial;

	public float segundosEntreLlamadas = 2f;


	bool reconocido;
	float tiempoReconocido;


	void Start()
	{
		posicionInicial = new Vector3(0f, 1.0f, 0f);
	}

	void Update()
	{
		if (!reconocido)
		{

			if (posicionInicial.x - inclinacionDerecha > Input.acceleration.x)
			{
				reconocido = true;
				tiempoReconocido = Time.time;
				SubirVolumen();
			}
			if (posicionInicial.x + inclinacionIzquierda < Input.acceleration.x)
			{
				reconocido = true;
				tiempoReconocido = Time.time;
				BajarVolumen();
			}
		}
		else
		{
			if (Time.time - tiempoReconocido > segundosEntreLlamadas)
			{
				reconocido = false;
			}
		}
	}

	public void SubirVolumen()
	{
		AudioListener.volume = AudioListener.volume - 0.1f;
	}

	public void BajarVolumen()
	{
		AudioListener.volume = AudioListener.volume + 0.1f;
	}
}