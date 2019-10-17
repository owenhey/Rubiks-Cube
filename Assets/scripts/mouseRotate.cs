using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mouseRotate : MonoBehaviour {

	public int clickTimer;
	public char rotating;
	public GameObject[,,] rubiksCube = new GameObject[3, 3, 3];
	public GameObject cubesCenter;
	public int randomizer;
	public List<char> moves = new List<char>();

	//the rubiks cube can be though of as the red side facing the screen, with the array
	//going backwards. It goes bottom left -> top right-> front -> backs
	//so when you start, you are looking at the red face, which the bottom left corner
	//cube has the place in the 3d array of [0,0,0]. The back right corner of the cube
	// (the orange side), would be [2,2,2].

	// Use this for initialization
	void Start () {
		makeRubiksCube();
		clickTimer = 0;
		randomizer = 0;
		rotating = 'n';
		cubesCenter = GameObject.Find("cubes");
	}
	
	// Update is called once per frame
	void Update () {
		clickTimer++;

		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}

		if(Input.GetKeyDown(KeyCode.R)){
			SceneManager.LoadScene("SampleScene");
		}

		//rotates the cube when you drag
		if(Input.GetKey(KeyCode.Mouse2)){
			transform.Rotate(new Vector3(6f*Input.GetAxis("Mouse Y"), 0, 0), Space.World);
			transform.Rotate(new Vector3(0, -6f*Input.GetAxis("Mouse X"), 0), Space.World);
		}

		if(Input.GetKey(KeyCode.DownArrow)){
			transform.Rotate(new Vector3(-3, 0, 0), Space.World);	
		}
		if(Input.GetKey(KeyCode.UpArrow)){
			transform.Rotate(new Vector3(3, 0, 0), Space.World);
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			transform.Rotate(new Vector3(0, 3, 0), Space.World);
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			transform.Rotate(new Vector3(0, -3, 0), Space.World);
		}

		if(rotating != 'n'){
			if(rotating == 'r'){
				rubiksCube[1,1,0].transform.Rotate(6f*Vector3.forward);
				if(clickTimer > 14){
					rotating = 'n';

		    		for(int i = 0; i < 3; i++){
		    			for(int j = 0; j < 3; j++){
		    				if(!(i != 1 && j != 1)){
		    					setCubeParent(ref rubiksCube[i,j,0]);
		    				}
		    			}
		    		}
				}
			}
			if(rotating == 'R'){
				rubiksCube[1,1,0].transform.Rotate(-6f*Vector3.forward);
				if(clickTimer > 14){
					rotating = 'n';
			
		    		for(int i = 0; i < 3; i++){
		    			for(int j = 0; j < 3; j++){
		    				if(!(i != 1 && j != 1)){
		    					setCubeParent(ref rubiksCube[i,j,0]);
		    				}
		    			}
		    		}
				}
			}
			if(rotating == 'b'){
				rubiksCube[0,1,1].transform.Rotate(6f*Vector3.up);
				if(clickTimer > 14){
					rotating = 'n';
		    		for(int i = 0; i < 3; i++){
		    			for(int j = 0; j < 3; j++){
		    				if(!(i != 1 && j != 1)){
		    					setCubeParent(ref rubiksCube[0,i,j]);
		    				}
		    			}
		    		}
				}
			}
			if(rotating == 'B'){
				rubiksCube[0,1,1].transform.Rotate(-6f*Vector3.up);
				if(clickTimer > 14){
					rotating = 'n';
			
	        		for(int i = 0; i < 3; i++){
	        			for(int j = 0; j < 3; j++){
	        				if(!(i != 1 && j != 1)){
	        					setCubeParent(ref rubiksCube[0,i,j]);
	        				}
	        			}
	        		}
				}
			}
			if(rotating == 'g'){
				rubiksCube[2,1,1].transform.Rotate(-6f*Vector3.up);
				if(clickTimer > 14){
					rotating = 'n';
	        		for(int i = 0; i < 3; i++){
	        			for(int j = 0; j < 3; j++){
	        				if(!(i != 1 && j != 1)){
	        					setCubeParent(ref rubiksCube[2,i,j]);
	        				}
	        			}
	        		}
				}
			}
			if(rotating == 'G'){
				rubiksCube[2,1,1].transform.Rotate(6f*Vector3.up);
				if(clickTimer > 14){
					rotating = 'n';
		    		for(int i = 0; i < 3; i++){
	        			for(int j = 0; j < 3; j++){
	        				if(!(i != 1 && j != 1)){
	        					setCubeParent(ref rubiksCube[2,i,j]);
	        				}
	        			}
	        		}
				}
			}
			if(rotating == 'o'){
				rubiksCube[1,1,2].transform.Rotate(-6f*Vector3.forward);
				if(clickTimer > 14){
					rotating = 'n';
	        		for(int i = 0; i < 3; i++){
	        			for(int j = 0; j < 3; j++){
	        				if(!(i != 1 && j != 1)){
	        					setCubeParent(ref rubiksCube[i,j,2]);
	        				}
	        			}
	        		}
				}
			}
			if(rotating == 'O'){
				rubiksCube[1,1,2].transform.Rotate(6f*Vector3.forward);
				if(clickTimer > 14){
					rotating = 'n';
	        		for(int i = 0; i < 3; i++){
	        			for(int j = 0; j < 3; j++){
	        				if(!(i != 1 && j != 1)){
	        					setCubeParent(ref rubiksCube[i,j,2]);
	        				}
	        			}
	        		}
				}
			}
			if(rotating == 'w'){
	        	rubiksCube[1,2,1].transform.Rotate(-6f*Vector3.right);
				if(clickTimer > 14){
					rotating = 'n';
	        		for(int i = 0; i < 3; i++){
	        			for(int j = 0; j < 3; j++){
	        				if(!(i != 1 && j != 1)){
	        					setCubeParent(ref rubiksCube[i,2,j]);
	        				}
	        			}
	        		}
				}
			}
			if(rotating == 'W'){
				rubiksCube[1,2,1].transform.Rotate(6f*Vector3.right);
				if(clickTimer > 14){
					rotating = 'n';
	        		for(int i = 0; i < 3; i++){
	        			for(int j = 0; j < 3; j++){
	        				if(!(i != 1 && j != 1)){
	        					setCubeParent(ref rubiksCube[i,2,j]);
	        				}
	        			}
	        		}
				}
			}
			if(rotating == 'y'){
	        	rubiksCube[1,0,1].transform.Rotate(6f*Vector3.right);
				if(clickTimer > 14){
					rotating = 'n';
	        		for(int i = 0; i < 3; i++){
	        			for(int j = 0; j < 3; j++){
	        				if(!(i != 1 && j != 1)){
	        					setCubeParent(ref rubiksCube[i,0,j]);
	        				}
	        			}
	        		}
				}
			}
			if(rotating == 'Y'){
				rubiksCube[1,0,1].transform.Rotate(-6f*Vector3.right);
				if(clickTimer > 14){
					rotating = 'n';
	        		for(int i = 0; i < 3; i++){
	        			for(int j = 0; j < 3; j++){
	        				if(!(i != 1 && j != 1)){
	        					setCubeParent(ref rubiksCube[i,0,j]);
	        				}
	        			}
	        		}
				}
			}
		}
 
		if(moves.Count > 0 && Input.GetKey(KeyCode.A) && clickTimer > 17){
			clickTimer = 0;
			if(moves[moves.Count - 1] == 'R'){
        		for(int i = 0; i < 3; i++){
        			for(int j = 0; j < 3; j++){
        				if(!(i == 1 && j == 1)){
        					rubiksCube[i,j,0].transform.SetParent(rubiksCube[1,1,0].transform);
        				}
        			}
        		}

        		//move the squares around
        		rotateCubes('r');
        		rotating = 'r';
        	}
        	else if(moves[moves.Count - 1] == 'B'){
        		for(int i = 0; i < 3; i++){
        			for(int j = 0; j < 3; j++){
        				if(!(i == 1 && j == 1)){
        					rubiksCube[0,i,j].transform.SetParent(rubiksCube[0,1,1].transform);
        				}
        			}
        		}
        		rotateCubes('b');
        		rotating = 'b';
        	}
        	else if(moves[moves.Count - 1] == 'G'){
        		for(int i = 0; i < 3; i++){
        			for(int j = 0; j < 3; j++){
        				if(!(i == 1 && j == 1)){
        					rubiksCube[2,i,j].transform.SetParent(rubiksCube[2,1,1].transform);
        				}
        			}
        		}
        		rotateCubes('g');
        		rotating = 'g';
        	}
        	else if(moves[moves.Count - 1] == 'O'){
        		for(int i = 0; i < 3; i++){
        			for(int j = 0; j < 3; j++){
        				if(!(i == 1 && j == 1)){
        					rubiksCube[i,j,2].transform.SetParent(rubiksCube[1,1,2].transform);
        				}
        			}
        		}
        		//move the squares around
        		rotateCubes('o');
        		rotating = 'o';
        	}
        	else if(moves[moves.Count - 1] == 'W'){
        		for(int i = 0; i < 3; i++){
        			for(int j = 0; j < 3; j++){
        				if(!(i == 1 && j == 1)){
        					rubiksCube[i,2,j].transform.SetParent(rubiksCube[1,2,1].transform);
        				}
        			}
        		}
        		//move the squares around
        		rotateCubes('w');
        		rotating = 'w';
        	}
        	else if(moves[moves.Count - 1] == 'Y'){
        		for(int i = 0; i < 3; i++){
        			for(int j = 0; j < 3; j++){
        				if(!(i == 1 && j == 1)){
        					rubiksCube[i,0,j].transform.SetParent(rubiksCube[1,0,1].transform);
        				}
        			}
        		}
        		//move the squares around
        		rotateCubes('y');
        		rotating = 'y';
        	}
        	if(moves[moves.Count - 1] == 'r'){
        		for(int i = 0; i < 3; i++){
        			for(int j = 0; j < 3; j++){
        				if(!(i == 1 && j == 1)){
        					rubiksCube[i,j,0].transform.SetParent(rubiksCube[1,1,0].transform);
        				}
        			}
        		}
        		//move the squares around
        		rotateCubes('r');
        		rotateCubes('r');
        		rotateCubes('r');
        		rotating = 'R';
        	}
        	else if(moves[moves.Count - 1] == 'b'){
        		for(int i = 0; i < 3; i++){
        			for(int j = 0; j < 3; j++){
        				if(!(i == 1 && j == 1)){
        					rubiksCube[0,i,j].transform.SetParent(rubiksCube[0,1,1].transform);
        				}
        			}
        		}
        		rotateCubes('b');
        		rotateCubes('b');
        		rotateCubes('b');
        		rotating = 'B';
        	}
        	else if(moves[moves.Count - 1] == 'g'){
        		for(int i = 0; i < 3; i++){
        			for(int j = 0; j < 3; j++){
        				if(!(i == 1 && j == 1)){
        					rubiksCube[2,i,j].transform.SetParent(rubiksCube[2,1,1].transform);
        				}
        			}
        		}
        		rotateCubes('g');
        		rotateCubes('g');
        		rotateCubes('g');
        		rotating = 'G';
        	}
        	else if(moves[moves.Count - 1] == 'o'){
        		for(int i = 0; i < 3; i++){
        			for(int j = 0; j < 3; j++){
        				if(!(i == 1 && j == 1)){
        					rubiksCube[i,j,2].transform.SetParent(rubiksCube[1,1,2].transform);
        				}
        			}
        		}
        		//move the squares around
        		rotateCubes('o');
        		rotateCubes('o');
        		rotateCubes('o');
        		rotating = 'O';
        	}
        	else if(moves[moves.Count - 1] == 'w'){
        		for(int i = 0; i < 3; i++){
        			for(int j = 0; j < 3; j++){
        				if(!(i == 1 && j == 1)){
        					rubiksCube[i,2,j].transform.SetParent(rubiksCube[1,2,1].transform);
        				}
        			}
        		}
        		//move the squares around
        		rotateCubes('w');
        		rotateCubes('w');
        		rotateCubes('w');
        		rotating = 'W';
        	}
        	else if(moves[moves.Count - 1] == 'y'){
        		for(int i = 0; i < 3; i++){
        			for(int j = 0; j < 3; j++){
        				if(!(i == 1 && j == 1)){
        					rubiksCube[i,0,j].transform.SetParent(rubiksCube[1,0,1].transform);
        				}
        			}
        		}
        		//move the squares around
        		rotateCubes('y');
        		rotateCubes('y');
        		rotateCubes('y');
        		rotating = 'Y';
        	}
        	moves.RemoveAt(moves.Count - 1);
		}

		if(randomizer > 0 || Input.GetKey(KeyCode.S)){
			randomizer++;
			if(randomizer == 320){
				randomizer = 0;
			}
			if(randomizer % 16 == 0){
				clickTimer = 0;
				int ran = Random.Range(0,12);
				if(ran == 0){
            		for(int i = 0; i < 3; i++){
            			for(int j = 0; j < 3; j++){
            				if(!(i == 1 && j == 1)){
            					rubiksCube[i,j,0].transform.SetParent(rubiksCube[1,1,0].transform);
            				}
            			}
            		}
            		moves.Add('r');
            		//move the squares around
            		rotateCubes('r');
            		rotating = 'r';
            	}
            	else if(ran == 1){
            		for(int i = 0; i < 3; i++){
            			for(int j = 0; j < 3; j++){
            				if(!(i == 1 && j == 1)){
            					rubiksCube[0,i,j].transform.SetParent(rubiksCube[0,1,1].transform);
            				}
            			}
            		}
            		moves.Add('b');
            		rotateCubes('b');
            		rotating = 'b';
            	}
            	else if(ran == 2){
            		for(int i = 0; i < 3; i++){
            			for(int j = 0; j < 3; j++){
            				if(!(i == 1 && j == 1)){
            					rubiksCube[2,i,j].transform.SetParent(rubiksCube[2,1,1].transform);
            				}
            			}
            		}
            		moves.Add('g');
            		rotateCubes('g');
            		rotating = 'g';
            	}
            	else if(ran == 3){
            		for(int i = 0; i < 3; i++){
            			for(int j = 0; j < 3; j++){
            				if(!(i == 1 && j == 1)){
            					rubiksCube[i,j,2].transform.SetParent(rubiksCube[1,1,2].transform);
            				}
            			}
            		}
            		//move the squares around
            		moves.Add('o');
            		rotateCubes('o');
            		rotating = 'o';
            	}
            	else if(ran == 4){
            		for(int i = 0; i < 3; i++){
            			for(int j = 0; j < 3; j++){
            				if(!(i == 1 && j == 1)){
            					rubiksCube[i,2,j].transform.SetParent(rubiksCube[1,2,1].transform);
            				}
            			}
            		}
            		//move the squares around
            		moves.Add('w');
            		rotateCubes('w');
            		rotating = 'w';
            	}
            	else if(ran == 5){
            		for(int i = 0; i < 3; i++){
            			for(int j = 0; j < 3; j++){
            				if(!(i == 1 && j == 1)){
            					rubiksCube[i,0,j].transform.SetParent(rubiksCube[1,0,1].transform);
            				}
            			}
            		}
            		//move the squares around
            		moves.Add('y');
            		rotateCubes('y');
            		rotating = 'y';
            	}
            	if(ran == 6){
            		for(int i = 0; i < 3; i++){
            			for(int j = 0; j < 3; j++){
            				if(!(i == 1 && j == 1)){
            					rubiksCube[i,j,0].transform.SetParent(rubiksCube[1,1,0].transform);
            				}
            			}
            		}
            		//move the squares around
            		rotateCubes('r');
            		rotateCubes('r');
            		rotateCubes('r');
            		moves.Add('R');
            		rotating = 'R';
            	}
            	else if(ran == 7){
            		for(int i = 0; i < 3; i++){
            			for(int j = 0; j < 3; j++){
            				if(!(i == 1 && j == 1)){
            					rubiksCube[0,i,j].transform.SetParent(rubiksCube[0,1,1].transform);
            				}
            			}
            		}
            		rotateCubes('b');
            		rotateCubes('b');
            		rotateCubes('b');
            		moves.Add('B');
            		rotating = 'B';
            	}
            	else if(ran == 8){
            		for(int i = 0; i < 3; i++){
            			for(int j = 0; j < 3; j++){
            				if(!(i == 1 && j == 1)){
            					rubiksCube[2,i,j].transform.SetParent(rubiksCube[2,1,1].transform);
            				}
            			}
            		}
            		rotateCubes('g');
            		rotateCubes('g');
            		rotateCubes('g');
            		moves.Add('G');
            		rotating = 'G';
            	}
            	else if(ran == 9){
            		for(int i = 0; i < 3; i++){
            			for(int j = 0; j < 3; j++){
            				if(!(i == 1 && j == 1)){
            					rubiksCube[i,j,2].transform.SetParent(rubiksCube[1,1,2].transform);
            				}
            			}
            		}
            		//move the squares around
            		rotateCubes('o');
            		rotateCubes('o');
            		moves.Add('O');
            		rotateCubes('o');
            		rotating = 'O';
            	}
            	else if(ran == 10){
            		for(int i = 0; i < 3; i++){
            			for(int j = 0; j < 3; j++){
            				if(!(i == 1 && j == 1)){
            					rubiksCube[i,2,j].transform.SetParent(rubiksCube[1,2,1].transform);
            				}
            			}
            		}
            		//move the squares around
            		rotateCubes('w');
            		rotateCubes('w');
            		rotateCubes('w');
            		moves.Add('W');
            		rotating = 'W';
            	}
            	else if(ran == 11){
            		for(int i = 0; i < 3; i++){
            			for(int j = 0; j < 3; j++){
            				if(!(i == 1 && j == 1)){
            					rubiksCube[i,0,j].transform.SetParent(rubiksCube[1,0,1].transform);
            				}
            			}
            		}
            		//move the squares around
            		rotateCubes('y');
            		rotateCubes('y');
            		rotateCubes('y');
            		moves.Add('Y');
            		rotating = 'Y';
            	}
			}
		}

        if(Input.GetMouseButtonDown(1) && clickTimer > 17 && rotating == 'n'){
        	//checks if you hit a game object
	        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	        RaycastHit hit;
	         
	        if(Physics.Raycast(ray, out hit, 25.0f)){
	           if(hit.transform){ 
	            	clickTimer = 0;
	            	if(hit.transform.gameObject.name == "redSide"){
	            		moves.Add('r');
	            		for(int i = 0; i < 3; i++){
	            			for(int j = 0; j < 3; j++){
	            				if(!(i == 1 && j == 1)){
	            					rubiksCube[i,j,0].transform.SetParent(rubiksCube[1,1,0].transform);
	            				}
	            			}
	            		}

	            		//move the squares around
	            		rotateCubes('r');
	            		rotating = 'r';
	            	}
	            	else if(hit.transform.gameObject.name == "blueSide"){
	            		moves.Add('b');
	            		for(int i = 0; i < 3; i++){
	            			for(int j = 0; j < 3; j++){
	            				if(!(i == 1 && j == 1)){
	            					rubiksCube[0,i,j].transform.SetParent(rubiksCube[0,1,1].transform);
	            				}
	            			}
	            		}
	            		rotateCubes('b');
	            		rotating = 'b';
	            	}
	            	else if(hit.transform.gameObject.name == "greenSide"){
	            		moves.Add('g');
	            		for(int i = 0; i < 3; i++){
	            			for(int j = 0; j < 3; j++){
	            				if(!(i == 1 && j == 1)){
	            					rubiksCube[2,i,j].transform.SetParent(rubiksCube[2,1,1].transform);
	            				}
	            			}
	            		}
	            		rotateCubes('g');
	            		rotating = 'g';
	            	}
	            	else if(hit.transform.gameObject.name == "orangeSide"){
	            		moves.Add('o');
	            		for(int i = 0; i < 3; i++){
	            			for(int j = 0; j < 3; j++){
	            				if(!(i == 1 && j == 1)){
	            					rubiksCube[i,j,2].transform.SetParent(rubiksCube[1,1,2].transform);
	            				}
	            			}
	            		}
	            		//move the squares around
	            		rotateCubes('o');
	            		rotating = 'o';
	            	}
	            	else if(hit.transform.gameObject.name == "whiteSide"){
	            		moves.Add('w');
	            		for(int i = 0; i < 3; i++){
	            			for(int j = 0; j < 3; j++){
	            				if(!(i == 1 && j == 1)){
	            					rubiksCube[i,2,j].transform.SetParent(rubiksCube[1,2,1].transform);
	            				}
	            			}
	            		}
	            		//move the squares around
	            		rotateCubes('w');
	            		rotating = 'w';
	            	}
	            	else if(hit.transform.gameObject.name == "yellowSide"){
	            		moves.Add('y');
	            		for(int i = 0; i < 3; i++){
	            			for(int j = 0; j < 3; j++){
	            				if(!(i == 1 && j == 1)){
	            					rubiksCube[i,0,j].transform.SetParent(rubiksCube[1,0,1].transform);
	            				}
	            			}
	            		}
	            		//move the squares around
	            		rotateCubes('y');
	            		rotating = 'y';
	            	}
	            }
	        }
	    }

	    if(Input.GetMouseButtonDown(0) && clickTimer > 17 && rotating == 'n'){
	        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	        RaycastHit hit;

	         
	        if(Physics.Raycast(ray, out hit, 25.0f)){
	            if(hit.transform){ 
	            	clickTimer = 0;
	            	if(hit.transform.gameObject.name == "redSide"){
	            		moves.Add('R');
	            		for(int i = 0; i < 3; i++){
	            			for(int j = 0; j < 3; j++){
	            				if(!(i == 1 && j == 1)){
	            					rubiksCube[i,j,0].transform.SetParent(rubiksCube[1,1,0].transform);
	            				}
	            			}
	            		}
	            		//move the squares around
	            		rotateCubes('r');
	            		rotateCubes('r');
	            		rotateCubes('r');
	            		rotating = 'R';
	            	}
	            	else if(hit.transform.gameObject.name == "blueSide"){
	            		moves.Add('B');
	            		for(int i = 0; i < 3; i++){
	            			for(int j = 0; j < 3; j++){
	            				if(!(i == 1 && j == 1)){
	            					rubiksCube[0,i,j].transform.SetParent(rubiksCube[0,1,1].transform);
	            				}
	            			}
	            		}
	            		rotateCubes('b');
	            		rotateCubes('b');
	            		rotateCubes('b');
	            		rotating = 'B';
	            	}
	            	else if(hit.transform.gameObject.name == "greenSide"){
	            		moves.Add('G');
	            		for(int i = 0; i < 3; i++){
	            			for(int j = 0; j < 3; j++){
	            				if(!(i == 1 && j == 1)){
	            					rubiksCube[2,i,j].transform.SetParent(rubiksCube[2,1,1].transform);
	            				}
	            			}
	            		}
	            		rotateCubes('g');
	            		rotateCubes('g');
	            		rotateCubes('g');
	            		rotating = 'G';
	            	}
	            	else if(hit.transform.gameObject.name == "orangeSide"){
	            		moves.Add('O');
	            		for(int i = 0; i < 3; i++){
	            			for(int j = 0; j < 3; j++){
	            				if(!(i == 1 && j == 1)){
	            					rubiksCube[i,j,2].transform.SetParent(rubiksCube[1,1,2].transform);
	            				}
	            			}
	            		}
	            		//move the squares around
	            		rotateCubes('o');
	            		rotateCubes('o');
	            		rotateCubes('o');
	            		rotating = 'O';
	            	}
	            	else if(hit.transform.gameObject.name == "whiteSide"){
	            		moves.Add('W');
	            		for(int i = 0; i < 3; i++){
	            			for(int j = 0; j < 3; j++){
	            				if(!(i == 1 && j == 1)){
	            					rubiksCube[i,2,j].transform.SetParent(rubiksCube[1,2,1].transform);
	            				}
	            			}
	            		}
	            		//move the squares around
	            		rotateCubes('w');
	            		rotateCubes('w');
	            		rotateCubes('w');
	            		rotating = 'W';
	            	}
	            	else if(hit.transform.gameObject.name == "yellowSide"){
	            		moves.Add('Y');
	            		for(int i = 0; i < 3; i++){
	            			for(int j = 0; j < 3; j++){
	            				if(!(i == 1 && j == 1)){
	            					rubiksCube[i,0,j].transform.SetParent(rubiksCube[1,0,1].transform);
	            				}
	            			}
	            		}
	            		//move the squares around
	            		rotateCubes('y');
	            		rotateCubes('y');
	            		rotateCubes('y');
	            		rotating = 'Y';
	            	}
	            }
	        }
	    }
        
	}

	public void makeRubiksCube(){
		//first depth
		rubiksCube[0,0,0] = GameObject.Find("bry");
		rubiksCube[1,0,0] = GameObject.Find("yr");
		rubiksCube[2,0,0] = GameObject.Find("gyr");
		//first col
		rubiksCube[0,1,0] = GameObject.Find("rb");
		rubiksCube[1,1,0] = GameObject.Find("r");
		rubiksCube[2,1,0] = GameObject.Find("gr");
		//second col
		rubiksCube[0,2,0] = GameObject.Find("rwb");
		rubiksCube[1,2,0] = GameObject.Find("rw");
		rubiksCube[2,2,0] = GameObject.Find("rgw");
		//third col

		//second depth
		rubiksCube[0,0,1] = GameObject.Find("yb");
		rubiksCube[1,0,1] = GameObject.Find("y");
		rubiksCube[2,0,1] = GameObject.Find("gy");
		//first col
		rubiksCube[0,1,1] = GameObject.Find("b");
		rubiksCube[1,1,1] = null;
		rubiksCube[2,1,1] = GameObject.Find("g");
		//second col
		rubiksCube[0,2,1] = GameObject.Find("bw");
		rubiksCube[1,2,1] = GameObject.Find("w");
		rubiksCube[2,2,1] = GameObject.Find("wg");
		//third col

		//final depth
		rubiksCube[0,0,2] = GameObject.Find("oyb");
		rubiksCube[1,0,2] = GameObject.Find("yo");
		rubiksCube[2,0,2] = GameObject.Find("ygo");
		//first col
		rubiksCube[0,1,2] = GameObject.Find("bo");
		rubiksCube[1,1,2] = GameObject.Find("o");
		rubiksCube[2,1,2] = GameObject.Find("go");
		//second col
		rubiksCube[0,2,2] = GameObject.Find("bwo");
		rubiksCube[1,2,2] = GameObject.Find("ow");
		rubiksCube[2,2,2] = GameObject.Find("gwo");
		//third col
	}

	public void setCubeParent(ref GameObject go){
		go.transform.SetParent(cubesCenter.transform);
	}

	public void rotateCubes(char side){
		if(side == 'r'){
			GameObject temp = rubiksCube[0,0,0];
			rubiksCube[0,0,0] = rubiksCube[2,0,0];
			rubiksCube[2,0,0] = rubiksCube[2,2,0];
			rubiksCube[2,2,0] = rubiksCube[0,2,0];
			rubiksCube[0,2,0] = temp;
			temp = rubiksCube[0,1,0];
			rubiksCube[0,1,0] = rubiksCube[1,0,0];
			rubiksCube[1,0,0] = rubiksCube[2,1,0];
			rubiksCube[2,1,0] = rubiksCube[1,2,0];
			rubiksCube[1,2,0] = temp;
		}
		else if(side == 'b'){
			GameObject temp = rubiksCube[0,0,0];
			rubiksCube[0,0,0] = rubiksCube[0,2,0];
			rubiksCube[0,2,0] = rubiksCube[0,2,2];
			rubiksCube[0,2,2] = rubiksCube[0,0,2];
			rubiksCube[0,0,2] = temp;
			temp = rubiksCube[0,1,0];
			rubiksCube[0,1,0] = rubiksCube[0,2,1];
			rubiksCube[0,2,1] = rubiksCube[0,1,2];
			rubiksCube[0,1,2] = rubiksCube[0,0,1];
			rubiksCube[0,0,1] = temp;
		}
		else if(side == 'g'){
			GameObject temp = rubiksCube[2,0,0];
			rubiksCube[2,0,0] = rubiksCube[2,0,2];
			rubiksCube[2,0,2] = rubiksCube[2,2,2];
			rubiksCube[2,2,2] = rubiksCube[2,2,0];
			rubiksCube[2,2,0] = temp;
			temp = rubiksCube[2,1,0];
			rubiksCube[2,1,0] = rubiksCube[2,0,1];
			rubiksCube[2,0,1] = rubiksCube[2,1,2];
			rubiksCube[2,1,2] = rubiksCube[2,2,1];
			rubiksCube[2,2,1] = temp;
		}
		else if(side == 'o'){
			GameObject temp = rubiksCube[0,2,2];
			rubiksCube[0,2,2] = rubiksCube[2,2,2];
			rubiksCube[2,2,2] = rubiksCube[2,0,2];
			rubiksCube[2,0,2] = rubiksCube[0,0,2];
			rubiksCube[0,0,2] = temp;
			temp = rubiksCube[0,1,2];
			rubiksCube[0,1,2] = rubiksCube[1,2,2];
			rubiksCube[1,2,2] = rubiksCube[2,1,2];
			rubiksCube[2,1,2] = rubiksCube[1,0,2];
			rubiksCube[1,0,2] = temp;
		}
		else if(side == 'w'){
			GameObject temp = rubiksCube[0,2,0];
			rubiksCube[0,2,0] = rubiksCube[2,2,0];
			rubiksCube[2,2,0] = rubiksCube[2,2,2];
			rubiksCube[2,2,2] = rubiksCube[0,2,2];
			rubiksCube[0,2,2] = temp;
			temp = rubiksCube[0,2,1];
			rubiksCube[0,2,1] = rubiksCube[1,2,0];
			rubiksCube[1,2,0] = rubiksCube[2,2,1];
			rubiksCube[2,2,1] = rubiksCube[1,2,2];
			rubiksCube[1,2,2] = temp;
		}
		else if(side == 'y'){
			GameObject temp = rubiksCube[0,0,2];
			rubiksCube[0,0,2] = rubiksCube[2,0,2];
			rubiksCube[2,0,2] = rubiksCube[2,0,0];
			rubiksCube[2,0,0] = rubiksCube[0,0,0];
			rubiksCube[0,0,0] = temp;
			temp = rubiksCube[0,0,1];
			rubiksCube[0,0,1] = rubiksCube[1,0,2];
			rubiksCube[1,0,2] = rubiksCube[2,0,1];
			rubiksCube[2,0,1] = rubiksCube[1,0,0];
			rubiksCube[1,0,0] = temp;
		}
	}
}
