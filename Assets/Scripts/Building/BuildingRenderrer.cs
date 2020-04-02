using UnityEngine;

public class BuildingRenderrer : MonoBehaviour
{
    public GameObject[] gameObjects;
    public int[,] building = {
        {0, 3, 1, 1, 1, 0},
        {0, 0, 0, 3, 0, 0}
    };

    ///Render building based on public building array.
    public void render(){
        for(int i=0; i<building.GetLength(0); i++){
            for(int j=0; j<building.GetLength(1); j++){
                createBlock(building[i,j], i, j);    
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
