namespace EFCoreDemo.Data.Models
{
    public class Relation
    {
        public int RelationId { get; set; } // PK
        public int SourceObjectId { get; set; } // zdrojové ID
        public int SourceObjectType { get; set; }  // zdrojový typ objektu
        public int ObjectId { get; set; } // cílové ID objektu
        public int ObjectType { get; set; } // cílový typ objektu
    }
}
