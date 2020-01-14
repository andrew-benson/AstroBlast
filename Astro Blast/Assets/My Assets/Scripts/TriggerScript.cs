using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour
{	

//Public Variables	
	
	private Asteroid_Move otherScript;
	private TouchInput touchScript;
	private Score scoreScript;
	private PCControls buttonScript;
	private Defence_Trigger defenceScript;
	private GameOver gameOverScript;
	GameObject defence;
	Behaviour halo;
	public bool collided = false;
	Behaviour greenHaloComp;
	public ParticleSystem flash2;
	int mineralCount = 0;
	LaserPointer pointerScript;

	void Awake ()
	{

		touchScript = GetComponent<TouchInput> ();
		scoreScript = Camera.mainCamera.GetComponent<Score> ();
		buttonScript = GetComponent<PCControls> ();
		defence = GameObject.Find ("Defence Field");
		halo = (Behaviour)defence.GetComponent ("Halo");
		defenceScript = defence.GetComponent<Defence_Trigger> ();
		greenHaloComp = (Behaviour)GameObject.Find ("haloGreen").GetComponent ("Halo");
		pointerScript = GetComponent<LaserPointer>();
		gameOverScript = GetComponent<GameOver>();
	}
	
	void Update ()
	{

		// Increase timescale back to normal (1f)
		if (collided) {
			if (Time.timeScale < 1f) {

				Time.timeScale += 0.4f * Time.deltaTime;
			} else if (Time.timeScale >= 1f) {
				Time.timeScale = 1;
			}
		}
	}
	
	//method called when collider detects collision
	void OnTriggerEnter (Collider other)
	{
		otherScript = other.gameObject.GetComponent<Asteroid_Move> ();
		
		
		//if the collision is not a bullet
		if (other.name != "Bullet(Clone)" || other.name != "Spray_Bullet(Clone)") {
			// Spray
			if (other.name == "Spray_Bullet_Perk(Clone)") {
				Debug.Log ("collided with Spray Bullet Perk");
				buttonScript.sprayBulletPerk = true;
				touchScript.sprayBulletPerk = true;
				StartCoroutine ("StopSprayBullets");			
				Debug.Log ("Spray Bullet activated");
				
				// Light speed
			} else if (other.name == "Light_Speed_Perk(Clone)") {
				Debug.Log ("collided with light speed Perk");
				Instantiate (Resources.Load ("LightSpeed"));
				touchScript.lightspeed = true;
				buttonScript.lightSpeed = true;
				scoreScript.scoreMultiplier = 500;
				GameObject.Find ("Stopper").collider.enabled = true;
				StartCoroutine ("StopLightSpeed");		
				
				//Defence
			} else if (other.name == "TwoShot_Bullet_Perk(Clone)") {
				buttonScript.dualBulletPerk = true;
				touchScript.dualBulletPerk = true;
				StartCoroutine(StopDualBullets());
			} else if (other.name == "Defence_Perk(Clone)" && defenceScript.isShieldActive == false) {
				Debug.Log ("collide with defence");
				defenceScript.isShieldActive = true;
				defenceScript.currentHalo = greenHaloComp;
				defenceScript.currentHalo.enabled = true;
				defenceScript.ResetHitPoints ();
			} 
			else if (other.name == "SlowMo_Perk(Clone)") {
				Debug.Log("Touched");
				Time.timeScale = 0.1f;
				StartCoroutine(StopSlowMotion());
			}
		}
		
		if(other.gameObject.layer == 9){
			flash2.Play();
			Debug.Log("touched perk");

		}
		
		if(other.gameObject.layer == 13){
			
			
			flash2.Play();
			mineralCount++;
			Debug.Log(mineralCount.ToString());
		}
		
		if (other.tag == "Asteroid") {
				DeactivateShip ();
				
				StartCoroutine (GameOverCoroutine ());
		}
		
		
	}
		
	IEnumerator GameOverCoroutine ()
	{
		gameOverScript.enabled = true;
		yield return new WaitForSeconds(2f);
		scoreScript.GameOver ();

	}

	IEnumerator StopSprayBullets ()
	{
		yield return new  WaitForSeconds(7.5f);
		touchScript.sprayBulletPerk = false;
		buttonScript.sprayBulletPerk = false;
	}
	
	IEnumerator StopDualBullets ()
	{

		yield return new  WaitForSeconds(12f);
				Debug.Log ("turn off");

		touchScript.dualBulletPerk = false;
		buttonScript.dualBulletPerk = false;
	}

	IEnumerator StopLightSpeed ()
	{
		yield return new  WaitForSeconds(5f);
		touchScript.lightspeed = false;
		buttonScript.lightSpeed = false;
		scoreScript.scoreMultiplier = 100f;
		GameObject.Find ("Stopper").collider.enabled = false;
	}
	
	IEnumerator StopSlowMotion()
	{
		yield return new  WaitForSeconds(0.5f);
		Time.timeScale = 1f;
	}
	
	void DeactivateShip ()
	{
		scoreScript.scoreMultiplier = 0f;
		touchScript.enabled = false;
		pointerScript.enabled = false;
		Time.timeScale = 0.2f;
		GameObject.Find ("Explosion").gameObject.particleSystem.Play ();
		collided = true;
		collider.enabled = false;
		gameObject.transform.renderer.enabled = false;
		gameObject.transform.FindChild ("BurnerRight").renderer.enabled = false;
		gameObject.transform.FindChild ("BurnerLeft").renderer.enabled = false;
	}
}		

	

