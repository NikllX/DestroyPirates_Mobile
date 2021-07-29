using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public Joystick joystick;
    public Rigidbody2D rb;
    Vector2 move;
    public Transform Player;
    public Button RestartLevel;



    public GameObject bulletPrefab;
    public GameObject LbulletStart;
    public GameObject LtargetStart;
    public float bulletSpeed = 3f;
    public GameObject RbulletStart;
    public GameObject RtargetStart;
    private Vector3 target;
    private float distance;
    private Vector2 direction;
    private float rotationZ = 0f;
    
    void Update()
    {
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            move.x = joystick.Horizontal;
            move.y = joystick.Vertical;
            float hAxis = joystick.Horizontal;
            float vAxis = joystick.Vertical;
            float zAxis = Mathf.Atan2(hAxis, vAxis) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, -zAxis);
            transform.rotation = Quaternion.Euler(0f, 0f, -zAxis);
            rb.MovePosition(rb.position + move * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D ColAsteroid)
    {
        if (ColAsteroid.gameObject.tag == "Enemy")
        {
            Destroy(ColAsteroid.gameObject);
            RestartLevel.gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
    }
    
    public void ButtonFire()
    {
        target = LtargetStart.transform.position;
        Vector3 difference = target - LbulletStart.transform.position;
        rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        distance = difference.magnitude;
        direction = difference / distance;
        direction.Normalize();
        fireBullet(direction, rotationZ, LbulletStart);
    }


    void fireBullet(Vector2 direction, float rotationZ, GameObject bulletStart)
    {

        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = bulletStart.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        Destroy(b, 4);
    }

    public void RightButtonFire()
    {
        target = RtargetStart.transform.position;
        Vector3 difference = target - RbulletStart.transform.position;
        rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        distance = difference.magnitude;
        direction = difference / distance;
        direction.Normalize();
        fireBullet(direction, rotationZ, RbulletStart);
    }
}
