using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    private float timeCount;
    [SerializeField] private float speed, timeMove;

    private void Update() {
        timeCount += Time.deltaTime;

        if(timeCount < timeMove) {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            collision.GetComponent<PlayerItems>().WoodsLimis(1f);
            Destroy(gameObject);
        }
    }
}
