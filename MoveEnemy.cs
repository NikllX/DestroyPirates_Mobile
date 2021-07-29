using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public Vector2 direction;
    public float moveSpeed = 1;
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D ColAsteroid)
    {
        if (ColAsteroid.gameObject.tag == "Bullet")
        {
            Destroy(ColAsteroid.gameObject);
            Destroy(this.gameObject);
        }
    }
}
