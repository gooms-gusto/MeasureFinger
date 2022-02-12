using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using BorderStyleEnum = C1.Win.C1Command.BorderStyleEnum;

namespace MeasureFinger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _flex.Cols.Count = 8;
            _flex.Rows.Count = 0;
            _flex.AddItem("\tMonday\tTuesday\tWednesday\tThursday\tFriday\tSaturday\tSunday");
            _flex.Rows.Fixed = 1;
            _flex.AddItem("12:00\tWalker\tMorning Show\tMorning Show\tSport\tWeather\tN/A\tN/A");
            _flex.AddItem("13:00\tToday Show\tToday Show\tSesame Street\tFootball\tMarket Watch\tN/A\tN/A");
            _flex.AddItem("14:00\tToday Show\tToday Show\tKid Zone\tFootball\tSoap Opera\tN/A\tN/A");
            _flex.AddItem("15:00\tNews\tNews\tNews\tNews\tNews\tN/A\tN/A");
            _flex.AddItem("16:00\tNews\tNews\tNews\tNews\tNews\tN/A\tN/A");

            // add some formatting
            _flex.Styles.Normal.Border.Style =C1.Win.C1FlexGrid.BorderStyleEnum.Groove;
            _flex.Styles.Normal.TextAlign = TextAlignEnum.CenterCenter;
            _flex.Cols[0].Width = 50;
            _flex.Rows.MinSize = 40;
            for (int i = 1; i < _flex.Cols.Count; i++)
                _flex.Cols[i].Width = 100;

            // allow merging (that's the whole point)
            _flex.AllowMerging = AllowMergingEnum.Free;
            for (int i = 1; i < _flex.Cols.Count; i++)
                _flex.Cols[i].AllowMerging = true;
            for (int i = 1; i < _flex.Rows.Count; i++)
                _flex.Rows[i].AllowMerging = true;
        }
    }
}
