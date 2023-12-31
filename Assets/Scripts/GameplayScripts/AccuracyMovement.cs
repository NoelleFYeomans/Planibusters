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

    private bool isActive = false;

    public GameObject targetCH;
    public GameObject movingCH;

    // Start is called before the first frame update
    void Start()
    {
        m_Pivot = movingCH.transform.position;
        isMoving = false;
    }

    public void enableAccuracy()
    {
        isMoving = true;
        targetCH.gameObject.SetActive(true);
        movingCH.gameObject.SetActive(true);

        movingCH.transform.position = targetCH.transform.position; //WHY ARE YOU STARTING AT X1 Y1????????????
    }

    public void disableAccuracy()
    {
        isMoving = false;
        targetCH.gameObject.SetActive(false);
        movingCH.gameObject.SetActive(false);
    }

    public void calcAccuracy()
    {
        if (Vector2.Distance(movingCH.transform.position, targetCH.transform.position) > 1)
        {
            Debug.Log("Weak");
            GameObject.Find("GameManager").GetComponent<ScreenshakeScript>().determineInt += 1;
        }
        else if (Vector2.Distance(movingCH.transform.position, targetCH.transform.position) > 0.25)
        {
            Debug.Log("Med");
            GameObject.Find("GameManager").GetComponent<ScreenshakeScript>().determineInt += 2;
        }
        if (Vector2.Distance(movingCH.transform.position, targetCH.transform.position) <= 0.25)
        {
            Debug.Log("Strong");
            GameObject.Find("GameManager").GetComponent<ScreenshakeScript>().determineInt += 3;
        }
    }

    // Update is called once per frame
    void Update() //maybe work on inverted movement?
    {
        if (Input.GetKeyDown(KeyCode.Space) && movingCH.gameObject.activeInHierarchy && isActive) //is made active on the same frame that space is pressed, making it inactive
        {
            //take relevent info here
            calcAccuracy();
            disableAccuracy();
            GameObject.Find("MechanicsManager").GetComponent<MechanicsManager>().accuracyInputted = true;
            GameObject.Find("Fist(placeholder)").GetComponent<punchScript>().punchFist();
            
            GameObject.Find("GameManager").GetComponent<ScreenshakeScript>().startShaking();
            //determines experience formula?
            //gameObject.GetComponent<BalanceMechs>().enableBalance();
        }

        isActive = (targetCH.gameObject.activeInHierarchy) ? true: false;

        if (!isMoving) return; 

        m_PivotOffset = Vector3.right * 2 * m_XScale;

        m_Phase += m_speed * Time.deltaTime;
        if (m_Phase > m_2PI)
        {
            m_Invert = !m_Invert;
            m_Phase -= m_2PI;
        }
        if (m_Phase < 0) m_Phase += m_2PI;

        movingCH.transform.position = m_Pivot + (m_Invert ? m_PivotOffset : Vector3.zero);
        Vector3 tempVector3 = new Vector3((Mathf.Cos(m_Phase) * (m_Invert ? -1 : 1) * m_XScale), (Mathf.Sin(m_Phase) * m_YScale), 0);
        movingCH.transform.position += tempVector3;

    }
}
