using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.IMGUI.Controls.PrimitiveBoundsHandle;

public class Bow : MonoBehaviour
{
    public GameObject bow;
    public GameObject arrowPrefab;
    public Transform arrowSpawnPoint;
    public float shootingPower = 30f;

    private GameObject currentArrow;
    private bool isPulling;

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            StartPulling();
        }

        if (Input.GetMouseButtonUp(0))
        {
            Shoot();
            BowFire();
        }

        if (isPulling)
        {
            PullString();
        }
    }

    void StartPulling()
    {
        isPulling = true;
        currentArrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
    }

    void PullString()
    {
        float pullValue = Mathf.Clamp(Vector3.Distance(transform.position, currentArrow.transform.position), 0f, 1f);
        currentArrow.transform.position = arrowSpawnPoint.position + arrowSpawnPoint.forward * pullValue;
    }

    void Shoot()
    {
        isPulling = false;
        Rigidbody rb = currentArrow.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce(arrowSpawnPoint.forward * shootingPower, ForceMode.Impulse);
        currentArrow.transform.SetParent(null);
        currentArrow = null;
    }

    IEnumerator BowFire()
    {
        bow.GetComponent<Animator>().Play("bowstring");
        yield return new WaitForSeconds(1.5f);
        bow.GetComponent<Animator>().Play("New State");
    }

}
