using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class EnemyInteraction : MonoBehaviour {
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Enemy")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        }
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
