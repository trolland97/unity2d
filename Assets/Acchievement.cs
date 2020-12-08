using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Acchievement : MonoBehaviour {

    public Image imageToChange;
    public Sprite gold;

    // Use this for initialization
    void Start () {

        if (PlayerPrefs.GetInt("firstEnemy") == 1)
        {
            imageToChange.sprite = gold;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
