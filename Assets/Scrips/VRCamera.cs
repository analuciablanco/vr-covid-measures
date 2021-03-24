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
  UnityEngine.UI.Image loadingImage;

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
      reticleTrs.position = new Vector3(hit.point.x, hit.point.y, hit.point.z - 0.1f);
      reticleTrs.localScale = initialScale * hit.distance;
      reticleTrs.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
      reticleTrs.gameObject.GetComponent<Light>().range = 0.6f;
      reticleTrs.rotation = Quaternion.LookRotation(hit.normal);
      if(hit.transform.CompareTag("Button")){
        isCounting = true;
        buttonImage.color = new Color(0.4f,0.4f,0.4f);
        //reticleMask.alphaCutoff = 0;
        loadingImage.fillAmount = 0;
      }else{
        isCounting = false;
        countdown = 0;
        buttonImage.color = Color.white;
        //reticleMask.alphaCutoff = 0;
        loadingImage.fillAmount = 0;
      } 
    }
    else
    {
      //target ??= null;
      if(target) target = null;
      reticleTrs.localScale = initialScale;
      reticleTrs.localPosition = new Vector3(0, 0, 1);
      reticleTrs.localRotation = Quaternion.identity;
      reticleTrs.gameObject.GetComponent<Light>().range = 0;


      isCounting = false;
      countdown = 0;
      buttonImage.color = Color.white;
      reticleTrs.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.7f, 0.7f);
      //reticleMask.alphaCutoff = 0;
      loadingImage.fillAmount = 0;
    }

    if(countdown >= 3) {
      int sceneIndex = SceneManager.GetActiveScene().buildIndex;
      if(sceneIndex >= 14) SceneManager.LoadScene(0);
      SceneManager.LoadScene(sceneIndex + 1);
    }
    if(isCounting){
      countdown += Time.deltaTime;
      float color = countdown > 0.4f ? countdown/3f : 0.4f;
      buttonImage.color = new Color(color, color, color);
      //reticleMask.alphaCutoff = countdown/3f;
      loadingImage.fillAmount = countdown/3f;

    } 
  }

  void OnDrawGizmosSelected()
  {
    Gizmos.color = rayColor;
    Gizmos.DrawRay(transform.position, transform.forward * rayDistance);
  }
}
