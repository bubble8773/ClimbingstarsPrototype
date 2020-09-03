using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachedTop : MonoBehaviour
{
    [SerializeField]
    float maxY, maxZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("reached top");
            //other.GetComponent<CharacterController>().Move(transform.position);
            other.transform.localPosition = new Vector3(other.transform.position.x,
                maxY, maxZ);
            GameData._instance.hasReachedTop = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
