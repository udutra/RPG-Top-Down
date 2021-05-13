using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Animator anim;
    public int index;
    public float speed, initialSpeed;
    public List<Transform> paths;

    private void Start() {
        anim = GetComponent<Animator>();
        initialSpeed = speed;
    }

    private void Update() {

        if(DialogueController.instance.IsShowing == true) {
            speed = 0f;
            anim.SetBool("IsWalking", false);
        }
        else {
            speed = initialSpeed;
            anim.SetBool("IsWalking", true);
        }

        transform.position = Vector2.MoveTowards(transform.position, paths[index].position, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, paths[index].position) < 0.1f ) {

            if(index < paths.Count - 1) {
                //index++;
                index = Random.Range(0, paths.Count);
            }
            else {
                index = 0;
            }
        }

        Vector2 direction = paths[index].position - transform.position;
        if(direction.x > 0) {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if(direction.x < 0) {
            transform.eulerAngles = new Vector2(0, -180);
        }
    }
}