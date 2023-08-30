using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorItem : MonoBehaviour
{
    public delegate void OnDestroyedHandler(GameObject gameObject);
    public event OnDestroyedHandler OnDestroyed;
    
    [SerializeField] private float moveSpeed;
    
    private Transform endPosition;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * (moveSpeed * Time.deltaTime));

        Debug.Log(Vector3.Distance(transform.position, endPosition.position));
        
        if (Vector3.Distance(transform.position, endPosition.position) <= 0.75f)
        {
            OnDestroyed?.Invoke(gameObject);
            Destroy(gameObject);
        }
    }

    public void SetEndPosition(Transform endPosition)
    {
        this.endPosition = endPosition;
    }
}
