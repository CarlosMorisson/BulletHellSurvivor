using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoBasico : MonoBehaviour
{
    public Transform target; // Refer�ncia ao objeto do jogador
    public float moveSpeed = 5f; // Velocidade de movimento do inimigo

    private Rigidbody2D rb;

    private void Start()
    {
        target = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Calcula a dire��o para onde o inimigo deve se mover
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);
    }
}
