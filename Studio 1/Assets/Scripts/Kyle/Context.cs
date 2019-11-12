using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Context : MonoBehaviour
{
    Node root;

    // Start is called before the first frame update
    void Start()
    {
        root = new Selector();
    }

    // Update is called once per frame
    void Update()
    {
        root.UpdateNode(this);
    }

    public void SetNode(Node node)
    {
        root = node;
    }
}
