using UnityEngine;
using UnityEngine.UI;

public class PlayerSetup : MonoBehaviour
{
    private void Start()
    {
        // Se for um objeto de UI com componente Image
        Image img = GetComponent<Image>();
        if (img != null)
        {
            img.color = GameData.PlayerColor;
        }
    }
}
