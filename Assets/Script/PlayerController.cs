using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    public float speed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        this.transform.position += moveVec * speed * Time.deltaTime;
    }
}
