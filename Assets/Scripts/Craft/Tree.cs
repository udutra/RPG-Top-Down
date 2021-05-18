using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private float treeHealth;
    [SerializeField] private int totalWood;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject WoodPrefab;
    [SerializeField] private ParticleSystem leafs;

    public void OnHit() {
        treeHealth--;
        anim.SetTrigger("IsHit");
        leafs.Play();

        if(treeHealth <= 0) {
            for(int i = 0; i < totalWood; i++) {
                Instantiate(WoodPrefab, transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0f), transform.rotation);
                anim.SetTrigger("Cut");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Axe")) {
            OnHit();
        }
    }
}
