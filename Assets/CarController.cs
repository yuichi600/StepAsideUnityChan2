using System.Collections;
using UnityEngine;

public class CarController : MonoBehaviour {
		
		public GameObject unityPlace;
		public float distance;
        // Use this for initialization
        void Start () {
				
				this.unityPlace = GameObject.Find("unitychan");
        }
        
        // Update is called once per frame
        void Update () {
				//Destroy(this.gameObject);
				distance = unityPlace.transform.position.z-this.transform.position.z;
				if(distance>0){
					Destroy(this.gameObject);
				}				
        }
}