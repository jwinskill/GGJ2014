using UnityEngine;
using System.Collections;

public class CoreLayer : MonoBehaviour {

	public string LayerName = "Unknown_Corelayer";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter() { 
		Light[] lights = gameObject.GetComponentsInChildren<Light> ();
		foreach (Light light in lights) {
			light.intensity = 0.3f;
		}

		Debug.Log("I am over something " + LayerName); 
	}

	void OnMouseExit () {
		Light[] lights = gameObject.GetComponentsInChildren<Light> ();
		foreach (Light light in lights) {
			light.intensity = 0.1f;
		}
	}
}
