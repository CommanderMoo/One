using UnityEngine.UI;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public Text livesText;

    private void Update() {
        livesText.text = Player.Lives.ToString() + "LIVES";
    }
}
