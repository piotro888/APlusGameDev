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
        (Bitmask)
    */
    public int[,] building = {
        {1, 2, 2, 2, 2, 2, 2, 1, 1+8, 1},
        {1, 2, 2, 2, 2+64+8, 2+64, 2+64, 1+64, 1+8+64, 1},
        {1, 2, 2, 2, 2+8, 2, 2, 1, 1+8, 1},
        {1, 2, 2+64+8, 2+64, 2+64+8, 2, 2, 1, 1+8, 1},
        {1, 2, 2+8+64, 2, 2, 2, 2, 1, 1+8, 1},
        {1, 2, 2+64+8, 2, 2, 2+64+8, 2+64, 1+64, 1+8, 1},
        {1, 2, 1+64, 1+64, 1+64, 1+64+8, 2, 1, 1+8, 1},
        {1, 2+64, 2+64+8, 2, 2, 2, 2, 1+64+8, 1+64, 1},
        {1, 2, 2, 2, 2+64+8, 2+64, 2, 1+8, 1, 1+64},
        {1, 2, 2+64, 2+64, 2+64, 2+64, 2, 1+8, 1, 1},
        {1, 2, 2+8+64, 2+64, 2, 2, 2, 1+8+64, 1+8+64, 1+64},
        {1, 2, 2, 2, 2, 2, 2, 1, 1+8, 1},
    };
    public GameObject[,,] buildingGameObjects = new GameObject[20, 10, 8];
    public GameObject[,] emptyGameObjects = new GameObject[20, 10];

    public int buildingHeight;
    public int savedObjectsScore;

    void Start(){
        buildingHeight = building.GetLength(0);
        savedObjectsScore = building.GetLength(0)*building.GetLength(1)*10;
    }

    ///Render building based on public building array.
    public void render(){
        for(int i=0; i<building.GetLength(0); i++){
            for(int j=0; j<building.GetLength(1); j++){
                int num = building[i,j];
                addEmpty(i, j);
                for(int k=0; k<gameObjects.Length; k++){
                    if((num & (1<<k)) != 0){
                        addElement(k, i, j, true);
                    }
                }
            }
        }
    }

    public void addElement(int id, int x, int y, bool disable_check){
        if(((building[x, y] & (1<<id)) == 0) || disable_check){
            building[x,y] |= (1<<id);
            Vector3 blockPosition = transform.position + new Vector3(y, x, 0);
            buildingGameObjects[x,y,id] =  (GameObject) Instantiate(
                gameObjects[id],
                blockPosition,
                Quaternion.identity);
        }
    }

    void addEmpty(int x, int y){
            Vector3 blockPosition = transform.position + new Vector3(y, x, 0);
            emptyGameObjects[x,y] =  (GameObject) Instantiate(
                gameObjects[7],
                blockPosition,
                Quaternion.identity);
    }

    public void deleteBlock(int x, int y){
        if((building[x,y] & 1) != 0 ||
        (building[x,y] & 2) != 0){
            savedObjectsScore-=10;
        }
        for(int i=0; i<gameObjects.Length-1; i++){
            if((building[x,y] & (1<<i)) != 0){
                deleteElement(i, x, y);
            }
        }
        building[x, y] = 0;
    }

    public void deleteEmpty(int x, int y){
        if(emptyGameObjects[x, y]!=null){
            Destroy(emptyGameObjects[x, y]);
            emptyGameObjects[x, y]=null;
        }
    }

    public void deleteElement(int id, int x, int y){
        Destroy(buildingGameObjects[x, y, id]);
        buildingGameObjects[x, y, id] = null;
        building[x, y] &= ~(1<<id);
    }

    public void moveBlock(int x, int y, float shift){
        for(int i=0; i<gameObjects.Length-1; i++){
            if((building[x,y] & (1<<i)) != 0){
                buildingGameObjects[x, y, i].transform.position += new Vector3(0, shift, 0); 
            }
        }
    }

    public void roundPos(int fromLine){
        for(int i=fromLine; i<building.GetLength(0); i++){
            for(int j=0; j<building.GetLength(1); j++){
                for(int k=0; k<gameObjects.Length-1; k++){
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
