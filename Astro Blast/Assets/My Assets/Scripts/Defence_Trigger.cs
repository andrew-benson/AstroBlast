using UnityEngine;
using System.Collections;

public class Defence_Trigger : MonoBehaviour
{
	Color yellow = Color.yellow, red = Color.red;
	public GameObject target, haloGreen, haloYellow, haloRed;
	Behaviour greenHaloComp, yellowHaloComp, redHaloComp;
	public Behaviour currentHalo;
	GameObject defence;
	public float timer = 15f;
	public int hitPoints = 7;
	public bool isFlashing = false;
	public bool isShieldActive = false;

	void Start ()
	{
		defence = GameObject.Find ("Defence Field");
		greenHaloComp = (Behaviour)haloGreen.GetComponent ("Halo");
		yellowHaloComp = (Behaviour)haloYellow.GetComponent ("Halo");
		redHaloComp = (Behaviour)haloRed.GetComponent ("Halo");
	}
	
	void Update ()
	{
		// Follow the monkeyship
		if(target){
			transform.position = new Vector3 (target.transform.position.x, target.transform.position.y, 1f);
		}
		
	 	// Enable the collider and start timer once the shield is active
		if (isShieldActive) {
			collider.enabled = true;
			timer -= Time.deltaTime * 1;
		}else{
			collider.enabled = false;
			currentHalo = null;
		}
	
		// After x seconds flash the current component 
		// call coroutine once using boolean flag
		if (timer < 0) {
			if (!isFlashing) {
				Debug.Log("call this once");
				StartCoroutine (FlashHalo ());
			}
		}
		
	}
	
	void OnCollisionEnter (Collision other)
	{
	
		// Change the halo colour depending on the hit points
		if (isShieldActive) {
			switch (hitPoints) {
			case 7: 
				greenHaloComp.enabled = true;
				currentHalo = greenHaloComp;
				break;
			case 6: 
				greenHaloComp.enabled = true;
				currentHalo = greenHaloComp;
				break;
			case 5: 
				yellowHaloComp.enabled = true;
				greenHaloComp.enabled = false;
				currentHalo = yellowHaloComp;
				break;
			case 4: 
				yellowHaloComp.enabled = true;
				greenHaloComp.enabled = false;
				currentHalo = yellowHaloComp;
				break;
			case 3: 
				greenHaloComp.enabled = false;
				yellowHaloComp.enabled = false;
				redHaloComp.enabled = true;
				currentHalo = redHaloComp;
				break;
			case 2: 
				greenHaloComp.enabled = false;
				yellowHaloComp.enabled = false;
				redHaloComp.enabled = true;
				currentHalo = redHaloComp;
				break;
			case 1: 
				greenHaloComp.enabled = false;
				yellowHaloComp.enabled = false;
				redHaloComp.enabled = false;
				TurnOffShield();
				break;
			default:
				greenHaloComp.enabled = false;
				yellowHaloComp.enabled = false;
				redHaloComp.enabled = false;
				break;
			}
		}
		
		if (hitPoints > 0 && other.gameObject.tag == "Asteroid") {
			hitPoints--; 
		}
	}

	public void ResetHitPoints ()
	{
		hitPoints = 7;
		timer = 15f;
	}
	
	// Coroutine to turn the halo on/off
	IEnumerator FlashHalo ()
	{
		isFlashing = true;
		Debug.Log("Flashing:" + currentHalo.ToString());
		yield return new  WaitForSeconds(0.6f);
		currentHalo.enabled = false;
		yield return new  WaitForSeconds(0.4f);
		currentHalo.enabled = true; 
		yield return new  WaitForSeconds(0.6f);
		currentHalo.enabled = false;
		yield return new  WaitForSeconds(0.4f);
		currentHalo.enabled = true; 
		yield return new  WaitForSeconds(0.6f);
		currentHalo.enabled = false;
		yield return new  WaitForSeconds(0.4f);
		currentHalo.enabled = true; 
		yield return new  WaitForSeconds(0.6f);
		currentHalo.enabled = false;
		isFlashing = false;
		TurnOffShield();
		ResetHitPoints ();
	}
	
	void TurnOffShield(){
		isShieldActive = false;
		collider.enabled = false;
		currentHalo.enabled = false;
	}
}
