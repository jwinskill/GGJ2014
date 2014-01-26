using UnityEngine;
using System.Collections;

public class Beam : MonoBehaviour {
	
	private ParticleSystem particles;

	// Use this for initialization
	void Start () {
		particles = gameObject.GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void StartBeam(float particleTime)
	{
		particles.startLifetime = particleTime;
		particles.enableEmission = true;
	}

	public void StopBeam()
	{
		particles.enableEmission = false;
	}
}
