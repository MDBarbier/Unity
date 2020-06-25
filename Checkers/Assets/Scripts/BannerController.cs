using UnityEngine;
using UnityEngine.UI;

public class BannerController : MonoBehaviour
{
    private Text banner;

    // Start is called before the first frame update
    void Start()
    {
        banner = FindObjectOfType<Text>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBannerMessage(string message)
    {
        banner.text = message;
    }
}
