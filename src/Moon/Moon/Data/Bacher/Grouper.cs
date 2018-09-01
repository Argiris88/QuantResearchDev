﻿using Moon.Data.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moon.Data.Bacher
{
    public enum TimeRange
    {
        onemin,
        fivemin,
        tenmin
    }
    public class Grouper
    {
        public ObservableCollection<IPair> SourceData { get; set; } = new ObservableCollection<IPair>();
        public Dictionary<DateTime, IPair> PerMinuteGroup { get; set; } = new Dictionary<DateTime, IPair>();
        public string Exchanger { get; set; } = "Binance";
        public Grouper()
        {
            SourceData.CollectionChanged += SourceData_CollectionChanged;
        }

        private void SourceData_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if(e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                switch(this.Exchanger)
                {
                    case "Binance":
                        var FinalCandleSource = SourceData.ToList().Where(u => u.Properties["Final"] = true).ToList();
                        var testGroupPerMin = FinalCandleSource.ToList().GroupBy(y => y.Candle.DateTime.Minute);
                        break;
                }
            }
            //Change Happen here
        }
    }
}
