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
		float atmosphere = targetplanet.Atmosphere;
		percent = atmosphere * threshold;
		pos = new Vector3(origin + percent, atmoBar.transform.position.y, atmoBar.transform.position.z);
		atmoBar.transform.position = pos;

		// Water
		float water = targetplanet.Water;
		percent = water * threshold;
		pos = new Vector3(origin + percent, waterBar.transform.position.y, waterBar.transform.position.z);
		waterBar.transform.position = pos;

	}
}
