using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeEyes : MonoBehaviour {

	public static bool BestPathFound = false;
	public static int xMoves = 0;
	public static int yMoves = 0;
	public static bool Verified = false;
	public static bool TopGate = false;
	public static bool BottomGate = false;

	// Use this for initialization
	void Start () {
		
	}

		void OnCollisionEnter2D(Collision2D col){
			if(col.gameObject.name == "Food"){
				//print ("They've kissed");
			}	
		}
	// Update is called once per frame
	void Update () {


		for (int i = (TestOfMove.BodyCount); i >= 0; i--) {
			if (GameObject.Find ("Snake").GetComponent<Transform> ().position.y == GameObject.Find ("Bod"+i).GetComponent<Transform> ().position.y && GameObject.Find ("Snake").GetComponent<Transform> ().position.x == GameObject.Find ("Bod"+i).GetComponent<Transform> ().position.x) {
				TestOfMove.HelpMe = 1;
			}
		}

		/*if(TestOfMove.BodyCount>0){
			
			for (int i =(TestOfMove.BodyCount); i >= 0; i--) {
				string name = "Bod" + i;
				print(GameObject.Find (name).GetComponent<Transform> ().position.y);

//Just a heads up, for SOME REASON, this for loop wont allow me to make a name with the Bod and BodyCount beacuase of a 'null' error.

				//print (GameObject.Find (name).GetComponent<Transform> ().position.y);
			}
		}*/


		if((GameObject.Find ("Snake").GetComponent<Transform> ().position.y)< ((GameObject.Find ("Food").GetComponent<Transform> ().position.y)-.3) || (GameObject.Find ("Snake").GetComponent<Transform> ().position.y)> ((GameObject.Find ("Food").GetComponent<Transform> ().position.y)+.3)){
			//print("verticle equality detected");
			TopGate = false;
			BottomGate = false;
			SafetyProcedures ();


			if(Verified){
				if((GameObject.Find ("Snake").GetComponent<Transform> ().position.y)< ((GameObject.Find ("Food").GetComponent<Transform> ().position.y)-.3)){
					//up
					GameObject.Find ("Snake").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Snake head");
					TestOfMove.pos = 1;
				}
				if((GameObject.Find ("Snake").GetComponent<Transform> ().position.y)> ((GameObject.Find ("Food").GetComponent<Transform> ().position.y)+.3)){
					//down
					GameObject.Find ("Snake").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Snake head Down");
					TestOfMove.pos = 2;
					Verified = false;
				}
			}

		}
		else{FinishThisShit();}






//Uncomment this if statement chunk to see if the snake eyes function works at its basic level


/*		
 * 
 * 
 * if (BestPathFound == false) {
			
			if (transform.position.x != GameObject.Find ("Food").GetComponent<Transform> ().position.x) {
				if (transform.position.x > GameObject.Find ("Food").GetComponent<Transform> ().position.x) {
					transform.Translate (-1.2f, 0f, 0f);
					xMoves = xMoves - 1;
				}
				if (transform.position.x < GameObject.Find ("Food").GetComponent<Transform> ().position.x) {
					transform.Translate (+1.2f, 0f, 0f);
					xMoves = xMoves + 1;
				}
			}

			if (transform.position.y != GameObject.Find ("Food").GetComponent<Transform> ().position.y) {
				if (transform.position.y > GameObject.Find ("Food").GetComponent<Transform> ().position.y) {
					transform.Translate (0f, -1.2f, 0f);
					yMoves = yMoves - 1;
				}
				if (transform.position.y < GameObject.Find ("Food").GetComponent<Transform> ().position.y) {
					transform.Translate (0f, +1.2f, 0f);
					yMoves = yMoves + 1;
				}
			}

			if (transform.position == GameObject.Find ("Food").GetComponent<Transform> ().position) {
				print ("its over");
				BestPathFound = true;
			}
				//		this.gameObject.GetComponent<SpriteRenderer> ().sprite = Cer [0];
		}





		/*	if (pos == 2) {
				transform.Translate (0f, -1.2f, 0f);
				//		this.gameObject.GetComponent<SpriteRenderer> ().sprite = Cer [1];
			}
			if (pos == 3) {
				transform.Translate (-1.2f, 0f, 0f);
				//		this.gameObject.GetComponent<SpriteRenderer> ().sprite = Cer [2];
			}
			if (pos == 4) {
				transform.Translate (+1.2f, 0f, 0f);
				//		this.gameObject.GetComponent<SpriteRenderer> ().sprite = Cer [3];
*/
			}

	/*
				*
				*
				*
				*
				*
				*
				*
				*
				*/


	void FinishThisShit(){


		//Since the snake's movements are based on a clock work system, you still have to check for upper and lower bounds with in this function as well.
		bool LeftObst = false;
		bool RightObst = false;


		if ((GameObject.Find ("Snake").GetComponent<Transform> ().position.x) < ((GameObject.Find ("Food").GetComponent<Transform> ().position.x) - .3) || (GameObject.Find ("Snake").GetComponent<Transform> ().position.x) > ((GameObject.Find ("Food").GetComponent<Transform> ().position.x) + .3)) {
			//print("horizontal equality detected");


			//checking if any objects are to the left or right


			if ((GameObject.Find ("Snake").GetComponent<Transform> ().position.x + 1.5) > 3.4) {
//				print ("Obstacle on the right");
				RightObst = true;



				bool Upwards = false;
				bool Downwards = false;


				for (int k = (TestOfMove.BodyCount); k >= 0; k--) {
					//print ("Snake Pos plus 2 =" + (GameObject.Find ("Snake").GetComponent<Transform> ().position.y + 2));
//					print ("Bod(x) y position = " + (GameObject.Find ("Bod" + k).GetComponent<Transform> ().position.y));
//					print (k);

					// the i varible isn't iterating propperly. You can maybe make another iteration, but the run time will b o(n^2) so, just keep that in mind

					if (((GameObject.Find ("Snake").GetComponent<Transform> ().position.y + 2) > (GameObject.Find ("Bod" + k).GetComponent<Transform> ().position.y)) && ((GameObject.Find ("Snake").GetComponent<Transform> ().position.y + 1) < (GameObject.Find ("Bod" + k).GetComponent<Transform> ().position.y))) {
						if (((GameObject.Find ("Snake").GetComponent<Transform> ().position.x) == (GameObject.Find ("Bod" + k).GetComponent<Transform> ().position.x))) {
							//print ("and There is something above me");
							Upwards = true;
						}
					} else {Upwards = false;}

					if (((GameObject.Find ("Snake").GetComponent<Transform> ().position.y - 2) < (GameObject.Find ("Bod" + k).GetComponent<Transform> ().position.y)) && ((GameObject.Find ("Snake").GetComponent<Transform> ().position.y - 1) > (GameObject.Find ("Bod" + k).GetComponent<Transform> ().position.y))) {
						if (((GameObject.Find ("Snake").GetComponent<Transform> ().position.x) == (GameObject.Find ("Bod" + k).GetComponent<Transform> ().position.x))) {
							//print ("and There is something BELLOW me");
							Downwards = true;
						}
					} else {Downwards = false;}
				}
				//print ("Down"+Downwards);
				//print ("Up"+Upwards);
				//print ("Left"+LeftObst);
				//print ("Right"+RightObst);
				if (Upwards && Downwards == false) {
					RightObst = true;
					print ("I will go down");
					TestOfMove.pos = 2;
					GameObject.Find ("Snake").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Snake head Down");
				}
				if (Downwards && Upwards == false) {
					RightObst = true;
					//print ("I will go up");
					TestOfMove.pos = 1;
					GameObject.Find ("Snake").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Snake head");
				}

					if (Downwards && Upwards) {
						RightObst = true;
						//print ("I will go to the left");
						TestOfMove.pos = 3;
						GameObject.Find ("Snake").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Snake head Left");
					}
				}
			 else {RightObst = false;}

			if ((GameObject.Find ("Snake").GetComponent<Transform> ().position.x - 1.7) < -4.7) {
				//print ("Obstacle on the Left");
				LeftObst = true;


				bool Upwards = false;
				bool Downwards = false;


				for (int k = (TestOfMove.BodyCount); k >= 0; k--) {
					//print ("Snake Pos plus 2 =" + (GameObject.Find ("Snake").GetComponent<Transform> ().position.y + 2));

					// the i varible isn't iterating propperly. You can maybe make another iteration, but the run time will b o(n^2) so, just keep that in mind

					if (((GameObject.Find ("Snake").GetComponent<Transform> ().position.y + 2) > (GameObject.Find ("Bod" + k).GetComponent<Transform> ().position.y)) && ((GameObject.Find ("Snake").GetComponent<Transform> ().position.y + 1) < (GameObject.Find ("Bod" + k).GetComponent<Transform> ().position.y))) {
						if (((GameObject.Find ("Snake").GetComponent<Transform> ().position.x) == (GameObject.Find ("Bod" + k).GetComponent<Transform> ().position.x))) {
							//print ("and There is something above me");
							Upwards = true;
						}
					} else {Upwards = false;}

					if (((GameObject.Find ("Snake").GetComponent<Transform> ().position.y - 2) < (GameObject.Find ("Bod" + k).GetComponent<Transform> ().position.y)) && ((GameObject.Find ("Snake").GetComponent<Transform> ().position.y - 1) > (GameObject.Find ("Bod" + k).GetComponent<Transform> ().position.y))) {
						if (((GameObject.Find ("Snake").GetComponent<Transform> ().position.x) == (GameObject.Find ("Bod" + k).GetComponent<Transform> ().position.x))) {
							//print ("and There is something BELLOW me");
							Downwards = true;
						}
					} else {Downwards = false;}
				}
//				print ("Down"+Downwards);
//				print ("Up"+Upwards);
//				print ("Left"+LeftObst);
//				print ("Right"+RightObst);
				if (Upwards && Downwards == false) {
					print ("I will go down");
					TestOfMove.pos = 2;
					GameObject.Find ("Snake").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Snake head Down");
				}
				if (Downwards && Upwards == false) {
					LeftObst = true;
					//print ("I will go Up");
					TestOfMove.pos = 1;
					GameObject.Find ("Snake").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Snake head");
				}

				if (Downwards && Upwards) {
					//print ("I will go to the Right");
					LeftObst = true;
					TestOfMove.pos = 4;
					GameObject.Find ("Snake").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Snake head Right");

				}
				if (Downwards == false && Upwards == false) {
					LeftObst = true;
					//print ("aple");
					TestOfMove.pos = 1;
					GameObject.Find ("Snake").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Snake head");
				}
			} else {LeftObst = false;}



			for (int i = (TestOfMove.BodyCount); i >= 0; i--) {

				//if there is a block to the right and if the food is to the right
				if (((GameObject.Find ("Snake").GetComponent<Transform> ().position.x + 2) > (GameObject.Find ("Bod" + i).GetComponent<Transform> ().position.x) && ((GameObject.Find ("Snake").GetComponent<Transform> ().position.x + 1) < (GameObject.Find ("Bod" + i).GetComponent<Transform> ().position.x)) && (GameObject.Find ("Snake").GetComponent<Transform> ().position.x) < ((GameObject.Find ("Food").GetComponent<Transform> ().position.x) - .3))) { 
					if ((GameObject.Find ("Snake").GetComponent<Transform> ().position.y) == (GameObject.Find ("Bod" + i).GetComponent<Transform> ().position.y)) {
						
						//ObstacleAvoidance (RightObst, null);
						//print ("Obstacle on the right");

						RightObst = true;

						//If by an edge




//						if (((GameObject.Find ("Snake").GetComponent<Transform> ().position.y + 1.4) > 3.59)) {
//
//
//							bool a = (((GameObject.Find ("Snake").GetComponent<Transform> ().position.y - 2) < (GameObject.Find ("Bod" + i).GetComponent<Transform> ().position.y))) && (((GameObject.Find ("Snake").GetComponent<Transform> ().position.y - 1) > (GameObject.Find ("Bod" + i).GetComponent<Transform> ().position.y)));
//							bool b = (((GameObject.Find ("Snake").GetComponent<Transform> ().position.x) == (GameObject.Find ("Bod" + i).GetComponent<Transform> ().position.x)));
//						
//
//							if (false == (!b && !a)) {
//								print ("aasds");
//								TestOfMove.pos = 2;
//							}
//						}
//						if (((GameObject.Find ("Snake").GetComponent<Transform> ().position.y - 1.4) > -4.5)) {
//							
//							bool a = (((GameObject.Find ("Snake").GetComponent<Transform> ().position.y + 2) > (GameObject.Find ("Bod" + i).GetComponent<Transform> ().position.y))) && (((GameObject.Find ("Snake").GetComponent<Transform> ().position.y + 1) < (GameObject.Find ("Bod" + i).GetComponent<Transform> ().position.y)));
//							bool b = (((GameObject.Find ("Snake").GetComponent<Transform> ().position.x) == (GameObject.Find ("Bod" + i).GetComponent<Transform> ().position.x)));
//
//							if (false == (b && a)) {
//								//print ("aasds");
//								TestOfMove.pos = 1;
//							
//							}
//						}

						//(((GameObject.Find ("Snake").GetComponent<Transform> ().position.y + 2) > (GameObject.Find ("Bod" + i).GetComponent<Transform> ().position.y))) && (((GameObject.Find ("Snake").GetComponent<Transform> ().position.y + 1) < (GameObject.Find ("Bod" + i).GetComponent<Transform> ().position.y)))
						//(((GameObject.Find ("Snake").GetComponent<Transform> ().position.x) == (GameObject.Find ("Bod" + i).GetComponent<Transform> ().position.x)))
						//if in a straight line


						bool Upwards = false;
						bool Downwards = false;


						for (int k = (TestOfMove.BodyCount); k >= 0; k--) {
							//print ("Snake Pos plus 2 =" + (GameObject.Find ("Snake").GetComponent<Transform> ().position.y + 2));
							//print ("Bod(x) y position = " + (GameObject.Find ("Bod" + k).GetComponent<Transform> ().position.y));
							//print (k);
						
							// the i varible isn't iterating propperly. You can maybe make another iteration, but the run time will b o(n^2) so, just keep that in mind

							if (((GameObject.Find ("Snake").GetComponent<Transform> ().position.y + 2) > (GameObject.Find ("Bod" + k).GetComponent<Transform> ().position.y)) && ((GameObject.Find ("Snake").GetComponent<Transform> ().position.y + 1) < (GameObject.Find ("Bod" + k).GetComponent<Transform> ().position.y))) {
								if (((GameObject.Find ("Snake").GetComponent<Transform> ().position.x) == (GameObject.Find ("Bod" + k).GetComponent<Transform> ().position.x))) {
									//print ("and There is something above me");
									Upwards = true;
								}
							} else {Upwards = false;}
					
							if (((GameObject.Find ("Snake").GetComponent<Transform> ().position.y - 2) < (GameObject.Find ("Bod" + k).GetComponent<Transform> ().position.y)) && ((GameObject.Find ("Snake").GetComponent<Transform> ().position.y - 1) > (GameObject.Find ("Bod" + k).GetComponent<Transform> ().position.y))) {
								if (((GameObject.Find ("Snake").GetComponent<Transform> ().position.x) == (GameObject.Find ("Bod" + k).GetComponent<Transform> ().position.x))) {
									//print ("and There is something BELLOW me");
									Downwards = true;
								}
							} else {Downwards = false;}
						}
//						print ("Down"+Downwards);
//						print ("Up"+Upwards);
//						print ("Left"+LeftObst);
//						print ("Right"+RightObst);
						if (Upwards && Downwards == false) {
							RightObst = true;
							//print ("I will go down");
								TestOfMove.pos = 2;
								GameObject.Find ("Snake").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Snake head Down");
							}
						if (Downwards && Upwards == false) {
							RightObst = true;
							//print ("I will go up");
							TestOfMove.pos = 1;
							GameObject.Find ("Snake").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Snake head");
						}

						if (Downwards && Upwards) {
							RightObst = true;
							//print ("I will go to the left");
							TestOfMove.pos = 3;
							GameObject.Find ("Snake").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Snake head Left");
							
						}
						
					}
				} else {
						RightObst = false;
					}
						



				 


				//Left side Commented out


				if (((GameObject.Find ("Snake").GetComponent<Transform> ().position.x - 2) < (GameObject.Find ("Bod" + i).GetComponent<Transform> ().position.x) && ((GameObject.Find ("Snake").GetComponent<Transform> ().position.x - 1) > (GameObject.Find ("Bod" + i).GetComponent<Transform> ().position.x)) && (GameObject.Find ("Snake").GetComponent<Transform> ().position.x) > ((GameObject.Find ("Food").GetComponent<Transform> ().position.x)))) { 
					if ((GameObject.Find ("Snake").GetComponent<Transform> ().position.y) == (GameObject.Find ("Bod" + i).GetComponent<Transform> ().position.y)) {

						//print ("Obstacle on the left");

						LeftObst = true;

						//					
						bool Upwards = false;
						bool Downwards = false;


						for (int k = (TestOfMove.BodyCount); k >= 0; k--) {
							//print ("Snake Pos plus 2 =" + (GameObject.Find ("Snake").GetComponent<Transform> ().position.y + 2));

							// the i varible isn't iterating propperly. You can maybe make another iteration, but the run time will b o(n^2) so, just keep that in mind

							if (((GameObject.Find ("Snake").GetComponent<Transform> ().position.y + 2) > (GameObject.Find ("Bod" + k).GetComponent<Transform> ().position.y)) && ((GameObject.Find ("Snake").GetComponent<Transform> ().position.y + 1) < (GameObject.Find ("Bod" + k).GetComponent<Transform> ().position.y))) {
								if (((GameObject.Find ("Snake").GetComponent<Transform> ().position.x) == (GameObject.Find ("Bod" + k).GetComponent<Transform> ().position.x))) {
									//print ("and There is something above me");
									Upwards = true;
								}
							} else {Upwards = false;}

							if (((GameObject.Find ("Snake").GetComponent<Transform> ().position.y - 2) < (GameObject.Find ("Bod" + k).GetComponent<Transform> ().position.y)) && ((GameObject.Find ("Snake").GetComponent<Transform> ().position.y - 1) > (GameObject.Find ("Bod" + k).GetComponent<Transform> ().position.y))) {
								if (((GameObject.Find ("Snake").GetComponent<Transform> ().position.x) == (GameObject.Find ("Bod" + k).GetComponent<Transform> ().position.x))) {
									//print ("and There is something BELLOW me");
									Downwards = true;
								}
							} else {Downwards = false;}
						}
//						print ("Down"+Downwards);
//						print ("Up"+Upwards);
//						print ("Left"+LeftObst);
//						print ("Right"+RightObst);
						if (Upwards && Downwards == false) {
							//print ("I will go down");
							TestOfMove.pos = 2;
							GameObject.Find ("Snake").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Snake head Down");
						}
						if (Downwards && Upwards == false) {
							LeftObst = true;
							//print ("I will go Up");
							TestOfMove.pos = 1;
							GameObject.Find ("Snake").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Snake head");
						}

						if (Downwards && Upwards) {
							//print ("I will go to the Right");
							LeftObst = true;
							TestOfMove.pos = 4;
							GameObject.Find ("Snake").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Snake head Right");

						}

						if (Downwards == false && Upwards == false) {
							LeftObst = true;
							//print ("aple");
							TestOfMove.pos = 1;
							GameObject.Find ("Snake").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Snake head");
						}
					

						}
					} else {LeftObst = false;}


				if (LeftObst == false && RightObst == false) {


					//print ("Normal");

					if ((GameObject.Find ("Snake").GetComponent<Transform> ().position.x) < ((GameObject.Find ("Food").GetComponent<Transform> ().position.x) - .3)) {
						GameObject.Find ("Snake").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Snake head Right");
						TestOfMove.spriteChanger4 ();
						TestOfMove.pos = 4;
					}
					if ((GameObject.Find ("Snake").GetComponent<Transform> ().position.x) > ((GameObject.Find ("Food").GetComponent<Transform> ().position.x) + .3)) {
						GameObject.Find ("Snake").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Snake head Left");
						TestOfMove.pos = 3;
					}




				} 


			}
		}}
			

			//if there is a block to the left and if the food is to the left

				
			
		


				/*
				*
				*
				*
				*
				*
				*
				*
				*
				*/

	void SafetyProcedures(){

		//Debug for overlaping true statements

		//The function wont tell you if a block is above or bellow when it is turned to the left/right because the verticle change function doesnt have any code that checks for above or bellow
		//blocks. Just keep that in mind

		// an issue with this method is that it doesnt account for verticle distance. If a block is immedeatly lower than the snake but 10+ x distnace away, than it still
		//thinks the body piece is a threat.

		TopGate = false;
		BottomGate = false;
		bool UpperFucker = false;
		bool BottomText = false;
		bool LeftOc = false;
		bool RightOc = false;
		//Making sure that the snake doesnt run into its self



		if (((GameObject.Find ("Snake").GetComponent<Transform> ().position.y + 1.4) > 3.59)) {
			TopGate = true;
		}
		if (((GameObject.Find ("Snake").GetComponent<Transform> ().position.y - 1.4) > -4.5)) {
			BottomGate = true;
		}

		for (int i =(TestOfMove.BodyCount); i >= 0; i--) {//The traversal and the indexies are most likely causes of error)
			//print(TestOfMove.Positions [i-1].y);


			if (((GameObject.Find ("Snake").GetComponent<Transform> ().position.x+1) < (GameObject.Find ("Bod" + i).GetComponent<Transform> ().position.y)) && ((GameObject.Find ("Snake").GetComponent<Transform> ().position.x+2) > (GameObject.Find ("Bod" + i).GetComponent<Transform> ().position.y))) {
				if (((GameObject.Find ("Snake").GetComponent<Transform> ().position.y) == (GameObject.Find ("Bod" + i).GetComponent<Transform> ().position.y))) {
					RightOc = true;
				}
			}

			if (((GameObject.Find ("Snake").GetComponent<Transform> ().position.x-1) > (GameObject.Find ("Bod" + i).GetComponent<Transform> ().position.y)) && ((GameObject.Find ("Snake").GetComponent<Transform> ().position.x-2) < (GameObject.Find ("Bod" + i).GetComponent<Transform> ().position.y))) {
				if (((GameObject.Find ("Snake").GetComponent<Transform> ().position.y) == (GameObject.Find ("Bod" + i).GetComponent<Transform> ().position.y))) {
					LeftOc = true;
				}
			}


			if ((GameObject.Find ("Snake").GetComponent<Transform> ().position.y) > (GameObject.Find ("Bod"+i).GetComponent<Transform> ().position.y+.3) && (GameObject.Find ("Snake").GetComponent<Transform> ().position.y-1) > (GameObject.Find ("Bod"+i).GetComponent<Transform> ().position.y)){ 
				//print (i+"Dont Worry about this number for now");
				if ((GameObject.Find ("Snake").GetComponent<Transform> ().position.x) > (GameObject.Find ("Bod" + i).GetComponent<Transform> ().position.x-1) && (GameObject.Find ("Snake").GetComponent<Transform> ().position.x) < (GameObject.Find ("Bod" + i).GetComponent<Transform> ().position.x+1)) {
						
					//print ("There is a block BELLOW of me");	
					BottomText = true;
					}
				}
			if ((GameObject.Find ("Snake").GetComponent<Transform> ().position.y+.3) < (GameObject.Find ("Bod"+i).GetComponent<Transform> ().position.y) && (GameObject.Find ("Snake").GetComponent<Transform> ().position.y) < (GameObject.Find ("Bod"+i).GetComponent<Transform> ().position.y)) {//Potential out of bounds error
					if ((GameObject.Find ("Snake").GetComponent<Transform> ().position.x) > (GameObject.Find ("Bod" + i).GetComponent<Transform> ().position.x-1) && (GameObject.Find ("Snake").GetComponent<Transform> ().position.x) < (GameObject.Find ("Bod" + i).GetComponent<Transform> ().position.x +1)) {
					//	print ("There is a block above me");		
					UpperFucker = true;
					}
				}
			}

		if(BottomText == false && UpperFucker == false){
			Verified = true;
		}

		if (BottomText && UpperFucker) {

			if(RightOc && LeftOc == false){
				GameObject.Find ("Snake").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Snake head Left");
				TestOfMove.pos = 3;
			}

			else if(LeftOc && RightOc == false){
				GameObject.Find ("Snake").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Snake head Right");
				TestOfMove.pos = 4;
			}else{
			FinishThisShit ();
			}
		}

		if (UpperFucker && ((GameObject.Find ("Snake").GetComponent<Transform> ().position.y) < ((GameObject.Find ("Food").GetComponent<Transform> ().position.y) - .3))) {
			if(RightOc && LeftOc == false){
				GameObject.Find ("Snake").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Snake head Left");
				TestOfMove.pos = 3;
			}

			else if(LeftOc && RightOc == false){
				GameObject.Find ("Snake").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Snake head Right");
				TestOfMove.pos = 4;
			}else{
				TopGate = true;
				ObstacleAvoidance (false, false);
			}

		}

		if (BottomText && ((GameObject.Find ("Snake").GetComponent<Transform> ().position.y)> ((GameObject.Find ("Food").GetComponent<Transform> ().position.y)+.3))) {
			if (UpperFucker && ((GameObject.Find ("Snake").GetComponent<Transform> ().position.y) < ((GameObject.Find ("Food").GetComponent<Transform> ().position.y) - .3))) {
				if(RightOc && LeftOc == false){
					GameObject.Find ("Snake").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Snake head Left");
					TestOfMove.pos = 3;
				}

				else if(LeftOc && RightOc == false){
					GameObject.Find ("Snake").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Snake head Right");
					TestOfMove.pos = 4;
				}else{
					BottomGate = true;
					ObstacleAvoidance (false, false);
				}

			}

		}
		//If something is in its way
		if (UpperFucker && ((GameObject.Find ("Snake").GetComponent<Transform> ().position.y)> ((GameObject.Find ("Food").GetComponent<Transform> ().position.y)+.3))) {
			//print ("I should move down");
			Verified = true;
		}
		if (BottomText && ((GameObject.Find ("Snake").GetComponent<Transform> ().position.y) < ((GameObject.Find ("Food").GetComponent<Transform> ().position.y) - .3))) {
			Verified = true;
		}
	}



	void ObstacleAvoidance (bool R,bool L){

			

			for (int i = (TestOfMove.BodyCount); i >= 0; i--) {

				//Checking above

		


			if ((((GameObject.Find ("Snake").GetComponent<Transform> ().position.y + 1) > (GameObject.Find ("Bod" + i).GetComponent<Transform> ().position.y)) && ((GameObject.Find ("Snake").GetComponent<Transform> ().position.y + 2) < (GameObject.Find ("Bod" + i).GetComponent<Transform> ().position.y)))) {
					if(((GameObject.Find ("Snake").GetComponent<Transform> ().position.x + .3) < (GameObject.Find ("Bod" + i).GetComponent<Transform> ().position.x) && ((GameObject.Find ("Snake").GetComponent<Transform> ().position.x - .3) > (GameObject.Find ("Bod" + i).GetComponent<Transform> ().position.x)))){
						TopGate = true;
					}
				}




			if ((((GameObject.Find ("Snake").GetComponent<Transform> ().position.y - 1) < (GameObject.Find ("Bod" + i).GetComponent<Transform> ().position.y)) && ((GameObject.Find ("Snake").GetComponent<Transform> ().position.y - 2) > (GameObject.Find ("Bod" + i).GetComponent<Transform> ().position.y)))) {
					if(((GameObject.Find ("Snake").GetComponent<Transform> ().position.x + .3) < (GameObject.Find ("Bod" + i).GetComponent<Transform> ().position.x) && ((GameObject.Find ("Snake").GetComponent<Transform> ().position.x - .3) > (GameObject.Find ("Bod" + i).GetComponent<Transform> ().position.x)))){
						BottomGate = true;
					}
				}
			}


			if (TopGate && BottomGate == false) {
				GameObject.Find ("Snake").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Snake head Down");
				TestOfMove.pos = 2;
				FinishThisShit ();
			}

			if (BottomGate && TopGate == false) {
				GameObject.Find ("Snake").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Snake head");
				TestOfMove.pos = 1;
				FinishThisShit ();
			}

//			if (BottomGate && TopGate) {
//				if (R) {
//					GameObject.Find ("Snake").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Snake head Left");
//					TestOfMove.pos = 3;
//				} else {
//					GameObject.Find ("Snake").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Snake head Right");
//					TestOfMove.pos = 4;
//				}
//
//			}
				
		}
}