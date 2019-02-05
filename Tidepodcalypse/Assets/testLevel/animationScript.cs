using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationScript : MonoBehaviour {

	public Animator anim;

	void Start () 
	{
		anim = GetComponent<Animator> ();	
	}


	void Update () 
	{
		if(Input.GetKey(KeyCode.D))
		{
			anim.SetBool ("right", true);
			anim.SetBool ("left", false);
			anim.SetBool ("down", false);
			anim.SetBool ("up", false);
		}
		if (Input.GetKey(KeyCode.A))
		{
			anim.SetBool ("left", true);
			anim.SetBool ("right", false);
			anim.SetBool ("down", false);
			anim.SetBool ("up", false);
		}
		if (Input.GetKey(KeyCode.S))
		{
			anim.SetBool ("down", true);
			anim.SetBool ("right", false);
			anim.SetBool ("left", false);
			anim.SetBool ("up", false);
		}
		if (Input.GetKey (KeyCode.W)) 
		{
			anim.SetBool ("up", true);
			anim.SetBool ("right", false);
			anim.SetBool ("left", false);
			anim.SetBool ("down", false);
		}	
		if (Input.GetKey (KeyCode.D)) 
		{
			anim.SetBool ("walkRight", true);

		} else 
		{
			anim.SetBool ("walkRight", false);

		}if (Input.GetKey (KeyCode.A)) 
		{
			anim.SetBool ("walkLeft", true);

		} else 
		{
			anim.SetBool ("walkLeft", false);

		}if (Input.GetKey (KeyCode.S)) 
		{
			anim.SetBool ("walkDown", true);

		} else 
		{
			anim.SetBool ("walkDown", false);

		}if (Input.GetKey (KeyCode.W)) 
		{
			anim.SetBool ("walkUp", true);

		} else 
		{
			anim.SetBool ("walkUp", false);

		}

	}
}
