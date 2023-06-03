using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject grass;
    [SerializeField] private GameObject treeGrass;
    [SerializeField] private GameObject dirt;
    [SerializeField] private GameObject tree;
    [SerializeField] private GameObject sand;

    [SerializeField] private GameObject grassContainer;
    [SerializeField] private GameObject dirtContainer;
    [SerializeField] private GameObject treeGrassContainer;
    [SerializeField] private GameObject treeContainer;
    [SerializeField] private GameObject sandContainer;


    private void Start()
    {
        for(int i=0; i<252; i++)
        {
            GameObject grassCloneDx = Instantiate(grass, new Vector3(grass.transform.position.x+0.32f * i, grass.transform.position.y , grass.transform.position.z), grass.transform.rotation);
            grassCloneDx.transform.parent = grassContainer.transform;
            grassCloneDx.name = "grass dx Clone " + i;

            
            GameObject grassCloneSx = Instantiate(grass, new Vector3(grass.transform.position.x - 0.32f *i, grass.transform.position.y, grass.transform.position.z), grass.transform.rotation);
            grassCloneSx.transform.parent = grassContainer.transform;
            grassCloneSx.name = "grass sx Clone " + i;

            
        }
        for (int i = 0; i < 504; i++)
        {
            GameObject sandContainerDx = Instantiate(sand, new Vector3(sand.transform.position.x + 0.32f * i, sand.transform.position.y, sand.transform.position.z), sand.transform.rotation);
            sandContainerDx.transform.parent = sandContainer.transform;
            sandContainerDx.name = "sand dx Clone " + i;
            GameObject sandContainerSx = Instantiate(sand, new Vector3(-(sand.transform.position.x + 0.32f * i), sand.transform.position.y, sand.transform.position.z), sand.transform.rotation);
            sandContainerSx.transform.parent = sandContainer.transform;
            sandContainerSx.name = "sand sx Clone " + i;
        }
        for (int i = 0; i < 504; i++)
        {
            GameObject treeGrassContainerDx = Instantiate(treeGrass, new Vector3(treeGrass.transform.position.x + 0.32f * i, treeGrass.transform.position.y, treeGrass.transform.position.z), treeGrass.transform.rotation);
            treeGrassContainerDx.transform.parent = treeGrassContainer.transform;
            treeGrassContainerDx.name = "Treegrass dx Clone " + i;
            GameObject treeGrassContainerSx = Instantiate(treeGrass, new Vector3(-(treeGrass.transform.position.x + 0.32f * i), treeGrass.transform.position.y, treeGrass.transform.position.z), treeGrass.transform.rotation);
            treeGrassContainerSx.transform.parent = treeGrassContainer.transform;
            treeGrassContainerSx.name = "Treegrass sx Clone " + i;
        }
        for (int i = 0; i < 144; i++)
        {
            GameObject dirtCloneDx = Instantiate(dirt, new Vector3(dirt.transform.position.x + 1.6926f *i, dirt.transform.position.y, dirt.transform.position.z), dirt.transform.rotation);
            dirtCloneDx.transform.parent = dirtContainer.transform;
            dirtCloneDx.name = "dirt dx Clone " + i;
            GameObject dirtCloneSx = Instantiate(dirt, new Vector3(dirt.transform.position.x- 1.6926f* i, dirt.transform.position.y, dirt.transform.position.z), dirt.transform.rotation);
            dirtCloneSx.transform.parent = dirtContainer.transform;
            dirtCloneSx.name = "dirt sx Clone " + i;
        }
        for(int i=0; i<Random.RandomRange(75, 200); i++)
        {
            float f = Random.RandomRange(3f, 7);
            GameObject treeCloneDx = Instantiate(tree, new Vector3(Random.RandomRange(81.4f, 240.5f) , tree.transform.position.y/(f/3)-0.25f, tree.transform.position.z), tree.transform.rotation);
            treeCloneDx.transform.localScale = new Vector3(f,f,f);
            treeCloneDx.transform.parent = treeContainer.transform;
            treeCloneDx.name = "tree dx Clone " + i;
            GameObject treeCloneSx = Instantiate(tree, new Vector3(-Random.RandomRange(81.4f, 240.5f), tree.transform.position.y / (f / 3) - 0.25f, tree.transform.position.z), tree.transform.rotation);
            treeCloneSx.transform.localScale = new Vector3(f, f, f);
            treeCloneSx.transform.parent = treeContainer.transform;
            treeCloneSx.name = "tree dx Clone " + i;
        }
    }


}
