﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]

public class HealthUpdate : MonoBehaviour
{

    //remember to use the trigger object inside the visual/physical object as it is not meant to be physical originally

    [SerializeField] private int healthChangeAmount;
    [SerializeField] private bool destroyOnContact;

    void OnTriggerStay2D(Collider2D colliderObject)
    {

        if (colliderObject.tag == "Player" || colliderObject.tag == "Enemy")
        {

            colliderObject.GetComponent<CharacterStatus>().UpdateHealth(healthChangeAmount);

            if (healthChangeAmount < 0 && colliderObject.GetComponent<Rigidbody2D>()!=null && colliderObject.tag=="Player")
            {
                Vector3 forcevec = (colliderObject.transform.position - transform.position).normalized * 35000f;

                colliderObject.GetComponent<Rigidbody2D>().AddForce(forcevec);
            }

            if (destroyOnContact == true)
            {
                if (transform.parent != null)
                {
                    Destroy(transform.parent.gameObject); //destroys the parent object aswell
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }

    }

}