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

        public int Id { get; set; }

        public string Title { get; set; }
        
        public string Content { get; set; }

        public bool IsImportant { get; set; }

        public bool IsDeleted { get; set; }

        public string UserId { get; set; }

        //public UserDTO User { get; set; }
    }
}
