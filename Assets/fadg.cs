using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadg : MonoBehaviour
{
    public Texture2D BluePrint;
    public GameObject Block;
    public SpriteRenderer srr;
    Texture2D texture;
    public GameObject shortblock;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Build()
    {
        BluePrint = srr.sprite.texture;
        int temp = 0;
        int hei = 0;
        int wid = 0;
        for ( ; hei < BluePrint.height && wid < BluePrint.width; hei++, wid++)
        {
            Color col = BluePrint.GetPixel(wid, hei);
            if(col.r < 0.4 && col.g < 0.4 && col.b < 0.4)
            {
                temp++;
            }
            else
            {
                if (temp > 1)
                {
                    break;
                }
                temp = 0;
            }
        }
        
        texture = new Texture2D(BluePrint.width / temp, BluePrint.height / temp);
        
        for(hei = 0; hei < BluePrint.height; hei+=temp)
        {
            for(wid = 0; wid < BluePrint.width; wid += temp)
            {
                Color col = BluePrint.GetPixel(wid, hei);
                if(col.r < 0.4 && col.g < 0.4 && col.b < 0.4)
                {
                    texture.SetPixel(wid / temp, hei / temp, Color.black); 
                }
            }
        }
        texture.Apply();
        Sprite sr = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0f, 0f));
      //  b();
        Clear();

    }
    void b()
    {
        for (int hei = 0; hei < texture.height; hei++)
        {
            for (int wid = 0; wid < texture.width; wid++)
            {
                Color col = texture.GetPixel(wid, hei);
                if (col == Color.black)
                {
                    Instantiate(Block, new Vector3(wid, 0, hei), transform.rotation);
                }
            }
        }
    }
    void Clear()
    {
        Texture2D d;
        d = texture;
        for(int hei = 0; hei < texture.height; hei++)
        {
            for (int wid = 0; wid < texture.width; wid++)
            {
                Color col = texture.GetPixel(wid, hei);
                if (col == Color.black)
                {
                    search(wid, hei, wid, hei);
                    wid = texture.width;
                    hei = texture.height;
                }
            }
        }
    }
    void search(int wid, int hei, int b, int a)
    {
        bool aa = false;
        Instantiate(Block, new Vector3(wid, 0, hei), transform.rotation);
        texture.SetPixel(wid, hei, Color.blue);
        Color col;
        if (wid - b != -1) {
            col = texture.GetPixel(wid + 1, hei);
            if (col == Color.black)
            {
                aa = true;
                search(wid + 1, hei, wid, hei);
            }
            else if (col == Color.blue)
            {
                aa = true;
            }
        }
        if (wid - b != 1)
        {
            col = texture.GetPixel(wid - 1, hei);
            if (col == Color.black)
            {
                aa = true;
                search(wid - 1, hei, wid, hei);
            }
            else if (col == Color.blue)
            {
                aa = true;
            }
        }

        if (hei - a != 1)
        {
            col = texture.GetPixel(wid, hei - 1);
            if (col == Color.black)
            {
                aa = true;
                search(wid, hei - 1, wid, hei);
            }
            else if (col == Color.blue)
            {
                aa = true;
            }
        }
        if (hei - a != -1)
        {
            col = texture.GetPixel(wid, hei + 1);
            if (col == Color.black)
            {
                aa = true;
                search(wid, hei + 1, wid, hei);
            }
            else if (col == Color.blue)
            {
                aa = true;
            }
        }
        int aw = wid - b;
        int aww = hei - a;
        if (!aa)
        {
            int t = wid;
            int tt = hei;
            wid += aw;
            hei += aww;
            int ii = 0;
            col = texture.GetPixel(wid, hei);
            while(col != Color.black && col != Color.blue)
            {
                texture.SetPixel(wid, hei, Color.blue);
                wid += aw;
                hei += aww;
                col = texture.GetPixel(wid, hei);
                ii++;
            }
            if (ii > 5)
            {
                for(int x = 1; x <= ii; x++)
                {
                    Instantiate(shortblock, new Vector3(t + aw * x, -1.45f, tt + aww * x), transform.rotation);
                }
            }
            else
            {
                {
                    Instantiate(door, new Vector3(wid, -2.74f, hei), transform.rotation);
                }
            }
            if (col == Color.black)
            {
                search(wid, hei, wid - aw, hei - aww);
            } 
        }
    }
    public GameObject door;
}