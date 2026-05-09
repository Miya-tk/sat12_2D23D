using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    [SerializeField]
    private Camera targetCamera = null;

    [SerializeField]
    private float defaultFov = 60f;

    [SerializeField]
    private float lifeTimeSec = 2f;
    private float lifeFrame = 0f;

    [SerializeField]
    private float FoVDegreeShifterPerSec = -2.5f;

    [SerializeField]
    private bool fPause;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(targetCamera == null)
        {
            targetCamera = this.gameObject.GetComponent<Camera>();

            if(targetCamera = null )
            {
                Debug.Log("カメラが見つからんぜよ");
            }
        }
        Initialised();
    }

    // Update is called once per frame
    void Update()
    {
        // ポーズフラグが立っているときは、何もしないでUpdateを打ち切る。
        if (fPause) return;

        lifeFrame -= Time.deltaTime;

        if (lifeFrame > 0)
        {
            //Zoom
            this.targetCamera.fieldOfView += FoVDegreeShifterPerSec * Time.deltaTime;
        }
                
    }
    public void Initialised()
    {
        if (targetCamera != null) targetCamera.fieldOfView = defaultFov;

        lifeFrame = lifeTimeSec;
    }

    public void Pause()
    {
        fPause = !fPause;
    }
}
