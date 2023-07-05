using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBase : SkillController
{
    void Start()
    {
        Destroy(this.gameObject, tempoDeInstancia);
    }

    void Update()
    {
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);
    }
}
