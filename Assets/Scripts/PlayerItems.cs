using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour {

    [Header("Currents")]
    [SerializeField] private float currentWater;
    [SerializeField] private float currentWood, currentCarrot;

    [Header("Limits")]
    public float waterLimit;
    public float woodLimit, carrotLimit;

    public float CurrentWood {
        get => currentWood;
        set => currentWood = value;
    }

    public float CurrentWater {
        get => currentWater;
        set => currentWater = value;
    }

    public float CurrentCarrot {
        get => currentCarrot;
        set => currentCarrot = value;
    }

    public void WatersLimits(float water) {
        currentWater += water;
        if(currentWater < 0.1f) {
            currentWater = 0;
        }
        else if(currentWater >= waterLimit) {
            currentWater = waterLimit;
        }
    }

    public void WoodsLimis(float wood) {
        currentWood += wood;
        if(currentWood < 1) {
            currentWood = 0;
        }
        else if(currentWood >= woodLimit) {
            currentWood = woodLimit;
        }
    }

    public void CarrotsLimits(float carrot) {
        currentCarrot += carrot;
        if(currentCarrot < 1) {
            currentCarrot = 0;
        }
        else if(currentCarrot >= carrotLimit) {
            currentCarrot = carrotLimit;
        }
    }
}
