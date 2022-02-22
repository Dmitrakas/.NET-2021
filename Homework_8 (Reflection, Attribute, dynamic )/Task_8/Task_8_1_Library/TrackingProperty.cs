using System;

namespace Task_8_1_Library
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class TrackingProperty : Attribute
    {
        public string PropertyName { get; }

        public TrackingProperty(string name = "")
        {
            PropertyName = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}