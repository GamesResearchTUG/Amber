﻿using UnityEngine;
using UnityEditor;
using System.Collections;

public class RenderSceneToCubemap : ScriptableWizard
{
  public Transform renderFromPosition;
  public Cubemap cubemap;


  //----------------------------------------------------------------------------
  void OnWizardUpdate()
  {
    string helpString = "Select transform to render from and cubemap to render into";
    bool isValid = (renderFromPosition != null) && (cubemap != null);
  }


  //----------------------------------------------------------------------------
  void OnWizardCreate()
  {
    // create temporary camera for rendering
    GameObject go = new GameObject("CubemapCamera");
    go.AddComponent<Camera>();
    // place it on the object
    go.transform.position = renderFromPosition.position;
    go.transform.rotation = Quaternion.identity;
    // render into cubemap
    go.GetComponent<Camera>().RenderToCubemap(cubemap);

    // destroy temporary camera
    DestroyImmediate(go);
  }


  //----------------------------------------------------------------------------
  [MenuItem("zarG Byte/Render into Cubemap")]
  static void RenderToCubemap()
  {
    ScriptableWizard.DisplayWizard<RenderSceneToCubemap>(
        "Render cubemap", "Render!");
  }
}
