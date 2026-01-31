using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;

    public float dialogSpeed = 0.1f;

    [SerializeField]
    TMP_Text textDialog;
    string text;


    private void Awake()
    {
        instance = this;
    }

    public void ShowDialog(TextAsset dialogFile) {

        if (dialogFile == null) return;

        text = dialogFile.text;

        StartCoroutine(ReadDialog());
    }

    IEnumerator ReadDialog() {

        foreach (char c in text.ToCharArray()) {
            textDialog.text += c;
            yield return new WaitForSeconds(dialogSpeed);
        }
    }
}
 