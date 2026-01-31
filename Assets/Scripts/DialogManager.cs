using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;

    public float dialogSpeed = 0.1f;
    public bool dialogEnd;
    public bool endCurrentLine;

    [SerializeField]
    TMP_Text textDialog;
    string text;
    public string[] lines;
    int currentLine;

    private void Awake()
    {
        instance = this;
    }

    public void handleDialog(bool show) {
        transform.GetChild(0).gameObject.SetActive(show);
    }

    public void ShowDialog(TextAsset dialogFile) {

        if (dialogFile == null) return;

        handleDialog(true);

        dialogEnd = false;

        textDialog.text = "";

        lines = dialogFile.text.Split(new string[] { "\n\n", "\r\n\r\n" }, System.StringSplitOptions.RemoveEmptyEntries);
        currentLine = 0;

        text = dialogFile.text;

        StartCoroutine(ReadDialog(lines[currentLine]));
    }

    IEnumerator ReadDialog(string line) {

        textDialog.text = "";

        foreach (char c in line) {
            textDialog.text += c;
            yield return new WaitForSeconds(dialogSpeed);
        } 
        
        endCurrentLine = true;

        if (currentLine >= lines.Length -1) dialogEnd = true;

        if(endCurrentLine && dialogEnd) handleDialog(false);
    }

    public void NextLine() {

        if (!endCurrentLine) return;

        currentLine++;

        if (currentLine < lines.Length)
        {
            StartCoroutine(ReadDialog(lines[currentLine]));
        }
        else {
            textDialog.text = "";
        }
    }
}
 