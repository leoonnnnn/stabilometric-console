//this is kinda useless now

using UnityEngine;
using System.Collections;
using System.IO.Ports;

// new shit
public class testunityconnection : MonoBehaviour
{
    SerialPort data_stream = new SerialPort("COM4", 9600);
    public string receivedstring;
    public Rigidbody rb;
    public float sensitivity = 0.01f;

    public string[] datas;

    void Start()
    {
        data_stream.Open();
    }

    void Update()
    {
        receivedstring = data_stream.ReadLine();

        string[] datas = receivedstring.Split(',');
        rb.AddForce(0, 0, float.Parse(datas[0])* sensitivity * Time.deltaTime, ForceMode.VelocityChange);
        rb.AddForce(float.Parse(datas[1]) * sensitivity * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        transform.Rotate(0, float.Parse(datas[2]), 0);
    }
}