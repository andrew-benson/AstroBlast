using UnityEngine;
using System.Collections;

public class LaserPointer : MonoBehaviour {
	Color color1 = Color.red;
	Color color2 = Color.clear;
	Color color3 = Color.green;
	Vector3 origin, direction, endPoint;
	LineRenderer lineRenderer;
	public GameObject  laserLight;
	RaycastHit hit;
	public LayerMask asteroidLayer;	
	Material greenDot, redDot;
	float zOffset = .15f;
	
	void Awake(){
	}
	
	// Use this for initialization
	void Start () {
		//asteroidLayer = ~asteroidLayer;
		
		lineRenderer = (LineRenderer)gameObject.AddComponent("LineRenderer");
		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));	
		lineRenderer.SetColors(color1, color1);
		lineRenderer.SetWidth(0.01f,0.01f);
		lineRenderer.SetVertexCount(2);
	}
	
	
	
	void Update(){
		
		origin = transform.position;
		endPoint = origin + direction * 10;
		direction = transform.forward;
		
		
		if(Physics.Raycast(origin, direction, out hit, 20f, asteroidLayer)){
			if(hit.collider.gameObject.tag == "Asteroid"){
				//turn on
				laserLight.SetActive(true);
				
				//assign new pos & rot
				laserLight.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z - zOffset);
				
			}
		}
	}
	
	void LateUpdate () {
		
		if(Input.touchCount > 0 || Application.platform == RuntimePlatform.WindowsEditor){
			lineRenderer.enabled = true;
			lineRenderer.SetPosition(0, origin);
			if(Physics.Raycast(origin, direction, 20f, asteroidLayer)){
				endPoint = hit.point;
			}
			lineRenderer.SetPosition(1, endPoint);
		}else{
			lineRenderer.enabled = false;
			laserLight.SetActive(false);
		}
		
		
	}
	
}
