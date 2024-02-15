using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int pointsForCoinPickup = 100;

    bool wasCollected = false;

    void OnTriggerEnter2D(Collider2D collision) {

       if (collision.tag == "Player") {

            if (collision.tag == "Player" && !wasCollected) {
                wasCollected = true;
                FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
                AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
            
        } 
    }
}
