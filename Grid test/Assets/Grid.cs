using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Grid : MonoBehaviour
{

#pragma warning disable 649 //disable the "Field x is never assigned to" warning which is a roslyn compaitibility issue 
    [SerializeField] GameObject square;
    [SerializeField] Material material1;
    [SerializeField] Material material2;
    [SerializeField] int desiredXLength = 5;
    [SerializeField] int desiredZLength = 5;
#pragma warning restore 649

    private Dictionary<(int, int), GameObject> squares;

    // Start is called before the first frame update
    void Start()
    {
        squares = new Dictionary<(int, int), GameObject>();
        RenderGrid(desiredXLength, desiredZLength, square);
        ApplyMaterials(material1, material2, desiredXLength, desiredZLength, squares);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Render a grid of the specified height and width and create one of the specified template game objects for each position
    /// </summary>
    /// <param name="height">the height of the grid</param>
    /// <param name="width">the width of the grid</param>
    private void RenderGrid(int height, int width, GameObject templateGameObject)
    {
        for (int x = 0; x < height; x++)
        {
            for (int z = 0; z < width; z++)
            {
                var tempGameObject = Instantiate(templateGameObject, new Vector3(x, 0.2f, z), Quaternion.identity);
                tempGameObject.name = $"Square ({x},{z})";
                squares.Add((x, z), tempGameObject);
            }
        }
    }

    private void ApplyMaterials(Material material1, Material material2, int xlength, int zlength, Dictionary<(int,int), GameObject> gridPositions)
    {
        bool polarity = true;

        for (int x = 0; x < xlength; x++)
        {
            for (int z = 0; z < zlength; z++)
            {
                GameObject gameObject = gridPositions.Where(a => a.Key.Item1 == x && a.Key.Item2 == z).Select(a => a.Value).FirstOrDefault();

                if (polarity)
                {
                    if (z % 2 == 0)
                    {
                        gameObject.GetComponent<MeshRenderer>().material = material1;                        
                    }
                    else
                    {
                        gameObject.GetComponent<MeshRenderer>().material = material2;
                    }  
                }   
                else
                {
                    if (z % 2 == 0)
                    {
                        gameObject.GetComponent<MeshRenderer>().material = material2;
                    }
                    else
                    {
                        gameObject.GetComponent<MeshRenderer>().material = material1;
                    }
                }
            }

            polarity = !polarity;
        }
    }
}
