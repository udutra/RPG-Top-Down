using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {

    //Variaveis de Controle
    private bool isShowing;         //Se a janela esta visivel
    private int index;              //indexes das sentencas
    private string[] sentences;     //sentencas

    public static DialogueController instance;
    public Idioma language;

    [Header("Components")]
    public GameObject dialogueObj;  //Janela do Dialogo
    public Image profileSprite;     //Sprite do Perfil
    public Text speechText;         //Texto da Fala
    public Text actorNameText;      //Nome do NPC

    [Header("Settings")]
    public float typingSpeed;       //Velocidade da Fala

    private void Awake() {
        instance = this;
    }

    private IEnumerator TypeSentence() {
        foreach(char letter in sentences[index].ToCharArray()) {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    //Pular para a proxima fala
    public void NextSentence() {
        if(speechText.text == sentences[index]) {
            if(index < sentences.Length - 1) {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else { //Quando terminam os textos
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                sentences = null;
                isShowing = false;
            }
        }
    }

    //Chamar a fala do NPC
    public void Speech(string[] txt) {
        if(!isShowing) {
            dialogueObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }
}