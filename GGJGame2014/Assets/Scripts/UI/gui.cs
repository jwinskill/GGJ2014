using UnityEngine;
using System.Collections;

public class gui : MonoBehaviour {

	public GameObject stableBar;
	public GameObject tempBar;
	public GameObject atmoBar;
	public GameObject waterBar;

	public GameObject credits;
	public GameObject defeat;
	public GameObject victory;

	public planet targetplanet;

	private float lowerThreshold = -0.1f; // Lowest X value of UI
	private float upperThreshold = 1.75f; // Highest X value of UI

	private float threshold;
	private float origin;

	private bool showingEndScreen = false;

	void Start () {
		threshold = upperThreshold - lowerThreshold;
		origin = tempBar.transform.position.x;
	}

	void Update () {

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

		// Stability
		float stability = targetplanet.Stability;
		percent = stability * threshold;
		pos = new Vector3(origin + percent, stableBar.transform.position.y, stableBar.transform.position.z);
		stableBar.transform.position = pos;

		if (!showingEndScreen && targetplanet.GameOver()) {
			showingEndScreen = true;

			pos = new Vector3(0, 0, 90);

			// Move Credit forward
			credits.transform.position += pos;


			if (targetplanet.Victory) {
				victory.transform.position += pos;
				//victory text forward
			} else {
				defeat.transform.position += pos;
				// defeat text forward

			}
		}

	}

	void OnGUI () {
		// if planet is destroyed
		if (targetplanet.GameOver()) {
			if (GUI.Button(new Rect(407, 330, 150, 50), "Find new planet.")) {
				Application.LoadLevel("Main");
			}
		}
	}

}
