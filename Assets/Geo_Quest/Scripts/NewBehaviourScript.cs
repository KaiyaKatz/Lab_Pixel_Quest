using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewBehaviourScript : MonoBehaviour
{
    string String = "Hello";
    int Bleh = 3;
    private Rigidbody2D rb;
    public int speed = 5;
    public string blueLevel = "Scene_2";
    private int coinCounter = 0;
    void Start()
    {
      

        Vector3 vector3 = new Vector3(1, 1, 1);

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += new Vector3(0, 1, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        switch (collision.tag)
        {
            case "Death":
                {
                    string thisLevel = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(thisLevel);
                    break;
                }
            case "Finish":
                {
                    SceneManager.LoadScene(blueLevel);
                    break;

                }

            case "Coin":
                {
                    coinCounter++;
                    Destroy(collision.gameObject);
                    break;

                }

        }
    }
}
 
    
    
// Start is called before the first frame update
