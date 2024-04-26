using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Stuff"))
        {
            ScoreSystem.scoreValue += 10;
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
