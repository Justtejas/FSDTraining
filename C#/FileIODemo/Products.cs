namespace FileIODemo
{
    public class Products
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return $"ID : {ID}\t Name: {Name}\t Description: {Description}\t Price : {Price}";
        }
    }
}
