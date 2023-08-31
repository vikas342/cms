namespace Task__007.dtos
{
    public class OrderDTO
    {
        public int? Uid { get; set; }

        public int? Cid { get; set; }

        public int? Hid { get; set; }

        public DateTime? BookedDate { get; set; } =DateTime.Now;

    }
}
