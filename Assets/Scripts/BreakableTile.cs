using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableTile : MonoBehaviour
{
    public int id;
    public bool clicked = false;
    public Sprite _0;
    public Sprite _1;
    public Sprite _2;
    public Sprite _3;
    public Sprite _4;
    public Sprite _5;
    public Sprite _6;
    public Sprite _7;
    public Sprite _8;
    public Sprite bomb;
    public Sprite flag;
    SpriteRenderer image_component;

    // Start is called before the first frame update
    void Start()
    {
      image_component = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (clicked) {
            switch (id)
            {
                case 0: //0
                   // image_component.sprite = _0;
                    clicked = false;
                    break;
                case 1: //Bomba
                    image_component.sprite = bomb;
                    //make_all_bombs_appear();
                    clicked = false;
                    break;
                case 2: //Numero1
                    image_component.sprite = _1;
                    clicked = false;
                    break;
                case 3: //Numero2
                    image_component.sprite = _2;
                    clicked = false;
                    break;
                case 4: //Numero3
                    image_component.sprite = _3;
                    clicked = false;
                    break;
                case 5: //Numero4
                    image_component.sprite = _4;
                    clicked = false;
                    break;
                case 6: //Numero5
                    image_component.sprite = _5;
                    clicked = false;
                    break;
                case 7: //Numero6
                    image_component.sprite = _6;
                    clicked = false;
                    break;
                case 8: //Numero7
                    image_component.sprite = _7;
                    clicked = false;
                    break;
                case 9: //Numero8
                    image_component.sprite = _8;
                    clicked = false;
                    break;
                case 10: //flag
                    image_component.sprite = flag;
                    clicked = false;
                    break;
            }
        }
    }
}
