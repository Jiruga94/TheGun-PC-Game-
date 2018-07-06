using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapPanelController : MonoBehaviour {
    public Text playText;
    private AudioManager audioManager;
    private void Start()
    {
        audioManager = AudioManager.instance;
        audioManager.PlaySound("FirstSceneSound");
    }
    public void GoToMenu()
    {
        
        playText.color = Color.red;
        SceneManager.LoadScene(1);
    }
}
