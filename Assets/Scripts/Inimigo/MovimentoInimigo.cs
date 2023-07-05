using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoInimigo : Inimigo
{

    public Transform target; // Referência ao objeto do jogador
    public float moveSpeed = 5f; // Velocidade de movimento do inimigo

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Calcula a direção para onde o inimigo deve se mover
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);
    }
}
