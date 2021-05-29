using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rig;
    private Vector2 _direction;
    private float initialSpeed;
    [SerializeField] private int handlingObj;
    [SerializeField] private bool _isRunning, _isRolling, _isCutting, _isDigging;
    public float speed, runSpeed;
    
    public Vector2 Direction {
        get {
            return _direction;
        }
        set {
            _direction = value;
        }
    }

    public bool IsRunning {
        get {
            return _isRunning;
        }
        set {
            _isRunning = value;
        }
    }

    public bool IsRolling {
        get {
            return _isRolling;
        }
        set {
            _isRolling = value;
        }
    }

    public bool IsCutting {
        get {
            return _isCutting;
        }
        set {
            _isCutting = value;
        }
    }

    public bool IsDigging {
        get {
            return _isDigging;
        }
        set {
            _isDigging = value;
        }
    }

    private void Start() {
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
        handlingObj = 1;
    }

    private void Update() {

        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            handlingObj = 1;
        }

        if(Input.GetKeyDown(KeyCode.Alpha2)) {
            handlingObj = 2;
        }

        OnInput();
        OnRun();
        OnRooling();
        OnCutting();
        OnDigging();
    }

    private void FixedUpdate() {
        OnMove();
    }

    #region Movement
    private void OnInput() {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void OnMove() {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    private void OnRun() {
        if(Input.GetKeyDown(KeyCode.LeftShift)) {
            speed = runSpeed;
            IsRunning = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)) {
            speed = initialSpeed;
            IsRunning = false;
        }
    }

    private void OnRooling() {
        if(Input.GetMouseButtonDown(1)) {
            speed = runSpeed;
            _isRolling = true;
        }

        if(Input.GetMouseButtonUp(1)) {
            speed = initialSpeed;
            _isRolling = false;
        }
    }
    #endregion

    #region Action
    private void OnCutting() {
        if(handlingObj == 1) {
            if(Input.GetMouseButtonDown(0)) {
                speed = 0;
                IsCutting = true;
            }
            if(Input.GetMouseButtonUp(0)) {
                speed = initialSpeed;
                IsCutting = false;
            }
        }
    }

    private void OnDigging() {

        if(handlingObj == 2) {
            if(Input.GetMouseButtonDown(0)) {
                speed = 0;
                IsDigging = true;
            }
            if(Input.GetMouseButtonUp(0)) {
                speed = initialSpeed;
                IsDigging = false;
            }
        }
    }
    #endregion
}