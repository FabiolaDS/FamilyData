using System.ComponentModel.DataAnnotations;

namespace FamilyData.Data
{
    public class Adult : Person
    {

        public Job Job { get; set; }
    }
}