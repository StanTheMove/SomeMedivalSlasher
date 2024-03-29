using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [SerializeField]
    private Arrow arrowPrefab;

    [SerializeField]
    private float reloadTime;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private float maxFirePower;

    [SerializeField]
    private float firePowerSpeed;

    private float firePower;

    private bool fire;

    private Arrow currentArrow;
    private string enemyTag;
    private bool isReloading;

    private void Start()
    {
        TheEnemyTag(enemyTag);
        Reload();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fire = true;
        }

        if (fire && firePower < maxFirePower)
        {
            firePower += Time.deltaTime * firePowerSpeed;
        }

        if (fire && Input.GetMouseButtonUp(0))
        {
            Fire(firePower);
            firePower = 0;
            fire = false;
        }
    }

    public void TheEnemyTag(string enemyTag)
    {
        this.enemyTag = enemyTag;
    }

    public void Reload()
    {
        if (isReloading || currentArrow != null) return;
        {
            isReloading = true;
        }
        StartCoroutine(ReloadAfterShoot());
    }

    public void Fire(float firePower)
    {
        if (isReloading || currentArrow == null) return;
        var force = spawnPoint.TransformDirection(Vector3.forward * firePower);
        currentArrow.ArrowFly(force);
        currentArrow = null;
        Reload();
    }

    public bool IsReady()
    {
        return (!isReloading && currentArrow != null);
    }

    private IEnumerator ReloadAfterShoot ()
    {
        yield return new WaitForSeconds(reloadTime);
        currentArrow = Instantiate(arrowPrefab, spawnPoint);
        currentArrow.transform.localPosition = Vector3.zero;
        currentArrow.TheEnemyTag(enemyTag);
        isReloading = false;
    }
}
