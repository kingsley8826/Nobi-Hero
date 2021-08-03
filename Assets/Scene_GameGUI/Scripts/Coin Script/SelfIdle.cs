using UnityEngine;
using System.Collections;

public class SelfIdle : MonoBehaviour {

    void _SelftIdle()
    {
        this.GetComponent<Animator>().SetBool("isBuy", false);
    }
}
