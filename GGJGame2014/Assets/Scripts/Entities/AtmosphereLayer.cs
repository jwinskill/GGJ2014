using UnityEngine;
using System.Collections;

public class AtmosphereLayer: MonoBehaviour {

	public planet targetPlanet;

	private float lowerThreshold = 0.5f;
	private float upperThreshold = 0.65f;
	private float threshold;

	// Use this for initialization
	void Start () {
		threshold = upperThreshold - lowerThreshold;	
	}
	
	// Update is called once per frame
	void Update () {
		// Scale to the planet's atmosphere reading
		float newScale = lowerThreshold + threshold * targetPlanet.Atmosphere;
		Vector3 newScaleVector = new Vector3(newScale, newScale, 1);
		transform.localScale = newScaleVector;
	}
}
