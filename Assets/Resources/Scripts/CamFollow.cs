using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour {

	public GameObject target;

	private Transform container;
	// Use this for initialization
	void Start () {
		container = this.transform.parent;
		ParentToPlayer ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ParentToPlayer() {
		this.transform.SetParent (target.transform);
	}

	public void ParentToContainer() {
		this.transform.SetParent (container);
	}
}
