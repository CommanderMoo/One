using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconColor : MonoBehaviour
{

    private Image iconImage;
    public Sprite dimIconSprite;
    public Sprite goldIconSprite;

    // Start is called before the first frame update
    private void Start()
    {
        iconImage = GetComponent<Image>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (iconImage.sprite == dimIconSprite)
            {
                SwapIcon(goldIconSprite);
            }
            else
            {
                SwapIcon(dimIconSprite);
            }
        }
    }

    /// <summary>
    /// This method swaps the sprite of the UI Image ~ Adam Moore*
    /// </summary>
    /// <param name="spriteToChangeTo"></param>
    public void SwapIcon(Sprite spriteToChangeTo)
    {
        iconImage.sprite = spriteToChangeTo;
    }

}
