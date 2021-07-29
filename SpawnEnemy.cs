using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject Enemy;
    public Vector2 dir;
    void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            int randSec = Random.Range(3, 4);
            yield return new WaitForSeconds(randSec);
            float posX = transform.position.x ;
            float rotY = Random.Range(0, 2);
            float posY = Random.Range(-4.5f, 4.5f);

            if (rotY == 0)
            {
                rotY = 90;
            }
            else
            {
                rotY = -90;
                posX = posX * -1;
            }

            if (GameObject.Find("Player") != null)
            {
            var rotation = Quaternion.Euler(0, 0, rotY);
            GameObject newDuck = Instantiate(Enemy, new Vector3(posX, posY, 0), rotation);
            newDuck.GetComponent<MoveEnemy>().direction = dir;
            Destroy(newDuck, 15);
            }
        }
    }
}
