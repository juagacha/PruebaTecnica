using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public Renderer Renderer;
    private float colorR, colorG, colorB, colorA;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        ChangeColor();

    }

    // Update is called once per frame
    
    float GetRandomColor()
    {
        return Random.Range(0f, 1f);
    }

    void ChangeColor()
    {
        colorR = GetRandomColor();
        colorG = GetRandomColor();
        colorB = GetRandomColor();
        colorA = 1;
        Material material = Renderer.material;
        material.color = new Color(colorR, colorG, colorB, colorA);
    }

   

    


}
