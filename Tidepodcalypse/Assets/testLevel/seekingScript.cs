using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seekingScript : MonoBehaviour {
	// Use this for initialization
	private Transform target;
	public float speed;
	public float seekRange;
	private int Wall;
	public Rigidbody2D rb;
	public int health;

	void Start () 
	{
		Wall = 1 << 8;
		health = 100;
		rb = GetComponent<Rigidbody2D>();

	}

	// Update is called once per frame
	void Update () 
	{
		target = GameObject.FindGameObjectWithTag ("Player").transform;

		if(!Physics2D.Raycast(transform.position,(target.position - transform.position), 2, Wall))
		{
			float targetDistance = Vector3.Distance (transform.position, target.position);
			if (targetDistance < seekRange) 
			{
				Vector3 targetDir =  target.position - transform.position;
				float angle = Mathf.Atan2 (targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
				Quaternion Q = Quaternion.AngleAxis (angle, Vector3.forward);
				transform.rotation = Quaternion.RotateTowards (transform.rotation, Q, 180);
				transform.Translate (Vector3.up * Time.deltaTime * speed);
			}
		}

		if(health <= 0)
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D c)
	{	
		if(c.gameObject.tag == "attackTrigger")
		{
			if (target.GetComponent<playerScript>().Items [1] == 1) {
				health -= 50;	
			} else 
			{
				health -= 1;
			}
			float vertShove = c.gameObject.transform.position.y - transform.position.y;
			float horzShove = c.gameObject.transform.position.x - transform.position.x;

			rb.AddForce (new Vector2 (-horzShove, -vertShove)*500);
		}
	}

		
}
