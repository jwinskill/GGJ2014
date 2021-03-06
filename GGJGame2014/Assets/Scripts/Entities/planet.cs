﻿using UnityEngine;
using System.Collections;

public class planet : MonoBehaviour {

	float stability = 100;
	float atmosphere = 0;
	float[] temperature = new float[]{0.0f,0.0f,0.0f,0.0f}; //Smallest Chunk is index zero, atmosphere is four
	float water = 0;

	bool victory = false;
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
	
	
	public bool Victory
	{
		get {
			return victory;
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
			water -= 3f * Time.deltaTime;
		}

		if (atmosphere < temperature[2]) {
			temperature[2] -= 1.5f * Time.deltaTime;
		}

		if (stability <= 0 && planetAlive)
		{
			planetAlive = false;
			// Play explosion animation
			// Show game over UI
		} else if (planetAlive) {
			if (water > 45f &&
			    water < 70f &&
			    atmosphere > 85f &&
			    PlanetTemperature > 45f && 
			    PlanetTemperature < 70f
			    ) {
				victory = true;
				planetAlive = false;
			}
		}
		Debug.Log("Temperature: " + PlanetTemperature + " Atmosphere: " + atmosphere + " Water: " + water);
	}


	public void AbsorbHeat(int layer, float tempamplitude) {

		stability -= tempamplitude;
		if (stability < 0f) {
			stability = 0f;
		}


		// If core, temperature rises dramatically // Stability drops dramatically
		temperature[layer] += (basetempincrease * tempamplitude);
		
		// Diffuse heat from core
		if (layer == 0) {
			temperature[1] += (basetempincrease * tempamplitude * 0.5f);
			temperature[2] += (basetempincrease * tempamplitude * 0.25f);
		}

		if (layer == 1) {
			temperature[2] += (basetempincrease * tempamplitude * 0.5f);
		}

		//Debug.Log ("TEMPERATURE OF CORE LAYER: " + layer + " is : " + temperature [layer]);
		if (temperature[1] > VolcanoSpawnTemp) {
			
			Instantiate(VolcanoPrefab,new Vector3(0f,0f,7f),PlayerObject.transform.rotation);
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

	}

	
	public float GetLayerTemp(int layer) {
		return temperature[layer];
	}


	public bool GameOver() {
		return !planetAlive;
	}
}
