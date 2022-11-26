using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class History
{
    public HistoryData data; 

    public History() {
        data = new HistoryData();
    }

    public History(HistoryData data_in) {
        data = data_in;
    }

}
