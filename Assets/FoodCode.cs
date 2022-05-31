using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCode : MonoBehaviour {

	public int playerScore = 0;
	public int T = 0;
	public int a = 0;
	// Use this for initialization
	void Start () {
		int y = Random.Range (1, 6);
		int x = Random.Range (1, 6);
		float yz = (float)(-3.6 + (y * 1.2));
		float xz = (float)(-3.6 + (x*1.2));
		transform.position = new Vector3(xz,yz,0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D  (Collision2D col){
		if (col.gameObject.name == "Snake") {
			a = 1;
			UpOne ();
			SnakeEyes.BestPathFound = false;

		}
	
		if (col.gameObject.tag == "Player") {
			//print("a");
			tryAgain ();
		
		} /*else {
			T = 0;
		}*/

		/*int y = Random.Range (1, 6);
		//int x = Random.Range (1, 6);
		//float yz = (float)(-3.6 + (y * 1.2));
		//float xz = (float)(-3.6 + (x*1.2));
		//transform.position = new Vector3(xz,yz,0f); */
	}
	void UpOne(){
		while (a == 1) {


			int y = Random.Range (1, 6);
			int x = Random.Range (1, 6);
			float yz = (float)(-3.6 + (y * 1.2));
			float xz = (float)(-3.6 + (x * 1.2));
			transform.position = new Vector3(xz,yz,0f);
			TestOfMove.ExtendTail = 1;
			playerScore++;
			/*if (checkiftaken ()) {
				T = 0;
				a = 0;
			}*/
			a = 0;
		

		}



	}
	void tryAgain(){
		int y = Random.Range (1, 6);
		int x = Random.Range (1, 6);
		float yz = (float)(-3.6 + (y * 1.2));
		float xz = (float)(-3.6 + (x * 1.2));
		transform.position = new Vector3(xz,yz,0f);
	}
	bool checkiftaken(){
		if(T==1){
			return false;

		}
		else{
			return true;
		}
	}

}
