using UnityEngine;
using System.Collections;

public class ItemGenerator : MonoBehaviour {
        //carPrefabを入れる
        public GameObject carPrefab;
        //coinPrefabを入れる
        public GameObject coinPrefab;
        //cornPrefabを入れる
        public GameObject conePrefab;
        //スタート地点
        private int startPos = -160;
        //ゴール地点
        private int goalPos = 80;
        //アイテムを出すx方向の範囲
        private float posRange = 3.4f;
		//UnityChanの位置
		public GameObject unityPlace;
		//アイテム間距離計測用
		public float distance = 0;


        // Use this for initialization
        void Start () {

			this.unityPlace = GameObject.Find("unitychan");

        }

        // Update is called once per frame
        void Update () {
						//最初の15m移動時の処理
			if(this.distance==0){
				this.distance=this.unityPlace.transform.position.z;
			//継続的な15m移動時の処理
			}else{
				//15m以上の距離を移動したら処理を実行
				if((this.distance-this.unityPlace.transform.position.z)>15||(this.distance-this.unityPlace.transform.position.z)<-15){
					//追加系の処理
					this.distance=this.unityPlace.transform.position.z;
					//goalPos以降は作成しない
					if(goalPos>this.unityPlace.transform.position.z){
						this.CreateItem(this.unityPlace.transform.position.z+40);
					}
					
				}
			}
        }

		void CreateItem(float i){
			//どのアイテムを出すのかをランダムに設定
                        int num = Random.Range (1, 11);
                        if (num <= 2) {
                                //コーンをx軸方向に一直線に生成
                                for (float j = -1; j <= 1; j += 0.4f) {
                                        GameObject cone = Instantiate (conePrefab) as GameObject;
                                        cone.transform.position = new Vector3 (4 * j, cone.transform.position.y, i);
                                }
                        } else {

                                //レーンごとにアイテムを生成
                                for (int j = -1; j <= 1; j++) {
                                        //アイテムの種類を決める
                                        int item = Random.Range (1, 11);
                                        //アイテムを置くZ座標のオフセットをランダムに設定
                                        int offsetZ = Random.Range(-5, 6);
                                        //60%コイン配置:30%車配置:10%何もなし
                                        if (1 <= item && item <= 6) {
                                                //コインを生成
                                                GameObject coin = Instantiate (coinPrefab) as GameObject;
                                                coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, i + offsetZ);
                                        } else if (7 <= item && item <= 9) {
                                                //車を生成
                                                GameObject car = Instantiate (carPrefab) as GameObject;
                                                car.transform.position = new Vector3 (posRange * j, car.transform.position.y, i + offsetZ);
                                        }
                                }
                        }
		}
}