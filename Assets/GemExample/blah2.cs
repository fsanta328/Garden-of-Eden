using UnityEngine;
using System.Collections;

public class blah2 : MonoBehaviour {

	public GameObject TestBossAchivement;
	public static bool isBossDead = false;


	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyUp(KeyCode.Space))
		{
			isBossDead = true;
			//Destroy(TestBossAchivement);

		}
	


	}
}
