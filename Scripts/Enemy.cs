using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public NavMeshAgent Agent;
    public Text scoree;
    int score = 0;

    void Start()
    {
         Agent = GetComponent<NavMeshAgent>();
         score = 0;
    }

    // Update is called once per frame
    void Update()
    {
         Agent.SetDestination(player.transform.position);

    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Bullet")
        {
           Destroy(gameObject);
           scoree.text = "Score : 0";
           score = score + 1;
           scoree.text = "Score : " + score;

           
           

        }
        if(score >= 1)
            {
            SceneManager.LoadScene(2); 
            score = 0;
            }
    }
}
