namespace RestAPI_Nov2022.ModelsDTO
{
    public class OrderReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public List<ProductReadDto> Products { get; set; }
    }
}
