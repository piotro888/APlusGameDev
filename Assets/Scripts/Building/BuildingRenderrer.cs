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

    ///Render building based on public building array.
    public void render(){
        for(int i=0; i<building.GetLength(0); i++){
            for(int j=0; j<building.GetLength(1); j++){
                int num = building[i,j];
                for(int k=0; k<gameObjects.Length; k++){
                    if((num & (1<<k)) != 0){
                        createBlock(k, i, j);
                    }
                }
            }
        }
    }

    void createBlock(int id, int x, int y){
        Vector3 blockPosition = transform.position + new Vector3(y, x, 0);
        Instantiate(
            gameObjects[id],
            blockPosition,
            Quaternion.identity);
    }
}
