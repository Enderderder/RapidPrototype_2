using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Interactable : MonoBehaviour
{
    public string ButtonToInteract { get; set; } = "E";
    public Color OutlineColor { get; set; } = Color.yellow;
    public bool AbleToPickUp { get; set; } = false;
    private MeshRenderer Renderer { get; set; }
    private Material OriginMaterial { get; set; }
    private Material OutlineMaterial { get; set; }

    protected void Awake()
    { 
        Renderer = GetComponent<MeshRenderer>();
        OriginMaterial = Renderer.material;
        OutlineMaterial = (Material)Resources.Load("Materials/ItemOutline", 
            typeof(Material));
    }


    public void OutlineOn()
    {
        Renderer.material.shader = Resources.Load(
            "Materials/ItemOutline", typeof(Shader)) as Shader;

        // Change the Thickness and the Color of the outline shader
        // base on the property
    }

    public void OutlineOff()
    {
        Renderer.material = OriginMaterial;
    }

    public void ShowInteractButton()
    {

    }

    public virtual void InteractAction()
    {
        // Do some interaction code
    }
}
