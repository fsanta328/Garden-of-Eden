using UnityEngine;
using System.Collections;

public class TargetLock : MonoBehaviour 
{
	GameObject target;

	Vector3 relativePos;

	// Use this for initialization
	void Start () 
	{
		target = GameObject.FindGameObjectWithTag ("Target");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(target.activeInHierarchy == true)
		{
			relativePos = target.transform.position - transform.position;
		}

		if(Input.GetKey(KeyCode.D) && target.activeInHierarchy == true)
		{
			LockOnTarget ();
		}

		else if(Input.GetKeyUp(KeyCode.D) || target.activeInHierarchy == false)
		{
			transform.eulerAngles = new Vector3 (0,transform.eulerAngles.y,0);
		}
	}

	public void LockOnTarget()
	{
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation (relativePos), 2*Time.deltaTime);

		transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);
		
	}
}
