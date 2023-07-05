using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    public float vida;
    CameraPlayer cameraplayer;
    [HideInInspector]public bool podeReceberDano=true;
    void Start()
    {
        cameraplayer = FindObjectOfType<CameraPlayer>();
    }
    public float ReceberDano(float dano)
    {
        if (podeReceberDano)
        {
            cameraplayer.shake = true;
            vida -= dano;
            var rig = GetComponent<Rigidbody>();
            rig.velocity = new Vector3(0, 0, 0);
            podeReceberDano = false;
            StartCoroutine(PodeReceberDano());
        }
        return vida;
    }
    IEnumerator PodeReceberDano()
    {
        yield return  new WaitForSeconds(1f);
        podeReceberDano = true;
    }
    void Update()
    {
        if (vida <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
