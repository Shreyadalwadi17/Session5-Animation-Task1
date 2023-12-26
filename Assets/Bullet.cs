using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float S = 10f;
    [SerializeField] float MaxRange = 10f;
    Vector3 StartPos;

    void Start()
    {
        StartPos = transform.position;
    }
    void Update()
    {
        transform.Translate(Vector3.right * S * Time.deltaTime);
        DestroyBullet();

    }
    void DestroyBullet()
    {
        if (Vector3.Distance(StartPos, transform.position) > MaxRange)
        {
            Destroy(gameObject);

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);

        }
    }
}
