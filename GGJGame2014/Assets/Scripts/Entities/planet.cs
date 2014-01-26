using UnityEngine;
using System.Collections;

public class planet : MonoBehaviour {

	float stability = 100;
	float atmosphere = 0;
	float[] temperature = new float[]{0.0f,0.0f,0.0f,0.0f}; //Smallest Chunk is index zero, atmosphere is four
	float liquidwater = 0;

	bool ideal = false; // Fit for your species
	bool inhabitable = false; // Fit for life
	bool[] life = new bool[360];
	private float basetempincrease = 1.0f;

	public float MaxTemperature = 100f;

	public GameObject PlayerObject;
	public GameObject VolcanoPrefab;

	public float VolcanoSpawnTemp = 20f;
	public float VolcanoSpawnTempReduction = 15f;

	public float SteamSpawnTemp = 20f;
	public float SteamSpawnTempReduction = 15f;
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

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		atmosphere += 0.1f;
		if (atmosphere > 100f) {
			atmosphere = 100f;
		}
		if (temperature[0] > VolcanoSpawnTemp) {

			Instantiate(VolcanoPrefab,new Vector3(0f,0f,7f),PlayerObject.transform.rotation);
			temperature[0] -= Mathf.Max (0,VolcanoSpawnTempReduction);

		}
		if (temperature[2] > SteamSpawnTemp) {
			
			Instantiate(SteamParticleObject, new Vector3(0f,0f,0f),PlayerObject.transform.rotation);
			temperature[2] -= Mathf.Max (0,SteamSpawnTempReduction);
			
		}
	}

	public void AbsorbHeat(int layer, float tempamplitude) {
		// If core, temperature rises dramatically // Stability drops dramatically
		temperature[layer] += (basetempincrease * tempamplitude);

		Debug.Log ("TEMPERATURE OF CORE LAYER: " + layer + " is : " + temperature [layer]);
	}

	void AddLife(float angle) {
		// Set life to true for 
	}
}
