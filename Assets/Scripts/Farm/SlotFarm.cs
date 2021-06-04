using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    private PlayerItems playerItems;

    [Header("Componentes")]
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;
    [SerializeField] private SpriteRenderer spriteRender;

    [Header("Settings")]
    [SerializeField] private int digAmount; //Quantidade de "escavação"
    private int initialdigAmount;
    [SerializeField] private int waterAmount; //total de agua apra nascer uma cenoura
    private float currentWater;
    [SerializeField] private bool detecting, dugHole;
    

    private void Start() {
        initialdigAmount = digAmount;
        playerItems = FindObjectOfType<PlayerItems>();
    }

    private void Update() {
        if(dugHole) {
            if(detecting) {
                currentWater += 0.01f;
            }

            //Encheu o total de agua nescessario
            if(currentWater >= waterAmount) {
                spriteRender.sprite = carrot;

                if(Input.GetKeyDown(KeyCode.E)) {
                    spriteRender.sprite = hole;
                    playerItems.CarrotsLimits(1f);
                    currentWater = 0f;
                }
            }
        }
    }

    public void OnHit() {
        digAmount--;

        if(digAmount <= initialdigAmount /2) {
            //aparecer buraco
            spriteRender.sprite = hole;
            dugHole = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Dig")) {
            OnHit();
        }
        if(collision.CompareTag("Water")) {
            detecting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("Water")) {
            detecting = false;
        }
    }
}
