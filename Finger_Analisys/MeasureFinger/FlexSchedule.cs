using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using C1.Win.C1FlexGrid;

namespace MeasureFinger
{
    public class FlexSchedule : C1.Win.C1FlexGrid.C1FlexGrid
    {
        override public CellRange GetMergedRange(int row, int col, bool clip)
        {
            // create basic cell range
            CellRange rg = GetCellRange(row, col);

            // expand left/right
            int i;
            int cnt = Cols.Count;
            int ifx = Cols.Fixed;
            for (i = rg.c1; i < cnt - 1; i++)
            {
                if (GetDataDisplay(rg.r1, i) != GetDataDisplay(rg.r1, i + 1)) break;
                rg.c2 = i + 1;
            }
            for (i = rg.c1; i > ifx; i--)
            {
                if (GetDataDisplay(rg.r1, i) != GetDataDisplay(rg.r1, i - 1)) break;
                rg.c1 = i - 1;
            }

            // expand up/down
            cnt = Rows.Count;
            ifx = Rows.Fixed;
            for (i = rg.r1; i < cnt - 1; i++)
            {
                if (GetDataDisplay(i, rg.c1) != GetDataDisplay(i + 1, rg.c1)) break;
                rg.r2 = i + 1;
            }
            for (i = rg.r1; i > ifx; i--)
            {
                if (GetDataDisplay(i, rg.c1) != GetDataDisplay(i - 1, rg.c1)) break;
                rg.r1 = i - 1;
            }

            // done
            return rg;
        }
    }

}
