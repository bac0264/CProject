using UnityEngine;
using System.Collections;
using EnhancedScrollerDemos.SuperSimpleDemo;
using EnhancedUI;
using EnhancedUI.EnhancedScroller;

public class StageEnhance : SimpleDemo
{
    public static StageEnhance instance;
    private void Awake()
    {
        _data = new SmallList<Data>();
        if (instance == null) instance = this;
    }
    public override void Start()
    {
        base.Start();
    }
    public override float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
    {
        // in this example, even numbered cells are 30 pixels tall, odd numbered cells are 100 pixels tall
        return (dataIndex % 2 == 0 ? 401 : 401);
    }
    public override void LoadLargeData()
    {
        int amount = LoadUnitOnvalidate.instance.GetAmountStage();
        //   amount = 100;
        // set up some simple data
        for (var i = 0; i < amount; i++)
        {
            int _amountUnitStage = LoadUnitOnvalidate.instance.GetAmountUnitStage(i);
            _data.Add(new DataStage() { indexStage = i, amountUnitStage = _amountUnitStage });
        }
        // tell the scroller to reload now that we have the data
        scroller.ReloadData();
        StageManager.instance.SetupEvent();
    }
}
