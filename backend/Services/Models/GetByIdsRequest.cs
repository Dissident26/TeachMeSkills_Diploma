namespace Services.Models
{
    public class GetByIdsRequest
    {
        public string Token { get; set; }
        public int[] Ids { get; set; }
    }
}
