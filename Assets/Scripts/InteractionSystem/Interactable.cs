using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MeshRenderer))]
public class Interactable : MonoBehaviour
{
    public string ButtonToInteract { get; set; } = "E";
    public Color OutlineColor { get; set; } = Color.yellow;
    public bool AbleToPickUp { get; set; } = false;
    private MeshRenderer Renderer { get; set; }
    private Shader OriginShader { get; set; }
    private Shader OutlineShader { get; set; }

    private Color originColor;

    protected void Awake()
    {
        Renderer = GetComponent<MeshRenderer>();
        OriginShader = Renderer.material.shader;
        OutlineShader = Shader.Find("Custom/OutlineShader");
    }

    public void OutlineOn()
    {
        Renderer.material.shader = OutlineShader;
        Renderer.material.SetColor("_OutlineColor", OutlineColor);
    }

    public void OutlineOff()
    {
        Renderer.material.shader = OriginShader;
    }

    public virtual void ShowInteractHUD(GameObject _textObj)
    {
        _textObj.GetComponent<Text>().text 
            = "Press " + ButtonToInteract + " to Interact";
        _textObj.SetActive(true);
    }

    public void HideInteractHUD(GameObject _textObj)
    {
        _textObj.SetActive(false);
    }

    public virtual void InteractAction()
    {
        // Do some interaction code
    }
}
