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

    protected void Awake()
    { 
        Renderer = GetComponent<MeshRenderer>();
    }


    public void OutlineOn()
    {
        Renderer.material.shader = Resources.Load(
            "Materials/ItemOutline", typeof(Shader)) as Shader;
    }

    public void ShowInteractButton()
    {

    }

    public virtual void InteractAction()
    {
        // Do some interaction code
    }
}
