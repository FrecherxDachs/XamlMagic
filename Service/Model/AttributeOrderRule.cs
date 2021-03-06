﻿using System.Linq;
using XamlMagic.Service.Reorder;

namespace XamlMagic.Service.Model
{
    public sealed class AttributeOrderRule
    {
        public Wildcard Name { get; }
        public int Group { get; }
        public int Priority { get; }
        public int MatchScore { get; }

        public AttributeOrderRule(string name, int group, int priority)
        {
            this.Name = new Wildcard(name);
            this.Group = group;
            this.Priority = priority;

            // Calculate match score.
            // -2 = Catch-all ("*" or "*:*")
            // -1 = Contains '*'
            //  0 = Contains '?'
            //  1 = No Wildcards
            this.MatchScore = (name.Equals("*") || name.Equals("*:*"))
                ? -2
                : name.Any(_ => (_ == '*'))
                    ? -1
                    : name.Any(_ => _ == '?')
                        ? 0
                        : 1;
        }
    }
}