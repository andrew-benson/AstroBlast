using UnityEngine;
using System.Collections;

public class FrameCounter : MonoBehaviour {
     	float fps;
     
        void Update()
        {
            fps = 1 / Time.deltaTime;
        }
        void OnGUI()
        {
            GUI.Label(new Rect(0, 0, 30, 20), fps.ToString());
        }
     
        
    }
