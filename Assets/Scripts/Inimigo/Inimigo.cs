using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public float vida;
    public float dano;
    public float velocidade;
    public float coolDownAtaque;
    public float coolDownAtual;
    public bool podeIrParaTras;
    [HideInInspector] public Rigidbody rigd;
    PlayerCore player;
    public void Awake()
    {
        rigd = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerCore>();
    }
    public float RecebeDano(float dano) {
        vida-=dano;
        return vida;
    }
    public void InimigoVida()
    {
        if (vida <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.ReceberDano(dano);
        }
    }
}
