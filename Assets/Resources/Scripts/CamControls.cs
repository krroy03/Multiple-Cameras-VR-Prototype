using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class CamControls : MonoBehaviour
{

	private GameObject target;

	// Use this for initialization
	void Start ()
	{
		target = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}


	public void ControlCharacter ()
	{
		target.GetComponent<ThirdPersonCharacter> ().enabled = true;
		target.GetComponent<ThirdPersonUserControl> ().enabled = true;
	}

	public void ReleaseCharacter ()
	{
		target.GetComponent<ThirdPersonCharacter> ().enabled = false;
		target.GetComponent<ThirdPersonUserControl> ().enabled = false;
	}

}
