using System;

namespace ProgettoIndustriale.Type.Attribute;

[AttributeUsage(AttributeTargets.Field)]
public class AliasInUIAttribute : System.Attribute
{
    public readonly string AliasInUI;

    public AliasInUIAttribute(string aliasInUI)
    {
        AliasInUI = aliasInUI;
    }
}