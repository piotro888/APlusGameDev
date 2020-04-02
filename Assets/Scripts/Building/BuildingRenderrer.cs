using UnityEngine;

public class BuildingRenderrer : MonoBehaviour
{
    public GameObject[] gameObjects;

    /**
        Stores building blocks
        1-Wall
        2-Wall with window
        4-Construction element
        8-Ladder
        16-Player ladder
        32-Reinforcement
        64-Platform
        (Bitmask)
    */
    public int[,] building = {
        {1, 1, 1, 17, 1, 1},
        {1, 17, 0, 2, 66, 65}
    };

    private GameObject[,,] buildingGameObjects = new GameObject[2, 6, 8];

    ///Render building based on public building array.
    public void render(){
        for(int i=0; i<building.GetLength(0); i++){
            for(int j=0; j<building.GetLength(1); j++){
                int num = building[i,j];
                for(int k=0; k<gameObjects.Length; k++){
                    if((num & (1<<k)) != 0){
                        addElement(k, i, j);
                    }
                }
            }
        }
    }

    public void addElement(int id, int x, int y){
        Vector3 blockPosition = transform.position + new Vector3(y, x, 0);
        buildingGameObjects[x,y,id] =  (GameObject) Instantiate(
            gameObjects[id],
            blockPosition,
            Quaternion.identity);
    }

    public void deleteBlock(int x, int y){
        for(int i=0; i<gameObjects.Length; i++){
            if((building[x,y] & (1<<i)) != 0){
                deleteElement(i, x, y);
            }
        }
        building[x, y] = 0;
    }

    public void deleteElement(int id, int x, int y){
        Destroy(buildingGameObjects[x, y, id]);
        buildingGameObjects[x, y, id] = null;
        building[x, y] &= ~(1<<id);
    }
}
