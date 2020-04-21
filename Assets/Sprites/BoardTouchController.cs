using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Esse script lida com os toques no board
public class BoardTouchController : MonoBehaviour
{
    RaycastHit hit;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        System.Console.WriteLine("Não to batendo");
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                Destroy(hit.transform.gameObject);
            }
        }
        
    }
}
