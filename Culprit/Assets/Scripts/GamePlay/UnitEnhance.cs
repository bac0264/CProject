using UnityEngine;
using System.Collections;
using EnhancedScrollerDemos.SuperSimpleDemo;
using EnhancedUI;
using EnhancedUI.EnhancedScroller;
using System.Collections.Generic;

public class UnitEnhance : SimpleDemo
{
    public static UnitEnhance instance;
    public bool isDOMoveTutorialPosition;
    private void Awake()
    {
        _dataList = new SmallList<List<Data>>();
        if (instance == null) instance = this;
    }
    public override void Start()
    {
        scroller.GetContainer().SetActive(false);
        base.Start();
        isDOMoveTutorialPosition = true;
    }
    public override float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
    {
        // in this example, even numbered cells are 30 pixels tall, odd numbered cells are 100 pixels tall
        return (dataIndex % 2 == 0 ? 1070 : 1070);
    }

    public void LoadData(int amount, int _indexStage)
    {
        _dataList.Clear();
        int temp = amount / KeySave.SIZE_OF_BLOCK;
        // set up some simple data
        if (temp != 0)
        {
            int j = 0;
            for (var i = 0; i <= temp; i++)
            {
                List<Data> data = new List<Data>();

                for (; j < amount && j < (KeySave.SIZE_OF_BLOCK * (i + 1)); j++)
                {
                    DataUnitStage _data = new DataUnitStage() { indexStage = _indexStage, indexUnitStage = j };
                    data.Add(_data);
                }
                if (data.Count != 0)
                {
                    _dataList.Add(data);
                }
            }
        }
        else
        {

            List<Data> data = new List<Data>();
            for (int k = 0; k < amount; k++)
            {
                data.Add(new DataUnitStage() { indexStage = _indexStage, indexUnitStage = k });
            }
            _dataList.Add(data);
        }
        // tell the scroller to reload now that we have the data
        scroller.ReloadData();
    }
    public override EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
    {
        // first, we get a cell from the scroller by passing a prefab.
        // if the scroller finds one it can recycle it will do so, otherwise
        // it will create a new cell.
        CellView cellView = scroller.GetCellView(cellViewPrefab) as CellView;

        // set the name of the game object to the cell's data index.
        // this is optional, but it helps up debug the objects in 
        // the scene hierarchy.
        cellView.name = "Cell " + dataIndex.ToString();

        // in this example, we just pass the data to our cell's view which will update its UI
        cellView.SetData(_dataList[dataIndex]);

        // return the cell to the scroller
        return cellView;
    }
}
