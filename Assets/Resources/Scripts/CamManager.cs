using UnityEngine;
using System.Collections;

public class CamManager : MonoBehaviour
{

	public Camera frontCam;
	public Camera backCam;
	public Camera leftCam;
	public Camera rightCam;
	public Camera topCam;
	public Camera bottomCam;


	public RenderTexture front;
	public RenderTexture back;
	public RenderTexture left;
	public RenderTexture right;
	public RenderTexture top;
	public RenderTexture bottom;


	private Camera roomCam;
	private Camera currentCam;
	private RenderTexture currentRT;

	// Use this for initialization
	void Start ()
	{
		roomCam = Camera.main;
		currentCam = roomCam;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey (KeyCode.F)) {// if in room
			ApplyRaycastFromVRGaze ();
		}
		if (Input.GetKeyDown (KeyCode.G)) { // if not in room and press G, return to room
			BackToRoomCam ();
		}
			
	}

	void ApplyRaycastFromVRGaze ()
	{
		RaycastHit hit;
		if (Physics.Raycast (transform.position, roomCam.transform.forward, out hit, 10.0f)) {
			// get tag of camera we are looking at
			AwayFromRoomCam (hit.collider.tag);
		}
	}



	private void BackToRoomCam ()
	{
		if (currentCam.tag == "MainCamera") {
			return;
		} else {
			// sets currentCam back to MainCamera, so starts applying raycasts again
			// resets textures of all cameras in the room. 
			currentCam.GetComponent<CamControls> ().ReleaseCharacter ();
			currentCam = roomCam;
			frontCam.targetTexture = front;
			backCam.targetTexture = back;
			leftCam.targetTexture = left;
			rightCam.targetTexture = right;
			topCam.targetTexture = top;
			bottomCam.targetTexture = bottom;
		}
	}

	private void AwayFromRoomCam (string id)
	{
		Debug.Log (id);
		// if we press F. we change perspective to cam we are looking at. 
		// changes currentCam, meaning raycasts won't be applied anymore, and it overrides display of MainCamera

		switch (id) {
		case("FrontCam"):
			currentCam = frontCam;
			break;
		case("BackCam"):
			currentCam = backCam;
			break;
		case("LeftCam"):
			currentCam = leftCam;
			break;
		case("RightCam"):
			currentCam = rightCam;
			break;
		case("TopCam"):
			currentCam = topCam;
			break;
		case("BottomCam"):
			currentCam = bottomCam;
			break;
		}
		currentCam.targetTexture = null;
		currentCam.GetComponent<CamControls> ().ControlCharacter ();


	}
}
