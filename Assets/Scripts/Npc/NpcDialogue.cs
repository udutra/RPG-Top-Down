using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDialogue : MonoBehaviour {
    public List<string> sentences;
    
    public float dialogueRange;
    public LayerMask playerLayer;
    public bool playerHit;
    public DialogueSettings dialogue;

    private void Awake() {
        sentences = new List<string>();
    }
    private void Start() {
        //Editado por mim
        //GetNpcInfo();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.E) && playerHit) {
            DialogueController.instance.Speech(sentences.ToArray());
        }
    }

    private void FixedUpdate() {
        ShowDialogue();
    }

    private void ShowDialogue() {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        //Criado por mim
        sentences.Clear();
        GetNpcInfo();


        if(hit != null) {
            playerHit = true;
        }
        else {
            playerHit = false;
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }

    private void GetNpcInfo() {
        for(int i = 0; i < dialogue.dialogues.Count; i++) {
            switch(DialogueController.instance.language) {
                case Idioma.pt: {
                        sentences.Add(dialogue.dialogues[i].sentence.portuguese);
                        break;
                    }
                case Idioma.eng: {
                        sentences.Add(dialogue.dialogues[i].sentence.english);
                        break;
                    }
                case Idioma.spa: {
                        sentences.Add(dialogue.dialogues[i].sentence.spanish);
                        break;
                    }
                default: {
                        break;
                    }
            }
        }
    }
}
