using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemPickupScript : MonoBehaviour
{

    //[SerializeField] private float spinspeed = 0.5f;
    [SerializeField] private string _itemName;
    // Update is called once per frame
    void Update()
    {
        //Makes the item spin
        //transform.Rotate(0f, spinspeed, 0f, Space.Self);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GameManager.Instance.AddItemToList(_itemName);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }
}
