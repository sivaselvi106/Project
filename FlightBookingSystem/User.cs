namespace FlightBookingSystem
{
    class User
    {
        internal string UserName { get; set; }
        internal string MailId { get; set; }
        internal string Password { get; set; }
        internal long MobNo { get; set; }
        internal string Role { get; set; }
        internal bool BookStatus { get; set; }
        public User(string userName, string mailId, string password, long mobNo, string role,bool BookStatus)
        {
            this.UserName = userName;
            this.MailId = mailId;
            this.Password = password;
            this.MobNo = mobNo;
            this.Role = role;
            this.BookStatus = BookStatus;
        }
    }
}
