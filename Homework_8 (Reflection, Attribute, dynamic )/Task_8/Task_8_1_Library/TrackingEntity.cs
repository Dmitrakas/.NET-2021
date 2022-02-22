using System;

namespace Task_8_1_Library
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class TrackingEntity  : Attribute 
    {
    }
}