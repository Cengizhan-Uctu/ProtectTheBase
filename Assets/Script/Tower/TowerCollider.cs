using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class TowerCollider : MonoBehaviour
{
    [SerializeField] GameObject brokenTower;
    [SerializeField] GameObject destructionObject;
    [SerializeField] float power;
    [SerializeField] Text healtText;
    private int maxHealt;
    private int currentHealt;
    private void OnEnable()
    {
        maxHealt = Random.Range(2, 6);
        currentHealt = maxHealt;
        healtText.text = currentHealt.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Bullet"))
        {
            currentHealt--;
            transform.DOPunchScale(new Vector3(.18f, 0, .18f), 0.2f);
            healtText.text = currentHealt.ToString();

            if (currentHealt == maxHealt - 1)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                GameObject newBrokenTower = Instantiate(brokenTower, transform.position, Quaternion.identity);
                newBrokenTower.transform.SetParent(gameObject.transform);

            }
           
            if (currentHealt <= 0)
            {
                GameObject newDestructionObject = Instantiate(destructionObject, transform.position, Quaternion.identity);
                Rigidbody[] Crigdbody = newDestructionObject.GetComponentsInChildren<Rigidbody>();
                foreach (Rigidbody rb in Crigdbody)
                {
                    rb.AddForce(transform.position * power);
                }
                Destroy(newDestructionObject, 1);
                gameObject.SetActive(false);
            }
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("CannonBullet"))
        {
            currentHealt-=2;
            transform.DOPunchScale(new Vector3(.18f, 0, .18f), 0.2f);
            healtText.text = currentHealt.ToString();

            if (currentHealt == maxHealt - 1)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                GameObject newBrokenTower = Instantiate(brokenTower, transform.position, Quaternion.identity);
                newBrokenTower.transform.SetParent(gameObject.transform);

            }

            if (currentHealt <= 0)
            {
                GameObject newDestructionObject = Instantiate(destructionObject, transform.position, Quaternion.identity);
                Rigidbody[] Crigdbody = newDestructionObject.GetComponentsInChildren<Rigidbody>();
                foreach (Rigidbody rb in Crigdbody)
                {
                    rb.AddForce(transform.position * power);
                }
                Destroy(newDestructionObject, 1);
                gameObject.SetActive(false);
            }
            other.gameObject.SetActive(false);
        }
    }
    
}
