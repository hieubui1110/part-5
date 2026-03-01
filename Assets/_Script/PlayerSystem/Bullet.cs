using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float flySpeed;
    public float flyTime;
    public int damage;
    void Update()
    {
        transform.Translate(Vector3.up * flySpeed * Time.deltaTime);
        flyTime -= Time.deltaTime;
        if (flyTime <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
