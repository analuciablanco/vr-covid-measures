using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VRCamera : MonoBehaviour
{
  [SerializeField]
  Color rayColor = Color.green;
  [SerializeField, Range(0.1f, 100f)]
  float rayDistance = 5f;
  [SerializeField]
  LayerMask rayLayerDetection;
  RaycastHit hit;
  [SerializeField]
  Transform reticleTrs;

  [SerializeField]
  Vector3 initialScale;

  bool objectTouched;
  bool isCounting = false;
  float countdown = 0;

  VRControls vrcontrols;

  Target target;

  [SerializeField]
  UnityEngine.UI.Image buttonImage;

  void Awake()
  {
    vrcontrols = new VRControls();
  }

  void OnEnable()
  {
    vrcontrols.Enable();
  }

  void OnDisable()
  {
    vrcontrols.Disable();
  }

  void Start()
  {
      reticleTrs.localScale = initialScale;
      vrcontrols.Gameplay.VRClick.performed += _=> ClickOverObject();
  }

  void ClickOverObject()
  {
    Debug.Log(target?.gameObject.layer);
    switch(target?.gameObject.layer)
      {
        /*case 8:
          target?.handleClick();
          //target.HandleColor();
          break;*/
        case 9:
          Debug.Log("click");
          //target?.HandleTextInteraction();
          int sceneIndex = SceneManager.GetActiveScene().buildIndex;
          SceneManager.LoadScene(sceneIndex + 1);
          break;
      }
  }

  void FixedUpdate()
  {
    if(Physics.Raycast(transform.position, transform.forward, out hit, rayDistance, rayLayerDetection))
    {
      target = hit.collider.GetComponent<Target>();
      reticleTrs.position = hit.point;
      reticleTrs.localScale = initialScale * hit.distance;
      reticleTrs.localRotation = Quaternion.LookRotation(hit.normal);
      if(hit.transform.CompareTag("Button")){
        isCounting = true;
        buttonImage.color = new Color(0.4f,0.4f,0.4f);
      }else{
        isCounting = false;
        countdown = 0;
        buttonImage.color = Color.white;
      } 
    }
    else
    {
      //target ??= null;
      if(target) target = null;
      reticleTrs.localScale = initialScale;
      reticleTrs.localPosition = new Vector3(0, 0, 1);
      reticleTrs.localRotation = Quaternion.identity;

      isCounting = false;
      countdown = 0;
      buttonImage.color = Color.white;
    }

    if(countdown >= 3) {
      int sceneIndex = SceneManager.GetActiveScene().buildIndex;
      SceneManager.LoadScene(sceneIndex + 1);
    }
    if(isCounting){
      countdown += Time.deltaTime;
      float color = countdown > 0.4f ? countdown : 0.4f;
      buttonImage.color = new Color(color, color, color);
    } 
  }

  void OnDrawGizmosSelected()
  {
    Gizmos.color = rayColor;
    Gizmos.DrawRay(transform.position, transform.forward * rayDistance);
  }
}
