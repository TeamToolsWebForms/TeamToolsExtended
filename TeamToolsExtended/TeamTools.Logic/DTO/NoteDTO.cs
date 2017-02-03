namespace TeamTools.Logic.DTO
{
    public class NoteDTO
    {
        public string Title { get; set; }
        
        public string Content { get; set; }

        public string UserId { get; set; }

        public UserDTO User { get; set; }
    }
}
