using UnityEngine;
using System.Collections;

public class CoreLayer : MonoBehaviour {

	public string LayerName = "Unknown_Corelayer";
	private float baselightIntensity = 0.0f;
	private bool isUserMouseDown = false;

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
		if (isUserMouseDown) {
			transform.localScale += new Vector3(0.01f,0.01f,0.0f);
		}
	}

	void OnMouseDown() {
		isUserMouseDown = true;
		Debug.Log ("USER MOUSE DOWN : " + LayerName);
	}

	void OnMouseUp() {
		isUserMouseDown = false;
		Debug.Log ("USER MOUSE UP : " + LayerName);
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
