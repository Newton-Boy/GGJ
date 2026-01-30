using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    public int index;

    void Start()
    {
        textComponent.text = "";
        StartDialog();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartDialog() {
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine() {
        foreach (char c in lines[index].ToCharArray()) {
            textComponent.text += c.ToString();
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
 