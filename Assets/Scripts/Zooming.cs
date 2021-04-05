using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
public class Zooming : MonoBehaviour
{
    [SerializeField] private float zoomSize = 10;

    CinemachineVirtualCamera camera;

    private void Start() 
    {
        camera =  GetComponentInChildren<CinemachineVirtualCamera>();
        camera.m_Lens.OrthographicSize = 10;
    }

    private void Update() 
    {
        if (Mouse.current.scroll.ReadValue().y > 0)
        {
            camera.m_Lens.OrthographicSize = zoomSize--;
        }

        if (Mouse.current.scroll.ReadValue().y < 0)
        {
            camera.m_Lens.OrthographicSize = zoomSize++;

        }

        if (camera.m_Lens.OrthographicSize <= 1)
        {
            camera.m_Lens.OrthographicSize = 1;
        }
    }
}
