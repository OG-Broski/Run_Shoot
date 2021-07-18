using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolMono<T> where T: MonoBehaviour
{
    public T prefab{get;}
    public bool autoExpand{get;set;}
    public Transform conteiner {get;}
    private List<T> _poll;

    public PoolMono(T prefab,int count ){
        this.prefab = prefab;
        this.conteiner = null;
        this.CreatePool(count);

    }

    public PoolMono(T prefab,int count,Transform conteiner){
        this.prefab = prefab;
        this.conteiner = conteiner;
        this.CreatePool(count);

    }


    private void CreatePool(int count){
        this._poll = new List<T>();
        for(int i = 0; i<count;i++){
        this.CreateObject();
        }
    }


    private T CreateObject(bool isActiveByDefault = false){
        var createObject = UnityEngine.Object.Instantiate(this.prefab,this.conteiner);
        createObject.gameObject.SetActive(false);
        this._poll.Add(createObject);
        return createObject;
    }

    public bool HasFreeElement(out T element){
        foreach(var mono in _poll){
            if(!mono.gameObject.activeInHierarchy){
                element=mono;
                mono.gameObject.SetActive(true);
                return true;
            }
        }
        element = null;
        return false;
    }

    public T GetFreeElement(){
        if(this.HasFreeElement(out var element))
            return element;
        if(this.autoExpand){
            return this.CreateObject(true);
        }
        throw new Exception($"There is not free elements in pool of type {typeof(T)}");
    }

}
