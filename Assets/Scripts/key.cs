using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;
using UnityEngine.SceneManagement;

public class key : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            SceneManager.LoadScene("Window");
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
       transform.position = eventData.position;
    }

    public void OnDrop(PointerEventData eventData)
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }
}
