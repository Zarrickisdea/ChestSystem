using UnityEngine;

public class ChestController
{
    private ChestView chestView;
    private ChestModel chestModel;

    public ChestController(ChestView view, ChestModel model)
    {
        chestModel = model;
        chestView = view;
    }
}
