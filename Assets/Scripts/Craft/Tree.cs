using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private float treeHealth;
    [SerializeField] private Animator anim;

    public void OnHit() {
        treeHealth--;
        anim.SetTrigger("IsHit");

        if(treeHealth <= 0) {
            //Cria o toco e instancia os drops (madeira)
            anim.SetTrigger("Cut");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Axe")) {
            OnHit();
        }
    }
}
