using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField]
    private GameObject click;
    [SerializeField]
    private Inventory Pick;
    [SerializeField]
    private GameObject distGO;
    private MouseController Mouse;
    [SerializeField]
    private float dist;
    void Start()
    {
        MouseController Mouse = click.GetComponent<MouseController>();
        Inventory Pick = this.gameObject.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, distGO.transform.position) < dist)  {
           Pick.AddItem(distGO.GetComponent<Item>());
            GameObject.Destroy(distGO);
        }
    }
}
