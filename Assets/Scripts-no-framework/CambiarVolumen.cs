using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class CambiarVolumen : MonoBehaviour {

	public AudioSource origenAudio;

	public float inclinacionDerecha;
	public float inclinacionIzquierda;
	Vector3 posicionInicial;

	public float segundosEntreLlamadas = 2f;


	bool reconocido = false;
	float tiempoReconocido = 0f;


	void Start()
	{
		posicionInicial = new Vector3(0f, -1.0f, 0f);
		inclinacionDerecha = convertirGrados(inclinacionDerecha);
		inclinacionIzquierda = convertirGrados(inclinacionIzquierda);
	}

	void Update()
	{
		if (!reconocido)
		{

			if (posicionInicial.x + inclinacionDerecha < Input.acceleration.x)
			{
				reconocido = true;
				tiempoReconocido = Time.time;
				SubirVolumen();
			}
			if (posicionInicial.x - inclinacionIzquierda > Input.acceleration.x)
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
		if (origenAudio.volume < 1f)
		{
			origenAudio.volume = origenAudio.volume + 0.1f;
		}
	}

	public void BajarVolumen()
	{
		if (origenAudio.volume > 0f)
		{
			AudioListener.volume = AudioListener.volume - 0.1f;
		}
	}

	private float convertirGrados(float grados)
	{
		return grados / 90f;
	}
}
