using UnityEngine;
using System.Collections;

public class TargetShooter : MonoBehaviour
{

		//public float projectileSpeed = 100f;
		public GameObject bulletPrefabOne;

		public float fireRate = 0f;
		public float damage = 10f;
		public LayerMask whatToHit;

		float timeToFire = 0f;
		Transform firePoint;
		float bulletRight = 1;


		// Use this for initialization
		void Start ()
		{
				firePoint = transform.FindChild ("MagicGunPoint");
		}
	
		// Update is called once per frame
		void Update ()
		{
				//Shoot ();
				if (fireRate == 0f) {
						if (Input.GetButtonDown ("Fire1")) {
								ShootForward ();
						}
				} else {
						if (Input.GetButton ("Fire1") && Time.time > timeToFire) {
								timeToFire = Time.time + 1 / fireRate;
								ShootForward ();
						}
				}

		}

		/* Shooting to cursor mode
	void Shoot()
	{
		Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		Vector2 hornPosition = new Vector2 (hornPoint.position.x, hornPoint.position.y);
		Vector2 directions = mousePosition - hornPosition;
		directions.Normalize();

		RaycastHit2D hit = Physics2D.Raycast (hornPosition, mousePosition - hornPosition, 10f, whatToHit);
		Debug.DrawLine (hornPosition, (mousePosition - hornPosition)*1000f, Color.blue);

		GameObject newBullet = Instantiate(testBulletPrefab, transform.position, transform.rotation) as GameObject;
		newBullet.rigidbody2D.AddForce(directions * projectileSpeed);

		Destroy(newBullet, 10f);

		if (hit.collider != null)
		{

		}
	} */

		void ShootForward ()
		{
				bulletRight = transform.parent.localScale.x;
				GameObject newBullet = Instantiate (bulletPrefabOne, firePoint.position, transform.rotation) as GameObject;
				//bulletRight - scale.x of bullet
				newBullet.transform.localScale = new Vector3 (bulletRight, newBullet.transform.localScale.y, newBullet.transform.localScale.z);
		}

		void ShootForwardEffect ()
		{
			
		}
}
