using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Text heal;
    Rigidbody rb;
    public GameObject bullet; 
    GameObject cloneBullet;
    Rigidbody cloneB; 
    int health = 100;
    int score;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        health = 100;
        score = 0;
        print("Health: " + health);
    }

    // Update is called once per frame
    void Update()
    {
        float moveVertical = Input.GetAxis("Vertical");
    	float moveHorizontal = Input.GetAxis("Horizontal");
    	rb.AddForce(transform.forward * moveVertical * 50f);
    	transform.Rotate(0f, moveHorizontal * 5f, 0);

         if(Input.GetKeyDown("space"))
       {
          cloneBullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z+1f), Quaternion.identity);
          cloneB = cloneBullet.GetComponent<Rigidbody>();
          cloneB.AddForce(transform.forward * 1000f);

       }
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            health -= 1;
            //Debug.Log("Health: " + health);
            heal.text = "Health: " + health;

        }
          if(health <= 0)
            {
                SceneManager.LoadScene(3);
                health = 100;
            }
    }
}
