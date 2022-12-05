namespace RestAPI_Nov2022.ModelsDTO
{
    public class OrderCreateDto
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public List<int> ProductsIds { get; set; }
    }
}
