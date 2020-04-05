using System.Runtime.CompilerServices;
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
        128-Empty
        (Bitmask)
    */
    public int[,] building = {
        {1, 1, 1, 17, 1, 128, 128, 128, 2, 1},
        {1, 1, 1, 17, 1, 1, 2, 2, 2, 1},
        {1, 1+64, 1+64, 17+64, 1, 1, 2, 2, 2, 1},
        {1, 1, 1, 17+64, 1, 1, 2, 2, 2, 1},
        {1, 17, 0, 2, 66, 65, 2, 2, 2, 1}
    };

    public GameObject[,,] buildingGameObjects = new GameObject[5, 10, 8];

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

    public void moveBlock(int x, int y, float shift){
        for(int i=0; i<gameObjects.Length; i++){
            if((building[x,y] & (1<<i)) != 0){
                buildingGameObjects[x, y, i].transform.position += new Vector3(0, shift, 0); 
            }
        }
    }

    public void roundPos(int fromLine){
        for(int i=fromLine; i<building.GetLength(0); i++){
            for(int j=0; j<building.GetLength(1); j++){
                for(int k=0; k<gameObjects.Length; k++){
                    if((building[i,j] & (1<<k)) != 0){
                        if(buildingGameObjects[i, j, k].transform.position.y - i < 0.02f ){
                            buildingGameObjects[i, j, k].transform.position = new Vector3(
                                buildingGameObjects[i, j, k].transform.position.x,
                                i,
                                buildingGameObjects[i, j, k].transform.position.z
                            );
                        }
                    }
                }
            }
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void shiftArrayVertical(int deletedLine){
        for(int i=deletedLine+1; i<building.GetLength(0); i++){
            for(int j=0; j<building.GetLength(1); j++){
                building[i-1, j] = building[i, j];
                building[i, j] = 0;
                for(int k=0; k<gameObjects.Length; k++){
                    buildingGameObjects[i-1, j, k] = buildingGameObjects[i, j, k];
                    buildingGameObjects[i, j, k] = null;
                }
            }
        }
    }
}
