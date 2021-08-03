using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {

    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void _MouseOut()
    {
        anim.SetBool("MouseOut", true);
    }

    public void _MouseIn()
    {
        anim.SetBool("MouseOut", false);
    }
}
