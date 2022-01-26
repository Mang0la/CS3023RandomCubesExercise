/****
 * Created by: Thomas Nguyen
 * Date Created: January 24, 2022
 * 
 * Last Edited by: Thomas Nguyen
 * Date Edited: January 26, 2022
 * 
 * Description: Spawns multiple cube prefabs into the scene.
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubes : MonoBehaviour
{
    // variables
    public GameObject cubePrefab; //GameObject
    public int numberOfCubes = 0;
    public float scalingFactor = 0.95f;
    [HideInInspector]
    public List<GameObject> gameObjectList; //list for all the cubes
    



    // Start is called before the first frame update
    void Start()
    {
        gameObjectList = new List<GameObject>(); //instantiates the list
    } //end of start

    // Update is called once per frame
    void Update()
    {
        numberOfCubes++; //add the number of cubes
        GameObject gObj = Instantiate<GameObject>(cubePrefab); // instantiates the cube prefab
        gObj.name = "Cube" + numberOfCubes; //name property of the object

        gObj.transform.position = Random.insideUnitSphere; //random point inside a sphere radius of 1

        Color randColor = new Color(Random.value, Random.value, Random.value);
        gObj.GetComponent<Renderer>().material.color = randColor; //assigns random color to cube

        gameObjectList.Add(gObj); //adds the game object to the list

        List<GameObject> removeList = new List<GameObject>(); //lists of game objects to remove

        foreach(GameObject goTemp in gameObjectList)
        {
            float scale = goTemp.transform.localScale.x; //record starting scale
            scale *= scalingFactor; //set scale multiplied by scaling factor
            goTemp.transform.localScale = Vector3.one * scale; //transforms the scale

            if (scale <= 0.1f)
            {
                removeList.Add(goTemp); //add to remove list

            } //end if (scale <= 0.1f)
        } //end foreach(GameObject goTemp in gameObjectList)

        foreach(GameObject goTemp in removeList)
        {
            gameObjectList.Remove(goTemp); //remove from the game object lists
            Destroy(goTemp); //destroys the object from scene
        }
    }
}
