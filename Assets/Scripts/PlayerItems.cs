using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour {

    [SerializeField] private int totalWood;
    [SerializeField] private int carrots;
    [SerializeField] private float currentWater;
    public float waterLimit;

    public int TotalWood {
        get => totalWood;
        set => totalWood = value;
    }

    public float CurrentWater {
        get => currentWater;
        set => currentWater = value;
    }

    public int Carrots {
        get => carrots;
        set => carrots = value;
    }

    public void WaterLimit(float water) {
        if(currentWater < waterLimit) {
            currentWater += water;
        }
    }
}
