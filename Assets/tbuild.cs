using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tbuild : MonoBehaviour
{
    public Texture2D t;
    public SpriteRenderer b;
    public GameObject g;
    // Start is called before the first frame update
    public void ccc()
    {
        int a = 1;
        t = b.sprite.texture;
        for (int hei = 0; hei < t.height; hei++)
        {
            for (int wid = 0; t.width > wid; wid++)
            {
                Color col = t.GetPixel(wid, hei);
                if (col.r < 0.4 && col.g < 0.4 && col.b < 0.4)
                {
                    a++;
                    hei++;
                }else
                {
                    if (a > 1)
                    {
                        x(a);
                        return;
                    }
                }
            }
        }
    }
    void x(int a)
    {
        for (int hei = 0; hei < t.height; hei++)
        {
            for (int wid = 0; t.width > wid; wid++)
            {
                Color col = t.GetPixel(wid, hei);
                if (col.r < 0.4 && col.g < 0.4 && col.b < 0.4)
                {
                    for(int z = hei; z < hei + 5; z++)
                    {
                        for(int zz = wid; zz < wid + 5; zz++)
                        {
                            if (zz > t.width||z>t.height)
                            {   

                                z = hei + 5;
                                zz = wid;
                                break;
                            }
                            Color colx = t.GetPixel(z, zz);
                            if (colx.r < 0.4 && colx.g < 0.4 && colx.b < 0.4)
                            {

                            }
                            else
                            {
                                z = hei + 5;
                                zz = wid;
                            }


                        }
                    }
                    wid = wid + 4;
                }
            }
        }
    }
    void r()
    {

    }
    void search(int wid, int hei)
    {
        Color col = t.GetPixel(wid, hei);
        if (col.r < 0.4 && col.g < 0.4 && col.b < 0.4)
        {
            Instantiate(g, new Vector3(wid, 0, hei), transform.rotation);
            t.SetPixel(wid, hei, Color.white);
            
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
