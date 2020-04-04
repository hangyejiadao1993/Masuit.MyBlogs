using System.ComponentModel.DataAnnotations;

namespace Masuit.MyBlogs.Domain.Validation
{
    /// <summary>
    /// 强制true检查
    /// </summary>
    public class AssignTrueAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return (bool)value;
        }
    }
}