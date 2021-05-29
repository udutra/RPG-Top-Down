using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

    private PlayerItems playerItens;
    [SerializeField] private bool detectingPlayer;
    [SerializeField] private int waterValue;

    private void Start() {
        playerItens = FindObjectOfType<PlayerItems>();
    }

    private void Update() {
        if(detectingPlayer && Input.GetKeyDown(KeyCode.E)) {
            playerItens.WaterLimit(waterValue);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            detectingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            detectingPlayer = false;
        }
    }
}
