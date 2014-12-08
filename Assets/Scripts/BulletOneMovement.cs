using UnityEngine;
using System.Collections;

public class BulletOneMovement : MonoBehaviour {

	float posX;
	float posY;
	public float velocityX = 5f;
	public float acceleration = 1f;
	public float deathTimer = 2f;
	float orientationRight;

	// Use this for initialization
	void Start () 
	{
		posX = transform.position.x;
		posY = transform.position.y;
		orientationRight = transform.localScale.x;
	}

	void Update () 
	{
		velocityX += acceleration;
		posX = transform.position.x + velocityX;
		transform.Translate (Vector3.right * Time.deltaTime * velocityX * orientationRight);
		Destroy(gameObject, deathTimer);
	}
	

	void FixedUpdate () 
	{

	}
}
