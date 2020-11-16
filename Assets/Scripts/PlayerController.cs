using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 5.0f;
    float jumpforce = 5.0f;
    float deathCount = 0.0f;

    bool Dead = false;
    bool isOnPlayPlane;

    public Rigidbody playerRb;
    public Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        //playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Dead == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                playerAnim.SetBool("IsMove", true);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                playerAnim.SetBool("IsMove", true);
            }

            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            {
                playerAnim.SetBool("IsMove", false);
            }


            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, -90, 0);
                playerAnim.SetBool("IsMove", true);

            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 90, 0);
                playerAnim.SetBool("IsMove", true);
            }


            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                playerAnim.SetBool("IsMove", false);
            }

            if (Input.GetKeyDown(KeyCode.Space) && isOnPlayPlane)
            {
                playerRb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
                playerAnim.SetTrigger("trigFlip");
            }

            if (Input.GetKeyDown(KeyCode.K))
            {              
                deathCount += 1;
                Debug.Log("K pressed = " + deathCount);
            }

            if (deathCount == 10)
            {              
                playerAnim.SetBool("isDead", true);
                Dead = true;
            }
        }
  
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PlayPlane")
        {
            isOnPlayPlane = true;
        }
    }
}
