using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    public GameObject BrickTemplate;
    Color[] colors = new Color[] { Color.red, Color.green, Color.blue, Color.yellow, Color.cyan };

    void Start()
    {
        for (int y = 0; y < 5; y++)
        {
            for (int x = -3; x < 12; x++)
            {
                GameObject Brick = Instantiate(BrickTemplate);
                Brick.transform.position = new Vector3(x * 1, 4 - y) + new Vector3(-4, 0);
                SpriteRenderer renderer = Brick.GetComponent<SpriteRenderer>();
                renderer.material.color = colors[y];
            }
        }
    }


}
