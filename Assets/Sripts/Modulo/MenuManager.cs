using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField;

    private Color selectedColor = Color.white;

    private void Start()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
            nameInputField.text = PlayerPrefs.GetString("PlayerName");
    }

    public void SelectRed()   => selectedColor = Color.red;
    public void SelectBlue()  => selectedColor = Color.blue;
    public void SelectGreen() => selectedColor = Color.green;

    public void PlayGame()
    {
        string name = string.IsNullOrEmpty(nameInputField.text) ? "Jogador" : nameInputField.text;

        GameData.PlayerName = name;
        GameData.EnemyName = "Inimigo"; 
        GameData.PlayerColor = selectedColor;

        GameData.SaveNames();   
        GameData.SaveColor();   

        //PlayerPrefs.SetString("PlayerName", name);
        //PlayerPrefs.Save();

         UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");

        //SceneManager.LoadScene("GameScene");
    }
}