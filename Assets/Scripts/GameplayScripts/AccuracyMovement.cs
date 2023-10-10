using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccuracyMovement : MonoBehaviour
{ //ngl I don't *really* know how this works, but it's fine.

    float m_speed = 10;
    float m_XScale = 1;
    float m_YScale = 1;

    private Vector3 m_Pivot;
    private Vector3 m_PivotOffset;
    private float m_Phase;
    private bool m_Invert = false;
    private float m_2PI = Mathf.PI * 2;

    public bool isMoving = true;

    public GameObject targetCH;

    // Start is called before the first frame update
    void Start()
    {
        m_Pivot = transform.position;
        isMoving = true;
    }

    public void enableAccuracy()
    {
        isMoving = true;
        targetCH.gameObject.SetActive(true);
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update() //maybe work on inverted movement?
    {
        if (Input.GetKeyDown(KeyCode.Space)) //setactive turns the attached script off
        {
            isMoving = false;
            targetCH.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

        if (!isMoving) return; 

        m_PivotOffset = Vector3.right * 2 * m_XScale;

        m_Phase += m_speed * Time.deltaTime;
        if (m_Phase > m_2PI)
        {
            m_Invert = !m_Invert;
            m_Phase -= m_2PI;
        }
        if (m_Phase < 0) m_Phase += m_2PI;

        transform.position = m_Pivot + (m_Invert ? m_PivotOffset : Vector3.zero);
        Vector3 tempVector3 = new Vector3((Mathf.Cos(m_Phase) * (m_Invert ? -1 : 1) * m_XScale), (Mathf.Sin(m_Phase) * m_YScale), 0);
        transform.position += tempVector3;

    } //original code kept just incase of emergencies below

    //original code

    //float m_speed = 10;
    //float m_XScale = 1;
    //float m_YScale = 1;

    //private Vector3 m_Pivot;
    //private Vector3 m_PivotOffset;
    //private float m_Phase;
    //private bool m_Invert = false;
    //private float m_2PI = Mathf.PI * 2;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    m_Pivot = transform.position;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    m_PivotOffset = Vector3.up * 2 * m_YScale;

    //    m_Phase += m_speed * Time.deltaTime;
    //    if (m_Phase > m_2PI)
    //    {
    //        m_Invert = !m_Invert;
    //        m_Phase -= m_2PI;
    //    }
    //    if (m_Phase < 0) m_Phase += m_2PI;

    //    transform.position = m_Pivot + (m_Invert ? m_PivotOffset : Vector3.zero);
    //    Vector3 tempVector3 = new Vector3((Mathf.Sin(m_Phase) * m_XScale), (Mathf.Cos(m_Phase) * (m_Invert ? -1 : 1) * m_YScale), 0); //but how do I handle the +=
    //    transform.position += tempVector3;
    //    //transform.position.x += Mathf.Sin(m_Phase) * m_XScale;
    //    //transform.position.y += Mathf.Cos(m_Phase) * (m_Invert ? -1 : 1) * m_YScale;
    //}
}
