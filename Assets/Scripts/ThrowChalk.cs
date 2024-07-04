using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowChalk : MonoBehaviour
{
    [Header("Prefab Ref")]
    [SerializeField] Transform camera;
    [SerializeField] Transform throwPoint;
    [SerializeField] GameObject throwableChalk;

    [Header("Settings")]
    [SerializeField] KeyCode throwKey = KeyCode.Q;
    [SerializeField] [Range(1,999)] int throwAvailable; 
    [SerializeField] [Range(0,999f)] float throwCooldown;

    [Header("Math")]
    [SerializeField] [Range(0, 99f)] float throwForce = 10f;
    [SerializeField] [Range(0, 99f)] float throwUpwardForce = 3f;

    bool canThrowChalk;
    public static int throwremaining;

    // Start is called before the first frame update
    void Start()
    {
        if (camera == null)
        {
            Debug.LogError("Camera not found!");
        }
        if (throwPoint == null)
        {
            Debug.LogError("Throw Start Point not found!");
        }
        if (throwableChalk == null)
        {
            Debug.LogError("Chalk not found!");
        }
        if (throwKey == KeyCode.None)
        {
            Debug.LogError("Throw Key Command not assigned!");
        }
        if (throwAvailable == 0)
        {
            Debug.LogError("Available chalk set to 0 or negative!");
        }
        canThrowChalk = true;
        throwremaining = throwAvailable;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(throwKey) && canThrowChalk && throwAvailable > 0 && !GameClear.gameOver)
        {
            Debug.Log("ThrowAChalk");
            ThrowAChalk();
        }
    }

    void ThrowAChalk()
    {
        canThrowChalk = false;

        GameObject chalk = Instantiate(throwableChalk, throwPoint.position, camera.rotation);

        Rigidbody chalkRb = chalk.GetComponent<Rigidbody>();

        Vector3 forceDirection = camera.transform.forward;

        RaycastHit raycastHit;

        if (Physics.Raycast(camera.position, camera.forward, out raycastHit, 1000f))
        {
            forceDirection = (raycastHit.point - camera.position).normalized;
        }

        Vector3 forceToApply = forceDirection * throwForce + transform.up * throwUpwardForce;

        chalkRb.AddForce(forceToApply, ForceMode.Impulse);

        throwAvailable--;
        throwremaining = throwAvailable;

        StartCoroutine(ResetThrow());
    }

    IEnumerator ResetThrow()
    {
        yield return new WaitForSeconds(throwCooldown);
        canThrowChalk = true;
    }
}
