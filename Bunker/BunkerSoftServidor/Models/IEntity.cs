using System;
using System.Linq;
using System.Threading.Tasks;

public interface IEntity
{
    Guid id { get; }
    DateTime CreatedOn { get; set; }
    DateTime ModifiedOn { get; set; }
    Boolean IsDeleted  { get; set; }


}