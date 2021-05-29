using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [SerializeField] private Sprite hole, carrote;
    [SerializeField] private SpriteRenderer spriteRender;
    [SerializeField] private int digAmount; //Quantidade de "escavação"
    [SerializeField] private int initialdigAmount;

    private void Start() {
        initialdigAmount = digAmount;
    }

    public void OnHit() {
        digAmount--;

        if(digAmount <= initialdigAmount /2) {
            //aparecer buraco
            spriteRender.sprite = hole;
        }

        //if(digAmount <= 0) {
        //    //Plantar cenoura
        //    spriteRender.sprite = carrote;
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Dig")) {
            OnHit();
        }
    }
}
