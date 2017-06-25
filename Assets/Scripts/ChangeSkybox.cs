using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangeSkybox : MonoBehaviour {

	public List<Material> materiales;
	private int currentSkybox = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void ChangeSkyboxPls () {
		if (currentSkybox == materiales.Count - 1) {
			currentSkybox = 0;
		}else{
			currentSkybox++;
		}
		RenderSettings.skybox = materiales[currentSkybox];
	}
}
