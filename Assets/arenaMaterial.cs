using UnityEngine;
using System.Collections;

public class arenaMaterial : MonoBehaviour {


	Renderer render;
	Material material;

	// Use this for initialization
	void Start () {

		render = GetComponent<Renderer>();
		 material = render.material;
	}
	
	// Update is called once per frame
	void Update () {
		

		float emission = Mathf.PingPong (Time.time * 0.06f + 0.25f, 0.2f);
		Color baseColor = Color.red; 

		Color finalColor = baseColor * Mathf.LinearToGammaSpace (emission);

		material.SetColor ("_EmissionColor", finalColor);

	}
}
