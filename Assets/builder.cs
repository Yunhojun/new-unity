using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class builder : MonoBehaviour
{

    public GameObject dd;
    public Texture2D t;
    Texture2D d;
    // Start is called before the first frame update

    public SpriteRenderer srr;
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Build();
        }
    }

    int dsize;

    Texture2D origin;

    int originsize;

    // Update is called once per frame
    void Build()
    {
        t = (Texture2D)dd.GetComponent<CanvasSampleOpenFileImage>().output.texture;
        origin = t;
        dsize = 0;
        originsize = 0;
        Color col;
        int a = -1;/*
        for(int hei = 0; hei < t.height; hei++)
        {
            for (int wid = 0; wid < t.width; wid++)
            {
                col = t.GetPixel(wid, hei);
                t.SetPixel(wid, hei, Color.white);

                if (col.r < 0.4 && col.g < 0.4 && col.b < 0.4)
                {
                    a++;
                    break;
                }
                if((wid +1)== t.width)
                {
                    Debug.Log(213);
                    break;
                }
            }
        }*/

        a = 0;
        for (int hei = 0; hei < t.height; hei++)
        {
            for (int wid = 0; t.width > wid; wid++)
            {
                col = t.GetPixel(wid, hei);
                if (col.r < 0.4 && col.g < 0.4 && col.b<0.4)
                {
                    a++;
                    break;
                }
                if (wid == (t.width - 1))
                {
                   if (a < t.height / 2)
                   {
                        for(int n = a; n >= 0; n--)
                        {
                            for(int j = 0; j < t.width; j++)
                            {
                                t.SetPixel(j, hei-n, Color.white);
                            }
                        }
                    }
                    a = 0;
                }
            }
        }
        a = 0;
        for (int wid = 0; wid < t.width; wid++)
        {
            for (int hei = 0; t.width > hei; hei++)
            {
                col = t.GetPixel(wid, hei);
                if (col.r < 0.4 && col.g < 0.4 && col.b < 0.4)
                {
                    a++;
                    break;
                }
                if (hei == (t.height - 1))
                {
                    if (a < t.width / 2)
                    {
                        for (int n = a; n >= 0; n--)
                        {
                            for (int j = 0; j < t.height; j++)
                            {
                                t.SetPixel(wid - n, j, Color.white);
                            }
                        }

                    }
                    a = 0;
                }
            }
        }
        t.Apply();
        Sprite sr = Sprite.Create(origin, new Rect(0.0f, 0.0f, t.width, t.height), new Vector2(0f, 0f));
        srr = gameObject.GetComponent<SpriteRenderer>();
        srr.sprite = sr;
        r.Build();
    }
    public fadg r;
    
}