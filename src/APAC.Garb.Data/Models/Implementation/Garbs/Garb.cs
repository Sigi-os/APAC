using APAC.Garb.Data.Models.Definition.Common;

namespace APAC.Garb.Data.Models.Implementation.Garbs
{
    public class Garb : ILookup
    {
        /// <inheritdocs />
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
