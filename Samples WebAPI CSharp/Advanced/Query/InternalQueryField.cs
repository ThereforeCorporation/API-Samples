using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Query
{
    public enum InternalQueryField
    {
        Extension_DESC = -11,
        IsCheckedOut_DESC = -10,
        CheckedOutBy_DESC = -9,
        CheckedOutOn_DESC = -8,
        ModifiedBy_DESC = -7,
        CreatedBy_DESC = -6,
        CreatedOn_DESC = -5,
        OldVersion_DESC = -4,
        LastModified_DESC = -3,
        FileCount_DESC = -2,
        DocSize_DESC = -1,
        DocSize = 1,
        FileCount = 2,
        LastModified = 3,
        OldVersion = 4,
        CreatedOn = 5,
        CreatedBy = 6,
        ModifiedBy = 7,
        CheckedOutOn = 8,
        CheckedOutBy = 9,
        IsCheckedOut = 10,
        Extension = 11,
    }
}
