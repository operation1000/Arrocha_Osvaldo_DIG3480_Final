using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Done_Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	 
	private float nextFire;

    public Done_GameController gameController;

    public GameObject shot2;
    public Transform shotSpawn2;
    public float fireRate2;
    private float nextFire2;
    public GameObject shot3;
    public Transform shotSpawn3;
    public float fireRate3;
    private float nextFire3;

    void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play ();
		}
        
        if (gameController.ModeHard == true)  {
            if (Input.GetButton("Fire1")) {
                    if (Time.time > nextFire2) {
                        nextFire2 = Time.time + fireRate2;
                        Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);
                    }
                    if (Time.time > nextFire3) {
                        nextFire3 = Time.time + fireRate3;
                        Instantiate(shot, shotSpawn3.position, shotSpawn3.rotation);
                    }
  
            }
        }
    }

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;
		
		GetComponent<Rigidbody>().position = new Vector3
		(
			Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		);
		
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
}
