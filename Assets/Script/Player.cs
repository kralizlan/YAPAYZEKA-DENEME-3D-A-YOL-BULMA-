using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    private float speed = 5;


    public void GidilcekYer(Vector3 hedefNoktasi)
    {
        ++hedefNoktasi.y;
        transform.position = Vector3.MoveTowards(transform.position, hedefNoktasi, speed * Time.deltaTime);

    }

    public void LookToTarget(Vector3 target)
    {
        Vector3 direction = target - transform.position;

        // Eğer hedefe çok yakın değilse
        if (direction.magnitude > 0.1f)
        {
            // Yalnızca Y ekseninde dönecek şekilde, Y yönü için açıyı al
            direction.y = 0;  // X ve Z ekseninde dönmeyi engelliyoruz

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Mevcut rotasyonu al ve yalnızca Y eksenini ayarla
            Vector3 currentRotation = transform.rotation.eulerAngles;
            targetRotation = Quaternion.Euler(currentRotation.x, targetRotation.eulerAngles.y, currentRotation.z);

            // Arabayı sadece Y ekseninde hedefe bakacak şekilde yumuşakça döndür
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.0f);
        }
    }

    private void GameKontrol()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            ++speed;
        if (Input.GetKeyDown(KeyCode.DownArrow))
            --speed;
    }

    private void Update()
    {
 GameKontrol();
    }
}
