using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireRocket : MonoBehaviour {

	public Rigidbody2D rocket; //reference to rocket, set it from editor
	public float speed = 1f; //we're making it public, so we can test other values from the editor
	public Transform firePoint;

    public int rocketPoolSize = 10;
    public List<Rigidbody2D> rocketPool;


	// Use this for initialization
	void Start () {
        rocketPool = new List<Rigidbody2D>();

        for(int i=0; i<rocketPoolSize; i++)
        {
            Rigidbody2D rocketClone =
                (Rigidbody2D)Instantiate(rocket);
            rocketClone.gameObject.SetActive(false);

            rocketPool.Add(rocketClone);
        }
	}
	
	// Update is called once per frame
	void Update () {	
		if (Input.GetButtonDown ("Fire1")) {
			fireRocket();
            this.GetComponent<AudioSource>().Play();
        }
	}
	
	private void fireRocket() {
		float newRotationAngle =
            CharacterMovemenetController.facingRight ? 90 : 270;
        Rigidbody2D rocketClone = getRocketFromPool();

        rocketClone.transform.position = firePoint.position;
        rocketClone.transform.rotation =
            Quaternion.Euler(0, 0, newRotationAngle);
		
        rocketClone.gameObject.SetActive(true);

        Vector3 force =
            CharacterMovemenetController.facingRight ? transform.right : transform.right * -1;
        rocketClone.velocity = force * speed;
    }

    private Rigidbody2D getRocketFromPool()
    {
        foreach(Rigidbody2D rocket in rocketPool)
        {
            if(!rocket.gameObject.activeSelf)
            {
                return rocket;
            }
        }

        return null;
    }
}
