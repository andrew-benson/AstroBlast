using UnityEngine;
using System.Collections;

public class AsteroidCol_Large: MonoBehaviour
{
	int health = 100;
	Material asteroidMaterial;
	public Material flashMaterial;
	public ParticleSystem largeBlast;
	void Start ()
	{
		asteroidMaterial = renderer.material;
	}
	
	//When Asteroid collides with bullet
	void OnCollisionEnter (Collision collision)
	{
		// reduce the health
		if (collision.collider.name == "SprayBullet" || collision.collider.name == "Bullet(Clone)" 
						|| collision.collider.name == "Dual_Bullet") {
				
			
			//if health < 0 then explode & add score
			if (health <= 0) {
	
				GameObject explosion = Instantiate (Resources.Load ("Flame_Large"),
				                                    new Vector3(collision.transform.position.x, collision.transform.position.y, collision.transform.position.z),
				                                    new Quaternion (0f, 0f, 0f, 0f)) as GameObject;
			
				Camera.mainCamera.GetComponent<Score> ().score += 50f;	
				GetComponent<Asteroid_Move> ().Reset ();
				Destroy (explosion, 1f);
				health = 100; // Reset health

				// roll a number, 1 in 10 chance a mineral is found
				float roll = Random.value;
				if (roll > 0.9) {
					GameObject mineral = Instantiate(Resources.Load("Mineral"),transform.position,Quaternion.identity) as GameObject;
				}
			} else {
				health -= 30;
				gameObject.renderer.material = flashMaterial;
				Invoke("DefaultMaterial",0.07f);
			}
		} else if (collision.collider.name == "Shockwave Collider") {
			GameObject explosion = Instantiate (Resources.Load ("Flame_Large"),
				                                    new Vector3(collision.transform.position.x, collision.transform.position.y, collision.transform.position.z),
				                                    new Quaternion (0f, 0f, 0f, 0f)) as GameObject;
			Camera.mainCamera.GetComponent<Score> ().score += 50f;	
			GetComponent<Asteroid_Move> ().Reset ();
			Destroy (explosion, 1f);
			health = 100; // Reset health
				
			// roll a number, 1 in 10 chance a mineral is found
			float roll = Random.value;
			if (roll > 0.9) {
				GameObject mineral = GameObject.CreatePrimitive (PrimitiveType.Cube);
				mineral.transform.position = transform.position;
				mineral.transform.localScale = new Vector3 (.1f, .1f, .1f);
			}
		}
			

		
		// If collides with defence field or spray bullet then explode & add score 
		if (collision.collider.name == "Defence Field") {	
		
			Vector3 explosionPos = new Vector3 (collision.transform.position.x, collision.transform.position.y, collision.transform.position.z); 
	
			GameObject explosion = Instantiate (Resources.Load ("Flame_Large"),
					explosionPos, new Quaternion (0f, 0f, 0f, 0f)) as GameObject;
			
			Camera.mainCamera.GetComponent<Score> ().score += 50f;	
			GetComponent<Asteroid_Move> ().Reset ();
			Destroy (explosion, 1f);
		}
	}
	
	void DefaultMaterial(){
		gameObject.renderer.material = asteroidMaterial;
	}
}
