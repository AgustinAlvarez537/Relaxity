using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CambiarCielo : MonoBehaviour {

	public List<Material> cielos;
	private int actual = 0;

	public float velocidadRotacion = 2.0f;

	void Start () {
		Input.gyro.enabled = true;
	}

	void Update()
	{
		if (Input.gyro.rotationRateUnbiased.y > velocidadRotacion)// reconocí el movimiento de la cabeza hacia la izquierda
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
		}
		
	}
}
