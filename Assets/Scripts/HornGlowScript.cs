using UnityEngine;
using System.Collections;

public class HornGlowScript : MonoBehaviour {

	//public GameObject mainPony;
	Animator anim;
	Transform mainPony;
	PlatformerCharacter2D script2d;


	// Use this for initialization
	void Awake () 
	{
		anim = GetComponent<Animator>();
		mainPony = transform.parent;

		script2d = mainPony.gameObject.GetComponent("PlatformerCharacter2D") as PlatformerCharacter2D;
	}
	
	// Update is called once per frame
	void Update () 
	{
		anim.SetBool("Ground", script2d.anim.GetBool("Ground"));
		anim.SetFloat("vSpeed", script2d.anim.GetFloat("vSpeed"));
		anim.SetFloat("Speed", script2d.anim.GetFloat("Speed"));
	}

	void FixedUpdate()
	{

	}
}
