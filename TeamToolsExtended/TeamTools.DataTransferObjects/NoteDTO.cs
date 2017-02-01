namespace TeamTools.DataTransferObjects
{
    public class NoteDTO
    {
        public string Title { get; set; }
        
        public string Content { get; set; }
        
        public UserDTO User { get; set; }
    }
}
