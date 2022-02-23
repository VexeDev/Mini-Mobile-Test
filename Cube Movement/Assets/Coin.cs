using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    GameObject eventsystem;

    private void Start()
    {
        eventsystem = GameObject.FindGameObjectWithTag("EventSystem");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            eventsystem.GetComponent<ScoreTrack>().score = eventsystem.GetComponent<ScoreTrack>().score + 1;
            eventsystem.GetComponent<ScoreTrack>().UpdateScore();
            Destroy(gameObject);
        }
    }
}
