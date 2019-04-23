using UnityEngine;
using System.Collections;

public class Done_WeaponController2 : MonoBehaviour
{
	public GameObject shot;
	public Transform shotSpawn;
    public Transform shotSpawn2;
    public Transform shotSpawn3;
    public float fireRate;
	public float delay;
    
    void Start()
    {
        InvokeRepeating("Fire", delay, fireRate);
        InvokeRepeating("Fire2", delay, fireRate);
    }

    void Fire()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        GetComponent<AudioSource>().Play();       
    }
    void Fire2()
    {   
        Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);
        Instantiate(shot, shotSpawn3.position, shotSpawn3.rotation);
    }
}
