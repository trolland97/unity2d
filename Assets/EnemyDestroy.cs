using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour {
    public GameObject blood;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Rocket")
        {
            if (PlayerPrefs.GetInt("firstEnemy") == 1)
            {
                Debug.Log("First Enemy kill acchievement already got.");
            }
            else
            {
                Debug.Log("First Enemy kill acchievement reached.");
                PlayerPrefs.SetInt("firstEnemy", 1);
            }
            Instantiate(blood, transform.position, Quaternion.identity);
            ScoreScript.scoreValue += 1;

            col.gameObject.SetActive(false);
            this.gameObject.SetActive(false);

            AudioManager.instance.PlaySound("Dead");
        }
    }
}
