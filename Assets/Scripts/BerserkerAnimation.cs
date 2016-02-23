using UnityEngine;
using System.Collections.Generic;

public class BerserkerAnimation : MonoBehaviour 
{
	public Animator animate;

	public float speed;

	int Hit = 0;

	float timer = 0;

	bool XaxisMovement = false;

	// collection of float which will help transect b/w Animations
	public List<float> anim = new List<float> ();

	public GameObject Weapon;

	// Animations for (Idle, Walk, Run, Attack)
	void SetAnim(float slide)
	{
		animate.SetFloat ("Anim", slide);	
	}

	// Use this for initialization
	void Start () 
	{
		
		animate.SetTrigger ("Punch");
	}

	// Update is called once per frame
	void Update () 
	{
		//moving forward
		if (Input.GetKey (KeyCode.UpArrow) && animate.GetFloat("Anim") <= anim[2] && (Hit == 0)) 
		{
			//move forward
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
			SetAnim(anim[2]);
		} 
		//moving back
		else if (Input.GetKey (KeyCode.DownArrow) && animate.GetFloat("Anim") <= anim[2] && (Hit == 0)) 
		{
			//move forward
			transform.Translate (Vector3.back * speed * Time.deltaTime);
			SetAnim(anim[1]);
		}
		else if(Hit == 0)
		{
			SetAnim (anim [0]);
		}

		if(Input.GetKeyDown(KeyCode.A))
		{
			Hit++;
		}

		if(Hit == 1)
		{
			timer += Time.deltaTime;

			animate.SetTrigger("Punch1");
			SetAnim (anim [3]);

			if(timer >= 0.45f && Hit == 1)
			{
				Reset("Punch1");
				SetAnim (anim[0]);
			}
		}
		else if(Hit == 2)
		{
			timer += Time.deltaTime;

			animate.SetTrigger("Punch2");

			SetAnim (anim [4]);

			if(timer >= 1f && Hit == 2)
			{
				Reset("Punch1");
				Reset("Punch2");
				SetAnim (anim[0]);
			}
		}
		else if(Hit >= 3)
		{
			Hit = 3;

			timer += Time.deltaTime;

			animate.SetTrigger("Punch3");

			SetAnim (anim [5]);

			if(timer >= 1f)
			{
				Reset("Punch1");
				Reset("Punch2");
				Reset("Punch3");
				SetAnim (anim[0]);
			}
		}

		//Debug.Log ("Hit: "+Hit+"  Timer: "+timer);

		if(Input.GetKey(KeyCode.D))
		{
			XaxisMovement = true;
		}
		else if(Input.GetKeyUp(KeyCode.D))
		{
			XaxisMovement = false;
			animate.SetBool ("Right", false);
			animate.SetBool ("Left", false);
		}


		//Right Cam Rotation 
		if(Input.GetKey(KeyCode.RightArrow) && XaxisMovement == false)
		{
			transform.eulerAngles += new Vector3 (0, 5, 0);
		}
		else if(Input.GetKey(KeyCode.RightArrow) && XaxisMovement == true)
		{
			transform.Translate (Vector3.right * speed * Time.deltaTime);
			animate.SetBool ("Right", true);
		}
		else if(Input.GetKeyUp(KeyCode.RightArrow) && XaxisMovement == true)
		{
			animate.SetBool ("Right", false);
		}

		//Left Cam Rotation
		if(Input.GetKey(KeyCode.LeftArrow) && XaxisMovement == false)
		{
			transform.eulerAngles -= new Vector3 (0, 5, 0);
		}
		else if(Input.GetKey(KeyCode.LeftArrow) && XaxisMovement == true)
		{
			transform.Translate (Vector3.left * speed * Time.deltaTime);
			animate.SetBool ("Left", true);
		}
		else if(Input.GetKeyUp(KeyCode.LeftArrow) && XaxisMovement == true)
		{
			animate.SetBool ("Left", false);
		}
	}

	void Reset(string AnimName)
	{
		Hit = 0;

		animate.ResetTrigger (AnimName);

		timer = 0;
	}

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.name == "PickUpWeapon")
		{
			Weapon.SetActive (true);
			collision.gameObject.SetActive(false);
		}
	}
}
