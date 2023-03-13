namespace ClassLibrary1.Core
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreMappingAttribute : Attribute
    {
        public IgnoreMappingAttribute()
        {
        }
    }
}