using UnityEngine;
using UnityEngine.Timeline;

public class ActiveMe : MonoBehaviour
{

    [SerializeField] Vector3 activePosition;
    [SerializeField] float speed=1f;
    [SerializeField] float minDifference=10f;
    private RectTransform rectTrans;
    public bool active;
    [SerializeField] CameraFollowingBehaviour camFol; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTrans=GetComponent<RectTransform>();
    }

    

private void unhide()
{
    if (active)
    {
        Vector3 var =Vector3.Lerp(rectTrans.anchoredPosition, activePosition, Time.deltaTime * speed);

        if(var.magnitude>minDifference)
        rectTrans.anchoredPosition = var;
        else
        rectTrans.anchoredPosition=activePosition;
        camFol.updateYOffset(-1f);
    }
}

    // Update is called once per frame
    void Update()
    {
        unhide();
    }
}
