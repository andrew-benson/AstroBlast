using UnityEngine;
using System.Collections;

public class Particle_Velocity_Increase : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void LateUpdate () {
 		
		// Array of particles 
		ParticleSystem.Particle[] p = new ParticleSystem.Particle[particleSystem.particleCount + 1];
		int l = particleSystem.GetParticles(p);
		 
		int i = 0;
			while (i < l) {
			p[i].velocity += new Vector3(0f, 0f,Asteroid_Move.shipVelocity * Time.deltaTime);
			
			i++;
		}	 
		particleSystem.SetParticles(p, l); 
		

	}

}