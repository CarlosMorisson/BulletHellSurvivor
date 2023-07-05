using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    public float dano;
    public float tempoDeInstancia;
    public float coolDown;
    public float velocidade;
    Inimigo inimigo;
    Rigidbody rig;
    void Awake()
    {
        inimigo = FindObjectOfType<Inimigo>();
        rig = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Inimigo"))
        {
            if (inimigo.podeIrParaTras)
            {
                var direction = (rig.position - inimigo.gameObject.transform.position).normalized;
                inimigo.rigd.AddForce(direction*-3, ForceMode.VelocityChange);
                
            }
            inimigo.RecebeDano(dano);
            Destroy(this.gameObject);
        }
    }

}
