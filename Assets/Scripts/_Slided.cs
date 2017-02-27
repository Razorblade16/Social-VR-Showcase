using UnityEngine;
using System.Collections;

public class _Slided : MonoBehaviour {

	// Slided engine 1.0 par Creepy Cat (C)2015
	// The code is for example only, you should 
	// not resale it directly (or modified).
	
	//L'interface
	public  GameObject slidepivot;
	
	public  float camspeed=14.5f;
	public  float pivotspeed=12.5f;
	
	public  float decalX=0.0f;
	public  float decalY=0.0f;
	
	// Index du waypoint courant
	public static  int currentWaypoint= 0; //First Slide index
	public static  int totalWaypoint= 0; //Total Slide number
	public static  int videoStop=0;
	public  GameObject[] waypoints;
	
	// Positions du pivot
	private  float currentPivotX;
	private  float  currentPivotY;
	private  float  currentPivotZ;
	
	private  float  nextPivotX;
	private  float  nextPivotY;
	private  float  nextPivotZ;
	
	// Positions des slides
	private  float currentSlideX;
	private  float  currentSlideY;
	private  float  currentSlideZ;
	
	private  float  nextslideX;
	private  float  nextslideY;
	private  float  nextslideZ;
	
	// Variables de l'engine
	private  float cameraSmooth;
	private  float pivotSmooth;
	
	private  float zoomIn=0.9f;
	private  float zoomOut=5f;
	private  int zoomSwitch=0;
	private  float zoomValue;
	
	public static int videoDownloaded=0;

    private int currentDirection = 0;

    // Wake up neo
    public void Awake() {
		
		// If more than 0 waypoint
		if (waypoints.Length > 0) { 
			
			// getting first slide coordinates
			Vector3 posi=  waypoints[0].transform.TransformPoint (new Vector3(decalX,decalY,zoomValue));
			
			nextslideX=posi.x;
			nextslideY=posi.y;
			nextslideZ=posi.z;
			
			
			currentSlideX=posi.x;
			currentSlideY=posi.y;
			currentSlideZ=posi.z;
			
			nextPivotX=nextslideX;
			nextPivotY=nextslideY;
			nextPivotZ=nextslideZ;
			
			currentPivotX=nextslideX;
			currentPivotY=nextslideY;
			currentPivotZ=nextslideZ;
			
			currentPivotX=waypoints[currentWaypoint].transform.position.x;
			currentPivotY=waypoints[currentWaypoint].transform.position.y;
			currentPivotZ=waypoints[currentWaypoint].transform.position.z;
	
		}
	
	}

    private void Start() {
        zoomValue = zoomIn;
    }

    // ---------------
    // Function update
    // ---------------
    public void Update () {
		GetInputKey();
		FacingCamera();
	}
	
	
	//-----------------------------------------
	// Deplacement de la camera avec pivot
	// ----------------------------------------
	public void FacingCamera(){
	
		// Move camera and pivot
		cameraSmooth=Time.deltaTime * camspeed;
		pivotSmooth=Time.deltaTime * pivotspeed;
		
		// New pivot position searching
		if (zoomSwitch==0){
			nextPivotX=waypoints[currentWaypoint].transform.position.x;
			nextPivotY=waypoints[currentWaypoint].transform.position.y;
			nextPivotZ=waypoints[currentWaypoint].transform.position.z;
			
			Vector3 posi=  waypoints[currentWaypoint].transform.TransformPoint (new Vector3(decalX,decalY,zoomValue));
			
			nextslideX=posi.x;
			nextslideY=posi.y;
			nextslideZ=posi.z;
		}
		else {
			nextPivotX=0;
			nextPivotY=2;
			nextPivotZ=0;	
	
			nextslideX=4.8f;
			nextslideY=4.0f;
			nextslideZ=4.9f;
		}
	
		// Calculate the orientation and other shit : pivot+camera
		currentPivotX=Mathf.Lerp(currentPivotX, nextPivotX,pivotSmooth);
		currentPivotY=Mathf.Lerp(currentPivotY, nextPivotY,pivotSmooth);
		currentPivotZ= Mathf.Lerp(currentPivotZ, nextPivotZ,pivotSmooth);
		
		slidepivot.transform.position = new Vector3(currentPivotX,currentPivotY, currentPivotZ);
	
		currentSlideX= Mathf.Lerp(currentSlideX, nextslideX,cameraSmooth);
		currentSlideY= Mathf.Lerp(currentSlideY, nextslideY,cameraSmooth);
		currentSlideZ= Mathf.Lerp(currentSlideZ, nextslideZ,cameraSmooth);
	
		GetComponent<Camera>().transform.position = new Vector3(currentSlideX, currentSlideY, currentSlideZ);
		
		// Pointing camera to pivot
		GetComponent<Camera>().transform.LookAt(slidepivot.transform); 
		
	}


    // --------------------
    // Check keyboard entry
    // --------------------
    public void GetInputKey() {

        if (GvrViewer.Instance.Triggered) {
            if (currentDirection == 0) {
                currentWaypoint++;
                videoStop = 1;
                if (currentWaypoint >= waypoints.Length - 1) {
                    currentDirection = 1;
                    currentWaypoint = waypoints.Length - 1;  
                }
            } else if (currentDirection == 1) {
                currentWaypoint--;
                videoStop = 1;
                if (currentWaypoint == 0) {
                    currentWaypoint = 0;
                    currentDirection = 0;
                }
            }

        }


    }
	
	
}
