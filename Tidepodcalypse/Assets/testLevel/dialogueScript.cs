using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueScript : MonoBehaviour {

	public bool GuiOn;
	public string popUp;
	public Rect BoxSize = new Rect (0, 0, 200, 100);
	public GUISkin customSkin;
	private GameObject target;

	// Use this for initialization
	void Start () 
	{
		GuiOn = false;
		target = GameObject.FindGameObjectWithTag ("Player"); 
		// item logic
		if (gameObject.tag == "wrench") 
		{
			popUp = "Pick up wrench(e)";
		}
		if (gameObject.tag == "broom") 
		{
			popUp = "Pick up broom(e)";
		}
		if (gameObject.tag == "forbidenFruit") 
		{
			popUp = "Partake in the forbiden Fruit?(e)";
		}
		if (gameObject.tag == "health" || gameObject.tag == "health1") 
		{
			popUp = "Drink water(e)";
		}
		if (gameObject.tag == "keyCard") {
			popUp = "Pick up Key Car(e)";
		}
		if (gameObject.tag == "wires") {
			popUp = "Pick up wires(e)";
		}
		if (gameObject.tag == "daWay") {
			popUp = "Pick up Da Way(e)";
		}

		// event logic
		if (gameObject.tag == "transmission") 
		{
			popUp = "The Transmission seems to be broken.";
		}
		if (gameObject.tag == "toRadio") 
		{
			popUp = "The Transmission seems to be broken.";
		}
		if (gameObject.tag == "knuckles") 
		{
			popUp = "I seem to have lost Da Way.";
		}
		if (gameObject.tag == "knuckles2") 
		{
			popUp = "Da Way is not here either broda.";
		}
		if (gameObject.tag == "knuckles3") 
		{
			popUp = "Here lays da way broda, take it wit you.";
		}
		if (gameObject.tag == "keyCardDoor") {
			popUp = "Looks like we need a keycard.";
		}
		if (gameObject.tag == "generator") {
			popUp = "Looks like some wires need repairing.";
		}
		if (gameObject.tag == "message") {
			popUp = "Send transmission?(Q)";
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject == target) {
			GuiOn = true;

				if (target.GetComponent<playerScript> ().Items [0] == 1) {
					if (target.GetComponent<playerScript> ().events [0] == 1) {
						if (gameObject.tag == "transmission") {
							popUp = "The transmission was fixed.";
						}
						if (gameObject.tag == "toRadio") {
							popUp = "Go to the radio station?(q)";
						}
						if (gameObject.tag == "toStore") {
							popUp = "Go to the electronics store?(q)";
						}
					} else {
						if (gameObject.tag == "transmission") {
							popUp = "Fix the transmission?(Q)";
						}
						if (gameObject.tag == "toRadio") {
							popUp = "The Transmission seems to be broken.";
						}
					}
					

			}
			if (target.GetComponent<playerScript> ().Items [4] == 1) {
				if (target.GetComponent<playerScript> ().events [1] == 1) {
					if (gameObject.tag == "keyCardDoor") {
						popUp = "Unlock door?(q)";
					}
				} else {
					if (gameObject.tag == "keyCardDoor") {
						popUp = "Looks like the power is out.";
					}
				}
			}
			if (target.GetComponent<playerScript> ().Items [2] == 1) 
			{
				if (target.GetComponent<playerScript> ().events [1] == 1) {
					if (gameObject.tag == "generator") {
						popUp = "Power has been restored.";
					}
				} else {
					if (gameObject.tag == "generator") {
						popUp = "Fix wires?(Q)";
					}
				}
			}
			if(target.GetComponent<playerScript>().events[2] == 1)
			{
					if(gameObject.tag == "message")
					{
						popUp = "Message was transmitted, you saved da world.";
					}
			}
		}

	}

	void OnTriggerExit2D (Collider2D t)
	{
		if (t.gameObject == target) {
			GuiOn = false;
		}
	}

	void OnGUI()
	{
		if (customSkin != null) 
		{
			GUI.skin = customSkin;
		}
		if(GuiOn == true)
		{
			GUI.BeginGroup (new Rect ((Screen.width - BoxSize.width) / 2, (Screen.height - BoxSize.height) / 2, BoxSize.width, BoxSize.height));

			GUI.Label (BoxSize, popUp);

			GUI.EndGroup();
		}
	}

}
