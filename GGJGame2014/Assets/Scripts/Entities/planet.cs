using UnityEngine;
using System.Collections;

public class planet : MonoBehaviour {

	float stability = 100;
	float atmosphere = 0;
	float temperature = 0;
	float liquidwater = 0;

	bool ideal = false; // Fit for your species
	bool inhabitable = false; // Fit for life
	bool[] life = new bool[360];

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Every .5 seconds
			// If uninhabitable
				// Kill off life that can't survive
		// Temperature falls over time.
	}

	void AbsorbHeat(int layer) {
		// If core, temperature rises dramatically // Stability drops dramatically

	}

	void AddLife(float angle) {
		// Set life to true for 
	}
}
