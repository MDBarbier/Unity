using UnityEngine;
using UnityEngine.UI;

public class BannerController : MonoBehaviour
{
    private Text banner;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Inside Bannercontroller Start");
        GetBannerTextObject();
    }

    private void GetBannerTextObject()
    {
        if (banner == null)
        {
            banner = FindObjectOfType<Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBannerMessage(string message)
    {
        GetBannerTextObject();
        Debug.Log("Inside Bannercontroller SetBannerMessage");
        banner.text = message;
    }
}
