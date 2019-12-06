using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayCasting : MonoBehaviour
{
    private RaycastHit hit;
    private int direction = 1;
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private Transform[] _teleportLocations;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CameraRayCast();
    }

    private void CameraRayCast()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * 1000, Color.yellow);
            Debug.Log("Did not Hit");
        }

        if (hit.transform != null)
        {
            if (hit.transform.CompareTag("Teleport Button 1"))
            {
                print("Button1");
                _loadingScreen.SetActive(true);
                transform.position = _teleportLocations[0].transform.position;
                StartCoroutine(TurnOfLodaingScreen());
            }
            if (hit.transform.CompareTag("Teleport Button 2"))
            {
                print("Button2");
                _loadingScreen.SetActive(true);
                transform.position = _teleportLocations[1].transform.position;
                StartCoroutine(TurnOfLodaingScreen());
            }
            if (hit.transform.CompareTag("Grabbable"))
            {
                print("Grabbable Gamobject.");
                hit.transform.Translate(hit.transform.position);
            }
            direction = direction * -1;
        }
    }

    IEnumerator TurnOfLodaingScreen()
    {
        yield return new WaitForSeconds(2f);
        _loadingScreen.SetActive(false);
    }

}
