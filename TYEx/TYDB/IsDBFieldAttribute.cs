using System;

namespace TYDB
{
    /// <summary>
    /// 标识该属性是数据库字段
    /// </summary>
    [Serializable, AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
    public class IsDBFieldAttribute : Attribute
    {
    }
}
