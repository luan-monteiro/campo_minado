using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Esse script lida com os toques no board
public class BoardTouchController : MonoBehaviour
{
    RaycastHit hit;

    public Camera cam;
    UnityEvent on_click_event;
    BoardController board_controller;
    bool first_hit = true;

    // Start is called before the first frame update
    void Start()
    {
        //Usamos este evento para chamar uma função de criar board no BoardController
        on_click_event = new UnityEvent();
        board_controller = gameObject.GetComponent<BoardController>();
       // on_click_event.AddListener(board_controller.create_board);
       // on_click_event.AddListener(send_clicked_block_position);


    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (first_hit)
                {
                 //   on_click_event.Invoke();
                 //   on_click_event.RemoveListener(gameObject.GetComponent<BoardController>().create_board);
                //    first_hit = false;
                }
             //   hit.transform.gameObject.GetComponent<BreakableTile>().clicked = true;
            }
        }

    }

    void send_clicked_block_position()
    {
        board_controller.last_clicked_block = hit.transform.gameObject;
    }
}
