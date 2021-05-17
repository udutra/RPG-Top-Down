using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;

    private void Start() {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    private void Update() {
        OnMove();
        OnRun();
    }

    #region Movement
    private void OnMove() {
        if(player.Direction.sqrMagnitude > 0) {
            if(player.IsRolling) {
                anim.SetTrigger("IsRoll");
            }
            else {
                anim.SetInteger("Transition", 1);
            }
        }
        else {
            anim.SetInteger("Transition", 0);
        }

        if(player.Direction.x > 0) {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if(player.Direction.x < 0) {
            transform.eulerAngles = new Vector2(0, 180);
        }

        if(player.IsCutting) {
            anim.SetInteger("Transition", 3);
        }
    }

    private void OnRun() {
        if(player.IsRunning) {
            anim.SetInteger("Transition", 2);
        }
    }
    #endregion
}