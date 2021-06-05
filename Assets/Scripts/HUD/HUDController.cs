using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {

    private Player player;
    private PlayerItems playerItems;

    [Header("Items")]
    [SerializeField] private Image waterBar;
    [SerializeField] private Image woodBar, carrotBar;

    [Header("Tools")]
    public List<Image> toolsUI;
    public List<Image> toolsBT;
    [SerializeField] private Color selectColor, alphaColor;

    private void Awake() {
        player = FindObjectOfType<Player>();
        playerItems = player.GetComponent<PlayerItems>();
    }

    private void Start() {
        UpdateBar();
    }

    private void Update() {
        UpdateBar();
        UpdateTools();
    }

    private void UpdateBar() {
        waterBar.fillAmount = playerItems.CurrentWater / playerItems.waterLimit;
        woodBar.fillAmount = playerItems.CurrentWood / playerItems.woodLimit;
        carrotBar.fillAmount = playerItems.CurrentCarrot / playerItems.carrotLimit;
    }

    private void UpdateTools() {
        for(int i = 0; i < toolsUI.Count; i++) {
            if(i == player.HandlingObj - 1) {
                toolsUI[i].color = selectColor;
                toolsBT[i].gameObject.SetActive(true);
            }
            else {
                toolsUI[i].color = alphaColor;
                toolsBT[i].gameObject.SetActive(false);
            }
        }
    }
}