using System.Collections;
using UnityEngine;

public class CoinController : MonoBehaviour {
		
		public GameObject unityPlace;
		public float distance;
        // Use this for initialization
        void Start () {
				
				this.unityPlace = GameObject.Find("unitychan");

                //回転を開始する角度を設定
                this.transform.Rotate (0, Random.Range (0, 360), 0);
        }
        
        // Update is called once per frame
        void Update () {
                //回転
                this.transform.Rotate (0, 3, 0);
				//Destroy(this.gameObject);
				distance = unityPlace.transform.position.z-this.transform.position.z;
				if(distance>0){
					Destroy(this.gameObject);
				}				
        }
}