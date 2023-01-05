namespace Services.Dtos
{
    public class PostPageDto
    {
        public int Pages { get; set; }
        public int Current { get; set; }
        public List<PostDto> Posts { get; set; }
    }
}
