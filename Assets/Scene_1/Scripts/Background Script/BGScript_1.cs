using UnityEngine;
using System.Collections;

public class BGScript_1 : MonoBehaviour {

    [SerializeField]
    public GameObject player;

    public Transform playerTransform;

    public float scrollSpeed;

    private Material mat;

    private Vector2 offset = Vector2.zero;

    void Awake()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Use this for initialization
    void Start()
    {
        offset = mat.GetTextureOffset("_MainTex");
        var worldHeight = Camera.main.orthographicSize * 2f;
        var worldWidth = worldHeight * Screen.width / Screen.height;
        transform.localScale = new Vector3(worldWidth, worldHeight, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        offset.x += scrollSpeed * Time.deltaTime;
        mat.SetTextureOffset("_MainTex", offset);

    }

}
