namespace Task__007.dtos
{

    public class AddspeakerDTO
    {
        public speakerDTO[] speakers { get; set; }

    }

    public class speakerDTO
    { 

        public string name { get; set; } = null!;

        public string image { get; set; } = null!;

        public DateTime? intime { get; set; }

        public DateTime? outtime { get; set; }
    }


    //public class PropertyImages_DTO
    //{
    //    public ImagesDTO[] images { get; set; }
    //}


    //public class ImagesDTO

    //{

    //    public string imageurl { get; set; }




    //}
}
