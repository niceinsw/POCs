namespace MiscConsole.InterfaceInModels
{
    public class DemoInterfaceInModels
    {
    }


    public class BaseDto
    {
        public bool IsSuccess { get; set; }
        public string Errors { get; set; }
    }

    public class ProfileDto : BaseDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
    }

}
