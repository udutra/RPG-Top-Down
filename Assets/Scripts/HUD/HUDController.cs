using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {

    private PlayerItems playerItems;
    [SerializeField] private Image waterBar, woodBar, carrotBar;

    private void Awake() {
        playerItems = FindObjectOfType<PlayerItems>();
    }

    private void Start() {
        waterBar.fillAmount = CalculaBar(playerItems.CurrentWater,playerItems.waterLimit);
        woodBar.fillAmount = CalculaBar(playerItems.CurrentWood, playerItems.woodLimit);
        carrotBar.fillAmount = CalculaBar(playerItems.CurrentCarrot, playerItems.carrotLimit);
    }

    private void Update() {
        waterBar.fillAmount = CalculaBar(playerItems.CurrentWater, playerItems.waterLimit);
        woodBar.fillAmount = CalculaBar(playerItems.CurrentWood, playerItems.woodLimit);
        carrotBar.fillAmount = CalculaBar(playerItems.CurrentCarrot, playerItems.carrotLimit);
    }

    private float CalculaBar(float current, float limit) {
        return current / limit;
    }
}