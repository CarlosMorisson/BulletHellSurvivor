using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadorDeSkill : MonoBehaviour
{ 

    public Transform barrel;
    [SerializeField] private float fireRate;
    [SerializeField] private GameObject TiroBase;
    public Vector3 mousePos;
    public float coolDown = 0.5f;
    //public Transform pivo;
    private float fireTimer;

    void Update()
    { 
        Spell();
    }
    private void Spell()
    {
        if (Input.GetMouseButtonDown(0) && CanShoot())
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        fireTimer = Time.time + fireRate;
        Instantiate(TiroBase, barrel.position, barrel.rotation);

    }
    private bool CanShoot()
    {
        return Time.time > fireTimer;
    }


}
