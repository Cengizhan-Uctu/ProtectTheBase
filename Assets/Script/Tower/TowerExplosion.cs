using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class TowerExplosion : MonoBehaviour
{
    [SerializeField] GameObject effect;
    [SerializeField] float power;
    [SerializeField] Text healtText;
    [SerializeField] float speed;
    private GameObject[] picess;
    public int maxHealt;
    private int currentHealt;
    private void Start()
    {
        maxHealt = Random.Range(10, 40);
        float xAxisi = Random.Range(-3,3);
        transform.position = new Vector3(xAxisi,transform.position.y,transform.position.z);

        currentHealt = maxHealt;
        picess = new GameObject[transform.childCount - 1];
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            GameObject Newpicess = gameObject.transform.GetChild(i).gameObject;
            picess[i] = Newpicess;
        }
        healtText.text = currentHealt.ToString();
    }
    void Update()
    {
        transform.Translate(0, 0, -1 * Time.deltaTime * (speed / maxHealt));
        if (transform.position.z<=3.5f)
        {
            GameManager.Instance.GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Instantiate(effect, new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), Quaternion.identity);
            currentHealt--;
            CreateBrokenTower();
            healtText.text = currentHealt.ToString();
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("CannonBullet"))
        {
            Instantiate(effect, new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), Quaternion.identity);
            currentHealt-=5;
            CreateBrokenTower();
            healtText.text = currentHealt.ToString();
            collision.gameObject.SetActive(false);
        }
        if (currentHealt <= 0)
        {
            StartCoroutine(isTirigerPicess());
        }
    }
    IEnumerator isTirigerPicess()
    {
        foreach (var pices in picess)
        {
            pices.GetComponent<Rigidbody>().AddForce(transform.position * power);
            pices.GetComponent<Rigidbody>().isKinematic = false;

        }
        yield return new WaitForSeconds(0.2f);
        foreach (var pices in picess)
        {

            pices.GetComponent<Collider>().isTrigger = true;
            pices.transform.parent = null;

        }
        gameObject.SetActive(false);
    }
    void CreateBrokenTower()
    {

        foreach (var pices in picess)
        {
            pices.transform.localScale -= new Vector3(0.003f, 0.003f, 0.003f);


        }
        transform.DOPunchScale(new Vector3(0.02f, 0.02f, 0.02f), 0.1f);
    }
    
}
