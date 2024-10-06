using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject enemyNearby;
    public float bulletDelay;

    Transform bulletPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletPoint = GetComponentInChildren<Transform>();
        StartCoroutine(startShootSequence());
    }

    private void Update()
    {
        //looks at enemy
        Vector3 Look = transform.InverseTransformPoint(enemyNearby.transform.position);
        float Angle = Mathf.Atan2(Look.x, Look.y) * Mathf.Rad2Deg;

        transform.Rotate(0, 0, Angle);
    }

    //shoots bullets
    void ShootBullet()
    {
        Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
    }

    //Starts the shooting sequence until the game is over
    private IEnumerator startShootSequence()
    {
        while (true)//put game manager statement here
        {
            yield return new WaitForSeconds(bulletDelay * Time.deltaTime);
            ShootBullet();
        }
    }
}
