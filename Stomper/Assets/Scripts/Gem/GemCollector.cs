using UnityEngine;
using TMPro;

public class GemCollector : MonoBehaviour
{
    public static GemCollector instance;
    [SerializeField] private int gemCount;
    [SerializeField] private TextMeshProUGUI gemCountText;

    private void Awake()
    {
         if(instance == null)
         {
              instance = this;
              DontDestroyOnLoad(gameObject);
        }
         else
         {
              Destroy(gameObject);
         }
    }

    private void Update()
    {
        gemCountText.text = ": " + gemCount;
    }


    public void AddGem()
    {
        gemCount++;
    }
}