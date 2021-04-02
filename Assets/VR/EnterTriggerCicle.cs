using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterTriggerCicle : MonoBehaviour
{
    public MeshRenderer Circle;
    public Material MatOff, MatOn;
    public float totalTime = 2.0f;
    public float Speed = 3f;
    bool _gvrStatus, _iswalking = false;
    float Heigt;
    float _gvrTimer;
    public GameObject Camera; 
    public GameObject Personagen;
    public Image VrVew;


    private void Start()
    {
        
    }
    public void OnCircle ()
    {

        Circle.material = MatOn;
        _gvrStatus = true;
    }
    public void OffCircle ()
    {

        Circle.material = MatOff;
        _gvrStatus = false;


    }
    public void BackCircle()
    {
        Circle.material = MatOff;
    }
    void Update()
    {
        if (_gvrStatus)
        {
            if (_gvrTimer < totalTime)
            {
            _gvrTimer += Time.deltaTime;

            }
            else
            {
                _gvrTimer = totalTime;
                Heigt = Personagen.transform.position.y;
                _iswalking = true;
            }
        }
        if (!_gvrStatus)
        {
            if (_gvrTimer > 0)
            {
                _gvrTimer -= Time.deltaTime;

            }
            else
            {
                _gvrTimer = 0.0f;
                _iswalking = false;

            }
        }

        if (_iswalking)
        {
            // Personagen.GetComponent<Rigidbody>().AddForce(Camera.transform.forward * Speed); 
            VrVew.color = Color.Lerp(VrVew.color, new Color(0, 0, 0, 0.95f),1.5f * Time.deltaTime);
           // Personagen.transform.rotation = Quaternion.Euler(0, Camera.transform.rotation.y, 0);
           Personagen.transform.Translate(Camera.transform.forward * Speed * Time.deltaTime);
            Personagen.transform.position = new Vector3(Personagen.transform.position.x, Heigt, Personagen.transform.position.z);
            //Personagen.transform.position = Vector3.MoveTowards(transform.position, Personagen.transform.position, Speed * Time.deltaTime);
        }
        else
        {
            VrVew.color = Color.Lerp(VrVew.color, new Color(0, 0, 0, 0), 1f * Time.deltaTime);
        }


    }
}
