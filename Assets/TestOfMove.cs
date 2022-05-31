using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestOfMove : MonoBehaviour {
	public static int pos = 0;
	public static float speedOfGame = .5f;
	public static Vector3 PrevPos;
	public static int num = 0;
	public static int ExtendTail;
	public static int BodyCount = 0;
	public static List<GameObject> BodPieces = new List<GameObject>();
	public static GameObject qucker;
	public static int TestNum = 0;
	public static List<Vector3> Positions = new List<Vector3>();
	public static Vector3 prevOf3rdBlock;
	public bool HasHappened;
	public static int LastMovement = 0;
	public static Sprite[] Sprites = new Sprite[4];
	public static int HelpMe = 0;

	void awake(){
		Sprite S1 = Resources.Load<Sprite> ("Snake head");
		Sprite S2 = Resources.Load<Sprite> ("Snake head Down");
		Sprite S3 = Resources.Load<Sprite> ("Snake head Left");
		Sprite S4 = Resources.Load<Sprite> ("Snake head Right");

		Sprites[0] = S1;
		Sprites[1] = S2;
		Sprites[2] = S3;
		Sprites[3] = S4;


	}


	//, Resources.Load<Sprite>("Snake head Down"), Resources.Load<Sprite>("Snake head Left"),
	//	Resources.Load<Sprite>("Snake head Right")];

	public static bool run = true;
	//BasiclyTheSameThingButBlander BasiclyTheSameThingButBlander;
	void Start () {
		qucker = GameObject.Find ("Bod");
		InvokeRepeating ("Workz", 1, speedOfGame);

	}
	public static int a = BodyCount;
	void Update (){
//		if (Input.GetKeyDown (KeyCode.B)) {
//			SnakeEyes.xMoves = 0;
//		}
//		print (SnakeEyes.xMoves);
//		print (SnakeEyes.yMoves);



		if (SnakeEyes.yMoves != 0) {
			if (SnakeEyes.yMoves > 0) {
				//print (" y moves is pos");
				pos = 1;
			}
			if (SnakeEyes.yMoves < 0) {
				//print (" y moves is neg");
				pos = 2;
			}


		} else if(SnakeEyes.xMoves == 0){
			//This functions turns on immedeately....you most likely have alot more work than you think you have to get done
			//print ("It was on the whole time");
			if (SnakeEyes.xMoves > 0) {
				//print (" y moves is pos");
				pos = 3;
			}
			if (SnakeEyes.xMoves < 0) {
				//print (" x moves is neg");
				pos = 4;
			}
		}

		if (TestNum > 0) {
			
			//For the third block, takes care of its self
			//Array list of positions, n-1 

			if (TestNum == 1) {
				//BodPieces [0].GetComponent<Transform> ().position = BasiclyTheSameThingButBlander.PrevPos;
			}
			if (TestNum > 0) {

				for (int i = 0; i < BodPieces.Count; i++) {

					if (BodPieces [i] != null) {
						BodPieces [i].GetComponent<Transform> ().position = Positions [Positions.Count - (i + 2)];
					}
				}
			}
			

			//The player moves the snake
			//The second body pieces copies the player's prevPos value
			// the third body piece copies the second body pieces prevPos Value

			//Get the prev pos of the third block
			//have the third block move
			//Get the prev pos of the fourth block
			//have the fourth block move
			//get the prev pos of the 5th block
			//have the fith block move the fourth blocks' prev pos

			//get the prev pos of the nth block
			//the the nth block move to the n-1th block's prev pos


			/*			for (int i = 1 ; i < BodPieces.Count; i++) {
					Positions.Insert (i, NullVector);

				//The problem is you are adding positions, which prevents you from over lapping them
				if(Positions[i].Equals(null)){
				Positions.Insert(i,BodPieces [i].GetComponent<Transform> ().position);
				}else{
					Positions.RemoveAt(i);
					Positions.Insert(i,BodPieces [i].GetComponent<Transform> ().position);
				}

			} 

			for (int i = 1; i < BodPieces.Count; i++) {
				print ("a");
				BodPieces [i].GetComponent<Transform> ().position = Positions[i];
			}
			*/
			//This function is getting called continuously. Your only option is to continously set the same blocks to the same positions. You can't really use changing vars.
		}
	
			if (Input.GetMouseButtonDown(0)) {
			pos = 1;
			HelpMe = 1;
			}


			if (Input.GetKeyDown (KeyCode.Space)) {
				ExtendTail = 1;
			}
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
			HelpMe = 1;
			print (Resources.Load<Sprite> ("Snake head Right"));
			this.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Snake head Right");
			;
			if (LastMovement == 2) {pos = 2;} else {pos = 1;}
				
			}
			if (Input.GetKeyDown (KeyCode.DownArrow)) {
			HelpMe = 1;
			if (LastMovement == 1) {pos = 1;} else {pos = 2;}
			this.GetComponent<SpriteRenderer> ().sprite = Sprites[1];
			}
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			HelpMe = 1;
			if (LastMovement == 4) {pos = 4;} else {pos = 3;}
			this.GetComponent<SpriteRenderer> ().sprite = Sprites[2];
			}
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
			HelpMe = 1;
			if (LastMovement == 3) {pos = 3;} else {pos = 4;}
			this.GetComponent<SpriteRenderer> ().sprite = Sprites[3];						
			}
		
	
}
		void Workz (){
		PrevPos = transform.position;
		Positions.Add (PrevPos);
		if (pos == 1) {transform.Translate (0f, +1.2f, 0f);LastMovement = 1; 
	//		this.gameObject.GetComponent<SpriteRenderer> ().sprite = Cer [0];

			if (SnakeEyes.yMoves > 0) {
				SnakeEyes.yMoves--;
			}
		}
		if (pos == 2) {transform.Translate (0f, -1.2f, 0f);LastMovement = 2;
	
			if (SnakeEyes.yMoves < 0) {
				SnakeEyes.yMoves++;
			}

		}
		if (pos == 3) {transform.Translate (-1.2f, 0f, 0f);LastMovement = 3;

			if (SnakeEyes.xMoves < 0) {
				SnakeEyes.xMoves++;
			}

	//		this.gameObject.GetComponent<SpriteRenderer> ().sprite = Cer [2];
		}
		if (pos == 4) {transform.Translate (+1.2f, 0f, 0f);LastMovement = 4;
	//		this.gameObject.GetComponent<SpriteRenderer> ().sprite = Cer [3];

			if (SnakeEyes.xMoves > 0) {
				SnakeEyes.xMoves--;
			}

			}
		BasiclyTheSameThingButBlander.SomeFunction (PrevPos);
			if (ExtendTail == 1) {
				stall ();
			}
		}

	void stall(){
		BasiclyTheSameThingButBlander.num = 1; 
		if (ExtendTail == 1 ) {
			if (BodyCount == 0) {
				GameObject clone = Instantiate (qucker, PrevPos, transform.rotation);
				BodPieces.Add (clone);
			}
			if (BodyCount >0) {
				GameObject clone = Instantiate (qucker, BasiclyTheSameThingButBlander.PrevPos1, transform.rotation);
				BodPieces.Add (clone);
			}
			HasHappened = false;
			TestNum++;
			ExtendTail = 0;
			BodyCount++;
		}
	}


	public static void Ark(GameObject fuck){

		/*
		Vector3 prevPossss = BodPieces [2].GetComponent<Transform> ().position;
		Vector3 PrevPosss2;
		for(int i = 2; i<BodPieces.Count; i++){
			if (i == 2) {
				prevPossss = BodPieces [i].GetComponent<Transform> ().position;
				BodPieces [i].GetComponent<Transform> ().position = prevOf3rdBlock;
			} else {PrevPosss2 = BodPieces [i].GetComponent<Transform> ().position;
					BodPieces [i].GetComponent<Transform> ().position = prevPossss;
					prevPossss = PrevPosss2;
				
			}
		}
		*/
	BasiclyTheSameThingButBlander.num = 0;
}

		
	void OnCollisionEnter2D  (Collision2D col){
		
		if (HelpMe == 1 && col.gameObject.tag == "Player" || col.gameObject.tag == "Finish" ) {
			print ("you died");
			CancelInvoke ();
		}
	}



	public static void spriteChanger4 (){
		//GameObject.Find("Snake").GetComponent<SpriteRenderer> ().sprite = Sprites [3];
	}
	public static void spriteChanger3 (){
		//GameObject.Find("Snake").GetComponent<SpriteRenderer> ().sprite = Sprites [2];
	}
	public static void spriteChanger2 (){
		//GameObject.Find("Snake").GetComponent<SpriteRenderer> ().sprite = Sprites [1];
	}
	public void spriteChanger1 (){
	//	this.GetComponent<SpriteRenderer> ().sprite = Sprites [0];
	}
}

