using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Entities.Interfaces
{
    public interface INamedEntity
    {
        [Description("Ad")]
        string Name { get; set; }
    }
}
