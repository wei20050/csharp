using System;

namespace TYDB
{
    /// <summary>
    /// 标识该属性是主健
    /// </summary>
    [Serializable, AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
    public class IsIdAttribute : Attribute
    {
    }
}
