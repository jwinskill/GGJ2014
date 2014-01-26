using UnityEngine;
using System.Collections;

public class gui : MonoBehaviour {

	public GameObject stableBar;
	public GameObject tempBar;
	public GameObject atmoBar;
	public GameObject waterBar;

	public planet targetplanet;

	private float lowerThreshold = -0.1f; // Lowest X value of UI
	private float upperThreshold = 1.75f; // Highest X value of UI

	private float threshold;
	private float origin;

	void Start () {
		threshold = upperThreshold - lowerThreshold;
		origin = tempBar.transform.position.x;
	}

	void Update () {
		// Stability


		// Temperature
		float temp = targetplanet.PlanetTemperature / targetplanet.MaxTemperature;
		float percent = temp * threshold;
		Vector3 pos = new Vector3(origin + percent, tempBar.transform.position.y, tempBar.transform.position.z);
		tempBar.transform.position = pos;

		// Atmosphere

		// Water
	}
}
