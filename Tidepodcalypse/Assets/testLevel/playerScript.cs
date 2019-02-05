using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class playerScript : MonoBehaviour {
    // player stats
	public int[] Items;
	public int[] events;
    public float walkSpeed;
	public float health { get; set; }// player hit points "H-Ps"
    public float currHealth { get; set; }
    public Slider healthBar;
	public bool isTransmission;// true == near
	public bool isMessage;
	public bool toRadio;
	public bool toStore;
	public bool isKnuckles;
	public bool isWrench;
    public bool isBroom;
	public bool isWires;
	public bool isGen;
	public bool isDuctape;
	public bool isKeyCard;
	public bool isKeyCardDoor;
    public bool isSomethingSpecial;// daway
	public bool isForbidenFruit;
	public bool isHealth;
	public bool isHealth1;

    //Music Vars (Srry)
    public AudioMixerSnapshot lvl1;
    public AudioMixerSnapshot lvl2;
    // movement vars
    float normalized = 0.7071F; // 1/sqrt(2)

    // attacking vars
    private bool attacking = false;
    private float attackTimer = 0;
    private float attackCD = .01f;
	public Rigidbody2D rb;
    public Collider2D attackTrigger;

    void Awake()
    {
        attackTrigger.enabled = false;
    }

    void Start ()
    {
        //Audio Stuff
        lvl1.TransitionTo(1f);

        // Health Things
        health = 100f;
        currHealth = health;
        healthBar.value = CalculateHealth();

        // this is where obtaining the stat changes will go as well as changing them depending on what is equiped via the game script
		rb = GetComponent<Rigidbody2D>();

		// items
		isWrench = false;
		isBroom = false;
		isWires = false;
		isDuctape = false;
		isKeyCard = false;
		isKeyCardDoor = false;
		isGen = false;
		isSomethingSpecial = false;
		isForbidenFruit = false;
		isHealth = false;
		isHealth1 = false;
		toStore = false;

		// events
		isTransmission = false;
		isKnuckles = false;
		toRadio = false;
		isMessage = false;


		Items = new int[6];
		events = new int[6];
		// events: event 1 is fixing transmission, 0 is not fixed, 1 is fixed 
		// when you complete x event events [x] = 1
		// Items: spot 1 is wrench, spot 2 is broom, spot 3 wires, spot 4 ducktape, spot 5, spot 6
		// when you have x item Items [x] = 1
		for(int i = 0; i < 6; i++)
		{
			Items [i] = 0;
			events [i] = 0;
		}
		// hides the broom sprite and attack anim, until broom is found
		GameObject.FindGameObjectWithTag ("attack").GetComponent<SpriteRenderer> ().enabled = false;
	}
	
	void Update ()
    {
        // movement logic, d right, a left, w up, s down
        // normlized is to make diagonal movement 'simular' to vert/horz movement
		if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * walkSpeed * normalized);
			GameObject.FindGameObjectWithTag("attackTrigger").transform.rotation = Quaternion.Euler(0, 0, 90f);

        }
		if (Input.GetKey(KeyCode.A))
        {
			transform.Translate(Vector3.left * walkSpeed * normalized);
			GameObject.FindGameObjectWithTag("attackTrigger").transform.rotation = Quaternion.Euler(0, 0, -90f);
        }
		if (Input.GetKey(KeyCode.S))
        {
			transform.Translate(Vector3.down * walkSpeed * normalized);
			GameObject.FindGameObjectWithTag("attackTrigger").transform.rotation = Quaternion.Euler(0, 0, 0);
        }
		if (Input.GetKey(KeyCode.W))
        {
			transform.Translate(Vector3.up * walkSpeed * normalized);
			GameObject.FindGameObjectWithTag("attackTrigger").transform.rotation = Quaternion.Euler(0, 0, 180f);
        }
		if (Input.GetKey (KeyCode.E)) 
		{
			if (isWrench) 
			{
				Items [0] = 1;
				Destroy (GameObject.FindGameObjectWithTag ("wrench"));
			}
			if (isBroom) 
			{
				// once broom is found it enables broom sprite and attack anim
				GameObject.FindGameObjectWithTag ("attack").GetComponent<SpriteRenderer> ().enabled = true;
				Items [1] = 1;
				Destroy (GameObject.FindGameObjectWithTag ("broom"));
			}
			if (isForbidenFruit) 
			{
				Destroy(GameObject.FindGameObjectWithTag("forbidenFruit"));
				SceneManager.LoadScene (0);
			}
			if (isKeyCard) 
			{
				Items [4] = 1;
				Destroy (GameObject.FindGameObjectWithTag("keyCard"));
			}
			if (isWires) 
			{
				Items [2] = 1;
				Destroy (GameObject.FindGameObjectWithTag("wires"));
			}
			if (isSomethingSpecial) 
			{
				Items [5] = 1;
				Destroy (GameObject.FindGameObjectWithTag("daWay"));
			}


			if (isHealth) 
			{
				Destroy(GameObject.FindGameObjectWithTag("health"));
				if (currHealth == 80f || currHealth == 100f) {
					currHealth = health;
					healthBar.value = CalculateHealth();

				} else 
				{
					currHealth += 20f;
					healthBar.value = CalculateHealth();

				}
			}if (isHealth1) 
			{
				Destroy(GameObject.FindGameObjectWithTag("health1"));
				if (currHealth == 80f || currHealth == 100f) {
					currHealth = health;
					healthBar.value = CalculateHealth();

				} else 
				{
					currHealth += 20f;
					healthBar.value = CalculateHealth();

				}
			}
		}
		if(Input.GetKey (KeyCode.Q))
		{
			if (isTransmission) 
			{
				if (Items [0] == 1) {
					GameObject.FindGameObjectWithTag ("transmission").GetComponent<dialogueScript> ().popUp = "The transmission was fixed";
					events [0] = 1;
				}
			}
			if (toRadio) 
			{
                //Gonna put this here <<<
                lvl2.TransitionTo(2f);

				// traveling code
				gameObject.transform.position = new Vector3(46.6f,-51.5f,-0.125f);
			}
			if (toStore) {
				gameObject.transform.position = new Vector3(98.48f,-104.47f,2f);
			}
			if (isKeyCardDoor) 
			{
				Destroy(GameObject.FindGameObjectWithTag ("keyCardDoor"));
			}
			if (isGen) {
				if (Items [2] == 1) {
					events [1] = 1;// power is on
					GameObject.FindGameObjectWithTag ("generator").GetComponent<dialogueScript> ().popUp = "Power has been restored";
					GameObject.FindGameObjectWithTag ("keyCardDoor").GetComponent<dialogueScript> ().popUp = "Open the Door?(q)";
				}
			}
			if (isMessage) {
				events[2] = 1;
				GameObject.FindGameObjectWithTag("message").GetComponent<dialogueScript>().popUp = "Message was transmitted, you saved da world.";

			}
		}

		// Z position lock since were 2D
		Vector3 pos = transform.position;
		pos.z = -0.125f;
		transform.position = pos;

        // attacking logic
        if(Input.GetKeyDown("space") && !attacking)
        {
            attacking = true;
            attackTimer = attackCD;

            attackTrigger.enabled = true;
        }
        if(attacking)
        {
            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }

		}
    }



	void OnCollisionEnter2D(Collision2D c)
	{

		if (c.gameObject.tag == "enemy") 
		{	
			currHealth -= 20f;

			float vertShove = c.gameObject.transform.position.y - transform.position.y;
			float horzShove = c.gameObject.transform.position.x - transform.position.x;

			rb.AddForce (new Vector2 (-horzShove, -vertShove)*500);

            healthBar.value = CalculateHealth();
            if (currHealth <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }
	}	

    float CalculateHealth()
    {
        return currHealth / health;
    }

	void OnTriggerEnter2D(Collider2D t)
	{
		// item logic
		if (t.gameObject.tag == "wrench") 
		{
			isWrench = true;
		}
		if (t.gameObject.tag == "broom") 
		{
			isBroom = true;
		}
		if (t.gameObject.tag == "forbidenFruit") 
		{
			isForbidenFruit = true;
		}
		if (t.gameObject.tag == "health") 
		{
			isHealth = true;
		}
		if (t.gameObject.tag == "health1") 
		{
			isHealth1 = true;
		}
		if (t.gameObject.tag == "daWay") {
			isSomethingSpecial = true;
		}

		if (t.gameObject.tag == "wires") {
			isWires = true;
		}
		if (t.gameObject.tag == "generator") {
			isGen = true;
		}

		// event logic
		if (t.gameObject.tag == "transmission") 
		{
			isTransmission = true;
		}
		if (t.gameObject.tag == "knuckles") 
		{
			isKnuckles = true;
		}
		if (t.gameObject.tag == "toRadio") 
		{
			toRadio = true;
		}
		if (t.gameObject.tag == "keyCard") 
		{
			isKeyCard = true;
		}
		if (t.gameObject.tag == "keyCardDoor") 
		{
			isKeyCardDoor = true;
		}
		if (t.gameObject.tag == "toStore") 
		{
			toStore = true;
		}
		if (t.gameObject.tag == "message") 
		{
			isMessage = true;
		}
	}

	void OnTriggerExit2D(Collider2D t)
	{
		// item logic
		if (t.gameObject.tag == "wrench") 
		{
			isWrench = false;
		}
		if (t.gameObject.tag == "broom") 
		{
			isBroom = false;
		}
		if (t.gameObject.tag == "forbidenFruit") 
		{
			isForbidenFruit = false;
		}
		if (t.gameObject.tag == "health") 
		{
			isHealth = false;
		}
		if (t.gameObject.tag == "health1") 
		{
			isHealth1 = false;
		}
		if (t.gameObject.tag == "daWay") {
			isSomethingSpecial = false;
		}

		if (t.gameObject.tag == "wires") {
			isWires = false;
		}
		if (t.gameObject.tag == "generator") {
			isGen = false;
		}


		// event logic
		if (t.gameObject.tag == "transmission") 
		{
			isTransmission = false;
		}
		if (t.gameObject.tag == "knuckles") 
		{
			isKnuckles = false;
		}
		if (t.gameObject.tag == "toRadio") 
		{
			toRadio = false;
		}
		if (t.gameObject.tag == "toStore") 
		{
			toStore = false;
		}
		if (t.gameObject.tag == "keyCard") 
		{
			isKeyCard = false;
		}
		if (t.gameObject.tag == "message") 
		{
			isMessage = false;
		}

		if (t.gameObject.tag == "keyCardDoor") 
		{
			isKeyCardDoor = false;
		}
	}
}
