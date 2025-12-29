using System.Collections;
using UnityEngine;

public class ShootAtPlayerInIntervals : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float interval;
    [SerializeField] private Transform player;

    private Vector3 playerDirection;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (interval != 0)
            interval -= Time.deltaTime;
        
        if (player != null)
            playerDirection = player.position - transform.position;
        
        StartCoroutine(ShootPlayer(interval, playerDirection));
    }

    private IEnumerator ShootPlayer(float interval, Vector3 direction)
    {
        yield return new WaitForSeconds(interval);
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
