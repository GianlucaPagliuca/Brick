using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    private Vector3 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, transform.position.z));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if(collision.gameObject.tag == "Player")
            {
                Destroy(this.gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        float pwerupHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;
        if (transform.position.y < (screenBounds.y * -1) + pwerupHeight)
            Destroy(this.gameObject);
    }
}
