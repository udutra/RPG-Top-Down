using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private int index;
    public float speed;
    public List<Transform> paths;

    private void Update() {
        transform.position = Vector2.MoveTowards(transform.position, paths[index].position, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, paths[index].position) < 0.1f ) {

            if(index < paths.Count - 1) {
                index++;
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