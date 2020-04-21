using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardController : MonoBehaviour
{
    public int ditch_horizontal_range = 5;
    public int ditch_vertical_range = 5;

    public int board_length = 21;
    public int board_heigth = 15;
    public int board_area;

    public Tilemap breakable_tilemap;
    public Transform breakable_tilemap_transform;

    public List<GameObject> breakable_tiles;

    public GameObject last_clicked_block;
    public Vector3 last_clicked_block_position_in_tilemap;

    // Start is called before the first frame update
    void Start()
    {
        board_area = board_length * board_heigth;
        breakable_tiles = new List<GameObject>();
        breakable_tilemap_transform = breakable_tilemap.transform;
        foreach (Transform child in breakable_tilemap_transform)
        {
            breakable_tiles.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //last_clicked_block_position_in_tilemap = breakable_tilemap.WorldToCell(last_clicked_block.transform.position);
    }

    public void create_board()
    {
        int first_ditch_height = Random.Range(1, ditch_vertical_range);
        int first_ditch_length = Random.Range(1, ditch_vertical_range);

        spawn_bombs();
        spawn_numbers();
    }

    public void spawn_bombs()
    {
        int random;
        foreach(GameObject breakable_tile in breakable_tiles)
        {
            random = Random.Range(1, 10);
            if (random == 1)
            {
                breakable_tile.GetComponent<BreakableTile>().id = 1;
            }
        }
    }

    public void spawn_numbers()
    {
        for (int i = 0; i < breakable_tiles.Count; i++)
        {
            int number = 0;
            if (breakable_tiles[i].GetComponent<BreakableTile>().id != 1)
            {

                for (int j = -1; j < 2; j++)
                {
                    if (i - (board_length - j) >= 0)
                    {
                        if (breakable_tiles[i - (board_length - j)].GetComponent<BreakableTile>().id == 1)
                        {
                            number += 1;
                        }
                    }
                }

                int n = 0;
                int m = 2;

                //Validando se o bloco não está na ponta esquerda
                if(i + 1 % board_length == 1)
                {
                    if (breakable_tiles[i + 1].GetComponent<BreakableTile>().id == 1)
                    {
                        number += 1;
                    }
                }
                //Validando se o bloco não está na ponta direita
                else if (i + 1 % board_length == 0){
                    if (breakable_tiles[i - 1].GetComponent<BreakableTile>().id == 1)
                    {
                        number += 1;
                    }
                }
                else
                {
    
                        if (breakable_tiles[i + 1].GetComponent<BreakableTile>().id == 1)
                        {
                            number += 1;
                        }
                    
                    if (breakable_tiles[i - 1].GetComponent<BreakableTile>().id == 1)
                    {
                        number += 1;
                    }
                }
                

                for (int l = 1; l > -1; l--)
                {
                    if (i + (board_length + l) < board_area)
                    {
                        if (breakable_tiles[i + (board_length + l)].GetComponent<BreakableTile>().id == 1)
                        {
                            number += 1;
                        }
                    }
                }
                breakable_tiles[i].GetComponent<BreakableTile>().id = number + 1;
            } 
        }
    }
}
