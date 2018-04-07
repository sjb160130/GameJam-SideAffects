using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_manager : MonoBehaviour {
    public TextAsset textfile;
    public string[] textLines;

    public GameObject textBox;

    public Text theText;

    public int currentLines;
    public int endAtLine;

    public MC_Movement player;

    public bool isActive;
    public bool isTyping = false;
    private bool cancelTyping = false;

    public float typeSpeed;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<MC_Movement>();

        if (textfile != null)
        {
            textLines = (textfile.text.Split('\n'));
        }

        if(endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }
    }

   void Update()
    {
        //Return
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!isTyping)
            {
                currentLines += 1;
                if (currentLines > endAtLine)
                {
                    DisableTextBox();
                }
                else
                {
                    StartCoroutine(TextScroll(textLines[currentLines]));
                }
            }
            else if (isTyping && !cancelTyping)
            {
                cancelTyping = true;
            }
        }
        //End dialogue close box
        if (currentLines > endAtLine)
        {
            DisableTextBox();
        }

    }

    private IEnumerator TextScroll (string lineOfText)
    {
        int letter = 0;
        theText.text = "";
        isTyping = true;
        cancelTyping = false;
        while (isTyping && !cancelTyping && (letter < lineOfText.Length - 1))
        {
            theText.text += lineOfText[letter];
            letter += 1;
            yield return new WaitForSeconds(typeSpeed);
        }
        theText.text = lineOfText;
        isTyping = false;
        cancelTyping = false;
    }

    //call this to bring box back
    public void EnableTextBox() {

        textBox.SetActive(true);
        StartCoroutine(TextScroll(textLines[currentLines]));
    }
    //call this to hide box
    public void DisableTextBox() {
        textBox.SetActive(false);
    }

    public void ReloadScript(TextAsset theText)
    {
        textLines = new string[1];
    }
}
