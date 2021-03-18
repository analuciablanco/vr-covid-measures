using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
  [SerializeField]
  Color catchColor = Color.cyan;

  Renderer render;
  [SerializeField]
  GameObject textInteraction;

  void Awake()
  {
    render = GetComponent<Renderer>();
  }

  public void HandleColor() => render.material.color = catchColor;

  public void HandleTextInteraction() =>  textInteraction?.SetActive(!textInteraction.activeSelf);

  public void handleClick()
  {
    HandleColor();
    HandleTextInteraction();
  }
}
