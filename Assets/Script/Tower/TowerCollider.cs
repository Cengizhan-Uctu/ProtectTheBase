using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class TowerCollider : MonoBehaviour
{
    [SerializeField] GameObject brokenTower;
    [SerializeField] GameObject destructionObject;
    [SerializeField] GameObject effect;
    [SerializeField] float power;
    [SerializeField] Text healtText;
    [SerializeField] float speed;
    private int maxHealt;
    private int currentHealt;
    private void OnEnable()
    {
     
        maxHealt = Random.Range(10, 40);
        currentHealt = maxHealt;
        healtText.text = currentHealt.ToString();
        int xAxisi = Random.Range(-2, 3);
        transform.position = new Vector3(xAxisi, transform.position.y, 20);
    }
    void Update()
    {
        transform.Translate(0, 0, -1 * Time.deltaTime * (speed/maxHealt));
        if (transform.position.z<=3.5f)
        {
           // Time.timeScale = 0;// game over
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Bullet"))
        {
            currentHealt--;
            CreateBrokenTower();
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("CannonBullet"))
        {
            currentHealt -= 2;
            CreateBrokenTower();
            other.gameObject.SetActive(false);
        }
        //if (other.CompareTag("Redline"))
        //{
        //    // UI PROSESİNG
        //}
    }
    
    void CreateBrokenTower()
    {
        Instantiate(effect, new Vector3(transform.position.x,transform.position.y+1.5f,transform.position.z), Quaternion.identity);
       // transform.DOPunchScale(new Vector3(.2f, 0, .2f), 0.2f);
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
            Collider[] Ccollider = newDestructionObject.GetComponentsInChildren<Collider>();
            foreach (Rigidbody rb in Crigdbody)
            {
                rb.AddForce(transform.position * power);
            }
            currentHealt = 0;
            maxHealt = 0;
            gameObject.SetActive(false);
        }

    }
}
