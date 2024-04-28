using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class TextureTest : MonoBehaviour
{
    public Texture2D target;

    public Texture2D logo;

    public RawImage image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            //var texture = AddLogo(target, logo);
            var texture = ScalePNG(target);
            image.texture = texture;
            image.SetNativeSize();
        }
    }
    
    public Texture2D AddLogo(Texture2D targetPNG, Texture2D logoPNG)
    {
        var png = ScalePNG(targetPNG);
        var colors = png.GetPixels();
        for (int i = 0; i < png.width; i++)
        {
            int logoWidth = i % logoPNG.width;
            for (int j = 0; j < png.height; j++)
            {
                int logoHeight = j % logoPNG.height;
                Color c = logoPNG.GetPixel(logoWidth, logoHeight);
                Color targetColor = png.GetPixel(i, j);
                if (targetColor.a != 0)
                {
                    Color final_color = Color.Lerp(targetColor, c, c.a / 1.0f);
                    colors[targetPNG.width * j + i] = final_color;
                    // targetPNG.SetPixel(i, j, final_color);
                }
            }
        }

        png.SetPixels(colors);
        png.Apply();
        return png;
    }

    private Texture2D ScalePNG(Texture2D originPNG)
    {
        var texture2D = new Texture2D(originPNG.width * 3, originPNG.height * 3);
        
        for (int i = 0; i < originPNG.width; ++i)
        {
            for (int j = 0; j < originPNG.height; ++j)
            {
                Color newColor = originPNG.GetPixelBilinear((float)i / (float)texture2D.width,
                    (float)j / (float)texture2D.height);
                texture2D.SetPixel(i, j, newColor);
            }
        }
        texture2D.Apply();
        return texture2D;
    }
    Texture2D ScaleTexture(Texture2D source, float targetWidth, float targetHeight)
    {
        Texture2D result = new Texture2D((int)targetWidth, (int)targetHeight, source.format, false);

        float incX = (1.0f / targetWidth);
        float incY = (1.0f / targetHeight);

        for (int i = 0; i < result.height; ++i)
        {
            for (int j = 0; j < result.width; ++j)
            {
                Color newColor = source.GetPixelBilinear((float)j / (float)result.width, (float)i / (float)result.height);
                result.SetPixel(j, i, newColor);
            }
        }

        result.Apply();
        return result;
    }
}
