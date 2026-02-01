using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu(int option) {
        switch (option) {
            case 1:
                SceneManager.LoadScene("GameConstruct");
            break;

            case 2:
                
            break;

            case 3:
                SceneManager.LoadScene("Credits");
            break;
        }
    }
}
