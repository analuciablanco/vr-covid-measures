using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ya se armó
public class LavarseLasManos : MonoBehaviour
{
    public Text instruction;
    // Start is called before the first frame update
    void Start()
    {
        instruction = GetComponent<Text>();
        //StartCoroutine(Instructions());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Instructions() {
        //run instructions
        instruction.text = "Texto cambiado";
        yield return new WaitForSecondsRealtime(1);
        instruction.text = "Texto cambiado 2";
        yield return new WaitForSecondsRealtime(1);
    }
}
