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
    public BreakableTile[,] breakable_tiles_;

    public GameObject last_clicked_block;
    public Vector3 last_clicked_block_position_in_tilemap;

    public BoardController(){
        breakable_tiles_ = new BreakableTile[board_length, board_heigth];
        
    }

    // Start is called before the first frame update
    void Start()
    {
        board_area = board_length * board_heigth;
        breakable_tiles = new List<GameObject>();
        breakable_tilemap_transform = breakable_tilemap.transform;
        foreach (GameObject tile in breakable_tiles)
        {
            tile.GetComponent<BreakableTile>().clicked = true;
        }
        foreach (Transform child in breakable_tilemap_transform)
        {
            breakable_tiles.Add(child.gameObject);
        }
        for (int y = 0; y < board_heigth; y++)
        {

            for (int x = 0; x < board_length; x++)
            {
            
                if (y == 0) {
                    breakable_tiles_[x, y] = breakable_tiles[x].GetComponent<BreakableTile>();
                }
                else
                {
                    breakable_tiles_[x, y] = breakable_tiles[((y + 1)* (x+1)) - 1].GetComponent<BreakableTile>();
                }

            }
        }
        create_board();
    }

    // Update is called once per frame
    void Update()
    {
        //last_clicked_block_position_in_tilemap = breakable_tilemap.WorldToCell(last_clicked_block.transform.position);
    }

    public void create_board()
    {
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
        ///Neste método achei que utilizar vários ifs ficava menos confuso do que vários fors, então optei por vários ifs
        for (int y = 0; y < board_heigth - 1; y++)
        {
            int count = 0;

            for (int x = 0; x < board_length - 1; x++)
            {
                if (breakable_tiles_[x, y].id != 1)
                {
                    int _x = x + 1;
                    int _y = y + 1;

                    if ((_x * _y) % board_length != 1 && (_x * _y) % board_length != 0 && (_x*_y) > board_length && (_x*_y) < (board_area - board_length) + 1)
                    {

                        if (breakable_tiles_[_x + 1, _y].id == 1)
                        {
                            count++;
                        }
                        if (breakable_tiles_[_x - 1, _y].id == 1)
                        {
                            count++;
                        }
                        if (breakable_tiles_[_x, _y + 1].id == 1)
                        {
                            count++;
                        }
                        if (breakable_tiles_[_x, _y - 1].id == 1)
                        {
                            count++;
                        }
                        if (breakable_tiles_[_x - 1, _y + 1].id == 1)
                        {
                            count++;
                        }
                        if (breakable_tiles_[_x + 1, _y + 1].id == 1)
                        {
                            count++;
                        }
                        if (breakable_tiles_[_x - 1, _y - 1].id == 1)
                        {
                            count++;
                        }
                        if (breakable_tiles_[_x + 1, _y - 1].id == 1)
                        {
                            count++;
                        }
                    }

                    breakable_tiles_[x, y].id = count;

                    /*                        //Validando se o bloco não está na ponta direita
                                            if ((i + 1) % board_length == 0)
                                        {
                                            if ((i + 1) == board_length)
                                            {
                                                if (breakable_tiles[i - 1].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    count++;
                                                }
                                                if (breakable_tiles[i + (board_length - 1)].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    count++; 
                                                }

                                                if (breakable_tiles[i + (board_length)].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }
                                            }
                                            else if ((i + 1) == board_area) {
                                                if (breakable_tiles[i - (board_length + 1)].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }

                                                if (breakable_tiles[i - (board_length)].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }
                                                if (breakable_tiles[i - 1].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }
                                            }
                                            else {
                                                if (breakable_tiles[i - (board_length + 1)].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }

                                                if (breakable_tiles[i - (board_length)].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }
                                                if (breakable_tiles[i - 1].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }
                                                if (breakable_tiles[i + (board_length - 1)].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }

                                                if (breakable_tiles[i + (board_length)].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }
                                            }
                                        }
                                        //Validando se o bloco não está na ponta esquerda
                                        else if ((i + 1) % board_length == 1)
                                        {
                                            //Validando se o bloco não esta no canto superior esquerdo
                                            if (i == 0)
                                            {
                                                if (breakable_tiles[i + 1].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }
                                                if (breakable_tiles[i + (board_length + 1)].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }

                                                if (breakable_tiles[i + (board_length)].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }
                                            }
                                            //Validando se o bloco não esta no canto inferior esquerdo
                                            else if ((i + 1) == (board_area - board_length))
                                            {

                                                if (breakable_tiles[i - (board_length - 1)].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }

                                                if (breakable_tiles[i - (board_length)].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }

                                                if (breakable_tiles[i + 1].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }
                                            }
                                            else
                                            {
                                                if (breakable_tiles[i - (board_length - 1)].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }

                                                if (breakable_tiles[i - (board_length)].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }

                                                if (breakable_tiles[i + 1].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }
                                                Debug.Log(i);
                                                if (breakable_tiles[i + (board_length + 1)].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }

                                                if (breakable_tiles[i + (board_length)].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if ((i + 1) - board_length <= 0)
                                            {
                                                if (breakable_tiles[i + 1].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }

                                                if (breakable_tiles[i - 1].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }

                                                if (breakable_tiles[i + (board_length - 1)].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }

                                                if (breakable_tiles[i + (board_length)].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }
                                                if (breakable_tiles[i + (board_length + 1)].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }
                                            }
                                            else if ((i + 1) + board_length >= board_area) {
                                                if (breakable_tiles[i - (board_length + 1)].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }

                                                if (breakable_tiles[i - (board_length)].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }
                                                if (breakable_tiles[i - (board_length - 1)].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }
                                                if (breakable_tiles[i + 1].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }

                                                if (breakable_tiles[i - 1].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }
                                            }
                                            else {
                                                if (breakable_tiles[i - (board_length + 1)].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }

                                                if (breakable_tiles[i - (board_length)].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }
                                                if (breakable_tiles[i - (board_length - 1)].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }
                                                if (breakable_tiles[i + (board_length - 1)].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }

                                                if (breakable_tiles[i + (board_length)].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }
                                                if (breakable_tiles[i + (board_length + 1)].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }

                                                if (breakable_tiles[i + 1].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }

                                                if (breakable_tiles[i - 1].GetComponent<BreakableTile>().id == 1)
                                                {
                                                    number += 1;
                                                }
                                            }
                                        }*/
                    /*
                                        breakable_tiles[i].GetComponent<BreakableTile>().id = number + 1;*/
                }
            }
        }
    }
}
