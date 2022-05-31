using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasiclyTheSameThingButBlander : MonoBehaviour {
	public static Vector3 TheBigSauce;
	public static int num = 0;
	private static int Identification = TestOfMove.BodyCount;
	private static int head;
	public static Vector3 PrevPos;


	public static Vector3 PrevPos1;



	public static string LastName;



	void Start(){
		gameObject.name = "Bod" + TestOfMove.BodyCount;
		head = Identification - 1; 
		LastName = "Bod" + head;

		if (Identification == 1) {PleaseFuckingWork ();}
	}

	public static Vector3 ppRev(){
		return PrevPos;
	}

	public static void SomeFunction (Vector3 Coordz){
		
			//print (Coordz);
			TheBigSauce = Coordz;
			num = 1;

			



		// every action that occurs in this function will be a reuslt of using binary switch varibles.
	}

	void Update(){


		if (Identification == 0) {
			if (num == 1) {
				PrevPos = transform.position;
				transform.position = TheBigSauce;
				PrevPos1 = PrevPos;

			}
			num = 0;
		}
			
		//The script doesnt define the game object. Game objects are a part of the game object class, while scripts have thier own made classes.
	//problems:
		//Making each segment MotionVectorGenerationMode with the block infront of it


	//Identify the block ahead
	}

	void PleaseFuckingWork(){
		transform.Translate (+.1f, 0, 0);
	}


}
