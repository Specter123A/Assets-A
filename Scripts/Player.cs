using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public Player player;
    Rigidbody  rb;
    public bool gameOver = false;
// Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody>();
    }

    // Changed to fixed update because fixed update is linked to physics engine
    //update is linked with graphics rendering
    void FixedUpdate()
    {

        if (gameOver)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.GetActiveScene();     //this will restart the game
            }
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0,450,0), ForceMode.Acceleration);   //ForceMode.Impulse needs a consideration of time
            //ForceMode.Acceleration or Force considers the interval, so its taken care Force
        }

        else if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.velocity *= 0.3f;
        }
    }


    void OnTriggerEnter (Collider collider)
    {
        gameOver = true;
        rb.isKinematic = true;
        Debug.Log ("Game Over!   Press Space to Restart");

    }
}
