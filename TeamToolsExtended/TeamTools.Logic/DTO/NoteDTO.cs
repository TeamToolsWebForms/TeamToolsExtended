namespace TeamTools.Logic.DTO
{
    public class NoteDTO
    {
        public NoteDTO(string title, string content, string userId)
        {
            this.Title = title;
            this.Content = content;
            this.UserId = userId;
        }

        public string Title { get; set; }
        
        public string Content { get; set; }

        public string UserId { get; set; }

        public UserDTO User { get; set; }
    }
}
