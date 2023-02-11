using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Enums
{
    public enum DataStatus

    //a DataStatus class could be an Enum class that defines a set of possible values for the status of some data, such as "Active", "Inactive", "Deleted", etc. Enum classes are useful for defining and enforcing a set of possible values in an application, making it easier to manage and ensure that the correct values are being used throughout the code.
    {
        Inserted =1,
        Updated=2,
        Deleted=3
    }
}
