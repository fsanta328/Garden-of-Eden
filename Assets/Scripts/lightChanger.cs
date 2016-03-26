using UnityEngine;
using System.Collections;

public class lightChanger : MonoBehaviour {

	Color[] colours = new Color[7];
	public float time=0;
	public float repeatRate;
	public Light light;

	// Use this for initialization
	void Start () {

		light = GetComponent<Light>();
		colours[0] = Color.blue;
		colours[1] = Color.cyan;
		colours[2] = Color.green;
		colours[4] = Color.magenta;
		colours[5] = Color.red;
		colours[6] = Color.yellow;
	
	}
	
	// Update is called once per frame
	void Update () {

		time+= Time.deltaTime;
		if (time > 3)
		{
			light.color = colours[Random.Range(0, colours.Length -1)];
			time =0;

		}
	
	}
}
