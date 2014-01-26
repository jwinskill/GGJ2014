using UnityEngine;
using System.Collections;

public class planet : MonoBehaviour {

	float stability = 100;
	float atmosphere = 0;
	float[] temperature = new float[]{0.0f,0.0f,0.0f,0.0f}; //Smallest Chunk is index zero, atmosphere is four
	float water = 0;

	bool planetAlive = true;
	private float basetempincrease = 1.0f;

	public float MaxTemperature = 100f;

	public GameObject PlayerObject;
	public GameObject VolcanoPrefab;

	public float VolcanoSpawnTemp = 20f;
	public float VolcanoSpawnTempReduction = 10f;

	public float SteamSpawnTemp = 20f;
	public float SteamSpawnTempReduction = 10f;
	public GameObject SteamParticleObject;

	public float PlanetTemperature 
	{
		get {
			float currenttemp = 0.0f;
			foreach (float temp in temperature)
			{
				currenttemp += temp;
			}
			return Mathf.Min(MaxTemperature, currenttemp);
		}

	}


	public float Atmosphere
	{
		get {
			return atmosphere / 100f;
		}
	}


	public float Water
	{
		get {
			return water / 100f;
		}
	}


	public float Stability {
		get {
			return stability / 100f;
		}
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (water > atmosphere) {
			water -= 0.05f;
		}

		if (stability < 0 && planetAlive)
		{
			planetAlive = false;
			// Play explosion animation
			// Show game over UI
		}

	}


	public float AbsorbHeat(int layer, float tempamplitude) {

		stability -= tempamplitude;

		// If core, temperature rises dramatically // Stability drops dramatically
		temperature[layer] += (basetempincrease * tempamplitude);
		
		Debug.Log ("TEMPERATURE OF CORE LAYER: " + layer + " is : " + temperature [layer]);
		if (temperature[1] > VolcanoSpawnTemp) {
			
			Instantiate(VolcanoPrefab,new Vector3(0f,0f,0f),PlayerObject.transform.rotation);
			temperature[1] -= Mathf.Max (0,VolcanoSpawnTempReduction);
			atmosphere += 40f;		
			if (atmosphere > 100f) {
				atmosphere = 100f;
			}
		}
		
		if (temperature[2] > SteamSpawnTemp) {
			
			Instantiate(SteamParticleObject, new Vector3(0f,0f,0f),PlayerObject.transform.rotation);
			temperature[2] -= Mathf.Max (0,SteamSpawnTempReduction);
			water += 30f;
			if (water > 100f) {
				water = 100f;
			}
		}

		return temperature[layer];
	}


	void OnGUI () {
		// if planet is destroyed
		if (!planetAlive) {
			if (GUI.Button(new Rect(10, 10, 150, 50), "Find new planet.")) {
				Application.LoadLevel("Main");
			}
		}
	}

}
