using System.ComponentModel.DataAnnotations;

namespace poc.console
{
    public class Role
    {
        public string Id { get; set; }
        public int Order { get; set; }
        public string Property { get; set; }
        public string Value { get; set; }
        public Operator Operator { get; set; }
        public Condition Condition { get; set; }
    }

    public enum Condition
    {
        [Display(Description = "")]
        Default,
        [Display(Description = "OR")]
        Or,
        [Display(Description = "AND")]
        And,
        [Display(Description = "Count")]
        Count
    }

    public enum Operator
    {
        [Display(Description = "==")]
        Equals,
        [Display(Description = ">")]
        GratherThen,
        [Display(Description = ">=")]
        GratherOrEqualThen,
        [Display(Description = "<")]
        SmallerThen,
        [Display(Description = "<=")]
        SmallerOrEqualThen,
        [Display(Description = "!=")]
        NotEqual
    }
}
