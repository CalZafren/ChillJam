using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private SpriteRenderer spriteRend;
    [SerializeField]
    private Material switchOn;
    [SerializeField]
    private Material switchOff;
    [SerializeField]
    private GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(){
        spriteRend.material = switchOn;
        target.SetActive(true);
    }

    void OnTriggerExit2D(){
        spriteRend.material = switchOff;
        target.SetActive(false);
    }
}
