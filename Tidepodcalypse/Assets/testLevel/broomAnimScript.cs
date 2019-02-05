using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class broomAnimScript : MonoBehaviour {

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
			if (Input.GetKey (KeyCode.Space)) {
				anim.SetBool ("attackRight", true);
			} else 
			{
				anim.SetBool ("attackRight", false);
			}
		}
		if (Input.GetKey(KeyCode.A))
		{
			anim.SetBool ("left", true);
			anim.SetBool ("right", false);
			anim.SetBool ("down", false);
			anim.SetBool ("up", false);
			if(Input.GetKey(KeyCode.Space))
			{
				anim.SetBool("attackLeft", true);
			} else 
			{
				anim.SetBool ("attackLeft", false);
			}
		}
		if (Input.GetKey(KeyCode.S))
		{
			anim.SetBool ("down", true);
			anim.SetBool ("right", false);
			anim.SetBool ("left", false);
			anim.SetBool ("up", false);
			if(Input.GetKey(KeyCode.Space))
			{
				anim.SetBool("attackDown", true);
			} else 
			{
				anim.SetBool ("attackDown", false);
			}
		}
		if (Input.GetKey (KeyCode.W)) 
		{
			anim.SetBool ("up", true);
			anim.SetBool ("right", false);
			anim.SetBool ("left", false);
			anim.SetBool ("down", false);
			if(Input.GetKey(KeyCode.Space))
			{
				anim.SetBool("attackUp", true);
			} else 
			{
				anim.SetBool ("attackUp", false);
			}
		}		
	}
}
