using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CambiarCielo : MonoBehaviour {

	public List<Material> cielos;
	private int actual = 0;

	public float velocidadRotacion = 2.0f;

	public float segundosEntreLlamadas = 2f;
	bool reconocido = false;
	float tiempoReconocido = 0f; 

	void Start () {
		Input.gyro.enabled = true;
		RenderSettings.skybox = cielos[actual];
	}

	void Update()
	{
		if (!reconocido)
		{
			if (Input.gyro.rotationRateUnbiased.y > velocidadRotacion)
			{
				if (actual == cielos.Count - 1)
				{
					actual = 0;
				}
				else
				{
					actual++;
				}
				RenderSettings.skybox = cielos[actual];
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
