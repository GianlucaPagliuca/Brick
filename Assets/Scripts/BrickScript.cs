using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    private float health = 3f;
    private GameObject GameManager;
    public GameObject Powerup;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null)
        {
            health--;
            if (health <= 0)
            {
                int rndNum = Random.Range(0, 100);
                if (rndNum <= 10)
                    PowerupDrop();
                GameManager.GetComponent<GameManager>().UpdateScore(10);
                //Add a float to the destroy to give it a delayed destroy
                Destroy(this.gameObject);
            }

        }
    }

    private void PowerupDrop()
    {
        Instantiate(Powerup, transform.position, transform.rotation);
        Debug.Log("Powerup Drop");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
