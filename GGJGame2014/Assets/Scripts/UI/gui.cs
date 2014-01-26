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

	void Start () {
		threshold = upperThreshold - lowerThreshold;
	}

	void Update () {
		// Stability


		// Temperature

		// Atmosphere

		// Water
	}
}
