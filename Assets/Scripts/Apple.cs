using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private SpriteRenderer spr;
    private CircleCollider2D circ;

    public int score;
    public GameObject collected;

    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        circ = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            spr.enabled = false;
            circ.enabled = false;
            collected.SetActive(true);
            GameController.instance.score += this.score;
            GameController.instance.updateScoreText();
            Destroy(gameObject, 0.25f);
        }
    }
}
