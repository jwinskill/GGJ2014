using UnityEngine;
using System.Collections;

public class CoreLayer : MonoBehaviour {

	public string LayerName = "Unknown_Corelayer";
	private float baselightIntensity = 0.0f;
	// Use this for initialization
	void Start () {
		Light[] lights = gameObject.GetComponentsInChildren<Light> ();
		foreach (Light light in lights) {
			baselightIntensity = light.intensity;
			break;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter() { 
		Light[] lights = gameObject.GetComponentsInChildren<Light> ();
		foreach (Light light in lights) {
			light.intensity = baselightIntensity * 3;
		}

		Debug.Log("I am over something " + LayerName); 
	}

	void OnMouseExit () {
		Light[] lights = gameObject.GetComponentsInChildren<Light> ();
		foreach (Light light in lights) {
			light.intensity = baselightIntensity;
		}
	}
}
